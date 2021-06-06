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

namespace Sweetshop.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageSysAdminTableJoinHistory.xaml
    /// </summary>
    public partial class PageSysAdminTableJoinHistory : Page
    {
        public PageSysAdminTableJoinHistory()
        {
            InitializeComponent();
            DGHistory.ItemsSource = SweetshopEntities1.GetContext().JoinHistories.ToList();
        }
    }
}
