using AutoMapper;
using Chat.Application.Contracts.Persisence;
using Common.Services.Exceptions;
using MediatR;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Messages.Queries.GetMessage
{
    public record GetMessageQuery(string MessageId) : IRequest<ResponseMessage> { }
    internal class GetMessageQueryHandler : IRequestHandler<GetMessageQuery, ResponseMessage>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetMessageQueryHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            var message = await _messageRepository.GetMessage(request.MessageId);
            if (message == null)
                throw new NotFoundException("Message",$"{request.MessageId}");

            var response =  _mapper.Map<ResponseMessage>(message);
            response.Files = message.Files.Select(p=>new FileDto
            {
                Id = p.Id,
                Name = p.Name,
                  Path= p.Path,
            }).ToList();
            return response;
        }
    }
}
