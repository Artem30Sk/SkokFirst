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
using System.Threading;
using System.IO;
using Sweetshop.Pages;
using System.Windows.Threading;

namespace Sweetshop.Pages
{
    /// <summary>
    /// Логика взаимодействия для BaseWindow.xaml
    /// </summary>
    public partial class BaseWindow : Window
    {
        
        public BaseWindow()
        {

            InitializeComponent();
            BWFrame.Navigate(new PageAuthorization());
            PageMove.BWFrame = BWFrame;
            Object curPage = BWFrame.CurrentSource;
            btnMenu.Visibility = Visibility.Hidden;
            

        }
        
        private void BWFrame_ContentRendered(object sender, EventArgs e)
        {
           
            if (BWFrame.Content.GetType().Name == "PageAuthorization")
            {
                Application.Current.MainWindow.ResizeMode = System.Windows.ResizeMode.NoResize;
                btnMenu.Visibility = Visibility.Collapsed;
                Title.Text = "Авторизация";
            }
            else
            {
                Application.Current.MainWindow.ResizeMode = System.Windows.ResizeMode.CanResize;
                btnMenu.Visibility = Visibility.Visible;
                
            }
            if(BWFrame.CanGoBack && BWFrame.Content.GetType().Name != "PageAuthorization")
            {
                btnBack.Visibility = Visibility.Visible;
                
            }
            else
            {
                btnBack.Visibility = Visibility.Collapsed;
                
            }
            if (BWFrame.Content.GetType().Name == "PageAdmin")
            {
                Title.Text = "Администратор";
            }
            else if(BWFrame.Content.GetType().Name == "PageSysAdmin")
            {
                Title.Text = "Системный администратор";
            }
        }

        private void Btn_BackClick(object sender, RoutedEventArgs e)
        {
            PageMove.BWFrame.GoBack();
        }

        private void Btn_MenuClick(object sender, RoutedEventArgs e)
        {
            PageMove.BWFrame.Navigate(new PageAuthorization());
            btnMenu.Visibility = Visibility.Hidden;
        }
    }
    
}
