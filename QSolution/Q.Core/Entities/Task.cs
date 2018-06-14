using Q.Core.shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Core.Entities
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public int Status { get; set; }

        public int Priority { get; set; }
    }
}
