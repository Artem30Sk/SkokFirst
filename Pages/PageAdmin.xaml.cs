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
using Sweetshop.Classes;

namespace Sweetshop.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();
        }

        private void Button_PageMandgClick(object sender, RoutedEventArgs e)
        {
            PageMove.BWFrame.Navigate(new PageAdminTableManadger());
        }

        private void Button_PageRecipeClick(object sender, RoutedEventArgs e)
        {
            PageMove.BWFrame.Navigate(new PageAdminTableRecipe());
        }

        private void Button_PageProductClick(object sender, RoutedEventArgs e)
        {
            PageMove.BWFrame.Navigate(new PageAdminTableProduct());
        }

        private void Button_PageProductRecipeClick(object sender, RoutedEventArgs e)
        {
            PageMove.BWFrame.Navigate(new PageAdminTableRecipeProduct());
        }
    }
}
