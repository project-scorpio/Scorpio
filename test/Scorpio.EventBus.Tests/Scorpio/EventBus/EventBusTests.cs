using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Moq;

using NSubstitute;
using NSubstitute.ExceptionExtensions;

using Scorpio.EventBus.TestClasses;

using Shouldly;

using Xunit;

namespace Scorpio.EventBus
{
    public class EventBusTests : EventBusTestBase
    {


        [Fact]
        public void Subscribe_Action()
        {
            var eventBus = GetRequiredService<IEventBus>();
            var subscriber = eventBus.Subscribe<string>((o,s) => Task.Run(() => Console.WriteLine(s)));
            eventBus.ShouldBeOfType<LocalEventBus>().HandlerFactories.ShouldContainKey(typeof(string));
            eventBus.ShouldBeOfType<LocalEventBus>()
                .HandlerFactories[typeof(string)].OfType<SingleInstanceHandlerFactory>().ShouldHaveSingleItem()
                .ShouldBeOfType<SingleInstanceHandlerFactory>().HandlerInstance
                .ShouldBeOfType<ActionEventHandler<string>>();
            subscriber.Dispose();
            eventBus.ShouldBeOfType<LocalEventBus>().HandlerFactories.ShouldContainKey(typeof(string));
            eventBus.ShouldBeOfType<LocalEventBus>()
                .HandlerFactories[typeof(string)].OfType<SingleInstanceHandlerFactory>().ShouldBeEmpty();

        }

        [Fact]
        public void Subscribe_S()
        {
            var eventBus = GetRequiredService<IEventBus>();
            var mock = new Mock<IEventHandler<string>>();
            var subscriber = eventBus.Subscribe(mock.Object);
            eventBus.ShouldBeOfType<LocalEventBus>().HandlerFactories.ShouldContainKey(typeof(string));
            eventBus.ShouldBeOfType<LocalEventBus>()
                .HandlerFactories[typeof(string)].OfType<SingleInstanceHandlerFactory>().ShouldHaveSingleItem()
                .ShouldBeOfType<SingleInstanceHandlerFactory>().GetHandler().EventHandler.ShouldBe(mock.Object);
            eventBus.ShouldBeOfType<LocalEventBus>()
                .HandlerFactories[typeof(string)].OfType<SingleInstanceHandlerFactory>().ShouldHaveSingleItem()
                .ShouldBeOfType<SingleInstanceHandlerFactory>().HandlerInstance.ShouldBe(mock.Object);
            subscriber.Dispose();
            eventBus.ShouldBeOfType<LocalEventBus>().HandlerFactories.ShouldContainKey(typeof(string));
            eventBus.ShouldBeOfType<LocalEventBus>()
                .HandlerFactories[typeof(string)].OfType<SingleInstanceHandlerFactory>().ShouldBeEmpty();
        }

        [Fact]
        public void Subscribe_T()
        {
            var eventBus = GetRequiredService<IEventBus>();
            var subscriber = eventBus.Subscribe<string, EmptyEventHandler>();
            eventBus.ShouldBeOfType<LocalEventBus>().HandlerFactories.ShouldContainKey(typeof(string));
            eventBus.ShouldBeOfType<LocalEventBus>()
                .HandlerFactories[typeof(string)].OfType<TransientEventHandlerFactory<EmptyEventHandler>>().ShouldHaveSingleItem()
                .ShouldBeOfType<TransientEventHandlerFactory<EmptyEventHandler>>().GetHandler().EventHandler.ShouldBeOfType<EmptyEventHandler>();
            subscriber.Dispose();
            eventBus.ShouldBeOfType<LocalEventBus>().HandlerFactories.ShouldContainKey(typeof(string));
            eventBus.ShouldBeOfType<LocalEventBus>()
                .HandlerFactories[typeof(string)].OfType<TransientEventHandlerFactory<EmptyEventHandler>>().ShouldBeEmpty();
        }

        [Fact]
        public void Subscribe_TT()
        {
            var eventBus = GetRequiredService<IEventBus>();
            eventBus.ShouldBeOfType<LocalEventBus>().HandlerFactories.ShouldContainKey(typeof(TestEventData));
            eventBus.ShouldBeOfType<LocalEventBus>()
                .HandlerFactories[typeof(TestEventData)].ShouldHaveSingleItem()
                .ShouldBeOfType<IocEventHandlerFactory>().GetHandler().EventHandler
                .ShouldBeOfType<ServicedEventHandler>();
            eventBus.ShouldBeOfType<LocalEventBus>().HandlerFactories.ShouldContainKey(typeof(string));
            eventBus.ShouldBeOfType<LocalEventBus>()
                .HandlerFactories[typeof(string)].ShouldHaveSingleItem()
                .ShouldBeOfType<TransientEventHandlerFactory>().GetHandler().EventHandler
                .ShouldBeOfType<EmptyEventHandler>();
        }

        [Fact]
        public void Subscribe_F()
        {
            var eventBus = GetRequiredService<IEventBus>();
            var mock = new Mock<IEventHandlerFactory>();
            var subscriber = eventBus.Subscribe<string>(mock.Object);
            eventBus.ShouldBeOfType<LocalEventBus>().HandlerFactories.ShouldContainKey(typeof(string));
            eventBus.ShouldBeOfType<LocalEventBus>()
                .HandlerFactories[typeof(string)].Where(f => f.GetType() == mock.Object.GetType()).ShouldHaveSingleItem().ShouldBe(mock.Object);
            subscriber.Dispose();
            eventBus.ShouldBeOfType<LocalEventBus>().HandlerFactories.ShouldContainKey(typeof(string));
            eventBus.ShouldBeOfType<LocalEventBus>()
                .HandlerFactories[typeof(string)].ShouldNotContain(mock.Object);
        }

