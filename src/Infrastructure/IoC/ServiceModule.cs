using Autofac;
using Komis.Infrastructure.Services;
using System.Linq;
using System.Reflection;

namespace Komis.Infrastructure.IoC
{

    public class ServiceModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                var assembly = typeof(ServiceModule)
                    .GetTypeInfo()
                    .Assembly;

                builder.RegisterAssemblyTypes(assembly)
                        .Where(x => x.IsAssignableTo<IService>())
                        .AsImplementedInterfaces()
                        .InstancePerLifetimeScope();
            }
        }
    
}
