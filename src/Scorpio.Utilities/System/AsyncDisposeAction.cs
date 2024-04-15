using System.Threading.Tasks;

using Scorpio;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AsyncDisposeAction : IAsyncDisposable
    {
        private readonly Func<ValueTask> _action;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public AsyncDisposeAction(Func<ValueTask> action) => _action = Check.NotNull(action, nameof(action));

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        private async ValueTask DisposeCoreAsync(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    await _action();
                }
                _disposedValue = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public ValueTask DisposeAsync() => DisposeCoreAsync(true);
        #endregion

    }
}