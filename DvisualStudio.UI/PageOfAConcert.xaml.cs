using DvisualStudio.Core.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DvisualStudio.UI
{
    /// <summary>
    /// Логика взаимодействия для PageOfAConcert.xaml
    /// </summary>
    public partial class PageOfAConcert : Page
    {
        public PageOfAConcert(Concert concert)
        {
            InitializeComponent();
            DataContext = concert;
        }

        private void ButtonBackToListOfConcerts_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
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

        private void GoToSiteClick(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(((sender as Button).Content as TextBlock).Text);
            }
            catch (System.Exception)
            {
                MessageBox.Show("Unable to redirect to the website");
            }
        }
    }
}
