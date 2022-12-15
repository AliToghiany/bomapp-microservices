using CommunityToolkit.Mvvm.ComponentModel;
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

        public ChatDetailViewModel(IUserRepository userRepository, IUserService userService)
        {
           _userRepository = userRepository;
           _userService = userService;
        }
        private ChatDetaileHeader chatHeader;

        public ChatDetaileHeader ChatHeader
        {
            get { return chatHeader; }
            set { chatHeader = value; }
        }

        public async Task SetChatDetail(Type chattype, long id)
        {
            switch (chattype)
            {
                case Type.Group:
                    break;

                case Type.PrivateRomm:
                    await SetUserHeader(id);
                    break;
                default:
                    break;
            }
        }
        async Task SetUserHeader(long id)
        {
            var resOffline=await _userRepository.GetUser(id);
            if (resOffline.IsSuccess)
            {
                ChatHeader = new ChatDetaileHeader
                {
                    Image = resOffline.Data!.ImagesProfileResponses.First().Path ?? "undifind",
                    Title = resOffline.Data.FirstName + resOffline.Data.LastName,
                    SubTitle="Online"
                };
            }
            if (ServerUtilities.CheckForInternetConnection())
            {
                var resOnline=await _userService.GetUser(id);
                if (resOnline.IsSuccess)
                {
                    ChatHeader = new ChatDetaileHeader
                    {
                        Image = resOnline.Data!.ImagesProfileResponses.First().Path ?? "undifind",
                        Title = resOnline.Data.FirstName + resOffline.Data.LastName,
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
}
