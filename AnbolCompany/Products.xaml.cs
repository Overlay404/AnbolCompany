using AnbolCompany.Resourses;
using System;
using System.Collections.Generic;
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
        public Products()
        {
            InitializeComponent();

            quantity.SelectedIndex = 0;
            filtration.SelectedIndex = 0;
            sorting.SelectedIndex = 0;

            listProducts.ItemsSource = App.db.Products.ToList();
            foreach (var entity in listProducts.Items)
            {
                if ((entity as Product).count < 0)
                {
                    (entity as ListViewItem).Background = new SolidColorBrush(Colors.Blue);
                }
            }
        }

        private void listProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("" + (listProducts.SelectedItem as Product).nameProduct);
        }
    }
}
