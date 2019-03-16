using System;
using System.CodeDom;
using System.IO;
using System.Security.Cryptography;
using Microsoft.Ajax.Utilities;     //Comes from package AjaxMin    

using Cons = System.Console;

namespace ConsoleA1._16_ErrorAndExceptions
{
    class SexyColdCall
    {
        public static void Start()
        {
            Cons.Write($"File name:");
            string file = Cons.ReadLine();
            var callList = new ccFileReader();

            try
            {
                callList.Open(file);
                for (var i = 0; i < callList.NList; i++)
                {
                    callList.ProcessNext();
                    Cons.ReadLine();
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

    class ccFileReader : IDisposable
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

        public uint NList
        {
            get
            {
                if (isDisposed)
                {
                    throw new ObjectDisposedException("ccFileReader");
                }

                if (!isOpen)
                {
                    throw new UnexpectedException("Attempt to access cold call file that is not open!");
                }

                return nList;
            }
        }

        public void Dispose()
        {
            if (isDisposed)
            {
                return;
            }

            isDisposed = true;
            isOpen = false;

            if (fS != null)
            {
                fS.Close();
                fS = null;
            }

        }

        public void ProcessNext()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("ccFileReader");
            }

            if (!isOpen)
            {
                throw new UnexpectedException("Attempt to access ccFile file that is not open");
            }

            try
            {
                string name;
                name = sR.ReadLine();
                if (name == null)
                {
                    throw new ccFileFormatException("Not enough names in the file!");
                }

                if (name[0] == 'B')
                {
                    throw new ssFoundException(name);
                }

                Cons.WriteLine(name);
            }
            catch (ssFoundException ssE)
            {
                Cons.WriteLine(ssE.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

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

    class ssFoundException : Exception
    {
        public ssFoundException(string spyName) : base("Sales spy found, with name " + spyName)
        {
        }

        public ssFoundException(string spyName, Exception innerException) : base("Sales spy found with name " + spyName,
            innerException)
        {
        }
    }

    public class UnexpectedException : Exception
    {
        public UnexpectedException(string message) : base (message)
        {
        }

        public UnexpectedException(string message, Exception inExp) : base (message, inExp)
        {
        }
    }
}
