using System.Linq;
using System.Xml.Linq;
using Xunit;

namespace Procent.dotnetconf2015.MyApp.Tests
{
    public class project_file_conventions
    {
        [Fact]
        public void cshtml_files_should_be_marked_as_Content()
        {
            var projectFiles = ConventionsHelper.project_files()
                .ToList();

            Assert.NotEmpty(projectFiles);

            foreach (var csproj in projectFiles)
            {
                var sqls = from d in XDocument.Load(csproj).Descendants()
                    let include = d.Attribute("Include")
                    where include != null
                    where include.Value.EndsWith(".cshtml")
                    select d;

                var sqls_as_non_EmbeddedResource = sqls
                    .Where(x => x.Name.LocalName != "Content");

                Assert.Empty(sqls_as_non_EmbeddedResource);
            }
        }

        [Fact]
        public void sql_scripts_should_be_marked_as_EmbeddedResource()
        {
            var projectFiles = ConventionsHelper.project_files()
                .ToList();

            Assert.NotEmpty(projectFiles);

            foreach (var csproj in projectFiles)
            {
                var sqls = from d in XDocument.Load(csproj).Descendants()
                    let include = d.Attribute("Include")
                    where include != null
                    where include.Value.EndsWith(".sql")
                    select d;

                var sqls_as_non_EmbeddedResource = sqls
                    .Where(x => x.Name.LocalName != "EmbeddedResource");

                Assert.Empty(sqls_as_non_EmbeddedResource);
            }
        }
    }
}