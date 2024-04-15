using Scorpio.Entities;

namespace Scorpio.EntityFrameworkCore
{
    public class SimpleTable : Entity<int>
    {
        public string StringValue { get; set; }

    }
}