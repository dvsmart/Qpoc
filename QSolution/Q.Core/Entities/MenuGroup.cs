using Q.Core.shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Q.Core.Entities
{
    public class MenuGroup : BaseEntity
    {
        public string Name { get; set; }

        public bool IsVisible { get; set; }

        public List<MenuItem> MenuItems { get; set; }

    }
}
