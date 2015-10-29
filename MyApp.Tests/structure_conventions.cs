using System.Linq;
using Xunit;

namespace Procent.dotnetconf2015.MyApp.Tests
{
    public class structure_conventions
    {
        [Fact]
        public void each_class_in_DataAccess_namespace_implements_interface()
        {
            var types = typeof(User).Assembly.GetTypes();

            var data_access_classes = types
                .Where(x => x.Namespace.Contains(".DataAccess"))
                .Where(x => x.IsClass)
                .ToList()
            ;

            Assert.NotEmpty(data_access_classes);

            var data_access_without_interfaces = data_access_classes
                .Where(x => x.GetInterfaces().Length == 0)
            ;

            Assert.Empty(data_access_without_interfaces);
        }
    }
}