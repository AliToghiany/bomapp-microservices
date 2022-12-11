using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Search.Api.SearchService;
using Search.Api.SearchType;


namespace Search.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IdentityService _identityService;

        public SearchController(IdentityService identityService)
        {
            _identityService = identityService;
        }
        [Route("[action]")]
        [HttpGet]
       public async Task<ActionResult> SearchChat(string searchkey)
        {
            var response = new ResponseChatSearch
            {
                User = new Identity
                {
                    UserResponse = await _identityService.GetIdentityUserSearch(searchkey, HttpContext.Request.Headers["Authorization"])
                }
            };
            return Ok(response);



        }

    }


}
