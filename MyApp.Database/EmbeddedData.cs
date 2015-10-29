using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Procent.dotnetconf2015.MyApp.Database
{
    public static class EmbeddedData
    {
        public static string AsString(string name)
        {
            var stream = AsStream(name);
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static Stream AsStream(string name)
        {
            var callingAssembly = Assembly.GetCallingAssembly();
            var resources = callingAssembly.GetManifestResourceNames()
                .Where(x => x.EndsWith(name))
                .ToList();
            if (resources.Count == 0)
            {
                throw new ArgumentException(string.Format("Embedded resource with name '{0}' cannot be found in assembly '{1}", name, callingAssembly.FullName));
            }
            if (resources.Count > 1)
            {
                throw new ArgumentException(string.Format("Multiple resource with name '{0}' found in assembly '{1}", name, callingAssembly.FullName));
            }

            string fullName = resources[0];
            return callingAssembly
                .GetManifestResourceStream(fullName);
        }
    }
}