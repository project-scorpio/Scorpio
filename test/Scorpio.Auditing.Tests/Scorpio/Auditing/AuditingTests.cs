using System;

using AspectCore.DynamicProxy;

using Microsoft.Extensions.DependencyInjection;

using Shouldly;

using Xunit;
namespace Scorpio.Auditing
{
    public class AuditingTests : AuditingTestBase
    {
        private readonly IAuditingManager _auditingManager;

        public AuditingTests() => _auditingManager = ServiceProvider.GetService<IAuditingManager>();

        [Fact]
        public void AttributedAuditing()
        {
            using (var scope = _auditingManager.BeginScope())
            {
                var service = ServiceProvider.GetService<IAttributedAuditingInterface>();
                service.Test("test", 19);
            }
            var store = ServiceProvider.GetService<IAuditingStore>().ShouldBeOfType<FackAuditingStore>();
            store.Info.ShouldNotBeNull();
            store.Info.CurrentUser.ShouldBe("TestUser");
            var action = store.Info.Actions.ShouldHaveSingleItem();
            action.ServiceName.ShouldBe(typeof(AttributedAuditingInterface).FullName);
            action.MethodName.ShouldBe("Test");
        }

        [Fact]
        public void AttributedAuditingEx()
        {
            using (var scope = _auditingManager.BeginScope())
            {
                var service = ServiceProvider.GetService<IAttributedAuditingInterface>();
                Should.Throw<NotImplementedException>(() => service.TestEx("test", 19));
            }
            var store = ServiceProvider.GetService<IAuditingStore>().ShouldBeOfType<FackAuditingStore>();
            store.Info.ShouldNotBeNull();
            store.Info.CurrentUser.ShouldBe("TestUser");
            var action = store.Info.Actions.ShouldHaveSingleItem();
            action.ServiceName.ShouldBe(typeof(AttributedAuditingInterface).FullName);
            action.MethodName.ShouldBe("TestEx");
            store.Info.Exceptions.ShouldHaveSingleItem().ShouldBeOfType<NotImplementedException>();
        }


        [Fact]
        public void AttributedAuditingAsync()
        {
            using (var scope = _auditingManager.BeginScope())
            {
                var service = ServiceProvider.GetService<IAttributedAuditingInterface>();
                service.Test("test", 19);
                Should.NotThrow(() => scope.SaveAsync());
            }
            var store = ServiceProvider.GetService<IAuditingStore>().ShouldBeOfType<FackAuditingStore>();
            store.Info.ShouldNotBeNull();
            store.Info.CurrentUser.ShouldBe("TestUser");
            var action = store.Info.Actions.ShouldHaveSingleItem();
            action.ServiceName.ShouldBe(typeof(AttributedAuditingInterface).FullName);
            action.MethodName.ShouldBe("Test");
        }


        [Fact]
        public void DisAttributedAuditing()
        {
            using (_auditingManager.BeginScope())
            {
                
                var service = ServiceProvider.GetService<IAttributedAuditingInterface>();
                service.Test2("test", 19);
                _auditingManager.Current.Info.ShouldNotBeNull();
            }
            var store = ServiceProvider.GetService<IAuditingStore>().ShouldBeOfType<FackAuditingStore>();
            store.Info.ShouldBeNull();
        }

    }
}
