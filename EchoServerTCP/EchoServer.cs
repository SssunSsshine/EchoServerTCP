using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EchoServerTCP
{
    public class EchoServer
    {
        //Stream sr;
        //Stream sw;
        TcpClient client;
        public EchoServer(TcpClient tcpc)
        {
            client = tcpc;
        }

        public void Conversation()
        {
            try
            {
                Console.WriteLine("Connection accepted");

                //sr = new Stream(client.GetStream());

                //sw = new Stream();
                byte[] myReadBuffer = new byte[1024];

                int numberOfBytesRead = client.GetStream().Read(myReadBuffer, 0, myReadBuffer.Length);
                while(numberOfBytesRead > 0)
                {
                    String s = Encoding.UTF8.GetString(myReadBuffer,0, numberOfBytesRead).Trim();
                    Console.WriteLine(s);
                    client.GetStream().Write(myReadBuffer, 0, numberOfBytesRead);
                    numberOfBytesRead = client.GetStream().Read(myReadBuffer, 0, myReadBuffer.Length);
                    /*Console.WriteLine("Message recieved: " + incoming);
                    sw.WriteLine(incoming);
                    sw.Flush();
                    Console.WriteLine("Message Sent back: " + incoming);
                    incoming = sr.ReadLine();*/
                }

                Console.WriteLine("Client sent '.': closing connection.");
                /*sr.Close();
                sw.Close();*/
                client.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e + " " + e.StackTrace);
            }
            finally
            {
                /*if (sr != null) sr.Close();
                if (sw != null) sw.Close();*/
                if (client != null) client.Close();
            }
        }
    }
}
