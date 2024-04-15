using Scorpio.Middleware.Pipeline;

namespace Scorpio.Middleware
{
    public class NotTaskMiddleware
    {
        private readonly PipelineRequestDelegate<TestPipelineContext> _next;

        public NotTaskMiddleware(PipelineRequestDelegate<TestPipelineContext> next) => _next = next;

        public void Invoke(TestPipelineContext context)
        {
            context.PipelineInvoked = true;
            _next(context).Wait();
        }

    }
}