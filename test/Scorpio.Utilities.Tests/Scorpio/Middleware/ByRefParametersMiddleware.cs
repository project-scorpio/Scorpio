using System.Threading.Tasks;

using Scorpio.Middleware.Pipeline;

namespace Scorpio.Middleware
{
    public class ByRefParametersMiddleware
    {
        private readonly PipelineRequestDelegate<TestPipelineContext> _next;

        public ByRefParametersMiddleware(PipelineRequestDelegate<TestPipelineContext> next) => _next = next;
        public Task InvokeAsync(TestPipelineContext context, ref int age)
        {
            age = 100;
            context.PipelineInvoked = true;
            return _next(context);
        }
    }
}