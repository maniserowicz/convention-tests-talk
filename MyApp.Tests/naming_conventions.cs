using System.Linq;
using Xunit;

namespace Procent.dotnetconf2015.MyApp.Tests
{
    public class naming_conventions
    {
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