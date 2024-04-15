using System;

using NSubstitute;

using Xunit;

namespace Scorpio.EventBus
{
    public class EventHandlerDisposeWrapperTests
    {
        [Fact]
        public void Dispose()
        {
            var hander = Substitute.For<IEventHandler>();
            var action = Substitute.For<Action>();
            var wrapper = new EventHandlerDisposeWrapper(hander, action);
            wrapper.Dispose();
            action.Received(1);
        }
    }
}
