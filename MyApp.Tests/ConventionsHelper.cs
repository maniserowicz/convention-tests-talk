using System;
using System.Collections.Generic;
using System.IO;
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

        public static string sln_directory()
        {
            var dir = new DirectoryInfo(Directory.GetCurrentDirectory());

            while (dir.EnumerateFiles("*.sln").Any() == false)
            {
                dir = dir.Parent;
            }

            return dir.FullName;
        }

        public static string db_directory()
        {
            return Path.Combine(sln_directory(), "db");
        }

        public static IEnumerable<string> project_files()
        {
            var slnDirectory = sln_directory();
            return Directory
                .EnumerateFiles(slnDirectory, "*.csproj", SearchOption.AllDirectories);
        }

        public static bool IsAssignableTo<T>(this Type @this)
        {
            return typeof (T).IsAssignableFrom(@this);
        }
    }
}