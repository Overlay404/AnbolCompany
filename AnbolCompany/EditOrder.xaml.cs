using AnbolCompany.Resourses;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AnbolCompany
{
    /// <summary>
    /// Логика взаимодействия для EditOrder.xaml
    /// </summary>
    public partial class EditOrder : Page
    {

        List<Order_Product> order_Products;
        Order order1;
        public EditOrder(Order order)
        {
            InitializeComponent();

            if (order != null)
            {
                productOrderList.ItemsSource = order.Order_Product;
                order_Products = order.Order_Product.ToList();
                order1 = order;
            }

            productList.ItemsSource = App.db.Products.ToList();

            if (App.user.RoleId1.id == 1)
            {
                payment.Visibility = Visibility.Collapsed;
                reject.Visibility = Visibility.Collapsed;
                started.Visibility = Visibility.Collapsed;
                execute.Visibility = Visibility.Collapsed;
                ready.Visibility = Visibility.Collapsed;
                newOrder.Visibility = Visibility.Visible;
            }
            else if (App.user.RoleId1.id == 2)
            {
                payment.Visibility = Visibility.Collapsed;
                reject.Visibility = Visibility.Collapsed;
                started.Visibility = Visibility.Collapsed;
                execute.Visibility = Visibility.Visible;
                ready.Visibility = Visibility.Visible;
                newOrder.Visibility = Visibility.Collapsed;
                addBtn.IsEnabled = false;
            }
            else if (App.user.RoleId1.id == 3)
            {
                payment.Visibility = Visibility.Visible;
                reject.Visibility = Visibility.Visible;
                started.Visibility = Visibility.Visible;
                execute.Visibility = Visibility.Collapsed;
                ready.Visibility = Visibility.Collapsed;
                newOrder.Visibility = Visibility.Collapsed;
                addBtn.IsEnabled = false;
            }
        }

        private void productList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nameProduct.Text = (((ListView)sender).SelectedItem as Product).nameProduct;
            cost.Text = (((ListView)sender).SelectedItem as Product).cost.ToString();
            count.Text = (((ListView)sender).SelectedItem as Product).count.ToString();
            App.product = ((ListView)sender).SelectedItem as Product;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (order_Products.Where(o => o.ProductId == App.product.id && o.OrderId == App.order.id).Select(o => o.ProductId).FirstOrDefault() != null)
            {
                App.db.Order_Product.Remove(order_Products.Where(o => o.ProductId == App.product.id && o.OrderId == App.order.id).Select(o => o).FirstOrDefault());
                order1.Order_Product.Add(new Order_Product { cost = int.Parse(cost.Text), count = int.Parse(count.Text), ProductId = App.product.id, OrderId = App.order.id });
            }
            else
                App.db.Order_Product.Add(new Order_Product { cost = int.Parse(cost.Text), count = int.Parse(count.Text), ProductId = App.product.id, OrderId = order1.id });

            App.order_product = order1.Order_Product.LastOrDefault();
            App.db.SaveChanges();


            productOrderList.ItemsSource = App.db.Order_Product.Where(o => o.OrderId == order1.id).Select(o => o).ToList();
        }

        private void newOrder_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.frame.Navigate(new OrderPage());
            order1.StageId = 1;
            App.db.SaveChanges();
        }

        private void started_Click(object sender, RoutedEventArgs e)
        {
            if (order1.StageId == 1)
            {
                MainWindow.Instance.frame.Navigate(new OrderPage());
                order1.StageId = 2;
                App.db.SaveChanges();
            }
            else
                MessageBox.Show("Статус заказа не соответствует статусу: Новый");
        }

        private void reject_Click(object sender, RoutedEventArgs e)
        {
            if (order1.StageId == 2)
            {
                MainWindow.Instance.frame.Navigate(new OrderPage());
                order1.StageId = 3;
                App.db.SaveChanges();
            }
            else
                MessageBox.Show("Статус заказа не соответствует статусу: Обрабатывается");
        }

        private void payment_Click(object sender, RoutedEventArgs e)
        {
            if (order1.StageId == 2)
            {
                MainWindow.Instance.frame.Navigate(new OrderPage());
                order1.StageId = 4;
                App.db.SaveChanges();
            }
            else
                MessageBox.Show("Статус заказа не соответствует статусу: Обрабатывается");
        }

        private void execute_Click(object sender, RoutedEventArgs e)
        {
            if (order1.StageId == 4)
            {
                MainWindow.Instance.frame.Navigate(new OrderPage());
                order1.StageId = 5;
                App.db.SaveChanges();
            }
            else
                MessageBox.Show("Статус заказа не соответствует статусу: К оплате");
        }

        private void ready_Click(object sender, RoutedEventArgs e)
        {
            if (order1.StageId == 4)
            {
                App.product.count += int.Parse(count.Text);
                App.product.cost += int.Parse(cost.Text);

                MainWindow.Instance.frame.Navigate(new OrderPage());
                order1.StageId = 6;
                App.db.SaveChanges();
            }
            else
                MessageBox.Show("Статус заказа не соответствует статусу: Выполняется");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (order1 == null)
            {
                order1 = App.db.Orders.Add(new Order { CustomerId = App.user.RoleId1.id, date = System.DateTime.Today, StageId = 1 });
                App.db.SaveChanges();
                productOrderList.ItemsSource = order1.Order_Product;
                order_Products = order1.Order_Product.ToList();
            }
            if (order1.StageId != 1)
            {
                addBtn.IsEnabled = false;
            }
        }
    }
}
