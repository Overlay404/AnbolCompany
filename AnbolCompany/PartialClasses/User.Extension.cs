using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnbolCompany.Resourses
{
    public partial class User
    {
        public string Fullname => $"{name} {lastname} {firstname}";
    }
}
