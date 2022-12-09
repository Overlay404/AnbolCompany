using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnbolCompany.Resourses
{
    public partial class Order_Product
    {
        public int Sum => Convert.ToInt32(cost * count);
    }
}
