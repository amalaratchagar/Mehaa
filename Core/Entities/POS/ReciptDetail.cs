using Core.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities.POS
{
    public class ReciptDetail
    {
        public int Id { get; set; }
        [ForeignKey("Recipt")]
        public int ReciptId { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public float Discount { get; set; }

        public virtual Recipt Recipt { get; set; }
        public virtual Item Item  { get; set; }
    }
}
