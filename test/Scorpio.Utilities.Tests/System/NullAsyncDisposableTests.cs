using Shouldly;

using Xunit;

namespace System
{
    public class NullAsyncDisposableTests
    {
        [Fact]
        public void Instance()
        {
            var instance = NullAsyncDispose.Instance;
            Should.NotThrow(() => instance.DisposeAsync());
        }
    }
}