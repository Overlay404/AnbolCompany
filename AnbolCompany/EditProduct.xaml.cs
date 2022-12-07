using AnbolCompany.Resourses;
using Microsoft.Win32;
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
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Page
    {
        public EditProduct(Product product)
        {
            InitializeComponent();

            meaning.ItemsSource = App.db.Units.Select(u => u.meaning).ToList();

            if (Products.Instance.listProducts.SelectedItem != null)
            {
                nameProduct.Text = product.nameProduct;
                description.Text = product.description;
                count.Text = product.count.ToString();
                cost.Text = product.cost.ToString();
                date.Text = product.date.ToString();
                meaning.SelectedIndex = product.UnitId - 1;
            }
        }


        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "All Files (*.*)|*.*",
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                App.product.photoPath = File.ReadAllBytes(openFile.FileName);
            }
            image.Source = BitmapFrame.Create(new MemoryStream(App.product.photoPath), BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Products.Instance.listProducts.SelectedItem != null) {
                App.product.nameProduct = nameProduct.Text;
                App.product.description = description.Text;
                App.product.count = int.Parse(cost.Text);
                App.product.cost = int.Parse(cost.Text);
                App.product.date = DateTime.Parse(date.Text);
                App.product.UnitId = meaning.SelectedIndex + 1;
            }
            else
            {
                App.db.Products.Add(new Product
                    {
                    nameProduct = nameProduct.Text,
                    description = description.Text,
                    cost = int.Parse(cost.Text),
                    date = DateTime.Parse(date.Text),
                    count = int.Parse(cost.Text),
                    UnitId = meaning.SelectedIndex + 1
                });
            }
            App.db.SaveChanges();
        }
    }
}
