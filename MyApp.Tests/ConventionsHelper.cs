using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Procent.dotnetconf2015.MyApp.Tests
{
    public static class ConventionsHelper
    {
        public static IEnumerable<Assembly> assemblies()
        {
            yield return typeof (User).Assembly;
        }

        public static IEnumerable<Type> types()
        {
            return assemblies()
                .SelectMany(x => x.GetTypes());
        }

        public static IEnumerable<Type> classes()
        {
            return types()
                .Where(x => x.IsClass);
        }

        public static IEnumerable<Type> interfaces()
        {
            return types()
                .Where(x => x.IsInterface);
        }
    }
}