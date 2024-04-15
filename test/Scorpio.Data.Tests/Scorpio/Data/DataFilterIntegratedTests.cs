using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Scorpio.Data
{
    public abstract class DataFilterIntegratedTests<TModule> : TestBase.IntegratedTest<TModule>
        where TModule : Modularity.ScorpioModule
    {
        public IDataFilter DataFilter { get; set; }

        public DataFilterOptions DataFilterOptions { get; set; }

        public IDataFilterDescriptor DataFilterDescriptor { get; set; }
        protected DataFilterIntegratedTests()
        {
            DataFilter = ServiceProvider.GetService<IDataFilter>();
            DataFilterOptions = ServiceProvider.GetService<IOptions<DataFilterOptions>>().Value;
            DataFilterDescriptor = DataFilterOptions.Descriptors.GetValueOrDefault(typeof(ISoftDelete));
        }
    }
}
