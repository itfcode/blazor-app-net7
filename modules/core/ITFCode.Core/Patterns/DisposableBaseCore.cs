﻿namespace ITFCode.Core.Patterns
{
    // https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
    public abstract class DisposableBaseCore : IDisposable
    {
        // To detect redundant calls
        private bool _disposedValue;

        ~DisposableBaseCore() => Dispose(false);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }
    }
}