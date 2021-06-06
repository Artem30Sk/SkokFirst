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
using Sweetshop.Pages;
using System.IO;
using System.Threading;

namespace Sweetshop.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuthorization.xaml
    /// </summary>
    public partial class PageAuthorization : Page
    {
        public PageAuthorization()
        {
            InitializeComponent();
            ImgShowHide.Source = new BitmapImage(new Uri("/Resources/openeye.png", UriKind.Relative));
        }
        private void ImgShowHide_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            HidePassword();
        }

        private void ImgShowHide_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPassword();
        }
        private void ImgShowHide_MouseLeave(object sender, MouseEventArgs e)
        {
            HidePassword();
        }
        private void txtPasswordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PassBox.Password.Length > 0)
                ImgShowHide.Visibility = Visibility.Visible;
            else
                ImgShowHide.Visibility = Visibility.Hidden;
        }

        void ShowPassword()
        {
            ImgShowHide.Source = new BitmapImage(new Uri("/Resources/closeeye.png", UriKind.Relative));
            PassBoxSec.Visibility = Visibility.Visible;
            PassBox.Visibility = Visibility.Hidden;
            PassBoxSec.Text = PassBox.Password;
        }
        void HidePassword()
        {
            ImgShowHide.Source = new BitmapImage(new Uri("/Resources/openeye.png", UriKind.Relative));
            PassBoxSec.Visibility = Visibility.Hidden;
            PassBox.Visibility = Visibility.Visible;
            PassBox.Focus();
        }
        
        private void ButtonRetry_Click(object sender, RoutedEventArgs e)
        {
            butRetry.Visibility = Visibility.Collapsed;
            CheckConnection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   using (SweetshopEntities1 db = new SweetshopEntities1())
            {
                bool authorize = false;
                try
                {
                    foreach (var user in SweetshopEntities1.GetContext().Admins)
                        if (LoginBox.Text == user.Email && PassBox.Password == user.Password && user.Type == 2)
                        {
                            authorize = true;
                            DateTime dt = DateTime.Now;
                            JoinHistory history = new JoinHistory();
                            history.Email = LoginBox.Text;
                            history.Password = PassBox.Password;
                            history.Time = dt;
                            db.JoinHistories.Add(history);
                            db.SaveChanges();
                            MessageBox.Show("Вы вошли как администратор", "Добро пожаловать", MessageBoxButton.OK, MessageBoxImage.Information);
                            PageMove.BWFrame.Navigate(new PageAdmin());


                        }
                    foreach (var user in SweetshopEntities1.GetContext().SysAdmins)
                        if (LoginBox.Text == user.Email && PassBox.Password == user.Password && user.Type == 1)
                        {
                            authorize = true;
                            DateTime dt = DateTime.Now;
                            JoinHistory history = new JoinHistory();
                            history.Email = LoginBox.Text;
                            history.Password = PassBox.Password;
                            history.Time = dt;
                            db.JoinHistories.Add(history);
                            db.SaveChanges();

                            MessageBox.Show("Вы вошли как сис-админ", "Добро пожаловать", MessageBoxButton.OK, MessageBoxImage.Information);
                            PageMove.BWFrame.Navigate(new PageSysAdmin());

                        }
                    if (authorize == false)
                    {
                        DateTime dt = DateTime.Now;
                        JoinHistory history = new JoinHistory();
                        history.Email = LoginBox.Text;
                        history.Password = PassBox.Password;
                        history.Time = dt;
                        db.JoinHistories.Add(history);
                        db.SaveChanges();

                        MessageBox.Show("Неправильно введен логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    CheckConnection();
                }
            }
        }
        private async void CheckConnection()
        {
            butEnter.IsEnabled = false;
            PassBox.IsEnabled = false;
            PassBoxSec.IsEnabled = false;
            LoginBox.IsEnabled = false;
            try
            {
                SweetshopEntities1 db = new SweetshopEntities1();
                Task t = Task.Run(() => db.Database.Connection.Open());
                await t;
            }
            catch
            {
                MessageBox.Show("Отсутствует связь с базой данных. Проверьте подключение и повторите попытку", "Подключение", MessageBoxButton.OK, MessageBoxImage.Error);
                butRetry.Visibility = Visibility.Visible;
                return;
            }
            await Dispatcher.BeginInvoke(new ThreadStart(delegate
            {
                butEnter.IsEnabled = true;
                PassBox.IsEnabled = true;
                PassBoxSec.IsEnabled = true;
                LoginBox.IsEnabled = true;
            }));

        }

    }
}