        [Fact]
        public void Unsubscribe_A()
        {
            var eventBus = GetRequiredService<IEventBus>();
            Task Action(object sender,string s) => Task.Run(() => Console.WriteLine(s));

            eventBus.ShouldBeOfType<LocalEventBus>().HandlerFactories.Clear();
            eventBus.Subscribe((Func<object,string, Task>)Action);
            eventBus.ShouldBeOfType<LocalEventBus>().HandlerFactories.ShouldContainKey(typeof(string));
            eventBus.ShouldBeOfType<LocalEventBus>()
                .HandlerFactories[typeof(string)].ShouldHaveSingleItem()
                .ShouldBeOfType<SingleInstanceHandlerFactory>().HandlerInstance
                .ShouldBeOfType<ActionEventHandler<string>>();
            eventBus.Unsubscribe((Func<object,string, Task>)Action);
            eventBus.ShouldBeOfType<LocalEventBus>()
                .HandlerFactories[typeof(string)].ShouldBeEmpty();
        }

        [Fact]
        public void Unsubscribe()
        {
            var eventBus = GetRequiredService<IEventBus>();
            var mock = new Mock<IEventHandler<string>>();
            eventBus.Subscribe(mock.Object);
            eventBus.ShouldBeOfType<LocalEventBus>().HandlerFactories.ShouldContainKey(typeof(string));
            eventBus.ShouldBeOfType<LocalEventBus>()
                .HandlerFactories[typeof(string)].OfType<SingleInstanceHandlerFactory>().ShouldHaveSingleItem()
                .ShouldBeOfType<SingleInstanceHandlerFactory>().HandlerInstance.ShouldBe(mock.Object);
            eventBus.Unsubscribe(mock.Object);
            eventBus.ShouldBeOfType<LocalEventBus>()
                .HandlerFactories[typeof(string)].OfType<SingleInstanceHandlerFactory>().ShouldBeEmpty();
        }

        [Fact]
        public void Unsubscribe_F()
        {
            var eventBus = GetRequiredService<IEventBus>();
            var mock = new Mock<IEventHandlerFactory>();
            eventBus.Subscribe<string>(mock.Object);
            eventBus.ShouldBeOfType<LocalEventBus>().HandlerFactories.ShouldContainKey(typeof(string));
            eventBus.ShouldBeOfType<LocalEventBus>()
                .HandlerFactories[typeof(string)].Where(f => f.GetType() == mock.Object.GetType()).ShouldHaveSingleItem().ShouldBe(mock.Object);
            eventBus.Unsubscribe<string>(mock.Object);
            eventBus.ShouldBeOfType<LocalEventBus>()
                .HandlerFactories[typeof(string)].Where(f => f.GetType() == mock.Object.GetType()).ShouldBeEmpty();

        }

        [Fact]
        public void UnsubscribeAll()
        {
            var eventBus = GetRequiredService<IEventBus>();
            eventBus.UnsubscribeAll<string>();
            eventBus.ShouldBeOfType<LocalEventBus>()
                .HandlerFactories[typeof(string)].ShouldBeEmpty();

        }

        [Fact]
        public void Publish()
        {
            var eventBus = GetRequiredService<IEventBus>();
            var action = Substitute.For<Func<object, GenericEventData<string>, Task>>();
            action.Invoke(this,default).ReturnsForAnyArgs(Task.Delay(100).ContinueWith(t => Task.Delay(100)));
            var action2 = Substitute.For<Func<object,GenericEventData<object>, Task>>();
            action2.Invoke(this,default).ReturnsForAnyArgs(Task.CompletedTask);
            using (eventBus.Subscribe<GenericEventData<string>, EmptyEventHandler<GenericEventData<string>>>())
            {
                using (eventBus.Subscribe(action2))
                {
                    using (eventBus.Subscribe(action))
                    {
                        Should.NotThrow(() => eventBus.PublishAsync(this,new GenericEventData<string>("test")));
                        action.ReceivedWithAnyArgs(1).Invoke(this, default);
                        action2.ReceivedWithAnyArgs(1).Invoke(this, default);
                    }
                }

            }
        }
        [Fact]
        public void Publish_E()
        {
            var eventBus = GetRequiredService<IEventBus>();
            var action = Substitute.For<Func<object,GenericEventData<string>, Task>>();
            action.Invoke(this, default).ThrowsForAnyArgs<NotSupportedException>();
            var action2 = Substitute.For<Func<object, GenericEventData<object>, Task>>();
            action2.Invoke(this, default).ThrowsForAnyArgs(c => new TargetInvocationException(new ScorpioException()));
            using (eventBus.Subscribe(action))
            {
                Should.Throw<NotSupportedException>(() => eventBus.PublishAsync(this,new GenericEventData<string>("test")));
            }

            using (eventBus.Subscribe(action2))
            {
                Should.Throw<ScorpioException>(() => eventBus.PublishAsync(this,new GenericEventData<string>("test")));
            }

            using (eventBus.Subscribe(action2))
            {
                using (eventBus.Subscribe(action))
                {
                    Should.Throw<AggregateException>(() => eventBus.PublishAsync(this,new GenericEventData<string>("test")));
                }

            }

        }
    }
}
