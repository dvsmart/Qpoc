using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Q.API.Filters;
using Q.API.Models;
using Q.Core.Entities;
using Q.Core.Interfaces;
using Q.Core.shared;
using Q.Core.UseCases.Task;

namespace Q.API.Controllers.Task
{
    [Produces("application/json")]
    [Route("api/Task")]
    [ValidateModel]
    public class TaskController : Controller
    {
        private readonly IInputBoundary<TaskInput> _getTasks;
        private readonly TaskPresenter _taskPresenter;

        public TaskController(IInputBoundary<TaskInput> getTasks, TaskPresenter taskPresenter)
        {
            _getTasks = getTasks;
            _taskPresenter = taskPresenter;

        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<IActionResult> List()
        {
            //var items = _taskRepository.List().OrderByDescending(x=>x.CreatedOn).Select(item => TaskModel.ReturnTaskModel(item));
            await this._getTasks.Process(new TaskInput());
            return Ok(this._taskPresenter.ViewModel);
        }

        //// GET: api/Tasks/5
        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var item = TaskModel.ReturnTaskModel(_taskRepository.GetById(id));
        //    return Ok(item);
        //}

        //// POST: api/Tasks
        //[HttpPost]
        //public IActionResult Post([FromBody] TaskModel item)
        //{
        //    var todoItem = new Task()
        //    {
        //        Name = item.Name,
        //        Description = item.Description,
        //        CreatedOn = DateTime.Now,
        //        CreatedBy = 1,
        //        StartDate = item.StartDate,
        //        DueDate = item.DueDate,
        //        Status = EnumUtil.GetEnumFromString<TaskStatus>(item.Status),
        //        Priority = EnumUtil.GetEnumFromString<Priority>(item.Priority)
        //    };
        //    _taskRepository.Add(todoItem);
        //    return Ok(TaskModel.ReturnTaskModel(todoItem));
        //}

        //// PUT api/Tasks/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/Tasks/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    var task = _taskRepository.GetById(id);
        //    _taskRepository.Delete(task);
        //}

    }
}
