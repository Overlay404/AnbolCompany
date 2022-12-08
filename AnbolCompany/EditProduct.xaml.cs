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
        List<Country> listCountry = new List<Country>();
        public static EditProduct Instance { get; set; }
        byte[] photoPath = null;
        Product product1;
        public EditProduct(Product product)
        {
            InitializeComponent();

            Instance = this;

            product1 = product;

            meaning.ItemsSource = App.db.Units.Select(u => u.meaning).ToList();

            if (product != null)
            {
                nameProduct.Text = product.nameProduct;
                description.Text = product.description;
                count.Text = product.count.ToString();
                cost.Text = product.cost.ToString();
                date.Text = product.date.ToString();
                meaning.SelectedIndex = product.UnitId - 1;
                if (product.photoPath != null)
                    image.Source = BitmapFrame.Create( new MemoryStream(product.photoPath), BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                country.ItemsSource = App.db.Countries.ToList();
                foreach (var item in product.Countries)
                {
                    country.SelectedItems.Add(item);
                }
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
                image.Source = BitmapFrame.Create(new MemoryStream(File.ReadAllBytes(openFile.FileName)), BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                photoPath = File.ReadAllBytes(openFile.FileName);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (nameProduct.Text.Length > 0 && description.Text.Length > 0 && cost.Text.All(c => char.IsDigit(c)) && cost.Text.Length > 0 && count.Text.All(c => char.IsDigit(c)) && count.Text.Length > 0 && date.Text.Length > 0 && meaning.SelectedItem != null)
            {
                foreach(var item in country.SelectedItems)
                    listCountry.Add(new Country { nameCountry = (item as Country).nameCountry.ToString()});

                if (EditProduct.Instance.product1 != null)
                {
                    App.product.nameProduct = nameProduct.Text;
                    App.product.description = description.Text;
                    App.product.count = int.Parse(cost.Text);
                    App.product.cost = int.Parse(cost.Text);
                    App.product.date = DateTime.Parse(date.Text);
                    App.product.UnitId = meaning.SelectedIndex + 1;
                    if (photoPath != null)
                        App.product.photoPath = photoPath;
                    App.product.Countries = listCountry;
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
                        UnitId = meaning.SelectedIndex + 1,
                        photoPath = photoPath,
                        Countries = listCountry
                    });
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены или не соответствуют формату ввода");
                return;
            }
            App.db.SaveChanges();
            MainWindow.Instance.frame.Navigate(new Products());
        }
    }
}
