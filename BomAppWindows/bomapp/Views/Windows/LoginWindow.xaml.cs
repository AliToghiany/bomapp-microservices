using bomapp.Services.Contracts;
using bomapp.Views.Pages;
using dotnet_lib;
using dotnet_lib.Models.Request;
using dotnet_lib.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace bomapp.Views.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : INavigationWindow
    {
     
        private readonly IAuthService _authService;
        private readonly ISnackbarService _snackbarService;
        private readonly ITestWindowService _testWindowService;
        public LoginWindow(IAuthService authService, ISnackbarService snackbarService,ITestWindowService testWindowService)
        {


          
            InitializeComponent();
           
            ConfirmCode.Visibility = Visibility.Hidden;
            _authService = authService;
            _snackbarService = snackbarService;
           _testWindowService = testWindowService;
            _snackbarService.SetSnackbarControl(RootSnackbar);
            Loaded += LoginWindow_Loaded;


        }

        private void LoginWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Token))
            {
                _testWindowService.Show<StoreWindow>();
                this.Visibility = Visibility.Hidden;
                dotnet_lib.App.Token = Properties.Settings.Default.Token;
                dotnet_lib.App.UserId = Properties.Settings.Default.UserID;
            }
        }

        Guid authId;
        private async void SendCodebtn_Click(object sender, RoutedEventArgs e)
        {
            var res=  await _authService.GetAuthIdAsync(Phone.Text);
            if (!res.IsSuccess)
            {
                _snackbarService.Show("BomApp", res.Message, Wpf.Ui.Common.SymbolRegular.ErrorCircle24, Wpf.Ui.Common.ControlAppearance.Danger);
            }
            else
            {
                authId =res.Data!.Code;
                ConfirmCode.Visibility = Visibility.Visible;
                SendCode.Visibility = Visibility.Hidden;
            }
          
            
        }

        private async void ConfirmCodebtn_Click(object sender, RoutedEventArgs e)
        {
            var res=await _authService.ConfirmCodeAsync(new SignUserRequest
            {
               Code=Code.Text,
               ConfirmId=authId
            });
            if (!res.IsSuccess)
            {
                _snackbarService.Show("BomApp", res.Message, Wpf.Ui.Common.SymbolRegular.ErrorCircle24, Wpf.Ui.Common.ControlAppearance.Danger);
            }
            else
            {
                Properties.Settings.Default.Token = res.Data!.Token;
                Properties.Settings.Default.UserID = res.Data!.UserId;
                Properties.Settings.Default.Save();
                _testWindowService.Show<StoreWindow>();
                dotnet_lib.App.Token = res.Data!.Token!;
                dotnet_lib.App.UserId = res.Data!.UserId;


            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConfirmCode.Visibility = Visibility.Hidden;
            SendCode.Visibility = Visibility.Visible;
        }

        public Frame GetFrame()
        {
            throw new NotImplementedException();
        }

        public INavigation GetNavigation()
        {
            throw new NotImplementedException();
        }

        public bool Navigate(Type pageType)
        {
            throw new NotImplementedException();
        }

        public void SetPageService(IPageService pageService)
        {
            throw new NotImplementedException();
        }

        public void ShowWindow()
        {
            Show();
        }

        public void CloseWindow()
        {
            Close();
        }
    }
}
