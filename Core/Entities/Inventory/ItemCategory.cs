using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Inventory
{
    public class ItemCategory
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public ItemCategory()
        {
            IsActive = true;
        }
    }
}