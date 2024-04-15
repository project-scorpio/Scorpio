namespace Scorpio.Auditing
{
    [DisableAuditing]
    internal class DisableAuditingClassAuditingMethodWithAuditedAttribute
    {
        [Audited]
        public void Method()
        {
            // Method intentionally left empty.
        }
    }
}