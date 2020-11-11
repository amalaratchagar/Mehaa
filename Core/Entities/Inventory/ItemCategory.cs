using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Inventory
{
    public class ItemCategory
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        [DefaultValue(5.00)]
        [Range(minimum: 0.01, maximum: 99.99)]
        [Column(TypeName = "decimal(4,2)")]
        public decimal MarginPercentage { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public ItemCategory()
        {
            IsActive = true;
        }
    }
}