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
    /// Логика взаимодействия для PageAdminTableProduct.xaml
    /// </summary>
    public partial class PageAdminTableProduct : Page
    {
        public PageAdminTableProduct()
        {
            InitializeComponent();
        }

        private void Button_editClick(object sender, RoutedEventArgs e)
        {
            PageMove.BWFrame.Navigate(new PageAddProduct((sender as Button).DataContext as Product));
        }

        private void Button_addClick(object sender, RoutedEventArgs e)
        {
            PageMove.BWFrame.Navigate(new PageAddProduct(null));
        }

        private void Button_deleteClick(object sender, RoutedEventArgs e)
        {
            var productRemove = DGProduct.SelectedItems.Cast<Product>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {productRemove.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SweetshopEntities1.GetContext().Products.RemoveRange(productRemove);
                    SweetshopEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGProduct.ItemsSource = SweetshopEntities1.GetContext().Products.ToList();
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
                DGProduct.ItemsSource = SweetshopEntities1.GetContext().Products.ToList();
            }
        }
    }
}
