using AutoMapper;
using dotnet_lib.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_lib.Context;
using wpf_lib.Entity;
using wpf_lib.Interface;
using File = wpf_lib.Entity.File;

namespace wpf_lib.Service
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public MessageRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ResponseMessage> LoadPrivateRoomMessage(long myId, long userId)
        {
            var messages = _dbContext.Messages.Include(p => p.Files).Where(p => (p.UserId == myId && p.UserId == userId) || (p.UserId == userId && p.UserId == myId)).Take(300);
            List<ResponseMessage> result = new List<ResponseMessage>();
            foreach (var item in messages)
            {
                var resP = _mapper.Map<ResponseMessage>(messages);
                resP.Files = item.Files.Select(p => new FileDto
                {
                    Name = p.Name,
                    Path = p.Path
                }).ToList();
            }
            return result;
        }
        public async Task NewMessage(Message message)
        {
         await  _dbContext.Messages.AddAsync(message);
            await _dbContext.SaveChangesAsync();

        }
        public async Task NewFile(File file)
        {
            await _dbContext.Files.AddAsync(file);
        }

        public async Task UpdateMessage(ResponseMessage message)
        {
            var res = await _dbContext.Messages.FindAsync(message.Id);
            if (res == null)
            {
                await NewMessage(_mapper.Map<Message>(message));
                foreach (var item in message.Files)
                    await NewFile(new File
                    {
                        MessageId = message.Id,
                        Name = item.Name,
                        Path = item.Path
                    });
               await _dbContext.SaveChangesAsync();
               return;
            }
            res.Text = message.Text;
            _dbContext.Messages.Update(res);
            await _dbContext.SaveChangesAsync();
        }
    }
}
