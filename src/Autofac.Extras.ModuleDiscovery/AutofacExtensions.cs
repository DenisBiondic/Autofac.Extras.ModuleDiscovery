using Autofac.Extras.ModuleDiscovery.Helpers;

namespace Autofac.Extras.ModuleDiscovery
{
    public static class AutofacExtensions
    {
        public static void AutoregisterAllReferencedModules(this ContainerBuilder builder, string assemblyPrefix)
        {
            var assemblyLoader = new AssemblyLoader();
            
            var loadedAndSortedAssemblies = assemblyLoader.LoadAndFindReferencedAssemblies(assemblyPrefix);

            // find and register all AutoFac modules from all assemblies
            loadedAndSortedAssemblies.ForEach(x => builder.RegisterAssemblyModules(x));
        }
    }
}