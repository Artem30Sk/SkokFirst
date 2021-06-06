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
    /// Логика взаимодействия для PageAdd.xaml
    /// </summary>
    public partial class PageAdd : Page
    {
        private Admin admRole = new Admin();
        public PageAdd(Admin selectedAdmin)
        {
            if (selectedAdmin != null)
            {
                admRole = selectedAdmin;
            }
            InitializeComponent();
            DataContext = admRole;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(admRole.Name))
                errors.AppendLine("Укажите имя правильно");
            if (string.IsNullOrWhiteSpace(admRole.Email))
                errors.AppendLine("Укажите логин правильно");
            if (string.IsNullOrWhiteSpace(admRole.Password))
                errors.AppendLine("Укажите пароль правильно");
            if(errors.Length>0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (admRole.Id == 0)
            {
                SweetshopEntities1.GetContext().Admins.Add(admRole);
                admRole.Type = 2;
            }
            try
            {
                SweetshopEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                PageMove.BWFrame.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /*private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }*/
    }
}
