using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cons = System.Console;

namespace ConsoleA1._16_ErrorAndExceptions
{
    class SexyColdCall
    {
        static void Start()
        {
            Cons.Write($"File name:");
            string file = Cons.ReadLine();
            var callList = new ccFileReader();

            try
            {
                callList.Open(file);
                for (var i = 0; i < callList.nList; i++)
                {
                    callList.ProcessNextOnList();
                }

                Cons.WriteLine($"All on the list called.");
            }
            catch (FileNotFoundException e)
            {
                Cons.WriteLine($"File entered could not be found!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                callList.Dispose();
            }

            Cons.ReadLine();
        }
    }

    class ccFileReader: IDisposable
    {
    private FileStream fS;
    private StreamReader sR;
    private uint nList;
    private bool isDisposed = false;
    private bool isOpen = false;

    internal void Open(string file)
    {
        if (isDisposed)
            throw new ObjectDisposedException("callList");

        fS = new FileStream(file, FileMode.Open);
        sR = new StreamReader(fS);

        try
        {
            string fLine = sR.ReadLine();
            nList = uint.Parse(fLine);
            isOpen = true;
        }
        catch (FormatException e)
        {
            throw new ccFileFormatException("First like isn\'t an integer", e);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    class ccFileFormatException : Exception
    {
        public ccFileFormatException(string message) : base(message)
        {
        }

        public ccFileFormatException(string message, Exception iException)
            : base(message, iException)
        {
        }

    }
}
