using AnbolCompany.Resourses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        public App()
        {

        }
    }
}
