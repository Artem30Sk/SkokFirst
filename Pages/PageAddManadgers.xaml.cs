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
    /// Логика взаимодействия для PageAddManadgers.xaml
    /// </summary>
    public partial class PageAddManadgers : Page
    {
        private Manadger mandgRole = new Manadger();
        public PageAddManadgers(Manadger selectedMandg)
        {
            
            if (selectedMandg != null)
            {
                mandgRole = selectedMandg;
            }
            InitializeComponent();
            DataContext = mandgRole;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(mandgRole.Name))
                errors.AppendLine("Укажите имя правильно");
            if (string.IsNullOrWhiteSpace(mandgRole.Email))
                errors.AppendLine("Укажите логин правильно");
            if (string.IsNullOrWhiteSpace(mandgRole.Password))
                errors.AppendLine("Укажите пароль правильно");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (mandgRole.Id == 0)
            {
                SweetshopEntities1.GetContext().Manadgers.Add(mandgRole);
                mandgRole.Type = 3;
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
