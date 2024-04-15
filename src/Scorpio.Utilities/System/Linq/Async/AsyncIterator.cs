using System.Threading.Tasks;

namespace System.Linq.Async
{
    internal abstract class AsyncIterator<TSource> : AsyncIteratorBase<TSource>
    {
        protected TSource _current = default!;

        public override TSource Current => _current;

        public override ValueTask DisposeAsync()
        {
            _current = default!;

            return base.DisposeAsync();
        }
    }
}