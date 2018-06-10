using DvisualStudio.Core;
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
    /// Логика взаимодействия для MainFilterPage.xaml
    /// </summary>
    public partial class MainFilterPage : Page
    {
        ServiceManager sm = new ServiceManager();

        public MainFilterPage()
        {
            InitializeComponent();
            LoadingLabel.Visibility = Visibility.Hidden;
            CategoryComboBox.ItemsSource = new List<string>()
            {
                null, "restaurant", "bar", "movie_theater", "park"
            };
            RatingComboBox.ItemsSource = new List<int?>()
            {
                null, 0, 1, 2, 3, 4, 5
            };
            PriceComboBox.ItemsSource = new List<int?>()
            {
                null, 0, 1, 2, 3, 4
            };
            OpenOrNotComboBox.ItemsSource = new List<bool?>()
            {
                null, true
            };
            CategoryComboBox.SelectedIndex = 0;
            PriceComboBox.SelectedIndex = 0;
            RatingComboBox.SelectedIndex = 0;
            OpenOrNotComboBox.SelectedIndex = 0;
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

        private void RefreshSettings_Click(object sender, RoutedEventArgs e)
        {
            CategoryComboBox.SelectedIndex = 0;
            PriceComboBox.SelectedIndex = 0;
            RatingComboBox.SelectedIndex = 0;
            OpenOrNotComboBox.SelectedIndex = 0;
        }

        private async void SearchWithSettings_Click(object sender, RoutedEventArgs e)
        {
            ItemsControlOnPMainFilterPage.ItemsSource = await sm.SearchWithParameters(PriceComboBox.SelectedItem as int?, CategoryComboBox.SelectedItem as string, RatingComboBox.SelectedItem as int?, OpenOrNotComboBox.SelectedItem as bool?);
        }
    }
}
