using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
        }

        private void CommonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var list = new ListOfPlacesPage(button.Name);
            NavigationService.Navigate(list);
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

        private void ConcertClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new ListOfConcertsPage();
        }

            
    }


}
