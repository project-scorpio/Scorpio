using System;

using Scorpio.Timing;

namespace Scorpio.Auditing
{
    internal class TestClock : IClock
    {
        public DateTime Now { get; }
        public DateTimeKind Kind { get; }
        public bool SupportsMultipleTimezone { get; }

        public TestClock()
        {
            Now = new DateTime(2019, 1, 1, 0, 0, 0);
            SupportsMultipleTimezone = true;
        }
        public DateTime Normalize(DateTime dateTime) => dateTime;
    }
}