namespace Scorpio.Auditing
{
    internal class NonAuditingClassWithAuditedAttribute
    {
        public void Method()
        {
            // Method intentionally left empty.
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:删除未使用的参数", Justification = "<挂起>")]
        public void Action(string name, int age)
        {
            // Method intentionally left empty.
        }
    }
}