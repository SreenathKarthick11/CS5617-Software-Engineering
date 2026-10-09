
using System;
using System.Threading;
using Lib;

class Program
{
    private static readonly SimpleReaderWriterLock RwLock = new();
    private static readonly ManualResetEvent StartEvent = new(false);

    private static int _sharedValue = 0;

    static void Main()
    {
        Thread[] threads = new Thread[5];

        for (int i = 0; i < 3; i++)
        {
            int id = i + 1;
            threads[i] = new Thread(() => Reader(id));
        }

        for (int i = 0; i < 2; i++)
        {
            int id = i + 1;
            threads[i + 3] = new Thread(() => Writer(id));
        }

        foreach (Thread thread in threads)
        {
            thread.Start();
        }

        Console.WriteLine("Press Enter to start...");
        Console.ReadLine();

        StartEvent.Set();

        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        StartEvent.Dispose();
        RwLock.Dispose();

        Console.WriteLine($"Final value: {_sharedValue}");
    }

    static void Reader(int id)
    {
        StartEvent.WaitOne();

        for (int i = 0; i < 3; i++)
        {
            RwLock.EnterReadLock();

            try
            {
                Console.WriteLine(
                    $"Reader {id} reads {_sharedValue}");

                Thread.Sleep(200);
            }
            finally
            {
                RwLock.ExitReadLock();
            }

            Thread.Sleep(100);
        }
    }

    static void Writer(int id)
    {
        StartEvent.WaitOne();

        for (int i = 0; i < 2; i++)
        {
            RwLock.EnterWriteLock();

            try
            {
                _sharedValue++;

                Console.WriteLine(
                    $"Writer {id} writes {_sharedValue}");

                Thread.Sleep(300);
            }
            finally
            {
                RwLock.ExitWriteLock();
            }

            Thread.Sleep(100);
        }
    }
}