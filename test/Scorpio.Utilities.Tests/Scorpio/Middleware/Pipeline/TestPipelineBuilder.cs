using System;
using System.Threading.Tasks;

namespace Scorpio.Middleware.Pipeline
{
    public class TestPipelineBuilder : PipelineBuilder<TestPipelineContext>
    {
        public TestPipelineBuilder(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override PipelineRequestDelegate<TestPipelineContext> TailDelegate => context => Task.CompletedTask;
    }
}