using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Inventory
{
    public class ItemStock
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }

        public string Discription { get; set; }

        public int Quantity { get; set; }

        public DateTime Date { get; set; }

        public Item Item { get; set; }

        public ItemStock() { }
    }
}