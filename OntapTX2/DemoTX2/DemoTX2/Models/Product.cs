namespace DemoTX2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    [Table("Product")]
    public partial class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Khong duoc de trong!")]

        public int ProductID { get; set; }

        [Required(ErrorMessage ="Khong duoc de trong!")]

        [StringLength(50)]
        public string ProductName { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "Khong duoc de trong!")]

        public string Description { get; set; }

        [Column(TypeName = "numeric")]
        [Required(ErrorMessage = "Khong duoc de trong!")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Yêu c?u nh?p s?!")]

        public decimal? PurchasePrice { get; set; }

        [Column(TypeName = "numeric")]
        [Required(ErrorMessage = "Khong duoc de trong!")]
        [RegularExpression(@"^\d+$",ErrorMessage ="Yeu cau nhap dung dinh dang la so!")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Khong duoc de trong!")]

        public int? Quantity { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Khong duoc de trong!")]

        public string Vintage { get; set; }

        [StringLength(10)]
        public string CatalogyID { get; set; }

        [Column(TypeName = "text")]
        public string Image { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Khong duoc de trong!")]

        public string Region { get; set; }

        public virtual Catalogy Catalogy { get; set; }
    }
}
