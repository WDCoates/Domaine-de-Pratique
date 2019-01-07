using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using con = System.Console;

namespace ConsoleA1._21_Tasks_Threads_Synchronization
{
    internal static class ReaderWriterSim
    {
        private static List<int> items = new List<int>() {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
        private static ReaderWriterLockSlim rwls = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        internal static void ReaderMethod(object reader)
        {
            try
            {
                rwls.EnterReadLock();

                for (int i = 0; i < items.Count; i++)
                {
                    con.WriteLine($"Reader {reader}, loop: {i}, item: {items[i]}");
                    Thread.Sleep(40);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                rwls.ExitReadLock();
            }
        }

        internal static void WriteMethod(object writer)
        {
            try
            {
                while (!rwls.TryEnterWriteLock(50))
                {
                    con.WriteLine($"Writer {writer} waiting for the write lock!");
                    con.WriteLine($"Current reader count: {rwls.CurrentReadCount}");
                }
                con.WriteLine($"Writer {writer} acquired the lock");
                for (int i = 0; i < items.Count; i++)
                {
                    items[i]++;
                    Thread.Sleep(50);
                }
                con.WriteLine($"Writer {writer} finished.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                rwls.ExitWriteLock();
            }
        }
    }
}
