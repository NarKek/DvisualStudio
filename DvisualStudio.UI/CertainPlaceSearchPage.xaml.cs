using DvisualStudio.Core;
using DvisualStudio.Core.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace DvisualStudio.UI
{
    /// <summary>
    /// Логика взаимодействия для CertainPlaceSearchPage.xaml
    /// </summary>
    public partial class CertainPlaceSearchPage : Page
    {
        ServiceManager sm = new ServiceManager();

        public CertainPlaceSearchPage()
        {
            InitializeComponent();
            LoadingLabel.Visibility = Visibility.Hidden;
        }

        private async void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoadingLabel.Visibility = Visibility.Visible;
                ItemsControlOnPlaceSearchPage.ItemsSource = await sm.TextSearch(SearchBox.Text);
                LoadingLabel.Visibility = Visibility.Hidden;
            }
        }

        private void ButtonCategories_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new ContentForCategories();
        }

        private void ButtonMainFilter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new MainFilterPage();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new CertainPlaceSearchPage();
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchBox.Clear();
            SearchBox.GotFocus -= SearchBox_GotFocus;
            SearchBox.Foreground = Brushes.Black;
        }

        private void CommonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new PageOfAPlace((sender as Button).DataContext as Place);
        }


    }
}
