using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Autofac.Extras.ModuleDiscovery.Helpers
{
    public static class AssemblyEnumerableExtensions
    {
        /// <summary>
        /// Will sort the assemblies in an order where deepest item with no dependencies comes first, and
        /// the one with most dependencies comes as last.
        /// </summary>
        /// <param name="assemblies">
        /// Assemblies to sort
        /// </param>
        /// <returns>
        /// Sorted assemblies
        /// </returns>
        public static IEnumerable<Assembly> SortAssembliesPerDependencyHierarchy(this IEnumerable<Assembly> assemblies)
        {
            // First transform the input to something we can work with
            var assemblyItems = assemblies.Select(x => new AssemblyItem(x)).ToArray();

            foreach (var item in assemblyItems)
            {
                foreach (var reference in item.Item.GetReferencedAssemblies())
                {
                    var dependency = assemblyItems.SingleOrDefault(i => i.Item.FullName == reference.FullName);

                    if (dependency != null)
                    {
                        item.Dependencies.Add(dependency);
                    }
                }
            }

            // then return the sorted results
            return assemblyItems.TopologicalSort(i => i.Dependencies).Select(x => x.Item);
        }
    }
}