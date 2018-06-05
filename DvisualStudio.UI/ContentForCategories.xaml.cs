using DvisualStudio.API.Interfaces;
using DvisualStudio.API.Services;
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
    /// Логика взаимодействия для ContentForCategories.xaml
    /// </summary>
    public partial class ContentForCategories : Page
    {
        public ContentForCategories()
        {
            InitializeComponent();
            IGooglePlacesService lol = new GooglePlacesService();
            
            var kek = lol.FindNearestPlacesByCategory("movie_theater");
        }

        private void ButtonFood_Click(object sender, RoutedEventArgs e)
        {
            var restlist = new RestarauntListPage();
            NavigationService.Content = restlist;
        }
    }
}
