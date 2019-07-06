using System;
using System.Collections.Generic;

namespace Stock.Models
{
    public partial class UserGroups
    {
        public UserGroups()
        {
            Notifications = new HashSet<Notifications>();
            Users = new HashSet<Users>();
        }

        public int UserGroupId { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<Notifications> Notifications { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
