using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QuotesServer
{
    public class QuoteServer
    {
        private TcpListener _listener;
        private int port;
        private string filename;
        private List<string> quotes;
        private Random random;
        private Task listenerTask;

        public QuoteServer() : this ("quotes.txt")
        {
        }
        public QuoteServer(string filename) : this (filename, 7890)
        {
        }

        public QuoteServer(string filename, int port)
        {
            Contract.Requires<ArgumentNullException>(filename != null);
            Contract.Requires<ArgumentException>(port >= IPEndPoint.MinPort && port <= IPEndPoint.MaxPort);

            this.filename = filename;
            this.port = port;
        }

        public void ReadQuotes()
        {
            try
            {
                quotes = File.ReadAllLines(filename).ToList();
                if (quotes.Count == 0)
                {
                    throw new QuoteException("Quotes file is empty or not found.");
                }

                random = new Random();
            }
            catch (IOException ex)
            {
                throw new QuoteException("I/O Error", ex);
            }
        }

        protected string GetRandomQuoteOfTheDay()
        {
            int index = random.Next(0, quotes.Count - 1);
            return quotes[index];
        }

        protected void Listener()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Any;
                _listener = new TcpListener(ipAddress, port);
                _listener.Start();

                while (true)
                {
                    Socket clientSocket = _listener.AcceptSocket();
                    string message = GetRandomQuoteOfTheDay();
                    var encoder = new UnicodeEncoding();
                    byte[] buffer = encoder.GetBytes(message);
                    clientSocket.Send(buffer, buffer.Length, 0);
                    clientSocket.Close();
                }
            }
            catch (SocketException se)
            {
                Trace.TraceError($"QuoteServer: {se.Message}");
                throw new QuoteException("Socket error", se);
            }
        }

        public void Start()
        {
            ReadQuotes();

            listenerTask = Task.Factory.StartNew(Listener, TaskCreationOptions.LongRunning);
        }
        public void Stop()
        {
            _listener.Stop();
        }
        public void Suspend()
        {
            _listener.Stop();
        }
        public void Resume()
        {
            _listener.Start();
        }

        public void RefreshQuotes()
        {
            ReadQuotes();
        }
    }

    [Serializable]
    internal class QuoteException : Exception
    {
        public QuoteException()
        {
        }

        public QuoteException(string message) : base(message)
        {
        }

        public QuoteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected QuoteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
