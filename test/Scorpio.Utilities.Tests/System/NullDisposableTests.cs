
using Shouldly;

using Xunit;

namespace System
{
    public class NullDisposableTests
    {
        [Fact]
        public void Instance()
        {
            var instance = NullDisposable.Instance;
            Should.NotThrow(() => instance.Dispose());
        }
    }
}
