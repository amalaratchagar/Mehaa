using System;

namespace Core
{
    [Flags]
    public enum ApplicationPermission
    {
        None = 0,
        InventoryView = 1 << 0,
        InventoryAddAndUpdate = 1 << 1,
        InventoryDelete = 1 << 2,

        UserView = 1 << 3,
        UserAddAndUpdate = 1 << 4,
        UserDelete = 1 << 5,

        CustomerView = 1 << 6,
        CustomerAddAndUpdate = 1 << 7,
        CustomerDelete = 1 << 8,
    }
}