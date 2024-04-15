using Scorpio.Entities;

namespace Scorpio.Uow
{
    public class SimpleTable : Entity<int>
    {
        public string StringValue { get; set; }

    }
}