using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Inventory
{
    public enum MeasurementUnit : short
    {
        None = 0,

        // Count
        Unit = 1,

        // Weight
        Gram = 21,

        Milligram = 22,
        Kilogram = 23,

        // Volume
        Liter = 31,

        Milliliter = 32,
        Kiloliter = 33,
    }

    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string ShortName { get; set; }

        [MaxLength(200)]
        public string FullName { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public bool IsDiscontinued { get; set; }

        public bool IsOutOfStock { get; set; }

        public bool IsReturnable { get; set; }

        [Required]
        [Range(minimum: 0.01, maximum: 9999999.99)]
        [Column(TypeName = "decimal(10,2)")]
        [DefaultValue(0.00)]
        public decimal CostPrice { get; set; }

        [Required]
        [Range(minimum: 0.01, maximum: 9999999.99)]
        [Column(TypeName = "decimal(10,2)")]
        [DefaultValue(0.00)]
        public decimal SellingPrice { get; set; }

        public MeasurementUnit MeasurementUnit { get; set; }

        public virtual ItemCategory Category { get; set; }

        public virtual Supplier Supplier { get; set; }

        [NotMapped]
        public int Quantity { get; set; }

        public Item()
        {
            IsActive = true;
        }
    }
}