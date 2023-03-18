using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EchoClient
{
    public class Client : TcpClient
    {
        public Client(String host)
        {
            base.Connect(host, 7);
        }
    }
}
