using Scorpio.Middleware.Pipeline;

namespace Scorpio.Middleware
{
    public class NonMethodMiddleware
    {
        private readonly PipelineRequestDelegate<TestPipelineContext> _next;

        public NonMethodMiddleware(PipelineRequestDelegate<TestPipelineContext> next) => _next = next;

        public void Execute(TestPipelineContext context) => _next(context).Wait();


    }
}