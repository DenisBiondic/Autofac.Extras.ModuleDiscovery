using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Autofac.Extras.ModuleDiscovery.Helpers
{
    public class AssemblyLoader
    {
        /// <summary>
        /// Loads all referenced assemblies that are not loaded into the app domain yet.
        /// </summary>
        /// <param name="assemblyPrefix">
        /// Prefix to use to prevent unneccessary assembly loading.
        /// </param>
        /// <returns>
        /// All found and loaded assemblies.
        /// </returns>
        public IEnumerable<Assembly> LoadAndFindReferencedAssemblies(string assemblyPrefix)
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

            // need to get all references of the already loaded assemblies
            var references = loadedAssemblies.SelectMany(x => x.GetReferencedAssemblies())
                .Where(x => x.FullName.Contains(assemblyPrefix)).ToList();

            foreach (var reference in references)
            {
                LoadAssembly(reference, loadedAssemblies, assemblyPrefix);
            }

            return loadedAssemblies;
        }

        /// <summary>
        /// Loads unloaded assemblies and recursively traverses down the referenced assemblies of that one.
        /// </summary>
        /// <param name="assemblyToLoad">
        /// Assemly to start / continue loading with.
        /// </param>
        /// <param name="loadedAssemblies">
        /// Already loaded assemblies.
        /// </param>
        /// <param name="assemblyPrefix">
        /// Prefix to use to prevent unneccessary assembly loading
        /// </param>
        private void LoadAssembly(AssemblyName assemblyToLoad, IList<Assembly> loadedAssemblies, string assemblyPrefix)
        {
            // We only care about unloaded assembly from our own solution
            if (!assemblyToLoad.FullName.Contains(assemblyPrefix))
            {
                return;
            }

            if (loadedAssemblies.Any(x => x.GetName().FullName == assemblyToLoad.FullName))
            {
                return;
            }

            var assembly = Assembly.Load(assemblyToLoad);
            loadedAssemblies.Add(assembly);

            foreach (var reference in assembly.GetReferencedAssemblies())
            {
                LoadAssembly(reference, loadedAssemblies, assemblyPrefix);
            }
        }
    }
}