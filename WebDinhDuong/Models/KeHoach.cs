//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebDinhDuong.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KeHoach
    {
        public string IdThucDon { get; set; }
        public string IdBuoi { get; set; }
        public string IdThu { get; set; }
        public string GhiChu { get; set; }
    
        public virtual Buoi Buoi { get; set; }
        public virtual Thu Thu { get; set; }
        public virtual ThucDon ThucDon { get; set; }
    }
}
