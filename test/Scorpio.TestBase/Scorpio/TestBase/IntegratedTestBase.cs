using System;

namespace Scorpio.TestBase
{
    public abstract class IntegratedTestBase : TestBaseWithServiceProvider, IDisposable
    {
        private bool _disposedValue;

        protected abstract IBootstrapper Bootstrapper { get; }


        protected virtual void SetBootstrapperCreationOptions(BootstrapperCreationOptions options)
        {

        }

        protected virtual void DisposeInternal(bool disposing)
        {

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Bootstrapper.Shutdown();
                    Bootstrapper.Dispose();
                    DisposeInternal(disposing);
                }


                _disposedValue = true;
            }
        }


        public void Dispose()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}