//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> catId { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public Nullable<int> Stock { get; set; }
    
        public virtual category category { get; set; }
    }
}
