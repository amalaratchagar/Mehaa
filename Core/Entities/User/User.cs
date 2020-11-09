using System.Collections.Generic;
using System.ComponentModel;

namespace Core.Entities.User
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public virtual ICollection<UserPermission> UserPermissions { get; set; }

        public User()
        {
            IsActive = true;
            UserPermissions = new HashSet<UserPermission>();
        }
    }
}