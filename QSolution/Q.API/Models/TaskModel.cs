using Q.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Q.API.Models
{
    public class TaskModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public static TaskModel ReturnTaskModel(Task taskItem)
        {
            return new TaskModel
            {
                Id = taskItem.Id,
                Name = taskItem.Name,
                Description = taskItem.Description,
                CreatedBy = taskItem.CreatedBy,
                CreatedOn = taskItem.CreatedOn
            };
        }
    }
}
