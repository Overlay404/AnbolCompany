using AnbolCompany.Resourses;
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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        public AddProduct()
        {
            InitializeComponent();

            productList.ItemsSource = App.db.Products.ToList();   
        }

        private void productList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nameProduct.Text = ((sender as ListView).SelectedItem as Product).nameProduct;
            count.Text = "0";
            App.product = (sender as ListView).SelectedItem as Product;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            App.product.count += Convert.ToInt32(count.Text);
            App.db.SaveChanges();
            productOrderList.Items.Add(App.product);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Продукты добавлены");
        }
    }
}
