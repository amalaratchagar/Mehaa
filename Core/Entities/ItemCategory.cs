using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class ItemCategory
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public ItemCategory()
        {
        }
    }
}