using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace AnbolCompany.AuthRegist
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public static Authorization Instance { get; private set; }
        public static bool isAuth = false;
        public Authorization()
        {
            InitializeComponent();
            Instance = this;

            login.Text = Properties.Settings.Default.login;
            password.Password = Properties.Settings.Default.password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text.Trim().Length <= 0 || password.Password.Trim().Length <= 0) { clearValue(); MessageBox.Show("Введите логин и пароль"); return; }

            if (App.db.Users.Where(u => u.login.Equals(login.Text.Trim()) && u.password.Equals(password.Password.Trim())).Select(u => u).FirstOrDefault() != null)
                App.user = App.db.Users.Where(u => u.login.Equals(login.Text.Trim()) && u.password.Equals(password.Password.Trim())).Select(u => u).FirstOrDefault();
            else
                MessageBox.Show("Пользователь не найден");

            new VisibleRadiuButton();

            if (saveDataCheckBox.IsChecked == false)
            {
                Properties.Settings.Default.login = login.Text.Trim();
                Properties.Settings.Default.password = password.Password.Trim();
            }
            else
            {
                Properties.Settings.Default.login = null;
                Properties.Settings.Default.password = null;
            }
            Properties.Settings.Default.Save();
            if (App.user != null)
                isAuth = true;
            checkAuthorizationUser(isAuth);
        }

        public static void checkAuthorizationUser(bool isAuth)
        {
            if (isAuth)
            {
                MainWindow.Instance.Autorization.Visibility = Visibility.Collapsed;
                MainWindow.Instance.Registration.Visibility = Visibility.Collapsed;
                MainWindow.Instance.frame.Navigate(new UserInfo());
                MainWindow.Instance.Info.IsChecked = true;
            }
            else
            {
                App.user = null;
                MainWindow.Instance.Autorization.Visibility = Visibility.Visible;
                MainWindow.Instance.Registration.Visibility = Visibility.Visible;
                MainWindow.Instance.frame.Navigate(new Authorization());
                MainWindow.Instance.Autorization.IsChecked = true;
                new VisibleRadiuButton();
            }
        }
        void clearValue()
        {
            login.Text = "";
            password.Password = "";
        }
    }
}
