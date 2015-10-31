using Autofac;

namespace Procent.dotnetconf2015.MyApp._Infrastructure.Composition
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.Namespace.Contains(".DataAccess"))
                .AsImplementedInterfaces();
        }
    }
}