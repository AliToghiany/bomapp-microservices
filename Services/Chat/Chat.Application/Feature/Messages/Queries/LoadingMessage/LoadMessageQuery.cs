using MediatR;

namespace Chat.Application.Feature.Messages.Queries.LoadingMessage
{
    public class LoadMessageQuery:IRequest
    {
       public long UserId;
        public long? GroupId;
        public long? PrivateUserId;
        public long? LastMessageId;
        public long? FirstMessageId;
        public string ConnectionId;
       
    }
}
