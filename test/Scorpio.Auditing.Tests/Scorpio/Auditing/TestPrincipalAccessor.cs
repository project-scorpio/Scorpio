using System.Security.Principal;

using Scorpio.Security;

namespace Scorpio.Auditing
{
    internal class TestPrincipalAccessor : ICurrentPrincipalAccessor
    {
        public IPrincipal Principal { get; }

        public TestPrincipalAccessor() => Principal = new GenericPrincipal(new GenericIdentity("TestUser"), new[] { "Admin" });
    }
}