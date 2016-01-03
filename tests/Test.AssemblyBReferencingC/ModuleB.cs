using Autofac;
using Autofac.Core;
using Test.AssemblyC;

namespace Test.AssemblyBReferencingC
{
    public class ModuleB : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BType>()
                .As<IBType>()
                .WithParameter(new ResolvedParameter(
                    (pi, ctx) => pi.ParameterType == typeof (ICType),
                    (pi, ctx) => ctx.Resolve<ICType>()));
        }
    }
}
