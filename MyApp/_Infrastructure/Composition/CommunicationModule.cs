using Autofac;

namespace Procent.dotnetconf2015.MyApp._Infrastructure.Composition
{
    public class CommunicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ExternalServiceCommunication>()
                .AsImplementedInterfaces();
        }
    }
}