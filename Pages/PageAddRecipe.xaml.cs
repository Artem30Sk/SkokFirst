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
    /// Логика взаимодействия для PageAddRecipe.xaml
    /// </summary>
    public partial class PageAddRecipe : Page
    {
        private Recipe repRole = new Recipe();
        public PageAddRecipe(Recipe selectedRep)
        {
            if (selectedRep != null)
            {
                repRole = selectedRep;
            }
            InitializeComponent();
            
            DataContext = repRole;
            ComboType.ItemsSource = SweetshopEntities1.GetContext().ProductTypes.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(repRole.Name))
                errors.AppendLine("Укажите название правильно");
            if (string.IsNullOrWhiteSpace(repRole.Author))
                errors.AppendLine("Укажите имя автора правильно");
            if (repRole.ProductType==null)
                errors.AppendLine("Укажите тип продукта правильно");
            if (repRole.DataCreate == null)
                errors.AppendLine("Укажите дату создания правильно");
            if (repRole.Price <=0 || repRole.Price>1000)
                errors.AppendLine("Укажите цену правильно");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (repRole.Id == 0)
            {
                SweetshopEntities1.GetContext().Recipes.Add(repRole);
                
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
