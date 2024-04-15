using System;

using Shouldly;

using Xunit;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public class DisposeActionTests
    {
        [Fact]
        public void Dispose()
        {
            var number = 0;
            var obj = new DisposeAction(() => number += 1);
            obj.Dispose();
            number.ShouldBe(1);
            obj.Dispose();
            number.ShouldBe(1);
        }

    }
}
