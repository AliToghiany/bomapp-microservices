using dotnet_lib.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_lib.Interface
{
    public interface IMessageRepository
    {
        List<ResponseMessage> LoadPrivateRoomMessage(long myId, long userId);
        Task UpdateMessage(ResponseMessage message);
    }
}
