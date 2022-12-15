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
using Wpf.Ui.Controls;
using wpf_lib.ViewModels;
using TextBox = Wpf.Ui.Controls.TextBox;

namespace bomapp.Views.Pages
{
    /// <summary>
    /// Interaction logic for SearchChat.xaml
    /// </summary>
    public partial class SearchChat : Page
    {
        public event EventHandler? BackButtonClicked;
        public event EventHandler? Selected;
        public SearchChatViewModel SearchViewModel 
        {
            get;
        }
        public SearchChat(SearchChatViewModel searchViewModel)
        {
            InitializeComponent();
            SearchViewModel = searchViewModel;
            DataContext = SearchViewModel;


        }

      

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (BackButtonClicked != null)
                BackButtonClicked(this, EventArgs.Empty);
        }

        private async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            await SearchViewModel.InvokSearch((sender as TextBox).Text);
        }

        private void CardSearch_Click(object sender, RoutedEventArgs e)
        {
            var res =(sender as CardControl).DataContext as SearchChatModel;
            if(Selected != null)
            {
                Selected(res, EventArgs.Empty);
            }
        }
    }
}
