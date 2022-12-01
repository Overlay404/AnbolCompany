using System;
using System.Collections.Generic;
using System.Linq;
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
            if (ThemeChange.position)
            {
                var uri = new Uri(@"Style/WhiteTheme.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                ThemeChange.position = false;
            }
            else
            {
                var uri = new Uri(@"Style/DarkTheme.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                ThemeChange.position = true;
            }
        }
        public static void ShowTheme()
        {
            if (!ThemeChange.position)
            {
                var uri = new Uri(@"Style/WhiteTheme.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                ThemeChange.position = false;
            }
            if (ThemeChange.position)
            {
                var uri = new Uri(@"Style/DarkTheme.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                ThemeChange.position = true;
            }
        }
    }
}
