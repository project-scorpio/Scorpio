using Microsoft.EntityFrameworkCore;

using Scorpio.EntityFrameworkCore;

namespace Scorpio.Uow
{
    internal class TestDbContext : ScorpioDbContext<TestDbContext>
    {
        public TestDbContext(DbContextOptions<TestDbContext> contextOptions) : base(contextOptions)
        {
        }

        public DbSet<TestTable> TestTables { get; set; }
        public DbSet<TestTableDetail> TableDetails { get; set; }

        public DbSet<SimpleTable> SimpleTables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TestTable>().HasData(
                    new TestTable { Id = 1, StringValue = "Row1" },
                    new TestTable { Id = 2, StringValue = "Row2" },
                    new TestTable { Id = 3, StringValue = "Row3" },
                    new TestTable { Id = 4, StringValue = "Row4" },
                    new TestTable { Id = 5, StringValue = "Row5" },
                    new TestTable { Id = 6, StringValue = "Row6" }
                    );
        }

    }
}
