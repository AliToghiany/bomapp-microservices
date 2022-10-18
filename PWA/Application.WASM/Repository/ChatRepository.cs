using Application.WASM.Data;
using Application.WASM.IndexDbEntities;
using Application.WASM.Models;
using Application.WASM.Repository.Interface;
using Application.WASM.Services;
using IndexedDB.Blazor;

namespace Application.WASM.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly IIndexedDbFactory DbFactory;
        private readonly IChatService _chatService;
        private readonly IUserService _userService;

        public ChatRepository(IIndexedDbFactory dbFactory, IChatService chatService, IUserService userService)
        {
            DbFactory = dbFactory;
            _chatService = chatService;
            _userService = userService;
        }

        public async Task<long> NewMessage(Message message)
        {
           
                using (var db = await this.DbFactory.Create<ChatDb>())
                {
                
                //if (message.Group_Id != null)
                //{
                //    if (db.Messages.Where(p=>p.Group_Id==message.Group_Id).Count()==49)
                //    {
                //        db.Messages.Remove(db.Messages.First(p => p.Group_Id == message.Group_Id));
                //    }
                   
                //}  
                //if (message.PrivateRoom_Id != null)
                //{
                //    if (db.Messages.Where(p=> p.PrivateRoom_Id == message.PrivateRoom_Id).Count()==49)
                //    {
                //        db.Messages.Remove(db.Messages.First(p => p.PrivateRoom_Id == message.PrivateRoom_Id));
                //    }
                   
                //} 
                    db.Messages.Add(message);
                    await db.SaveChanges();
                message.Id = db.Messages.First(p => p.MessageId == message.MessageId).Id;
                }
                return message.Id;
          
          
            
            
        }
        public async Task<bool> NewGroup(Group group)
        {
                using (var db = await this.DbFactory.Create<ChatDb>())
                {
               
                    db.Groups.Add(group);
                    await db.SaveChanges();
                }
                return true;
        }

        public async Task<bool> CheckGroup(string groupid)
        {
            using (var db = await this.DbFactory.Create<ChatDb>())
            {

                if (db.Groups.FirstOrDefault(p => p.GroupId == groupid) != null)
                {
                    return true;
                }
            }
            return false;
        }
      
        public async Task<long> NewPrivateRoom(MyPrivateRoom privateRoom)
        {
          
            using (var db = await this.DbFactory.Create<ChatDb>())
                {
                
                db.MyPrivateRooms.Add(privateRoom);
                    await db.SaveChanges();
                privateRoom.Id= db.MyPrivateRooms.First(p => p.WithUserId == privateRoom.WithUserId).Id;
            }
                return privateRoom.Id;
        }
        public async Task<long?> CheckPrivateRoom(long withUserId)
        {
            using (var db = await this.DbFactory.Create<ChatDb>())
            {
                var res = db.MyPrivateRooms.FirstOrDefault(p => p.WithUserId == withUserId);
                if (res == null)
                    return null;
                return res.Id;
            }
        }
        public async Task<User?> CheckUser(long userId)
        {
            using (var db = await this.DbFactory.Create<ChatDb>())
            {
                return db.Users.FirstOrDefault(p => p.UserId == userId);
            }
        }
        public async Task<long> NewUser(User user)
        {

            using (var db = await this.DbFactory.Create<ChatDb>())
            {

                db.Users.Add(user);
                await db.SaveChanges();
            }
            return user.Id;
        }

        public async Task<Message> NewMessageService(ResponseMessage message)
        {
            Message messagelocal= new Message
            {
                CreatedDate = message.CreatedDate,
                Gif_Id = message.Gif_Id,
                LastModifiedDate = message.LastModifiedDate,
                MessageId = message.Id,
                Message_Id = message.Message_Id,
                Reply_To_MessageId = message.Reply_To_MessageId,
                Sticker_Id = message.Sticker_Id,
                Text = message.Text,
                User_Id = message.User_Id


            };
            long messageidlcal;
            if (message.Group_Id != null)
            {
                if (!await CheckGroup(message.Group_Id))
                {
                    var res = await _chatService.GetGroupById(message.Group_Id);
                    await NewGroup(new IndexDbEntities.Group
                    {
                        Description = res.Description,
                        GroupId = res.Id,
                        GroupName = res.GroupName,
                        Name = res.Name,

                    });
                }
                messagelocal.Group_Id = message.Group_Id;
                messageidlcal = await NewMessage(messagelocal);
                messagelocal.Id = messageidlcal;
            }
            if (message.ToUser_Id != null)
            {
                var privateRomm = await CheckPrivateRoom(message.ToUser_Id.Value);
                if (privateRomm == null)
                {
                    privateRomm = await NewPrivateRoom(new MyPrivateRoom
                    {
                        NewMessage = 1,
                        WithUserId = message.ToUser_Id.Value
                    });


                }
                messagelocal.PrivateRoom_Id = privateRomm;
                messageidlcal = await NewMessage(messagelocal);
                messagelocal.Id = messageidlcal;
            }
          
            return messagelocal;
        }

        public async Task<List<RecentChat>> GetRecentChat()
        {
            List<RecentChat> recentChats = new List<RecentChat>();
            var db = await this.DbFactory.Create<ChatDb>();
            var groups = db.Groups.AsEnumerable();
            var privateRooms = db.MyPrivateRooms.AsEnumerable();
            foreach (var privateRoom in privateRooms)
                {
               
                var lastMessage = db.Messages.LastOrDefault(p => p.PrivateRoom_Id == privateRoom.Id);
                if (lastMessage == null)
                    continue;
                recentChats.Add(new RecentChat
                {

                    Message = lastMessage,
                    MyPrivateRoom = privateRoom,

                });
 
                }
            foreach (var group in groups)
            {
               
                var lastMessage = db.Messages.LastOrDefault(p => p.Group_Id == group.GroupId);
                if (lastMessage == null)
                    continue;
                recentChats.Add(new RecentChat
                {
                    Group = group,
                    Message = lastMessage,

                });
            }

            return recentChats.OrderBy(p => p.Message.CreatedDate).ToList();
        }

    }
}
