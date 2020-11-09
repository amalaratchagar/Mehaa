using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.User
{
    public class UserPermission
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Permission")]
        public int PermisssionId { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public virtual User User { get; set; }

        public virtual Permission Permission { get; set; }

        public UserPermission()
        {
            IsActive = true;
        }
    }
}