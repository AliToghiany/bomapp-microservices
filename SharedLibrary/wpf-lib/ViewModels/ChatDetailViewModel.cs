using CommunityToolkit.Mvvm.ComponentModel;
using dotnet_lib.Models.Response;
using dotnet_lib.Services;
using dotnet_lib.Services.Interface;
using dotnet_lib.Utitlities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_lib.Interface;
using wpf_lib.Service;

namespace wpf_lib.ViewModels
{
    public class ChatDetailViewModel : ObservableObject
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IMessageRepository _messageRepository;
        public event EventHandler? NeedLoadMessage;
        public ChatDetailViewModel(IUserRepository userRepository, IUserService userService, IMessageRepository messageRepository)
        {
            _userRepository = userRepository;
            _userService = userService;
            _messageRepository = messageRepository;
        }
        private ChatDetaileHeader chatHeader;

        public ChatDetaileHeader ChatHeader
        {
            get { return chatHeader; }
            set => SetProperty(ref chatHeader, value);
        }
        private List<ResponseMessage> messages;

        public List<ResponseMessage> Messages
        {
            get { return messages; }
            set { SetProperty(ref messages, value); }
        }


        public async Task SetChatDetail(Type chattype, long id)
        {
            switch (chattype)
            {
                case Type.Group:
                    break;

                case Type.PrivateRomm:
                    await SetUserHeader(dotnet_lib.App.UserId);
                    LoadPrivateRoomMessage(id);
                    break;
                default:
                    break;
            }
        }

        private void LoadPrivateRoomMessage(long id)
        {
            var resOffline = _messageRepository.LoadPrivateRoomMessage(dotnet_lib.App.UserId, id);
            Messages = resOffline;
            if (messages.Count < 50&&messages.Count!=0)
            {
                if (NeedLoadMessage != null)
                {
                    NeedLoadMessage(new NeedLoadMessage
                    {
                        LastMessage = messages.First().Id
                    }, EventArgs.Empty);
                }
            }

        }

        async Task SetUserHeader(long id)
        {
            var resOffline = await _userRepository.GetUser(id);
            if (resOffline.IsSuccess)
            {
                var img = resOffline.Data!.ImagesProfileResponses.FirstOrDefault();
                ChatHeader = new ChatDetaileHeader
                {
                    Image = img != null ? img.Path : "undifind",
                    Title = resOffline.Data.FirstName + resOffline.Data.LastName,
                    SubTitle = "Online"
                };
            }
            if (ServerUtilities.CheckForInternetConnection())
            {
                var resOnline = await _userService.GetUser(id);
                if (resOnline.IsSuccess)
                {
                    var img = resOnline.Data!.ImagesProfileResponses.FirstOrDefault();

                    ChatHeader = new ChatDetaileHeader
                    {
                        Image = img != null ? img.Path : "undifind",
                        Title = resOnline.Data.FirstName + resOnline.Data.LastName,
                        SubTitle = "Online"
                    };
                    await _userRepository.UpdateUser(resOnline.Data);
                }

            }
        }


    }
    public class ChatDetaileHeader
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }

    }
    public class NeedLoadMessage
    {
        public long? FirstMessage { get; set; }
        public long? LastMessage { get; set; }
        public long? GroupId { get; set; }
        public long? ToUserId { get; set; }
    }
}
