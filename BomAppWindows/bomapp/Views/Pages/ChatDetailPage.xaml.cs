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
using wpf_lib.ViewModels;
using Type = wpf_lib.ViewModels.Type;

namespace bomapp.Views.Pages
{
    /// <summary>
    /// Interaction logic for ChatDetailPage.xaml
    /// </summary>
    public partial class ChatDetailPage : Page
    {
        public ChatDetailViewModel ChatDetailViewModel 
        {
            get;
        }
        public ChatDetailPage(ChatDetailViewModel chatDetailViewModel)
        {
            InitializeComponent();
            ChatDetailViewModel = chatDetailViewModel;
            DataContext = ChatDetailViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        public async void SetChatDetail(Type Chattype,long Id)
        {
          await  ChatDetailViewModel.SetChatDetail(Chattype,Id);
        }

    }
}
