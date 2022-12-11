using AutoMapper;
using Chat.Application.Feature.Messages.Queries.GetMessage;
using Chat.Domain.Entities.MessageE;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Application.Feature.Messages.Queries.GetMessagesByData
{
    public record GetMessagesByDataQuery(List<Message> Messages):IRequest<List<ResponseMessage>>;
    public class GetMessagesByDataQueryHandler : IRequestHandler<GetMessagesByDataQuery, List<ResponseMessage>>
    {
        private readonly IMapper _mapper;

        public GetMessagesByDataQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<List<ResponseMessage>> Handle(GetMessagesByDataQuery request, CancellationToken cancellationToken)
        {
            List<ResponseMessage> Messages=new List<ResponseMessage>();
            foreach (var message in request.Messages)
            {
                var response = _mapper.Map<ResponseMessage>(message);
                response.Files = message.Files.Select(p => new FileDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Path = p.Path,
                }).ToList();
                Messages.Add(response);
            }
            return Task.FromResult(Messages);
        }
    }
}
