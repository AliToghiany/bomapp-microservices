using Chat.Application.Contracts.Persisence;
using Chat.Domain.Entities.MessageE;
using Common.Services.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Messages.Commands.DeleteMessage
{
    internal class RemoveMessageCommandHandler : IRequestHandler<RemoveMessageCommand, bool>
    {
        private readonly IMessageRepository _messageRepository;

        public RemoveMessageCommandHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<bool> Handle(RemoveMessageCommand request, CancellationToken cancellationToken)
        {
            if (!await _messageRepository.ChckMessageForUser(request.User_Id,request.Message_Id))
            {
                throw new UnauthorizedAccessException($"User:{ request.User_Id } do not have acssess to this  { nameof(Message)}:{ request.Message_Id}");

            }
            if ((await _messageRepository.GetMessage(request.Message_Id))==null)
            {
                throw new NotFoundException("Message",request.Message_Id);
            }
            return await _messageRepository.RemoveMessage(request.Message_Id);
        }
    }
}
