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
    /// Логика взаимодействия для PageSysAdmin.xaml
    /// </summary>
    public partial class PageSysAdmin : Page
    {
        public PageSysAdmin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageMove.BWFrame.Navigate(new PageSysAdminTableAdmin());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PageMove.BWFrame.Navigate(new PageSysAdminTableJoinHistory());
        }
    }
}
