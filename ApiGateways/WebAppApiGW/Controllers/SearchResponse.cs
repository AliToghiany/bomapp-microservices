using WebAppApiGW.Models;

namespace WebAppApiGW.Controllers
{
    public class SearchResponse
    {
        public GroupResponse? GroupResponse { get; set; }
        public ResponseUser? ResponseUser { get; set; }
        
    }
}