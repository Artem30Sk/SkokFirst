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
    /// Логика взаимодействия для PageAddProduct.xaml
    /// </summary>
    public partial class PageAddProduct : Page
    {
        private Product prod = new Product();
        public PageAddProduct(Product selectedProd)
        {
            if (selectedProd != null)
            {
                prod = selectedProd;
            }
            InitializeComponent();
            DataContext = prod;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(prod.ProductName))
                errors.AppendLine("Укажите название правильно");
            if (prod.Counts <= 0 || prod.Counts > 10000) 
                errors.AppendLine("Укажите количество правильно");
            if (prod.DeliveryDate == null)
                errors.AppendLine("Укажите дату правильно");
            if (string.IsNullOrWhiteSpace(prod.Manafacturer))
                errors.AppendLine("Укажите производителя правильно");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (prod.Id == 0)
            {
                SweetshopEntities1.GetContext().Products.Add(prod);
                
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
