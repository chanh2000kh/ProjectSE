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
    
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            this.DanhGiaNhanXets = new HashSet<DanhGiaNhanXet>();
            this.KeHoaches = new HashSet<KeHoach>();
            this.ThucDons = new HashSet<ThucDon>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ChieuCao { get; set; }
        public Nullable<int> CanNang { get; set; }
        public string TanSuatHoatDong { get; set; }
        public string MucTieu { get; set; }
        public Nullable<int> CanNangMongMuon { get; set; }
        public Nullable<int> Thang { get; set; }
        public string GioiTinh { get; set; }
        public string IdLogin { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGiaNhanXet> DanhGiaNhanXets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KeHoach> KeHoaches { get; set; }
        public virtual Login Login { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThucDon> ThucDons { get; set; }
    }
}
