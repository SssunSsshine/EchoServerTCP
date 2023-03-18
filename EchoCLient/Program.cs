using EchoClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EchoCLient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client conversant = null;
            StreamWriter sw = null;
            StreamReader sr = null;
            try
            {
                String host = args.Length == 1 ? args[0] : "127.0.0.1";

                conversant = new Client(host);

                NetworkStream ns = conversant.GetStream();
                
                sw = new StreamWriter(ns);
                
                sr= new StreamReader(ns);

                String input;
                Console.WriteLine("Enter text: '.' to stop: ");

                while((input = Console.ReadLine()) != ".") {
                    sw.WriteLine(input);
                    sw.Flush();

                    String returnData = sr.ReadLine();
                    Console.WriteLine("Reply from " + host + ":" + returnData);
                    Console.WriteLine("Enter text: '.' to stop: ");
                }

                sw.WriteLine(".");
                sw.Flush();

            }catch(Exception ex)
            {
                Console.WriteLine(ex + " " + ex.StackTrace);
            }
            finally
            {
                if (sw != null) sw.Close();
                if (sr != null) sr.Close();
                if (conversant!= null) conversant.Close();
            }
        }
    }
}
