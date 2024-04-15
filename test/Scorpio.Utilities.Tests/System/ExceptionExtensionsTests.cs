using System.Runtime.Serialization;
using System.Text.RegularExpressions;

using Microsoft.Extensions.Logging;

using Shouldly;

using Xunit;

namespace System
{
    public class ExceptionExtensionsTests
    {
        [Fact]
        public void ReThrow()
        {
            const string rethrowMessageSubstring = "End of stack trace";
            var e = new FormatException();
            for (var i = 0; i < 3; i++)
            {
                Should.Throw<FormatException>(() => e.ReThrow()).ShouldBeSameAs(e);
                i.ShouldBe(Regex.Matches(e.StackTrace, rethrowMessageSubstring).Count);
            }
        }

        [Fact]
        public void GetLogLevel()
        {
            new FormatException().GetLogLevel().ShouldBe(LogLevel.Error);
            new FormatException().GetLogLevel(LogLevel.Critical).ShouldBe(LogLevel.Critical);
            new LogLevelException(LogLevel.Information).GetLogLevel().ShouldBe(LogLevel.Information);
            new LogLevelException(LogLevel.Information).GetLogLevel(LogLevel.Error).ShouldBe(LogLevel.Information);
        }
    }
}
