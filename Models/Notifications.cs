using System;
using System.Collections.Generic;

namespace Stock.Models
{
    public partial class Notifications
    {
        public int NotificationId { get; set; }
        public string Text { get; set; }
        public int? UserGroupId { get; set; }
        public int? UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual UserGroups UserGroup { get; set; }
    }
}
