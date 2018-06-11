using DvisualStudio.Core;
using DvisualStudio.Core.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
                null, "restaurants", "bars", "cinemas", "parks"
            };
            RatingComboBox.ItemsSource = new List<int?>()
            {
                null, 0, 1, 2, 3, 4, 5
            };
            PriceComboBox.ItemsSource = new List<string>()
            {
                null, "free", "cheap", "moderate", "expensive", "very expensive"
            };
            OpenOrNotComboBox.ItemsSource = new List<string>()
            {
                null, "open now"
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
            ItemsControlOnPMainFilterPage.ItemsSource = null;
        }

        private async void SearchWithSettings_Click(object sender, RoutedEventArgs e)
        {
            LoadingLabel.Visibility = Visibility.Visible;
            ItemsControlOnPMainFilterPage.ItemsSource = await sm.SearchWithParameters(PriceComboBox.SelectedItem as string, CategoryComboBox.SelectedItem as string, RatingComboBox.SelectedItem as int?, OpenOrNotComboBox.SelectedItem as string);
            LoadingLabel.Visibility = Visibility.Hidden;
        }

        private void CommonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new PageOfAPlace((sender as Button).DataContext as Place);
        }
    }
}
