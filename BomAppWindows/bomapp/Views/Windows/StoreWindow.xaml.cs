// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System;
using System.Windows.Controls;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace bomapp.Views.Windows;

/// <summary>
/// Interaction logic for StoreWindow.xaml
/// </summary>
public partial class StoreWindow : INavigationWindow
{
    public StoreWindow(IPageService pageService, INavigationService navigationService)
    {
       
        InitializeComponent();
        SetPageService(pageService);
        navigationService.SetNavigationControl(RootNavigation);
    }

    public void CloseWindow()
    {
        throw new NotImplementedException();
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
   => RootNavigation.PageService = pageService;

    public void ShowWindow()
    {
        Show();
    }
}
