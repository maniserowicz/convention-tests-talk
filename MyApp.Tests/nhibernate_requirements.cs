using System.Linq;
using Xunit;

namespace Procent.dotnetconf2015.MyApp.Tests
{
    public class nhibernate_requirements
    {
        [Fact]
        public void each_property_of_IEntity_is_virtual()
        {
            var entities = ConventionsHelper.types()
                .Where(x => x.IsAssignableTo<IEntity>())
            ;

            var entity_properties = entities.SelectMany(x => x.GetProperties())
                .ToList();

            Assert.NotEmpty(entity_properties);

            var non_virtual_getters = entity_properties
                .Select(x => x.GetGetMethod())
                .Where(x => x.IsVirtual == false)
            ;

            Assert.Empty(non_virtual_getters);
        }
    }
}