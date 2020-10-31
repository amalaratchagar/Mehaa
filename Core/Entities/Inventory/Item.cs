using System;
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

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDiscontinued { get; set; }
        public bool IsOutOfStock { get; set; }
        public bool IsReturnable { get; set; }
        public double Price { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; }

        public virtual ItemCategory Category { get; set; }

        public Item() { }
    }
}