using System.ComponentModel;

namespace Core.Entities.User
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DefaultValue(ApplicationPermission.None)]
        public ApplicationPermission Permissions { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public Permission()
        {
            IsActive = true;
        }
    }
}