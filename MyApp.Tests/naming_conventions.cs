using System.Linq;
using System.Web.Mvc;
using Xunit;

namespace Procent.dotnetconf2015.MyApp.Tests
{
    public class naming_conventions
    {
        [Fact]
        public void controllers_name_should_end_with_Controller()
        {
            var controllers = ConventionsHelper.classes()
                .Where(x => x.IsAssignableTo<Controller>())
                .ToList();

            Assert.NotEmpty(controllers);

            foreach (var controller in controllers)
            {
                Assert.EndsWith("Controller", controller.Name);
            }
        }

        [Fact]
        public void each_interface_name_starts_with_capital_I()
        {
            var interfaces = ConventionsHelper.interfaces();

            Assert.NotEmpty(interfaces);

            var interfaces_not_starting_with_I = interfaces
                .Where(x => x.Name.StartsWith("I") == false);

            Assert.Empty(interfaces_not_starting_with_I);
        }
    }
}