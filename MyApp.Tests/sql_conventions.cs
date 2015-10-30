using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace Procent.dotnetconf2015.MyApp.Tests
{
    public class sql_conventions
    {
        [Fact]
        public void scripts_do_not_contain_GO_statement()
        {
            var dbDirectory = ConventionsHelper.db_directory();

            var sql_scripts = Directory.EnumerateFiles(dbDirectory, "*sql")
                .ToList();

            Assert.NotEmpty(sql_scripts);

            var scripts_with_GO = sql_scripts
                .Select(x => File.ReadAllText(x))
                .Where(x => Regex.IsMatch(x, "^\\s*GO\\s*$", RegexOptions.IgnoreCase | RegexOptions.Multiline))
            ;

            Assert.Empty(scripts_with_GO);
        }
    }
}