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
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Orders = new HashSet<Order>();
            this.Orders1 = new HashSet<Order>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string password { get; set; }
        public string login { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public Nullable<int> GenderId { get; set; }
    
        public virtual Gender Gender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders1 { get; set; }
        public virtual RoleId RoleId1 { get; set; }
    }
}