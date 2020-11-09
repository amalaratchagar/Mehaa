using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text;

namespace Core.Entities.POS
{
    public enum OrderStatus
    {
        Open,
        Processed,
        Cancelled
    }

    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public DateTime OpenedDate { get; set; }
        public DateTime ClosedDate { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        [DefaultValue(OrderStatus.Open)]
        public OrderStatus Status { get; set; }
        public string Notes { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual User.User User  { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
    }
}
