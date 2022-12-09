using AnbolCompany.Resourses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public static bool isPlusPress = false;
        CollectionView order;
        public OrderPage()
        {
            InitializeComponent();


            if (App.user.RoleId == 1 || App.user.RoleId == 3)
                listOrder.ItemsSource = App.db.Orders.Where(o => o.CustomerId == App.user.id || o.ExecutorId == App.user.id).ToList();
            else
                listOrder.ItemsSource = App.db.Orders.ToList();

            if (App.user.RoleId1.id == 1)
            {
                MainWindow.isRoleIdMened = true;
            }
            MainWindow.Instance.plusImage.MouseUp += PlusImage_MouseUp;
            MainWindow.Instance.editImage.MouseUp += EditImage_MouseUp;

            order = (CollectionView)CollectionViewSource.GetDefaultView(listOrder.ItemsSource);
            order.SortDescriptions.Add(new SortDescription("Stage.nameStage", ListSortDirection.Ascending));
        }

        private void EditImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.Instance.frame.Content.ToString().Equals("AnbolCompany.OrderPage"))
            {
                if (listOrder.SelectedItem == null)
                    return;

                MainWindow.Instance.frame.Navigate(new EditOrder(listOrder.SelectedItem as Order));
                App.order = (listOrder.SelectedItem as Order);
            }
        }

        private void PlusImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isPlusPress = true;
            if (MainWindow.Instance.frame.Content.ToString().Equals("AnbolCompany.OrderPage"))
                MainWindow.Instance.frame.Navigate(new EditOrder(null));
        }
    }
}
