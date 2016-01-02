using System.Collections.Generic;
using System.Reflection;

namespace Autofac.Extras.ModuleDiscovery.Helpers
{
    internal class AssemblyItem
    {
        public AssemblyItem(Assembly item)
        {
            Item = item;
            Dependencies = new List<AssemblyItem>();
        }

        public Assembly Item { get; set; }

        public IList<AssemblyItem> Dependencies { get; set; }
    }
}