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
    /// Логика взаимодействия для RestarauntList.xaml
    /// </summary>
    public partial class ListOfPlacesPage : Page
    {
        ServiceManager sm = new ServiceManager();

        public ListOfPlacesPage(string name)
        {
            InitializeComponent();
            if(name == "ButtonFood")
                PageName.Text = "restaurant";
            if (name == "ButtonCinema")
                PageName.Text = "movie_theater";
            if (name == "ButtonBars")
                PageName.Text = "bar";
            if (name == "ButtonPark")
                PageName.Text = "park";
            LoadData();
        }

        private void ButtonBackToCategories_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CommonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new PageOfAPlace((sender as Button).DataContext as Place);
        }

        private async void LoadData()
        {
            var getData = await sm.GetPlacesByCategory(PageName.Text);
            ItemsControlOnListPage.ItemsSource = getData;
            LoadingLabel.Visibility = Visibility.Hidden;
        }
    }
}
