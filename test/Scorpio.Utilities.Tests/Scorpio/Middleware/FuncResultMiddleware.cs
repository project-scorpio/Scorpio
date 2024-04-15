using System.Threading.Tasks;

using Scorpio.Middleware.Pipeline;

namespace Scorpio.Middleware
{
    public class FuncResultMiddleware
    {
        private readonly PipelineRequestDelegate<TestPipelineContext> _next;

        public FuncResultMiddleware(PipelineRequestDelegate<TestPipelineContext> next) => _next = next;
        public async Task<string> InvokeAsync(TestPipelineContext context)
        {
            context.PipelineInvoked = true;
            await _next(context);
            return "";
        }
    }
}