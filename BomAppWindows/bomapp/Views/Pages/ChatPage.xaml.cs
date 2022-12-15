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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Controls;
using wpf_lib.ViewModels;

namespace bomapp.Views.Pages
{
    /// <summary>
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage : UiPage
    {
        private readonly SearchChat _searchChat;
        private readonly ChatDetailPage _chatDetail;
        public ChatPage(SearchChat searchChat, ChatDetailPage chatDetail)
        {
            InitializeComponent();

            _searchChat = searchChat;
            _chatDetail = chatDetail;

            _NavigationFrame.Navigate(_chatDetail);
          
            _searchChat.BackButtonClicked += _searchChat_BackButtonClicked;
            _searchChat.Selected += _searchChat_Selected;
        }

        private void _searchChat_Selected(object? sender, EventArgs e)
        {
            var chat = sender as SearchChatModel;
            _NavigationFrame.Navigate(_chatDetail);
            _chatDetail.SetChatDetail(chat.Type, chat.ID);
        }

        private void _searchChat_BackButtonClicked(object? sender, EventArgs e)
        {
           
            _NavigationFrame.Navigate(_chatDetail);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(_searchChat);
        }
    }
}
