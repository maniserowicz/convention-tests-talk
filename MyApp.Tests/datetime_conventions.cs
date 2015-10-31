using System;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Xunit;

namespace Procent.dotnetconf2015.MyApp.Tests
{
    public class datetime_conventions
    {
        [Fact]
        public void DateTime_Now_is_never_used__should_use_UtcNow_instead()
        {
            var sourcePaths = ConventionsHelper.GetSourceFiles()
                .ToArray();

            foreach (var sourcePath in sourcePaths)
            {
                var source = File.ReadAllText(sourcePath);

                var tree = CSharpSyntaxTree.ParseText(source);

                var root = tree.GetRoot();
                var memberAccesses = root.DescendantNodes()
                    .OfType<MemberAccessExpressionSyntax>()
                    .ToList();

                var datetime_now_invocations = memberAccesses
                    .Where(x => x.Expression.Parent.ToString()
                        .Equals("datetime.now", StringComparison.OrdinalIgnoreCase)
                ).ToArray();

                Assert.Empty(datetime_now_invocations);
            }
        }
    }
}