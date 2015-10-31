using System.Linq;
using Procent.dotnetconf2015.MyApp._Infrastructure;
using Xunit;

namespace Procent.dotnetconf2015.MyApp.Tests
{
    public class cqrs_conventions
    {
        [Fact]
        public void each_command_has_exactly_one_handler()
        {
            var commands = ConventionsHelper.classes()
                .Where(x => x.IsAssignableTo<ICommand>())
                .ToList();

            var handlers = ConventionsHelper.classes()
                .Where(x => x.IsAssignableTo<IHandleCommand>())
                .ToList();

            Assert.NotEmpty(commands);

            foreach (var command in commands)
            {
                var handler_type = typeof(IHandleCommand<>).MakeGenericType(command);

                var command_handlers = handlers.Where(x => x.GetInterfaces().Contains(handler_type));

                Assert.Equal(1, command_handlers.Count());
            }
        }
    }
}