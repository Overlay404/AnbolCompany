using AnbolCompany.Resourses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AnbolCompany
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AnbolEntities db = new AnbolEntities();

        public static User user { get; set; }
        public static Product product { get; set; }

        public static Order_Product order_product { get; set; }
        public static Order order { get; set; }
        public App()
        {
            db.Users.Load();
            db.Products.Load();
        }
    }
}
