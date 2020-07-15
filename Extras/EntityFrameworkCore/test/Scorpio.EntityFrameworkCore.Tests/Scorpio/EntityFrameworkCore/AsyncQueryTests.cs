﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Async;
using Microsoft.Extensions.DependencyInjection;

using Xunit;
using Shouldly;
using System.Threading.Tasks;

namespace Scorpio.EntityFrameworkCore
{
    public class AsyncQueryTests : TestBase.IntegratedTest<TestModule>
    {


        [Fact]
        public async Task AnyAsync()
        {
            using (var context = ServiceProvider.GetService<TestDbContext>())
            {
                context.TestTables.AddRange(
                    new TestTable { Id = 1, StringValue = "Row1" },
                    new TestTable { Id = 2, StringValue = "Row2" },
                    new TestTable { Id = 3, StringValue = "Row3" },
                    new TestTable { Id = 4, StringValue = "Row4" },
                    new TestTable { Id = 5, StringValue = "Row5" },
                    new TestTable { Id = 6, StringValue = "Row6" }
                    );
                await context.SaveChangesAsync();
                (await context.TestTables.Where(t => t.Id == 1).AnyAsync()).ShouldBeTrue();
            }
        }
    }
}
