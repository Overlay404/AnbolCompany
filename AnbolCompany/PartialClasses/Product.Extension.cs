using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AnbolCompany.Resourses
{
    public partial class Product
    {
        public string ColorBorder
        {
            get
            {
                if (count == 0)
                    return "Red";
                else
                    return "Black";
            }
        }
    }
}
