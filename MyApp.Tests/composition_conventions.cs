using System.Linq;
using Autofac;
using Xunit;

namespace Procent.dotnetconf2015.MyApp.Tests
{
    public class composition_conventions
    {
        [Fact]
        public void each_service_interface_can_be_resolved_from_container()
        {
            var assemblies = ConventionsHelper.assemblies()
                .ToArray();

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(assemblies);

            var container = builder.Build();

            var service_interfaces = ConventionsHelper.interfaces()
                .Where(x => x != typeof (IEntity))
                .ToList();

            Assert.NotEmpty(service_interfaces);

            foreach (var serviceInterface in service_interfaces)
            {
                var error = Record.Exception(
                    () => container.Resolve(serviceInterface)
                );

                Assert.Null(error);
            }
        }
    }
}