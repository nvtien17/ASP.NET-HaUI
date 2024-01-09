namespace Kiemtra2Demo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Kh�ng ???c ?? tr?ng")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Kh�ng ???c ?? tr?ng")]
        [StringLength(50)]
        [DisplayName("T�n s?n ph?m")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Kh�ng ???c ?? tr?ng!")]
        [Column(TypeName = "text")]
        [DisplayName("M� t?")]
        public string Description { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("Gi� nh?p")]
        [Required(ErrorMessage = "Kh�ng ???c ?? tr?ng!")]

        public decimal PurchasePrice { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("Gi� b�n")]
        [Required(ErrorMessage = "Kh�ng ???c ?? tr?ng!")]

        public decimal Price { get; set; }

        [DisplayName("S? l??ng")]
        [Required(ErrorMessage = "Kh�ng ???c ?? tr?ng!")]

        public int Quantity { get; set; }

        [StringLength(20)]
        [DisplayName("N?m s?n xu?t")]
        [Required(ErrorMessage = "Kh�ng ???c ?? tr?ng!")]

        public string Vintage { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Lo?i s?n ph?m")]
        public string CatalogyID { get; set; }

        [Column(TypeName = "text")]
        [DisplayName("?nh")]

        public string Image { get; set; }

        
        [StringLength(100)]
        [DisplayName("V�ng")]
        [Required(ErrorMessage = "Kh�ng ???c ?? tr?ng!")]

        public string Region { get; set; }

        public virtual Catalogy Catalogy { get; set; }
    }
}
