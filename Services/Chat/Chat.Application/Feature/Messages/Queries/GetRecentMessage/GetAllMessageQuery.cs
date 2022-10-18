using AutoMapper;
using Chat.Application.Contracts.Persisence;
using Chat.Application.Feature.Groups.Queries.GetGroup;
using Chat.Application.Feature.Messages.Queries.GetMessage;
using Chat.Domain.Entities.MessageE;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Messages.Queries.GetRecentMessage
{
    public record GetRecentMessageQuery(long UserId) : IRequest<List<ResponseMessage>> { }

    public class GetRecentMessageQueryHandler : IRequestHandler<GetRecentMessageQuery, List<ResponseMessage>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        public GetRecentMessageQueryHandler(IMessageRepository messageRepository, IGroupRepository groupRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _groupRepository = groupRepository;
            _mapper = mapper;
        }



        public async Task<List<ResponseMessage>> Handle(GetRecentMessageQuery request, CancellationToken cancellationToken)
        {
            List<Message> messages = new List<Message>();
            messages.AddRange(await _messageRepository
               .GetPrivateRoomMessage(request.UserId));
            messages.AddRange(await _messageRepository
                .GetGroupMessage(request.UserId));
            List<ResponseMessage> result = new List<ResponseMessage>();
            foreach (var message in messages)
            {
                var responsemessage = _mapper.Map<ResponseMessage>(message);
                responsemessage.Files = message.Files.Select(p => _mapper.Map<FileDto>(p)).ToList();
                result.Add(responsemessage);
                
            }
            return result;

         
      



        }
    }
   

}
