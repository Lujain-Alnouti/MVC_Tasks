//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIpractice.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CorStd
    {
        public int CorID { get; set; }
        public int StdID { get; set; }
        public string vv { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual MVCStudent MVCStudent { get; set; }
    }
}