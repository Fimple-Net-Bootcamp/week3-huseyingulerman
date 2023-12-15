using Autofac;
using System.Reflection;
using week3_huseyingulerman.Core.Repositories;
using week3_huseyingulerman.Core.Services;
using week3_huseyingulerman.Core.UnitOfWork;
using week3_huseyingulerman.Repository.Repositories;
using week3_huseyingulerman.Repository.UnitOfWork;
using week3_huseyingulerman.Repository;
using week3_huseyingulerman.Service.Mapping;
using week3_huseyingulerman.Service.Servcices;

namespace week3_huseyingulermanApi.Modules
{
    public class RepoServiceModule:Autofac.Module
    {


        protected override void Load(ContainerBuilder builder)
        {



            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<,,>)).As(typeof(IService<,,>)).InstancePerLifetimeScope();


            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
