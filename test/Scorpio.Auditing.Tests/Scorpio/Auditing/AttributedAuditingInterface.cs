namespace Scorpio.Auditing
{
    [Audited]
    public class AttributedAuditingInterface : IAttributedAuditingInterface, DependencyInjection.ITransientDependency
    {
        public void Test(string value, int num)
        {
            // Method intentionally left empty.
        }

        [DisableAuditing]
        public void Test2(string value, int num)
        {
            // Method intentionally left empty.
        }

        public void TestEx(string value, int num) => throw new System.NotImplementedException();
    }
}