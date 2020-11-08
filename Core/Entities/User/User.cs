using System.Collections.Generic;

namespace Core.Entities.User
{
    public class User
    {
        public User()
        {
            UserPermissions = new HashSet<UserPermission>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Modile { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}