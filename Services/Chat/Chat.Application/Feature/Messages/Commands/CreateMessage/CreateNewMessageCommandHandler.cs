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


        public CreateNewMessageCommandHandler(IMapper Mapper, IMessageRepository messageRepository, IGroupRepository groupRepository)
        {
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
            _mapper = Mapper ?? throw new ArgumentNullException(nameof(Mapper));
           
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
        }
        public async Task<long> Handle(CreateNewMessageCommand request, CancellationToken cancellationToken)
        {
            var group = await _groupRepository.GetGroupById(request.Group_Id);
            if (group == null)
                throw new NotFoundException("Group", request.Group_Id);

            if (await _groupRepository.CheckBanInGroup(request.User_Id, request.Group_Id))
            {
                throw new UnauthorizedAccessException($"User:{request.User_Id} do not have acssess to this  {nameof(Group)}:{request.Group_Id} because banned");
            }
            if (await _groupRepository.JoinInGroup(request.Group_Id, request.User_Id))
                throw new UnauthorizedAccessException($"User:{request.User_Id} do not have acssess to this {nameof(Group)}:{request.Group_Id} beacuse not joined");
            var message = _mapper.Map<Message>(request);
            message.Message_Id = (await _groupRepository.GetCountOfMessageGroup(request.Group_Id) + 1).ToString();
            var result = await _messageRepository.AddNewMessage(message);
            List<File> files = new List<File>();
            foreach (var item in request.Files)
            {
                files.Add(new File
                {
                    MessageId = result.Id,
                    Path = item,

                });
            }
            await _messageRepository.AddNewFiles(files);
            return result.Id;

        }



    }
}

