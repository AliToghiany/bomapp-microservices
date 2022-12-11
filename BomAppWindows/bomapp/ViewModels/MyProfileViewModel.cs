using CommunityToolkit.Mvvm.ComponentModel;
using dotnet_lib.Models.Response;
using dotnet_lib.Services.Interface;
using dotnet_lib.Utitlities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Common.Interfaces;

namespace bomapp.ViewModels
{
    public class MyProfileViewModel:ObservableObject
    {

        private readonly IUserService _userService;

        public MyProfileViewModel(IUserService userService)
        {
            _userService = userService;
           
        }

        private GetMyUserProfileResponse _myProfile=new GetMyUserProfileResponse();
       
        public GetMyUserProfileResponse MyProfile
        {
            get => _myProfile;
            set => SetProperty(ref _myProfile, value);
        }
        public async Task SetMyProfile()
        {
            
            if (ServerUtilities.CheckForInternetConnection())
            {
                var resOnlline = await _userService.GetMyUserProfileResponseAsync();
                if (resOnlline.IsSuccess)
                    MyProfile = resOnlline.Data!;

            }
          

           
        }
    }
}
