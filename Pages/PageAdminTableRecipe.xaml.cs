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
    /// Логика взаимодействия для PageAdminTableRecipe.xaml
    /// </summary>
    public partial class PageAdminTableRecipe : Page
    {
        public PageAdminTableRecipe()
        {
            InitializeComponent();
            DGRecipe.ItemsSource = SweetshopEntities1.GetContext().Recipes.ToList();
        }

        private void Button_editClick(object sender, RoutedEventArgs e)
        {
            PageMove.BWFrame.Navigate(new PageAddRecipe((sender as Button).DataContext as Recipe));
        }

        private void Button_addClick(object sender, RoutedEventArgs e)
        {
            PageMove.BWFrame.Navigate(new PageAddRecipe(null));
        }

        private void Button_deleteClick(object sender, RoutedEventArgs e)
        {
            var recipeRemove = DGRecipe.SelectedItems.Cast<Recipe>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {recipeRemove.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SweetshopEntities1.GetContext().Recipes.RemoveRange(recipeRemove);
                    SweetshopEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGRecipe.ItemsSource = SweetshopEntities1.GetContext().Recipes.ToList();
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
                DGRecipe.ItemsSource = SweetshopEntities1.GetContext().Recipes.ToList();
            }
        }

        private void TBoxFind_Change(object sender, TextChangedEventArgs e)
        {
            DGRecipe.ItemsSource = SweetshopEntities1.GetContext().Recipes.ToList().Where(p => p.Name.ToLower().Contains(tBoxFind.Text.ToLower())||p.ProductType.Name.ToLower().Contains(tBoxFind.Text.ToLower())|| p.Author.ToLower().Contains(tBoxFind.Text.ToLower())).ToList();
        }

        private void Button_goPrint(object sender, RoutedEventArgs e)
        {
            PageMove.BWFrame.Navigate(new PagePrint());
        }
    }
}
