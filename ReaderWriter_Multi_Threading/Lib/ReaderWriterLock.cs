using System;
using System.Threading;

namespace Lib;

public sealed class SimpleReaderWriterLock : IDisposable
{
    // Protects the internal state.
    private readonly Mutex _stateMutex = new();

    // Ensures only one writer owns the write lock at a time.
    private readonly Mutex _writerMutex = new();

    // Signalled when readers are allowed to enter.
    private readonly ManualResetEvent _noWriter = new(true);

    // Signalled when no readers are active.
    private readonly ManualResetEvent _noReaders = new(true);

    private int _activeReaders = 0;
    private bool _writerActive = false;

    public void EnterReadLock()
    {
        while (true)
        {
            // Wait while a writer is active.
            _noWriter.WaitOne();

            _stateMutex.WaitOne();

            try
            {
                // Recheck after acquiring the mutex.
                if (!_writerActive)
                {
                    _activeReaders++;

                    if (_activeReaders == 1)
                    {
                        _noReaders.Reset();
                    }

                    return;
                }
            }
            finally
            {
                _stateMutex.ReleaseMutex();
            }
        }
    }

    public void ExitReadLock()
    {
        _stateMutex.WaitOne();

        try
        {
            if (_activeReaders <= 0)
            {
                throw new InvalidOperationException(
                    "No reader currently holds the lock.");
            }

            _activeReaders--;

            if (_activeReaders == 0)
            {
                _noReaders.Set();
            }
        }
        finally
        {
            _stateMutex.ReleaseMutex();
        }
    }

    public void EnterWriteLock()
    {
        // Serialize writers.
        _writerMutex.WaitOne();

        try
        {
            _stateMutex.WaitOne();

            try
            {
                _writerActive = true;

                // Prevent new readers from entering.
                _noWriter.Reset();
            }
            finally
            {
                _stateMutex.ReleaseMutex();
            }

            // Wait until every existing reader has exited.
            _noReaders.WaitOne();
        }
        catch
        {
            _writerMutex.ReleaseMutex();
            throw;
        }
    }

    public void ExitWriteLock()
    {
        _stateMutex.WaitOne();

        try
        {
            if (!_writerActive)
            {
                throw new InvalidOperationException(
                    "No writer currently holds the lock.");
            }

            _writerActive = false;

            // Allow readers to attempt entry again.
            _noWriter.Set();
        }
        finally
        {
            _stateMutex.ReleaseMutex();
            _writerMutex.ReleaseMutex();
        }
    }

    public void Dispose()
    {
        _noWriter.Dispose();
        _noReaders.Dispose();
        _stateMutex.Dispose();
        _writerMutex.Dispose();
    }
}