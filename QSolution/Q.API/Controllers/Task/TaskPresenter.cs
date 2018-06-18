using Microsoft.AspNetCore.Mvc;
using Q.API.Models;
using Q.Core.shared;
using Q.Core.UseCases.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q.API.Controllers.Task
{
    public class TaskPresenter : IOutputBoundary<List<TaskOutput>>
    {
        public IActionResult ViewModel { get; private set; }
        public List<TaskOutput> Output { get; private set; }

        public void Populate(List<TaskOutput> response)
        {
            Output = response;

            if(Output == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            var tasks = new List<TaskModel>();

            foreach (var item in response)
            {
                tasks.Add(new TaskModel
                {
                    CreatedBy = item.CreatedBy,
                    CreatedOn = item.CreatedOn,
                    Description = item.Description,
                    Name = item.Name,
                    DueDate = item.DueDate,
                    StartDate = item.StartDate,
                    Id = item.Id,
                    Status = ((Models.TaskStatus)item.Status).ToString(),
                    Priority = ((Priority)item.Priority).ToString()
                });
            }

            ViewModel = new OkObjectResult(tasks);
        }
    }
}
