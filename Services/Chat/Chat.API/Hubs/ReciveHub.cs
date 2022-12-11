using Chat.API.Entities.Recives;
using Chat.API.Respositories;
using Chat.API.Respositories.Interface;
using Chat.Application.Contracts.Persisence;
using Chat.Application.Feature.Messages.Commands.CreateMessage;
using Chat.Application.Feature.Messages.Queries.GetRecentMessage;
using Chat.Application.Feature.Messages.Queries.LoadingMessage;
using Chat.Domain.Entities.MessageE;
using Common.Services.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace Chat.API.Hubs
{
    [Authorize]
    public class ReciveHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly IHubRepository _hubRepositorycs;
        private readonly IMediator _mediator;
        
        public ReciveHub(IHubRepository hubRepositorycs, IMediator mediator)
        {
            _hubRepositorycs = hubRepositorycs;
            _mediator = mediator;
        }

        public override async Task OnConnectedAsync()
        {

            //online
            var userid = UserIdentity.GetID(Context.User);
            var roleid = UserIdentity.GetIRole(Context.User);
            var clientId = Context.GetHttpContext()!.Request.Query["ClientId"];
            await _hubRepositorycs.AddConnection(new Connection
            {
                Connected = true,
                ConnectionID = Context.ConnectionId,
                UserAgent = "",
                User_Id = userid,
                ClientId = clientId
            });

            if (Context.GetHttpContext()!.Request.Query["app-search"] == "true")
            {
                var res = await _mediator.Send(new GetRecentMessageQuery(userid));
                foreach (var item in res)
                {
                    await Clients.Caller.SendAsync("ReciveMessage", JsonConvert.SerializeObject(item));
                }
            }
            foreach (var item in await _hubRepositorycs.GetMessagesQueue(userid, clientId))
            {


                switch (item.Satate)
                {
                    case "NewMessage":
                        await Clients.Caller.SendAsync("ReciveMessage", item.DataNessage);
                        break;
                    case "RemoveMessage":
                        await Clients.Caller.SendAsync("RemoveMessage", item.DataNessage);
                        break;
                    case "EditMessage":
                        await Clients.Caller.SendAsync("EditMessage", item.DataNessage);
                        break;
                    case "NewGroup":
                        await Clients.Caller.SendAsync("NewGroup", item.DataNessage);
                        break;
                    default:
                        break;
                }

            }
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            //offline
            var userid = UserIdentity.GetID(Context.User);
            await _hubRepositorycs.DisableConnection(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task LoadMessage(long? firstMessage,long? lastMessage,long? groupId,long? toUserId)
        {
            await _mediator.Send(new LoadMessageQuery
            {
                FirstMessageId = firstMessage,
                LastMessageId = lastMessage,
                GroupId = groupId,
                ConnectionId = Context.ConnectionId,
                UserId = UserIdentity.GetID(Context.User),
                PrivateUserId = toUserId
            });
        }

    }
}
