using Autofac;
using ToDoApi.Model;
using ToDoApi.Repository;
using ToDoApi.Services;
using ToDoApi.UnitOfWork;

namespace ToDoApi
{
    public class TrainingModule : Module
    {
        private readonly string _connectionString;
        private readonly string _assemblyName;

        public TrainingModule(string connectionString, string assemblyName)
        {
            _connectionString = connectionString;
            _assemblyName = assemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ToDoDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("assemblyName", _assemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ToDoRepository>().As<IToDoRepository>()
              .InstancePerLifetimeScope();

            builder.RegisterType<ToDoService>().As<IToDoService>()
                .InstancePerLifetimeScope();


            builder.RegisterType<ToDoUnitOfWork>().As<IToDoUnitOfWork>()
                .InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}
