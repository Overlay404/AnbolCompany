using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnbolCompany
{
    internal class ThemeChange
    {
        public static bool position { get; set; }
        public static void Change()
        {
            Uri uri = null;
            if (ThemeChange.position)
            {
                uri = new Uri(@"Style/WhiteTheme.xaml", UriKind.Relative);
                ThemeChange.position = false;
            }
            else
            {
                uri = new Uri(@"Style/DarkTheme.xaml", UriKind.Relative);
                ThemeChange.position = true;
            }
            SetStyle(uri);
        }

        private static void SetStyle(Uri uri)
        {
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}
