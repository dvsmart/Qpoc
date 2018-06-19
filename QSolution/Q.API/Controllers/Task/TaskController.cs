using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Q.API.Filters;
using Q.API.Models;
using Q.Core.shared;
using Q.Core.UseCases.Task;

namespace Q.API.Controllers.Task
{
    [Produces("application/json")]
    [Route("api/Task")]
    [ValidateModel]
    public class TaskController : Controller
    {
        private readonly IInputBoundary<TaskDto> _taskInteractor;
        private readonly IInputBoundary<AddTaskRequest> _addTaskInteractor;
        private readonly TaskPresenter _taskPresenter;

        public TaskController(IInputBoundary<TaskDto> taskInteractor, TaskPresenter taskPresenter,IInputBoundary<AddTaskRequest> addTaskInteractor)
        {
            _taskInteractor = taskInteractor;
            _taskPresenter = taskPresenter;
            _addTaskInteractor = addTaskInteractor;

        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<IActionResult> List()
        {
            //var items = _taskRepository.List().OrderByDescending(x=>x.CreatedOn).Select(item => TaskModel.ReturnTaskModel(item));
            await _taskInteractor.Process(new TaskDto());
            return Ok(_taskPresenter.ViewModel);
        }

        //// GET: api/Tasks/5
        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var item = TaskModel.ReturnTaskModel(_taskRepository.GetById(id));
        //    return Ok(item);
        //}

        // POST: api/Tasks
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskModel item)
        {
            var taskItem = new AddTaskRequest()
            {
                Name = item.Name,
                Description = item.Description,
                StartDate = item.StartDate,
                DueDate = item.DueDate,
                Status = EnumUtil.GetEnumFromString<Models.TaskStatus>(item.Status),
                Priority = EnumUtil.GetEnumFromString<Priority>(item.Priority)
            };
            await _addTaskInteractor.Process(taskItem);
            return Ok();
        }

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
