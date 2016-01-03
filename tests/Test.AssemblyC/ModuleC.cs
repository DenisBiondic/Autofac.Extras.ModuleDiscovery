using Autofac;

namespace Test.AssemblyC
{
    public class ModuleC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CType>()
                .As<ICType>();
        }
    }
}
