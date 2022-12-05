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

            listProducts.ItemsSource = (from products in App.db.Products
                                       select new
                                       {
                                           unit = App.db.Units.Where(u => u.meaning.Equals(products.Unit)).FirstOrDefault().meaning.ToString(),
                                           date = products.date.ToString(),
                                           description = products.description.ToString(),
                                           cost = products.cost.ToString(),
                                           count = products.count.ToString(),
                                           country = App.db.Countries.Where(c => c.nameCountry.Equals(products.CountryId)).FirstOrDefault().nameCountry.ToString()
                                       }).ToList();
        }
    }
}
