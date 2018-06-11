using DvisualStudio.Core;
using DvisualStudio.Core.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DvisualStudio.UI
{
    /// <summary>
    /// Логика взаимодействия для ListOfConcertsPage.xaml
    /// </summary>
    public partial class ListOfConcertsPage : Page
    {
        private ServiceManager sm = new ServiceManager();

        public ListOfConcertsPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void ButtonBackToCategories_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void CommonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new PageOfAConcert((sender as Button).DataContext as Concert);
        }

        private async void LoadData()
        {
            var getData = await sm.GetConcerts();
            LoadingLabel.Visibility = Visibility.Hidden;
            ItemsControlOnConcertPage.ItemsSource = getData.Where(c=>c.Date >= DateTime.Now).OrderBy(c => c.Date);
        }
    }
}
