using Microsoft.EntityFrameworkCore;

namespace Scorpio.EntityFrameworkCore
{
    internal class TestDbContext : ScorpioDbContext<TestDbContext>
    {
        public TestDbContext(DbContextOptions<TestDbContext> contextOptions) : base(contextOptions)
        {
        }

        public DbSet<TestTable> TestTables { get; set; }
        public DbSet<TestTableDetail> TableDetails { get; set; }

        public DbSet<SimpleTable> SimpleTables { get; set; }
    }
}
