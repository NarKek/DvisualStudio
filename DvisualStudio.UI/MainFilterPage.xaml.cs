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
        public MainFilterPage()
        {
            InitializeComponent();
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
            CategoryComboBox.SelectedIndex = 1;
            PriceComboBox.SelectedIndex = -1;
            RatingComboBox.SelectedIndex = -1;
            OpenOrNotComboBox.SelectedIndex = -1;
        }

        private void SearchWithSettings_Click(object sender, RoutedEventArgs e)
        {
            // code for searching with selected parameters
        }
    }
}
