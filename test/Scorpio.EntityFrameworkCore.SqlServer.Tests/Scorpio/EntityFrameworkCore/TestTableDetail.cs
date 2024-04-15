using Scorpio.Entities;

namespace Scorpio.EntityFrameworkCore
{
    public class TestTableDetail : Entity<int>
    {
        public string DetailValue { get; set; }
        public virtual TestTable TestTable { get; set; }
    }
}