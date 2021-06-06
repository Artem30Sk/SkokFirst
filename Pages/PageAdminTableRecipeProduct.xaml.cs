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
    /// Логика взаимодействия для PageAdminTableRecipeProduct.xaml
    /// </summary>
    public partial class PageAdminTableRecipeProduct : Page
    {
        private RecipeProduct repProd = new RecipeProduct();
        public PageAdminTableRecipeProduct()
        {
            InitializeComponent();
            
            DGRecipeProduct.ItemsSource = SweetshopEntities1.GetContext().RecipeProducts.ToList();
        }

        private void Button_addClick(object sender, RoutedEventArgs e)
        {
            PageMove.BWFrame.Navigate(new PageAddRecipeProduct());
        }

        private void Button_deleteClick(object sender, RoutedEventArgs e)
        {
            var reprpodRemove = DGRecipeProduct.SelectedItems.Cast<RecipeProduct>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {reprpodRemove.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SweetshopEntities1.GetContext().RecipeProducts.RemoveRange(reprpodRemove);
                    SweetshopEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGRecipeProduct.ItemsSource = SweetshopEntities1.GetContext().RecipeProducts.ToList();
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
                DGRecipeProduct.ItemsSource = SweetshopEntities1.GetContext().RecipeProducts.ToList();
            }
        }
    }
}
