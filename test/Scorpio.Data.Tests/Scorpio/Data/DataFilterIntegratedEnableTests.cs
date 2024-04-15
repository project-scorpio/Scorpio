using Shouldly;

using Xunit;

namespace Scorpio.Data
{
    public class DataFilterIntegratedEnableTests : DataFilterIntegratedTests<DataFilterEnableModule>
    {
        [Fact]
        public void Test()
        {
            DataFilter.IsEnabled<ISoftDelete>().ShouldBeTrue();
            var filterContext = new FakeFilterContext();
            DataFilterDescriptor.BuildFilterExpression<SoftDeleteEntity>(DataFilter, filterContext).Compile()(new SoftDeleteEntity(true)).ShouldBeFalse();
            DataFilterDescriptor.BuildFilterExpression<SoftDeleteEntity>(DataFilter, filterContext).Compile()(new SoftDeleteEntity(false)).ShouldBeTrue();
            using (DataFilter.Disable<ISoftDelete>())
            {
                DataFilterDescriptor.BuildFilterExpression<SoftDeleteEntity>(DataFilter, filterContext).Compile()(new SoftDeleteEntity(true)).ShouldBeTrue();
                DataFilterDescriptor.BuildFilterExpression<SoftDeleteEntity>(DataFilter, filterContext).Compile()(new SoftDeleteEntity(false)).ShouldBeTrue();
                using (DataFilter.Enable<ISoftDelete>())
                {
                    DataFilterDescriptor.BuildFilterExpression<SoftDeleteEntity>(DataFilter, filterContext).Compile()(new SoftDeleteEntity(true)).ShouldBeFalse();
                    DataFilterDescriptor.BuildFilterExpression<SoftDeleteEntity>(DataFilter, filterContext).Compile()(new SoftDeleteEntity(false)).ShouldBeTrue();
                }
                DataFilterDescriptor.BuildFilterExpression<SoftDeleteEntity>(DataFilter, filterContext).Compile()(new SoftDeleteEntity(true)).ShouldBeTrue();
                DataFilterDescriptor.BuildFilterExpression<SoftDeleteEntity>(DataFilter, filterContext).Compile()(new SoftDeleteEntity(false)).ShouldBeTrue();
            }
            DataFilterDescriptor.BuildFilterExpression<SoftDeleteEntity>(DataFilter, filterContext).Compile()(new SoftDeleteEntity(true)).ShouldBeFalse();
            DataFilterDescriptor.BuildFilterExpression<SoftDeleteEntity>(DataFilter, filterContext).Compile()(new SoftDeleteEntity(false)).ShouldBeTrue();
        }

    }
}