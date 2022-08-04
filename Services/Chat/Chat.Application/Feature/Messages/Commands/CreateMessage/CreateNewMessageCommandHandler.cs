using AutoMapper;
using Chat.Application.Contracts.Persisence;
using Chat.Domain.Entities.GroupE;
using Chat.Domain.Entities.MessageE;
using Common.Services.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public class CreateNewMessageCommandHandler : IRequestHandler<CreateNewMessageCommand, string>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IGroupRepository _groupRepository;

        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _environment;

        public CreateNewMessageCommandHandler(IMapper Mapper, IMessageRepository messageRepository, IGroupRepository groupRepository, IHostingEnvironment environment)
        {
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
            _mapper = Mapper ?? throw new ArgumentNullException(nameof(Mapper));
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
        }
        public async Task<string> Handle(CreateNewMessageCommand request, CancellationToken cancellationToken)
        {
            var group = await _groupRepository.GetGroupById(request.Group_Id);
            if (group == null)
                throw new NotFoundException("Group", group.Id);

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
                    Message_Id = result.Id,
                    Path = UploadFile(item.Upload).FileNameAddress,

                });
            }
            return result.Id;

        }
        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"File\Chat\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = Guid.NewGuid().ToString();
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }



    public class UploadDto
    {
        public long Id { get; set; }
        public bool Status { get; set; }
        public string FileNameAddress { get; set; }
    }

}

