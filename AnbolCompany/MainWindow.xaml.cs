﻿using System;
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
            frame.Navigate(new Authorization());
            Autorization.IsChecked = true;
            new VisibleRadiuButton();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e) => ThemeChange.Change();

        private void Autorization_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Authorization());
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Registration());
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}