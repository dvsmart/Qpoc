using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Q.Core.Interfaces;
using Q.Core.shared;
using Q.Core.UseCases.Task;
using Q.Core.UseCases.Task.GetTasks;
using Q.Infrastructure.Repositories;

namespace Q.Infrastructure.Modules
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IOutputConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
