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
    /// Логика взаимодействия для PageAddRecipeProduct.xaml
    /// </summary>
    public partial class PageAddRecipeProduct : Page
    {
        private RecipeProduct repProd = new RecipeProduct();
        public PageAddRecipeProduct()
        {
            InitializeComponent();
            DataContext = repProd;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            StringBuilder errors = new StringBuilder();
            
            if (repProd.IdProducts == null || repProd.IdRecipes== null)
                errors.AppendLine("Укажите id продукта или товара правильно");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (repProd.Id == 0)
            {
                SweetshopEntities1.GetContext().RecipeProducts.Add(repProd);

            }
            try
            {
                SweetshopEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                PageMove.BWFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
