using Chat.Application.Feature.Groups.Commands.NewGroup;
using Chat.Application.Feature.Groups.Queries.GetGroup;
using Chat.Application.Feature.Groups.Queries.GetGroups;
using Chat.Application.Feature.Messages.Commands.CreateMessage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Chat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHostingEnvironment _hostingEnvironment;

        public GroupController(IMediator mediator, IHostingEnvironment hostingEnvironment)
        {
            _mediator = mediator;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet]
        [ProducesResponseType(typeof(GroupResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Authorize]
        [HttpGet("{groupId}", Name = "GetGroup")]
        public async Task<ActionResult<GroupResponse>> GetGroup(long groupId)
        {
            var res = await _mediator.Send(new GetGroupQuery(groupId));
            return Ok(res);

        }
        [Route("[action]/{SearchKey}/{pagesize}/{page}", Name = "GetGames")]
        [HttpGet]
        [ProducesResponseType(typeof(List<GroupResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GroupResponse>> GetGroups(string SearchKey, int pagesize = 20, int page = 1)
        {
            var res = await _mediator.Send(new GetGroupsQuery(SearchKey, pagesize, page));
            return Ok(res);

        }
       
        [ProducesResponseType(typeof(GroupResponse), (int)HttpStatusCode.OK)]
        [HttpPost("NewGroup")]
        public async Task<ActionResult<GroupResponse>> NewGroup([FromBody] NewGroupCommand newGroupCommand)
        {

            var res = await _mediator.Send(newGroupCommand);
            return Ok(res);
        }
        
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType( (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType( (int)HttpStatusCode.BadRequest)]
        [HttpPost("UploadImageGroup")]
        public ActionResult<string> UploadImageGroup()
        {
            try
            {
                var file = Request.Form.Files[0];
                if (file != null)
                {
                    string folder = $@"Image\Group\";
                    var uploadsRootFolder =  Path.Combine(_hostingEnvironment.WebRootPath, folder);
                    if (!Directory.Exists(uploadsRootFolder))
                    {
                        Directory.CreateDirectory(uploadsRootFolder);
                    }


                    if (file == null || file.Length == 0)
                    {
                        return BadRequest();
                    }

                    string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                    var filePath = Path.Combine(uploadsRootFolder, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                 return Ok(folder + fileName);
                }
                else
                {
                    return BadRequest();
                }
            
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

    }

}
