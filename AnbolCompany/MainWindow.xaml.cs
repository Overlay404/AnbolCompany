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

namespace AnbolCompany
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static MainWindow Instance { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            frame.Navigate(new AuthRegist.Authorization());
            Autorization.IsChecked = true;
            new VisibleRadiuButton();

            var isAuth = AuthRegist.Authorization.isAuth;
            AuthRegist.Authorization.checkAuthorizationUser(isAuth);

            editImage.Visibility = Visibility.Collapsed;
            plusImage.Visibility = Visibility.Collapsed;
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e) => ThemeChange.Change();

        private void Autorization_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new AuthRegist.Authorization());
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new AuthRegist.Registration());
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Products());
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new OrderPage());
        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new UserInfo());
        }

        private void exitImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (AuthRegist.Authorization.isAuth)
            {
                if (MessageBox.Show("Вы хотите выйти из аккаунта ?", "Выйти", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    AuthRegist.Authorization.isAuth = false;
                    AuthRegist.Authorization.checkAuthorizationUser(AuthRegist.Authorization.isAuth);
                }
            }
            else
            {
                if(MessageBox.Show("Вы хотите выйти из приложения ?", "Выйти", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    this.Close();
            }
        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {
            if (frame.Content.ToString().Equals("AnbolCompany.UserInfo"))
            {
                editImage.Visibility = Visibility.Visible;
                plusImage.Visibility = Visibility.Collapsed;
            }
            else if (frame.Content.ToString().Equals("AnbolCompany.Products"))
            {
                editImage.Visibility = Visibility.Visible;
                plusImage.Visibility = Visibility.Visible;
            }
            else if (frame.Content.ToString().Equals("AnbolCompany.OrderPage"))
            {
                editImage.Visibility = Visibility.Visible;
                plusImage.Visibility = Visibility.Visible;
            }
            else
            {
                editImage.Visibility = Visibility.Collapsed;
                plusImage.Visibility = Visibility.Collapsed;
            }
        }
    }
}
