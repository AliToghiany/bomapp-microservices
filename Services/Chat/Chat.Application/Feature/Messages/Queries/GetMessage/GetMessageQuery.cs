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
    public record GetMessageQuery(long MessageId, long UserId) : IRequest<ResponseMessage> { }
    internal class GetMessageQueryHandler : IRequestHandler<GetMessageQuery, ResponseMessage>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IGroupRepository _groupRepository;

        private readonly IMapper _mapper;


        public async Task<ResponseMessage> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            var message = await _messageRepository.GetMessage(request.MessageId);
            if (message == null)
                throw new NotFoundException("Message", $"{request.MessageId}");
            if (message.GroupId != null)
            {
                var isJoined = await _groupRepository.JoinInGroup(message.GroupId.Value, request.UserId);
                if (!isJoined)
                {
                    throw new UnauthorizedAccessException("Cannot Access to this Message Because not joined on group");
                }

            }
            if (message.ToUser_Id!=null)
            {
                if (message.User_Id!=request.UserId|| message.ToUser_Id != request.UserId)
                {
                    throw new UnauthorizedAccessException("Cannot Access to this Message Because is Private");
                }
            }
            var response = _mapper.Map<ResponseMessage>(message);
            response.Files = message.Files.Select(p => new FileDto
            {
                Id = p.Id,
                Name = p.Name,
                Path = p.Path,
            }).ToList();
            return response;
        }
    }
}
