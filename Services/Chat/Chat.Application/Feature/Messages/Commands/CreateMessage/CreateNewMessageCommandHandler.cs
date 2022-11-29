using AutoMapper;
using Chat.Application.Contracts.Persisence;
using Chat.Domain.Entities.GroupE;
using Chat.Domain.Entities.MessageE;
using Common.Services.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using File = Chat.Domain.Entities.MessageE.File;

namespace Chat.Application.Feature.Messages.Commands.CreateMessage
{
    public class CreateNewMessageCommandHandler : IRequestHandler<CreateNewMessageCommand, long>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateNewMessageCommandHandler(IMapper Mapper, IMessageRepository messageRepository, IGroupRepository groupRepository,IMediator mediator)
        {
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
            _mapper = Mapper ?? throw new ArgumentNullException(nameof(Mapper));
           
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
            _mediator=mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<long> Handle(CreateNewMessageCommand request, CancellationToken cancellationToken)
        {
            string messageid="1";
            if (request.GroupId != null)
            {
                var group = await _groupRepository.GetGroupById(request.GroupId.Value);
                if (group == null)
                    throw new NotFoundException("Group", request.GroupId);

                if (await _groupRepository.CheckBanInGroup(request.User_Id, request.GroupId.Value))
                {
                    throw new UnauthorizedAccessException($"User:{request.User_Id} do not have acssess to this  {nameof(Group)}:{request.GroupId} because banned");
                }
                if (await _groupRepository.JoinInGroup(request.GroupId.Value, request.User_Id))
                    throw new UnauthorizedAccessException($"User:{request.User_Id} do not have acssess to this {nameof(Group)}:{request.GroupId} beacuse not joined");
                messageid = (await _groupRepository.GetCountOfMessageGroup(request.GroupId.Value) + 1).ToString();
            }
            var message = _mapper.Map<Message>(request);
            message.Message_Id = messageid;
            var result = await _messageRepository.AddNewMessage(message);
            List<File> files = new List<File>();
          
            await _messageRepository.AddNewFiles(files);
            await _mediator.Publish(new NewMessageNotification(result.Id));
            return result.Id;

        }



    }
}

