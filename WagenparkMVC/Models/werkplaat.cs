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
    
    public partial class werkplaat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public werkplaat()
        {
            this.onderhouds = new HashSet<onderhoud>();
        }
    
        public int werkplaatsnr { get; set; }
        public string naam { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<onderhoud> onderhouds { get; set; }
    }
}
