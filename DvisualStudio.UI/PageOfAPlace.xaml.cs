using DvisualStudio.Core;
using DvisualStudio.Core.Model;
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
    }
}
