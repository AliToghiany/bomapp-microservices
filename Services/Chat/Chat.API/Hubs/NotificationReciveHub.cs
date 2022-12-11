using Chat.API.Respositories.Interface;
using Chat.Application.Contracts.EndPoint;
using Chat.Application.Feature.Groups.Queries.GetGroupMember;
using Chat.Application.Feature.Messages.Queries.GetMessage;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace Chat.API.Hubs
{
    public class NotificationReciveHub : IReciveHub
    {
        private readonly IHubRepository _hubRepositorycs;
        private readonly IMediator _mediator;
        private readonly IHubContext<ReciveHub> _hubContext;

        public NotificationReciveHub(IHubRepository hubRepositorycs, IMediator mediator, IHubContext<ReciveHub> hubContext)
        {
            _hubRepositorycs = hubRepositorycs;
            _mediator = mediator;
            _hubContext = hubContext;
        }

        public async Task SendMessage(ResponseMessage message)
        {
            var messagejson = JsonConvert.SerializeObject(message);
            if (message.ToUser_Id != null || message.ToUser_Id != 0)
            {
                var cid = await _hubRepositorycs.GetConnectionOrAddQueue(new List<long> { message.ToUser_Id.Value }, messagejson, "NewMessage");
                if (cid.Count != 0)
                {
                    foreach (var item in cid)
                    {
                        await _hubContext.Clients.Client(item).SendAsync("ReciveMessage", messagejson);
                    }

                }
            }
            else if (message.GroupId != null)
            {
                var users = await _mediator.Send(new GetGroupMemberQuery(message.GroupId.Value));

                var cid = await _hubRepositorycs.GetConnectionOrAddQueue(users.Select(p => p.UserId).ToList(), messagejson, "NewMessage");
                if (cid.Count != 0)
                {
                    foreach (var item in cid)
                    {
                        await  _hubContext.Clients.Client(item).SendAsync("ReciveMessage", messagejson);
                    }

                }
            }
        }

        public async Task SendMessageForCaller(string connectionId, List<ResponseMessage> responseMessages)
        {
            foreach(var message in responseMessages)
            {
                await _hubContext.Clients.Client(connectionId).SendAsync("NewMessage");
            }
        }

        public async Task SendMessageNewGroup(long groupId, List<long> subescribesId, long cretedBy)
        {
            var cgn = JsonConvert.SerializeObject(new CreatedGroupNotif { CreatedBy = cretedBy, GroupId = groupId });

            var res = await _hubRepositorycs.GetConnectionOrAddQueue(subescribesId, JsonConvert.SerializeObject(cgn), "NewGroup");
            foreach (var item in res)
            {
                await _hubContext.Clients.Client(item).SendAsync("NewGroup", cgn);
            }
        }
    }
}
