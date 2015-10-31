using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;

namespace Procent.dotnetconf2015.MyApp._Infrastructure
{
    public interface IEvent
    {

    }

    public interface IHandleEvent
    {

    }

    public interface IHandleEvent<TEvent> : IHandleEvent
        where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }

    public interface IEventsBus
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }

    public class EventsBus : IEventsBus
    {
        private readonly Func<Type, IEnumerable<IHandleEvent>> _handlersFactory;

        public EventsBus(Func<Type, IEnumerable<IHandleEvent>> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var handlers = _handlersFactory(typeof(TEvent))
                .Cast<IHandleEvent<TEvent>>();

            foreach (var handler in handlers)
            {
                handler.Handle(@event);
            }
        }
    }

    public class EventsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.IsAssignableTo<IHandleEvent>())
                .AsImplementedInterfaces();

            builder.Register<Func<Type, IEnumerable<IHandleEvent>>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();
                return t =>
                {
                    var handlerType = typeof(IHandleEvent<>).MakeGenericType(t);
                    var handlersCollectionType = typeof(IEnumerable<>).MakeGenericType(handlerType);
                    return (IEnumerable<IHandleEvent>)ctx.Resolve(handlersCollectionType);
                };
            });

            builder.RegisterType<EventsBus>()
                .AsImplementedInterfaces();
        }
    }
}