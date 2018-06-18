using AutoMapper;
using Q.Core.Entities;
using Q.Core.UseCases.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Infrastructure.Mappings
{
    public class TasksProfile : Profile
    {
        public TasksProfile()
        {
            CreateMap<Task, TaskOutput>();
        }
    }
}
