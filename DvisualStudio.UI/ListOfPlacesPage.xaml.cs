using DvisualStudio.Core;
using DvisualStudio.Core.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DvisualStudio.UI
{
    /// <summary>
    /// Логика взаимодействия для RestarauntList.xaml
    /// </summary>
    public partial class ListOfPlacesPage : Page
    {
        ServiceManager sm = new ServiceManager();

         string searchCategory;

        public ListOfPlacesPage(string name)
        {
            InitializeComponent();

            if(name == "ButtonFood")
            {
                PageName.Text = "restaurants";
                searchCategory = "restaurant";
            }
            if (name == "ButtonCinema")
            {
                PageName.Text = "cinemas";
                searchCategory = "movie_theater";
            }
            if (name == "ButtonBars")
            {
                PageName.Text = "bars";
                searchCategory = "bar";
            }
            if (name == "ButtonPark")
            {
                PageName.Text = "parks";
                searchCategory = "park";
            }
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
            var getData = await sm.GetPlacesByCategory(searchCategory);
            ItemsControlOnListPage.ItemsSource = getData;
            LoadingLabel.Visibility = Visibility.Hidden;
        }
    }
}
