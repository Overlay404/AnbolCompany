using AnbolCompany.Resourses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
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
        ObservableCollection<Product> productsObs = new ObservableCollection<Product>();
        CollectionView products { get; set; }
        public static int currentPage = 0;
        public static int maxPage;
        public static Products Instance { get; set; }
        public Products()
        {
            InitializeComponent();

            Instance = this;

            filtration.SelectedIndex = 0;
            sorting.SelectedIndex = 0;
            quantity.SelectedIndex = 0;


            if(filtration.SelectedIndex != -1 && sorting.SelectedIndex != -1 && quantity.SelectedIndex != -1)
                Update();
            MainWindow.Instance.plusImage.MouseUp += PlusImage_MouseUp;
            MainWindow.Instance.editImage.MouseUp += EditImage_MouseUp;

        }


        #region Кнопки редактирования и добавления элементов
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
        #endregion

        #region Обработчик кнопок впрово и влево
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(currentPage > 0)
                currentPage--;
            Update();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(currentPage < maxPage -1)
                currentPage++;
            Update();
        }
        #endregion

        #region Обработчик ComboBox для фильтрации, сортировки, количества элементов 
        private void quantity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentPage = 0;
            if (filtration.SelectedIndex != -1 && sorting.SelectedIndex != -1 && quantity.SelectedIndex != -1)
                Update();
        }
        private void filtration_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentPage = 0;
            if (filtration.SelectedIndex != -1 && sorting.SelectedIndex != -1 && quantity.SelectedIndex != -1)
                Update();
        }
        private void sorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentPage = 0;
            if (filtration.SelectedIndex != -1 && sorting.SelectedIndex != -1 && quantity.SelectedIndex != -1)
                Update();
        }
        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
        #endregion

        void Update()
        {
            productsObs.Clear();

            listProducts.ItemsSource = App.db.Products.Where(p => p.nameProduct.StartsWith(search.Text)).ToList();

            switch ((filtration.SelectedItem as ComboBoxItem).Tag)
            {
                case "1":
                    products = (CollectionView)CollectionViewSource.GetDefaultView(listProducts.ItemsSource);
                    products.SortDescriptions.Add(new SortDescription("nameProduct", (sorting.SelectedItem as ComboBoxItem).Tag.Equals("0") ? ListSortDirection.Ascending: ListSortDirection.Descending));
                    break;
               case "2":
                    products = (CollectionView)CollectionViewSource.GetDefaultView(listProducts.ItemsSource);
                    products.SortDescriptions.Add(new SortDescription("date", (sorting.SelectedItem as ComboBoxItem).Tag.Equals("0") ? ListSortDirection.Ascending : ListSortDirection.Descending));
                    break;
                case "3":
                    products = (CollectionView)CollectionViewSource.GetDefaultView(listProducts.ItemsSource);
                    products.SortDescriptions.Add(new SortDescription("cost", (sorting.SelectedItem as ComboBoxItem).Tag.Equals("0") ? ListSortDirection.Ascending : ListSortDirection.Descending));
                    break;
                default:
                    break;
            }

            thisPage.Text = "Текущее страница " + currentPage.ToString();

            foreach(var item in listProducts.Items)
                productsObs.Add(item as Product);

            switch ((quantity.SelectedItem as ComboBoxItem).Tag)
            {
                case "1":
                    maxPage = (int)Math.Ceiling((double)App.db.Products.Count() / 2);
                    listProducts.ItemsSource = productsObs.Skip(2 * currentPage).Take(2);
                    break;
                case "2":
                    maxPage = (int)Math.Ceiling((double)App.db.Products.Count() / 5);
                    listProducts.ItemsSource = productsObs.Skip(5 * currentPage).Take(5);
                    break;
                case "3":
                    maxPage = (int)Math.Ceiling((double)App.db.Products.Count() / 10);
                    listProducts.ItemsSource = productsObs.Skip(10 * currentPage).Take(10);
                    break;
                default:
                    maxPage = 1;
                    break;
            }
        }

       
    }
}
