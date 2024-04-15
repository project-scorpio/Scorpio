using System.Threading.Tasks;

using Scorpio.Middleware.Pipeline;

namespace Scorpio.Middleware
{
    public class DoublyMethodMiddleware
    {
        private readonly PipelineRequestDelegate<TestPipelineContext> _next;

        public DoublyMethodMiddleware(PipelineRequestDelegate<TestPipelineContext> next) => _next = next;
        public async Task InvokeAsync(TestPipelineContext context)
        {
            context.PipelineInvoked = true;
            await _next(context);
        }

        public void Invoke(TestPipelineContext context) => context.PipelineInvoked = true;
    }
}