//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fakture_
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetaljiFakture1
    {
        public int Faktura { get; set; }
        public int Proizvod { get; set; }
        public Nullable<decimal> Cijena { get; set; }
        public Nullable<int> Kolicina { get; set; }
        public Nullable<int> Popust { get; set; }
        public Nullable<decimal> Ukupno { get; set; }
    
        public virtual Faktura1 Faktura1 { get; set; }
        public virtual Popust1 Popust1 { get; set; }
        public virtual Proizvod Proizvod1 { get; set; }
    }
}
