//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class PerImport
    {
        public int PerNum { get; set; }
        public Nullable<int> P_Code { get; set; }
        public string Sup_Email { get; set; }
        public string St_Name { get; set; }
        public Nullable<System.DateTime> PerDate { get; set; }
        public Nullable<int> Quentity { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
