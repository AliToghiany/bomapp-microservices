using dotnet_lib.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_lib.Interface
{
    public interface IChatRepository
    {
        Task<List<RecentChatResponse>> GetRecentChat { get; set; }
    }
    public class RecentChatResponse
    {
        public ResponseMessage Message { get; set; }
        public int UnSeen { get; set; }
    }
    
}
