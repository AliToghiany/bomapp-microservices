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

namespace bomapp.Views.Pages
{
    /// <summary>
    /// Interaction logic for SearchChat.xaml
    /// </summary>
    public partial class SearchChat : Page
    {
        public event EventHandler? BackButtonClicked;
        private readonly SearchViewModel _searchViewModel;
        public SearchChat(SearchViewModel searchViewModel)
        {
            InitializeComponent();
            _searchViewModel = searchViewModel;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (BackButtonClicked != null)
                BackButtonClicked(this, EventArgs.Empty);
        }
    }
}
