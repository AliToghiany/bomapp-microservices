using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppApiGW.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public MessageController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //[HttpPost]
        //public Task <IActionResult> NewMessage(CreateNewMessageCommand createNewMessageCommand)
        //{

        //}
    }
    public class CreateNewMessageCommand
    {
        public long User_Id { get; set; }
        public string Group_Id { get; set; }
        public long? ToUser_Id { get; set; }
        public string Reply_To_MessageId { get; set; }
        public string Text { get; set; }
        public long Sticker_Id { get; set; }
        public long Gif_Id { get; set; }

        public List<IFormFile> Files { get; set; }

    }
}
