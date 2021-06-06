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
    /// Логика взаимодействия для PageAdminTableManadger.xaml
    /// </summary>
    public partial class PageAdminTableManadger : Page
    {
        public PageAdminTableManadger()
        {
            InitializeComponent();
        }

        private void Button_editClick(object sender, RoutedEventArgs e)
        {
            PageMove.BWFrame.Navigate(new PageAddManadgers((sender as Button).DataContext as Manadger));
        }

        private void Button_addClick(object sender, RoutedEventArgs e)
        {
            PageMove.BWFrame.Navigate(new PageAddManadgers(null));
        }

        private void Button_deleteClick(object sender, RoutedEventArgs e)
        {
            var roleRemove = DGManadgers.SelectedItems.Cast<Manadger>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {roleRemove.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SweetshopEntities1.GetContext().Manadgers.RemoveRange(roleRemove);
                    SweetshopEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGManadgers.ItemsSource = SweetshopEntities1.GetContext().Manadgers.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                SweetshopEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGManadgers.ItemsSource = SweetshopEntities1.GetContext().Manadgers.ToList();
            }
        }
    }
}
