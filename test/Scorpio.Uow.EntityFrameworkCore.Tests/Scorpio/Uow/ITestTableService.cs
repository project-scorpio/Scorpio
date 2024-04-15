using System.Threading.Tasks;

namespace Scorpio.Uow
{
    [UnitOfWork]
    public interface ITestTableService
    {
        public TestTable Get(int id);

        public TestTable Add(TestTable testTable);

        public Task<TestTable> AddAsync(TestTable testTable);
    }
}
