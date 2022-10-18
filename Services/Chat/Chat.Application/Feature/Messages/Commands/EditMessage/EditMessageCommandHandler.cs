using Chat.Application.Contracts.EndPoint;
using Chat.Application.Contracts.Persisence;
using Chat.Application.Feature.Messages.Queries.GetMessage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Messages.Commands.EditMessage
{
    public class EditMessageCommandHandler : IRequestHandler<EditMessageCommand, ResponseMessage>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IReciveHub _reciveHub;

        public EditMessageCommandHandler(IMessageRepository messageRepository, IReciveHub reciveHub)
        {
            _messageRepository = messageRepository;
            _reciveHub = reciveHub;
        }

        public Task<ResponseMessage> Handle(EditMessageCommand request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
