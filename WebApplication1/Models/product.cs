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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            this.products_in_order = new HashSet<products_in_order>();
        }
    
        public int p_id { get; set; }
        public string p_name { get; set; }
        public string p_description { get; set; }
        public short retail_price { get; set; }
        public short wholesale_price { get; set; }
        public short agent_price { get; set; }
        public short p_status { get; set; }
        public string p_image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<products_in_order> products_in_order { get; set; }
    }
}
