using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class NullAsyncDispose : IAsyncDisposable
    {

        /// <summary>
        /// 
        /// </summary>
        public static readonly NullAsyncDispose Instance = new NullAsyncDispose();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValueTask DisposeAsync() => new ValueTask();
    }
}