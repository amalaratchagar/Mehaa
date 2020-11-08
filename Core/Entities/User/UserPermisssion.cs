using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.User
{
    public class UserPermisssion
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Permisssion")]
        public int PermisssionId { get; set; }

        public virtual User User { get; set; }

        public virtual Permisssion Permisssion { get; set; }
    }
}