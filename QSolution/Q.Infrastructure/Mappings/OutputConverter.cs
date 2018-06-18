using AutoMapper;
using Q.Core.shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Infrastructure.Mappings
{
    public class OutputConverter : IOutputConverter
    {
        private readonly IMapper mapper;

        public OutputConverter()
        {
            mapper = new MapperConfiguration(cfg => {
                cfg.AddProfile<TasksProfile>();
            }).CreateMapper();
        }

        public T Map<T>(object source)
        {
            T model = mapper.Map<T>(source);
            return model;
        }
    }
}
