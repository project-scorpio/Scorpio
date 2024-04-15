namespace Scorpio.Auditing
{
    internal class AuditingMethodWithAuditedAttribute
    {
        [Audited]
        public void Method()
        {
            // Method intentionally left empty.
        }
    }
}