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
            var message =await _messageRepository.GetMessage(request.MessageId);
            if (message.User_Id==request.UserId)
            {
                throw new UnauthorizedAccessException($"User:{ request.UserId } do not have acssess to this  { nameof(Message)}:{ request.MessageId}");

            }
            //چک کردن ادمین دسترسی داره یا ن
            if (message==null)
            {
                throw new NotFoundException("Message",request.MessageId);
            }
            message.IsRemoved = true;
            return await _messageRepository.UpdateMessage(message);
        }
    }
}
