using System.Collections.Generic;

using Scorpio.Data;
using Scorpio.Entities;

namespace Scorpio.EntityFrameworkCore
{
    public class TestTable : Entity<int>, ISoftDelete, IHasExtraProperties, IStringValue
    {

        public TestTable() => Details = new HashSet<TestTableDetail>();
        public string StringValue { get; set; }
        public bool IsDeleted { get; set; }

        public ExtraPropertyDictionary ExtraProperties { get; set; }

        public virtual ICollection<TestTableDetail> Details { get; set; }
    }
}