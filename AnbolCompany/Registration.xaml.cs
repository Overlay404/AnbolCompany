using AnbolCompany.Resourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

namespace AnbolCompany
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        DispatcherTimer timer;
        public static Registration Instance { get; set; }
        public Registration()
        {
            InitializeComponent();

            Instance = this;
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Timer_Elapsed);
            timer.Interval = new TimeSpan(0, 0, 3);

            gender.ItemsSource = App.db.Genders.Select(g => g.name).ToList();
            gender.SelectedIndex = 0;

            role.ItemsSource = App.db.RoleIds.Select(roleId => roleId.name).ToList();
            role.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string pass = password.Password.Trim();
            timer.Start();

            startButtonUser();
            if (name.Text.Trim().Length <= 0) { errorUserInput(name); infoText.Text = textForInfoTextBox("имя"); return; }
            if (lastname.Text.Trim().Length <= 0) { errorUserInput(lastname); infoText.Text = textForInfoTextBox("фамилия"); return; }
            if (firstname.Text.Trim().Length <= 0) { errorUserInput(firstname); infoText.Text = textForInfoTextBox("отчество"); return; }
            if (email.Text.Trim().Length <= 0 || !new Regex(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$").IsMatch(email.Text.Trim())) { errorUserInput(email); infoText.Text = textForInfoTextBox("почта") + " или не соответствует формату почты"; return; }
            if (phone.Text.Trim().Length <= 10 || !phone.Text.Trim().All(p => char.IsDigit(p))) { errorUserInput(phone); infoText.Text = textForInfoTextBox("телефон") + " или не соотвутсвует формату записи номера. Пример: 10000000000"; return; }
            if (login.Text.Trim().Length <= 0 || App.db.Users.Select(u => u.login).Contains(login.Text)) { errorUserInput(login); infoText.Text = textForInfoTextBox("логин") + " или такой логин уже используется"; return; }
            if (password.Password.Trim().Length < 6 || !new Regex(@"[!@#$%^]").IsMatch(password.Password.Trim()) || !password.Password.Trim().Any(p => char.IsDigit(p)) || password.Password.Trim().Equals(password.Password.Trim().ToLower())) { password.BorderBrush = new SolidColorBrush(Colors.Red); infoText.Text = textForInfoTextBox("пароль") + " или нет прописной буквы, цифры или же знака: ! @ # $ % ^ "; return; }

            App.db.Users.Add(new User
            {
                name = name.Text.Trim(),
                lastname = lastname.Text.Trim(),
                firstname = firstname.Text.Trim(),
                email = email.Text.Trim(),
                phone = phone.Text.Trim(),
                login = login.Text.Trim(),
                password = password.Password.Trim(),
                GenderId = App.db.Genders.Where(g => g.name.Equals(gender.SelectedItem.ToString())).Select(g => g.id).FirstOrDefault(),
                RoleId = App.db.RoleIds.Where(r => r.name.Equals(role.SelectedItem.ToString())).Select(r => r.id).FirstOrDefault()
            });
            App.db.SaveChanges();

            MainWindow.Instance.frame.Navigate(new Authorization());
            MainWindow.Instance.Autorization.IsChecked = true;
            Authorization.Instance.login.Text = Instance.login.Text;
            Authorization.Instance.password.Password = pass;
        }

        private void Timer_Elapsed(object sender, EventArgs e) { Instance.infoText.Text = ""; timer.Stop(); }

        void clearInfoTextBlock() { }


        void errorUserInput(TextBox sender)
        {
            sender.BorderBrush = new SolidColorBrush(Colors.Red);
        }

        string textForInfoTextBox(string nameField) { return "Не заполнено поле \"" + nameField + "\""; }

        void startButtonUser()
        {
            password.BorderBrush = new SolidColorBrush(Color.FromRgb(171, 173, 179));
            login.BorderBrush = new SolidColorBrush(Color.FromRgb(171, 173, 179));
            name.BorderBrush = new SolidColorBrush(Color.FromRgb(171, 173, 179));
            lastname.BorderBrush = new SolidColorBrush(Color.FromRgb(171, 173, 179));
            firstname.BorderBrush = new SolidColorBrush(Color.FromRgb(171, 173, 179));
            email.BorderBrush = new SolidColorBrush(Color.FromRgb(171, 173, 179));
            phone.BorderBrush = new SolidColorBrush(Color.FromRgb(171, 173, 179));
        }
    }
}
