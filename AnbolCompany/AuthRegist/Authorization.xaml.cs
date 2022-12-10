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
using System.Windows.Threading;

namespace AnbolCompany.AuthRegist
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public static Authorization Instance { get; private set; }
        public static bool isAuth = false;
        public static int countAttempt = 0;
        DispatcherTimer timer;
        public Authorization()
        {
            InitializeComponent();
            Instance = this;

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Timer_Elapsed);
            timer.Interval = new TimeSpan(0, 0, 10);

            login.Text = Properties.Settings.Default.login;
            password.Password = Properties.Settings.Default.password;
        }

        private void Timer_Elapsed(object sender, EventArgs e) { AuthButton.IsEnabled = true; timer.Stop(); }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text.Trim().Length <= 0 || password.Password.Trim().Length <= 0) { clearValue(); MessageBox.Show("Введите логин и пароль"); return; }

            if (App.db.Users.Where(u => u.login.Equals(login.Text.Trim()) && u.password.Equals(password.Password.Trim())).Select(u => u).FirstOrDefault() != null)
            {
                App.user = App.db.Users.Where(u => u.login.Equals(login.Text.Trim()) && u.password.Equals(password.Password.Trim())).Select(u => u).FirstOrDefault();
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
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
                countAttempt++;
            }

            CountCheck();

            new VisibleRadiuButton();


            if (App.user != null)
                isAuth = true;
            checkAuthorizationUser(isAuth);
            if (App.user.RoleId == 2)
            {
                MainWindow.isRoleIdAdmin = true;
            }
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

        private void AuthButton_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void CountCheck()
        {
            if (countAttempt == 3)
            {
                MessageBox.Show("adsdas");
                AuthButton.IsEnabled = false;
                AuthButton.Visibility = Visibility.Hidden;
                countAttempt = 0;
                timer.Start();
                MessageBox.Show("Вы слишком много раз пытались войти в аккаунт, повторите попытку через минуту");
            }
        }
    }
}
