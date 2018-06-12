using DvisualStudio.Core;
using DvisualStudio.Core.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DvisualStudio.UI
{
    /// <summary>
    /// Логика взаимодействия для PageOfAPlace.xaml
    /// </summary>
    public partial class PageOfAPlace : Page
    {
        private ServiceManager sm = new ServiceManager();
        private Place _place;

        public PageOfAPlace(Place place)
        {
            _place = place;
            InitializeComponent();
            LoadData();
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

        private void ButtonBackToListOfPlaces_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private async void LoadData()
        {
            var getData = await sm.GetDetailedPlace(_place);
            DataContext = getData;
            CommentControlOnLPlacePage.ItemsSource = getData.Reviews;
        }

        private void GoToSiteClick(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(((sender as Button).Content as TextBlock).Text);
            }
            catch (System.Exception)
            {
                MessageBox.Show("Unable to redirect to the website");
            }
        }
    }
}
