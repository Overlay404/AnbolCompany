//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnbolCompany.Resourses
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductSupply
    {
        public int id { get; set; }
        public int ProductId { get; set; }
        public Nullable<int> SupplyId { get; set; }
        public Nullable<int> cost { get; set; }
        public Nullable<int> count { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Supply Supply { get; set; }
    }
}
