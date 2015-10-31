using System;
using System.Linq;
using Procent.dotnetconf2015.MyApp._Infrastructure;
using Xunit;

namespace Procent.dotnetconf2015.MyApp.Tests
{
    public class runnabilility_conventions
    {
        [Fact]
        public void each_interface_has_at_least_one_implementation()
        {
            var interfaces = ConventionsHelper.interfaces()
                .Where(x => x.Namespace.Contains("._Infrastructure") == false)
                .ToList();

            var concrete_types = ConventionsHelper.classes()
                .Where(x => x.IsConcrete())
                .ToList();

            foreach (var @interface in interfaces)
            {
                var types_assignable_to_interface = concrete_types
                    .Where(x => @interface.IsAssignableFrom(x));

                Assert.NotEmpty(types_assignable_to_interface);
            }
        }
    }
}