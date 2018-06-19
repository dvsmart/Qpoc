using AutoMapper;
using Q.Core.UseCases.Task;
using Q.Entities;

namespace Q.Infrastructure.Mappings
{
    public class TasksProfile : Profile
    {
        public TasksProfile()
        {
            CreateMap<Task, TaskDto>();
            CreateMap<AddTaskRequest, Task>();
        }
    }

}
