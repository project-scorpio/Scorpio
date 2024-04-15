namespace System.Linq.Async
{
    internal enum AsyncIteratorState
    {
        New = 0,
        Allocated = 1,
        Iterating = 2,
        Disposed = -1,
    }
}