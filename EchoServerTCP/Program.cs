using System;
using System.Net.Sockets;
using System.Threading;

namespace EchoServerTCP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                int portNumber = 7;
                server = new TcpListener(portNumber);
                server.Start();
                Console.WriteLine("Echo server running on port 7");
                for(; ; )
                {
                    EchoServer es = new EchoServer(server.AcceptTcpClient());
                    Thread serverThread = new Thread(
                        new ThreadStart(es.Conversation));
                    serverThread.Start();
                }
            }catch(Exception e)
            {
                Console.WriteLine(e + " " + e.StackTrace);
            }
            finally
            {
                server.Stop();
            }
        }
    }
}
