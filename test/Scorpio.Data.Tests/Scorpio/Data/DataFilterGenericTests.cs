﻿using Shouldly;

using Xunit;
namespace Scorpio.Data
{
    public class DataFilterGenericTests
    {
        [Fact]
        public void Disable()
        {
            var filter = new DataFilter<ITestFilter>();
            filter.IsEnabled.ShouldBeTrue();
            using (filter.Disable())
            {
                filter.IsEnabled.ShouldBeFalse();
            }
            filter.IsEnabled.ShouldBeTrue();

            filter = new DataFilter<ITestFilter>(false);
            filter.IsEnabled.ShouldBeFalse();
            using (filter.Disable())
            {
                filter.IsEnabled.ShouldBeFalse();
            }
            filter.IsEnabled.ShouldBeFalse();
        }

        [Fact]
        public void Enable()
        {
            var filter = new DataFilter<ITestFilter>();
            filter.IsEnabled.ShouldBeTrue();
            using (filter.Enable())
            {
                filter.IsEnabled.ShouldBeTrue();
            }
            filter.IsEnabled.ShouldBeTrue();

            filter = new DataFilter<ITestFilter>(false);
            filter.IsEnabled.ShouldBeFalse();
            using (filter.Enable())
            {
                filter.IsEnabled.ShouldBeTrue();
            }
            filter.IsEnabled.ShouldBeFalse();
        }
    }
}