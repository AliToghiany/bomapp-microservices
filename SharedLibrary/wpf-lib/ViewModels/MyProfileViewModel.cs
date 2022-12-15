using CommunityToolkit.Mvvm.ComponentModel;
using dotnet_lib.Models.Response;
using dotnet_lib.Services.Interface;
using dotnet_lib.Utitlities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_lib.Interface;
using static Humanizer.In;
using static System.Net.Mime.MediaTypeNames;

namespace wpf_lib.ViewModels
{
    public class MyProfileViewModel: ObservableObject
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public MyProfileViewModel(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }
        private GetMyUserProfileResponse _myProfile = new GetMyUserProfileResponse();

        public GetMyUserProfileResponse MyProfile
        {
            get => _myProfile;
            set => SetProperty(ref _myProfile, value);
        }
     

        public async Task SetMyProfile()
        {
            var resOffline =await _userRepository.GetMyUserProfile();
            if (resOffline.IsSuccess)
                MyProfile = resOffline.Data!;
            if (ServerUtilities.CheckForInternetConnection())
            {
                var resOnlline = await _userService.GetMyUserProfileResponseAsync();
                if (resOnlline.IsSuccess)
                    MyProfile = resOnlline.Data!;
                    await _userRepository.UpdateUser(MyProfile);

            }



        }
       
    }
}
 