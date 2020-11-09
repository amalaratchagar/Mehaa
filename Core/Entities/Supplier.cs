using Core.Entities.Inventory;
using System.Collections.Generic;
using System.ComponentModel;

namespace Core.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string WebPage { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public Supplier()
        {
            IsActive = true;
            Items = new HashSet<Item>();
        }
    }
}