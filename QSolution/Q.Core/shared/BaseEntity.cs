using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Q.Core.shared
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
