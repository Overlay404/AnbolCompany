using AnbolCompany.Resourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnbolCompany
{
    internal class VisibleRadiuButton
    {
        public VisibleRadiuButton()
        {
            MainWindow.Instance.InitializeComponent();

            if (App.user == null)
            {
                MainWindow.Instance.Product.Visibility = System.Windows.Visibility.Collapsed;
                MainWindow.Instance.Order.Visibility = System.Windows.Visibility.Collapsed;
                MainWindow.Instance.Info.Visibility = System.Windows.Visibility.Collapsed;
                MainWindow.Instance.AddProduct.Visibility = System.Windows.Visibility.Collapsed;
            }
            else if(App.user.RoleId == 1)
            {
                MainWindow.Instance.Product.Visibility = System.Windows.Visibility.Visible;
                MainWindow.Instance.Order.Visibility = System.Windows.Visibility.Visible;
                MainWindow.Instance.Info.Visibility = System.Windows.Visibility.Visible;
            }
            else if (App.user.RoleId == 2)
            {
                MainWindow.Instance.Product.Visibility = System.Windows.Visibility.Visible;
                MainWindow.Instance.Order.Visibility = System.Windows.Visibility.Collapsed;
                MainWindow.Instance.Info.Visibility = System.Windows.Visibility.Visible;
            }
            else if (App.user.RoleId == 3)
            {
                MainWindow.Instance.Product.Visibility = System.Windows.Visibility.Visible;
                MainWindow.Instance.Order.Visibility = System.Windows.Visibility.Visible;
                MainWindow.Instance.Info.Visibility = System.Windows.Visibility.Visible;
            }
            else if (App.user.RoleId == 4)
            {
                MainWindow.Instance.Product.Visibility = System.Windows.Visibility.Collapsed;
                MainWindow.Instance.Order.Visibility = System.Windows.Visibility.Collapsed;
                MainWindow.Instance.Info.Visibility = System.Windows.Visibility.Visible;
                MainWindow.Instance.AddProduct.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
