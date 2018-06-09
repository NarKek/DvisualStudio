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
            NavigationService.Content = new PageOfAConcert();
        }

        private async void LoadData()
        {
            var getData = await sm.GetConcerts();
            LoadingLabel.Visibility = Visibility.Hidden;
            ItemsControlOnConcertPage.ItemsSource = getData.OrderBy(c => c.Date);
        }
    }
}
