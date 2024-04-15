using System.Threading.Tasks;

namespace Scorpio.Uow
{
    [UnitOfWork]
    public interface IUnitOfWorkTestInterface
    {
        void Method1();
        Task Method1Async();

        void DisableMethod();
    }
}