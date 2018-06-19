using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Q.Entities
{
    public class MenuItem : BaseEntity
    {
        public string Caption { get; set; }

        public string Route { get; set; }

        public bool HasChildren { get; set; }

        public string ClassName { get; set; }

        public string IconName { get; set; }

        public bool IsVisible { get; set; }

        public int SortOrder { get; set; }

        public int MenuGroupId { get; set; }
        public int? ParentId { get; set; }

        public virtual MenuItem Parent { get; set; }

        public virtual ICollection<MenuItem> Children { get; set; }

    }
}
