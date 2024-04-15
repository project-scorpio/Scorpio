namespace Scorpio.Auditing
{
    internal class DisableAuditingMethodWithAuditedAttribute
    {
        [DisableAuditing]
        public void Method()
        {
            // Method intentionally left empty.
        }
    }
}