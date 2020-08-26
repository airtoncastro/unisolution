using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UniSolutions.Teste.DependencyInjection
{
    public static class DependencyContextExtension
    {
        public static Assembly[] GetAssemblies(this DependencyContext context)
        {
            return context.RuntimeLibraries
                    .SelectMany(lib => lib.GetDefaultAssemblyNames(context).Select(Assembly.Load))
                    .ToArray();
        }
    }
}
