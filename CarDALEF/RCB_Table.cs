//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarDALEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class RCB_Table
    {
        public int RCB_ID { get; set; }
        public System.DateTime RCB_DOI { get; set; }
        public System.DateTime RCB_DOR { get; set; }
        public decimal RCB_RentPD { get; set; }
        public decimal RCB_TotalBill { get; set; }
        public int C_ID { get; set; }
        public int CA_ID { get; set; }
        public int T_ID { get; set; }
    
        public virtual Car_Table Car_Table { get; set; }
        public virtual Customer_Table Customer_Table { get; set; }
        public virtual Tax_Table Tax_Table { get; set; }
    }
}