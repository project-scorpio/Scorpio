namespace Scorpio.Auditing
{
    [Audited]
    internal class AuditingClassDisableAuditingMethodWithAuditedAttribute
    {
        [DisableAuditing]
        public void Method()
        {
            // Method intentionally left empty.
        }
    }
}