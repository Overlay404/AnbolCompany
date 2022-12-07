using AnbolCompany.Resourses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Логика взаимодействия для Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        static int thisPage1 = 1;
        CollectionView products { get; set; }
        
        public static Products Instance { get; set; }
        public Products()
        {
            InitializeComponent();

            Instance = this;

            products = (CollectionView)CollectionViewSource.GetDefaultView(listProducts.ItemsSource);
            quantity.SelectedIndex = 0;
            filtration.SelectedIndex = 0;
            sorting.SelectedIndex = 0;

            listProducts.ItemsSource = App.db.Products.ToList();

            MainWindow.Instance.plusImage.MouseUp += PlusImage_MouseUp;
            MainWindow.Instance.editImage.MouseUp += EditImage_MouseUp;
        }

        private void EditImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.Instance.frame.Content.ToString().Equals("AnbolCompany.Products"))
            {
                if (listProducts.SelectedItem != null)
                {
                    MainWindow.Instance.frame.Navigate(new EditProduct(listProducts.SelectedItem as Product));
                    App.product = (listProducts.SelectedItem as Product);
                }
                else
                    MessageBox.Show("Нет выбраного элемента");
            }
        }

        private void PlusImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.Instance.frame.Content.ToString().Equals("AnbolCompany.Products"))
            {
                MainWindow.Instance.frame.Navigate(new EditProduct(listProducts.SelectedItem as Product));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void quantity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        void Update()
        {
            
        }
    }
}
