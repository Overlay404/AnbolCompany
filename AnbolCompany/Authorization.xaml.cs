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

namespace AnbolCompany
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public static Authorization Instance { get; private set; }  
        public Authorization()
        {
            InitializeComponent();
            Instance = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text.Trim().Length <= 0 || password.Password.Trim().Length <= 0)
            {
                clearValue();
                MessageBox.Show("Введите логин и пароль");
                return;
            }

            if (App.db.Users.Where(u => u.login.Equals(login.Text.Trim()) && u.password.Equals(password.Password.Trim())).Select(u => u).FirstOrDefault() != null)
            {
                App.user = App.db.Users.Where(u => u.login.Equals(login.Text.Trim()) && u.password.Equals(password.Password.Trim())).Select(u => u).FirstOrDefault();
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
            new VisibleRadiuButton();
        }
        void clearValue()
        {
            login.Text = "";
            password.Password = "";
        }
    }
}
