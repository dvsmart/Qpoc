using Autofac;
using Microsoft.EntityFrameworkCore;
using Q.Infrastructure.Data;
using Q.Infrastructure.Mappings;

namespace Q.Infrastructure.Modules
{
    public class InfrastructureModule : Autofac.Module
    {
        public string SQLServerConnectionString { get; set; }
        protected override void Load(ContainerBuilder builder)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
            optionsBuilder.UseSqlServer(SQLServerConnectionString);
            optionsBuilder.EnableSensitiveDataLogging(true);

            builder.RegisterType<AppDbContext>()
              .WithParameter(new TypedParameter(typeof(DbContextOptions), optionsBuilder.Options))
              .InstancePerLifetimeScope();
           
            builder.RegisterAssemblyTypes(typeof(OutputConverter).Assembly)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            
        }
    }
}
