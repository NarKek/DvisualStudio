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
    public partial class RestarauntListPage : Page
    {
        public RestarauntListPage()
        {
            InitializeComponent();
        }

        private void ButtonBackToCategories_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CommonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("uuu");
        }


    }
}
