using System.Collections;
using System.Collections.Generic;

namespace System.Linq.Async
{
    internal class TestEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _source;

        public TestEnumerable(IEnumerable<T> source) => _source = source;
        public IEnumerator<T> GetEnumerator() => _source.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _source.GetEnumerator();
    }
}