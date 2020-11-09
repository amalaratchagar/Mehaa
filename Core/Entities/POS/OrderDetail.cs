using Core.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities.POS
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public float Discount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Item Item  { get; set; }
    }
}
