using Autofac.Extras.ModuleDiscovery.Helpers;

namespace Autofac.Extras.ModuleDiscovery
{
    public static class AutofacExtensions
    {
        public static void AutoregisterAllReferencedModules(this ContainerBuilder builder, string assemblyPrefix)
        {
            var assemblyLoader = new AssemblyLoader();
            
            var loadedAndSortedAssemblies = assemblyLoader.LoadAndFindReferencedAssemblies(assemblyPrefix)
                .SortAssembliesPerDependencyHierarchy();

            // find and register all AutoFac modules from all assemblies
            // HACK: to prevent AutoFac to register the assemblies in whatever way it sees fit,
            // we give it only one assembly at a time
            loadedAndSortedAssemblies.ForEach(x => builder.RegisterAssemblyModules(x));
        }
    }
}