using Microsoft.Extensions.DependencyInjection;

using Scorpio.TestBase;

using Shouldly;

using Xunit;
namespace Scorpio.Authorization.Permissions
{
    public class PermissionCheckerTest : IntegratedTest<AuthorizationTestModule>
    {
        private readonly IPermissionChecker _permissionChecker;
        public PermissionCheckerTest() => _permissionChecker = ServiceProvider.GetService<IPermissionChecker>();

        [Fact]
        public void CheckAsync()
        {
            _permissionChecker.CheckAsync("Permission_Test_1").Result.ShouldBeTrue();
            _permissionChecker.CheckAsync("Permission_Test_1.Permission_Test_2").Result.ShouldBeFalse();
            Should.Throw<PermissionNotFondException>(() => _permissionChecker.CheckAsync("Permission_Test_4"));
        }
    }
}
