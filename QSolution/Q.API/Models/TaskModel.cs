using Q.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Q.API.Models
{
    public class TaskModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public static TaskModel ReturnTaskModel(Task taskItem)
        {
            return new TaskModel
            {
                Id = taskItem.Id,
                Name = taskItem.Name,
                Description = taskItem.Description,
                CreatedBy = taskItem.CreatedBy,
                CreatedOn = taskItem.CreatedOn,
                StartDate = taskItem.StartDate,
                DueDate = taskItem.DueDate,
                Status = ((TaskStatus)taskItem.Status).ToString(),
                Priority = ((Priority)taskItem.Priority).ToString()
            };
        }
    }

    public enum TaskStatus
    {
        NotStarted = 1,
        InProgress = 2,
        Completed = 3,
        OnHold = 4,
        Abandoned = 5
    }

    public enum Priority
    {
        Low = 0,
        Minor = 1,
        Moderate = 2,
        High = 3,
        Urgent = 4,
    }

    public static class EnumUtil
    {
        public static int GetEnumFromString<T>(string value) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            return (int)Enum.Parse(typeof(T), value);
        }
    }
}
