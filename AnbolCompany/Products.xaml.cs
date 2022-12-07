using AnbolCompany.Resourses;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace AnbolCompany
{
    /// <summary>
    /// Логика взаимодействия для Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        CollectionView products { get; set; }
        public static int currentPage = 1;
        public static Products Instance { get; set; }
        public Products()
        {
            InitializeComponent();

            Instance = this;

            quantity.SelectedIndex = 0;
            filtration.SelectedIndex = 0;
            sorting.SelectedIndex = 0;

            Update();
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
                MainWindow.Instance.frame.Navigate(new EditProduct(null));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            currentPage--;
            Update();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            currentPage++;
            Update();
        }

        private void quantity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        void Update()
        {
            switch ((quantity.SelectedItem as ComboBoxItem).Tag)
            {
                case "1":
                    listProducts.ItemsSource = .Skip(2 * currentPage).Take(2);
                    break;
                case "2":
                    listProducts.ItemsSource = App.db.Products.ToList().Skip(5 * currentPage).Take(5);
                    break;
                case "3":
                    listProducts.ItemsSource = App.db.Products.ToList().Skip(10 * currentPage).Take(10);
                    break;
                default:
                    listProducts.ItemsSource = App.db.Products.ToList();
                    break;
            }

            products = (CollectionView)CollectionViewSource.GetDefaultView(listProducts.ItemsSource);
            products.SortDescriptions.Add(new SortDescription("nameProduct", ListSortDirection.Ascending));

            thisPage.Text = currentPage.ToString();
        }
    }
}
