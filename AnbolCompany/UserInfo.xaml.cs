using AnbolCompany.Resourses;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.IO;

namespace AnbolCompany
{
    /// <summary>
    /// Логика взаимодействия для UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Page
    {
        DispatcherTimer timer;
        public static UserInfo Instance { get; private set; }
        public bool IsEditImagePress;
        public UserInfo()
        {
            InitializeComponent();

            IsEditImagePress = false;

            Instance = this;

            name.Text = App.user.name;
            lastname.Text = App.user.lastname;
            firstname.Text = App.user.firstname;
            email.Text = App.user.email;
            phone.Text = App.user.phone;
            gender.ItemsSource = App.db.Genders.Select(g => g.name).ToList();
            gender.SelectedIndex =  App.db.Genders.Where(g => g.id == App.user.GenderId).Select(g => g.id).FirstOrDefault() - 1;
            MainWindow.Instance.editImage.MouseUp += EditImage_MouseUp;
            
            if(App.user.photoPath != null)
            {
                image.Source = BitmapFrame.Create(new MemoryStream(App.user.photoPath), BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Timer_Elapsed);
            timer.Interval = new TimeSpan(0, 0, 5);
        }

        private void EditImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsEditImagePress = true;

            name.IsEnabled = true;
            lastname.IsEnabled = true;
            firstname.IsEnabled = true;
            email.IsEnabled = true;
            phone.IsEnabled = true;
            gender.IsEnabled = true;
            login.IsEnabled = true;
            password.IsEnabled = true;
            confirm.Visibility = Visibility.Visible;
            login.Visibility = Visibility.Visible;
            password.Visibility = Visibility.Visible;
            loginText.Visibility = Visibility.Collapsed;
            passwordText.Visibility = Visibility.Collapsed;
            login.Text = App.user.login;
            password.Text = App.user.password;
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
            {
                if (lastname.Text.Length <= 0) infoMessage.Text = "Поле фамилия имеет неверный формат";
                else if (name.Text.Length <= 0) infoMessage.Text = "Поле имя имеет неверный формат";
                else if (firstname.Text.Length <= 0) infoMessage.Text = "Поле отчество имеет неверный формат";
                else if (email.Text.Trim().Length <= 0 || !new Regex(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$").IsMatch(email.Text.Trim())) infoMessage.Text = "Поле почта имеет неверный формат";
                else if (phone.Text.Trim().Length <= 10 || !phone.Text.Trim().All(p => char.IsDigit(p))) infoMessage.Text = "Поле телефон имеет неверный формат";
                else if (login.Text.Trim().Length <= 0 || App.db.Users.Where(u => u.login != login.Text).Select(u => u.login).Contains(login.Text)) infoMessage.Text = "Поле логин имеет неверный формат";
                else if (password.Text.Trim().Length < 6 || !new Regex(@"[!@#$%^]").IsMatch(password.Text.Trim()) || !password.Text.Trim().Any(p => char.IsDigit(p)) || password.Text.Trim().Equals(password.Text.Trim().ToLower())) infoMessage.Text = "Поле пароль имеет неверный формат";
                else
                {
                    App.user.name = name.Text.Trim();
                    App.user.lastname = lastname.Text.Trim();
                    App.user.firstname = firstname.Text.Trim();
                    App.user.email = email.Text.Trim();
                    App.user.phone = phone.Text.Trim();
                    App.user.login = login.Text.Trim();
                    App.user.GenderId = App.db.Genders.Where(g => g.name.Equals(gender.SelectedItem.ToString())).Select(g => g.id).FirstOrDefault();
                   
                    App.db.SaveChanges();
                }
                timer.Start();
            }
            name.IsEnabled = false;
            lastname.IsEnabled = false;
            firstname.IsEnabled = false;
            email.IsEnabled = false;
            phone.IsEnabled = false;
            gender.IsEnabled = false;
            login.IsEnabled = false;
            password.IsEnabled = false;
            confirm.Visibility = Visibility.Collapsed;
            login.Visibility = Visibility.Hidden;
            password.Visibility = Visibility.Hidden;
            loginText.Visibility = Visibility.Visible;
            passwordText.Visibility = Visibility.Visible;

            IsEditImagePress = false; 
        }
        private void Timer_Elapsed(object sender, EventArgs e) { Instance.infoMessage.Text = ""; timer.Stop(); }

        private void image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (IsEditImagePress)
            {
                OpenFileDialog openFile = new OpenFileDialog()
                {
                    Filter = "All Files (*.*)|*.*",

                };
                if (openFile.ShowDialog().GetValueOrDefault())
                {
                    App.user.photoPath = File.ReadAllBytes(openFile.FileName);
                    App.db.SaveChanges();
                }
            }

            if (App.user.photoPath != null)
            {
                image.Source = BitmapFrame.Create(new MemoryStream(App.user.photoPath), BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }
    }
}
