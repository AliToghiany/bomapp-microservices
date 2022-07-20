using AutoMapper;
using Chat.Application.Contracts.Persisence;
using Chat.Domain.Entities.GroupE;
using Chat.Domain.Entities.MessageE;
using Chat.Domain.Entities.UserE;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Messages.Commands
{
    public class CreateNewMessageCommandHandler : IRequestHandler<CreateNewMessageCommand, long>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

     
        public CreateNewMessageCommandHandler(IMapper Mapper,IMessageRepository messageRepository,IGroupRepository groupRepository,IUserRepository userRepository)
        {
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
            _mapper = Mapper ?? throw new ArgumentNullException(nameof(Mapper));
            _userRepository = userRepository;
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
        }
        public async Task<long> Handle(CreateNewMessageCommand request, CancellationToken cancellationToken)
        {
            //var group = await _groupRepository.GetGroupById(request.Group_Id);
            //var user = await _userRepository.GetUserById(request.User_Id);
            if (await _groupRepository.CheckBanInGroup(request.User_Id, request.Group_Id))
            {
                throw new UnauthorizedAccessException($"{nameof(User)}:{request.User_Id} do not have acssess to this {nameof(Group)}:{request.Group_Id}");
            }
            var message = new Message
            {
                Gif_Id = request.Gif_Id,
                Message_Id = (await _groupRepository.GetCountOfMessageGroup(request.Group_Id) + 1).ToString(),
                Group_Id = request.Group_Id,
                Reply_To_MessageId = request.Reply_To_MessageId,
                Sticker_Id = request.Sticker_Id,
                User_Id = request.User_Id,
                ToUser_Id = request.ToUser_Id,
                Text = request.Text,

            };
            var result = await _messageRepository.AddNewMessage(message);
            List<File> files = new List<File>();

            //foreach (var item in request.Files)
            //{
            //    files.Add(new File
            //    {
            //        Message_Id=result.Id,
            //        Path=item.
            //    })
            //}
            return result.Id;
            
        }
    }
}
