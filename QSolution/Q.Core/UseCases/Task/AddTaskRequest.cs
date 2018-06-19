using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Core.UseCases.Task
{
    public class AddTaskRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public int Status { get; set; }

        public int Priority { get; set; }
    }
}
