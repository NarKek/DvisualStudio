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
        public ListOfPlacesPage(string name)
        {
            InitializeComponent();
            LoadData();
            if(name == "ButtonFood")
            PageName.Text = "рестораны";
            if (name == "ButtonCinema")
                PageName.Text = "кино";
            if (name == "ButtonBars")
                PageName.Text = "бары";
            if (name == "ButtonPark")
                PageName.Text = "парки";
            if (name == "ButtonConcerts")
                PageName.Text = "концерты";

            
        }

        private void ButtonBackToCategories_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CommonClick(object sender, RoutedEventArgs e)
        {
            //common click for all items in the list , that depends on which button was clicked
        }

        private async void LoadData()
        {
            var result = await GetRestaurants();
            LoadingLabel.Visibility = Visibility.Hidden;
        }

        private Task<string> GetRestaurants()
        {
            return Task.Run(() =>
            {
                Task.Delay(2000).Wait();
                return "Restaurants";
            });

            //method that will be replaced in future (now is for showing loading window for 2 secs )
        }
    }
}
