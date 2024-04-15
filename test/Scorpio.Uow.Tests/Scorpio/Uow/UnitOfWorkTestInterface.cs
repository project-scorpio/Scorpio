using System.Threading.Tasks;

using Scorpio.DependencyInjection;

using Shouldly;

namespace Scorpio.Uow
{
    [UnitOfWork]
    public class UnitOfWorkTestInterface : IUnitOfWorkTestInterface, ITransientDependency
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UnitOfWorkTestInterface(IUnitOfWorkManager unitOfWorkManager) => _unitOfWorkManager = unitOfWorkManager;

        [DisableUnitOfWork]
        public  virtual void DisableMethod() => _unitOfWorkManager.Current.ShouldBeOfType<NullUnitOfWork>().Options.Scope.ShouldBe(System.Transactions.TransactionScopeOption.Suppress);

        public virtual void Method1() => _unitOfWorkManager.Current.ShouldBeOfType<NullUnitOfWork>().Options.Scope.ShouldBe(System.Transactions.TransactionScopeOption.Required);

        public virtual Task Method1Async()
        {
            _unitOfWorkManager.Current.ShouldBeOfType<NullUnitOfWork>();
            return Task.CompletedTask;
        }
    }
}