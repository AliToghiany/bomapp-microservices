﻿using bomapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Common.Interfaces;
using wpf_lib.ViewModels;

namespace bomapp.Views.Pages
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage 
    {
        public MyProfileViewModel MyProfile
        {
            get;
        }
        public ProfilePage(MyProfileViewModel myProfile)
        {
            MyProfile = myProfile;
            InitializeComponent();
            this.Loaded += ProfilePage_Loaded;
        }

        private async void ProfilePage_Loaded(object sender, RoutedEventArgs e)
        {
            await MyProfile.SetMyProfile();
        }
    }
}
