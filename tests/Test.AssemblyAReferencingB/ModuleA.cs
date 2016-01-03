using Autofac;
using Autofac.Core;
using Test.AssemblyBReferencingC;

namespace Test.AssemblyAReferencingB
{
    public class ModuleA : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AType>()
                .As<IAType>()
                .As<IStartable>()
                .SingleInstance()
                .WithParameter(new ResolvedParameter(
                   (pi, ctx) => pi.ParameterType == typeof(IBType),
                   (pi, ctx) => ctx.Resolve<IBType>()));
        }
    }
}
