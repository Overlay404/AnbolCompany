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
    /// Логика взаимодействия для UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Page
    {
        public UserInfo()
        {
            InitializeComponent();

            name.Text = App.user.name + " " + App.user.lastname + " " + App.user.firstname;
            email.Text += App.user.email;
            phone.Text += App.user.phone;
            gender.Text += App.db.Genders.Where(g => g.id == App.user.GenderId).Select(g => g.name).FirstOrDefault();
            MainWindow.Instance.editImage.MouseUp += EditImage_MouseUp;
        }

        private void EditImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            name.IsEnabled = true;
            email.IsEnabled = true;
            phone.IsEnabled = true;
            gender.IsEnabled = true;
            login.IsEnabled = true;
            password.IsEnabled = true;
            confirm.Visibility = Visibility.Visible;
        }

        private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            login.Text = App.user.login;
            loginText.Visibility = Visibility.Collapsed;
            login.Visibility = Visibility.Visible;
        }

        private void passwordText_MouseUp(object sender, MouseButtonEventArgs e)
        {
            password.Text = App.user.password;
            passwordText.Visibility = Visibility.Collapsed;
            password.Visibility = Visibility.Visible;
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите сохранить изменения?", "as", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                MessageBox.Show("good");
        }
    }
}
