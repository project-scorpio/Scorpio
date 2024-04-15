using System.Threading.Tasks;

using Shouldly;

using Xunit;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AsyncDisposeActionTests
    {
        [Fact]
        public async ValueTask DisposeAsync()
        {
            var number = 0;
            var obj = new AsyncDisposeAction(() =>
            {
                number += 1;
                return new ValueTask();
            });
            await obj.DisposeAsync();
            number.ShouldBe(1);
            await obj.DisposeAsync();
            number.ShouldBe(1);
        }


    }
}