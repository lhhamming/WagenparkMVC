//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WagenparkMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class onderhoud
    {
        public System.DateTime onderhoudsdatum { get; set; }
        public Nullable<decimal> kosten { get; set; }
        public string auto_kenteken { get; set; }
        public int werkplaats_werkplaatsnr { get; set; }
    
        public virtual auto auto { get; set; }
        public virtual werkplaats werkplaats { get; set; }
    }
}
