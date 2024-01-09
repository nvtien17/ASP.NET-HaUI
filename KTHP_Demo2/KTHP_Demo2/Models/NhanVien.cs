namespace KTHP_Demo2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        [Required]
        public int Manv { get; set; }
        [Required]
        [StringLength(30)]
        public string Hoten { get; set; }

        public int? Tuoi { get; set; }

        [StringLength(30)]
        public string Diachi { get; set; }

        public int? Luong { get; set; }

        public int? Maphong { get; set; }

        public virtual Phong Phong { get; set; }
    }
}
