using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppApiGW.Services;

namespace WebAppApiGW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IGroupSerivce _groupSerivce;
        private readonly IUserService _userService;

        public ChatController(IGroupSerivce groupSerivce, IUserService userService)
        {
            _groupSerivce = groupSerivce;
            _userService = userService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<SearchResponse>>> SearchOfChat(string searchKey){
            List<SearchResponse> searchResponses = new List<SearchResponse>();
             var groupres = await _groupSerivce.GetGroups(searchKey,1,10);

            //takeuser
            groupres.ForEach(p =>searchResponses.Add(new SearchResponse { GroupResponse=p}));
            return searchResponses;

        }
    }
}
