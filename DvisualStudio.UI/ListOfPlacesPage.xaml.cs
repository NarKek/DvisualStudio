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
                PageName.Text = "рестораны";
            if (name == "ButtonCinema")
                PageName.Text = "кино";
            if (name == "ButtonBars")
                PageName.Text = "бары";
            if (name == "ButtonPark")
                PageName.Text = "парки";
            if (name == "ButtonConcerts")
            {
                PageName.Text = "концерты";
               
            }
            LoadData();
        }

        private void ButtonBackToCategories_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CommonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new PageOfAPlace();
        }

        private async void LoadData()
        {
            //sm.ConcertsLoaded += OnConcertsLoaded;
            var getData = await sm.GetConcerts();
            ItemsControlOnListPage.ItemsSource = getData;
            LoadingLabel.Visibility = Visibility.Hidden;
        }
        //private  GetRestaurants()
        //{
        //    return Task.Run(() =>
        //    {
        //        Task.Delay(2000).Wait();
        //        return "Restaurants";
        //    });
        //
        //    //method that will be replaced in future (now is for showing loading window for 2 secs )
        //}
    }
}
