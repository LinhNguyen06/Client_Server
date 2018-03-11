using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Loopback, 1234);
            server.Bind(ip);
            StreamReader sr = new StreamReader("../../TextFile1.txt");
            string readFile = sr.ReadToEnd();
            Console.Write(readFile);
            sr.Close();
            server.Listen(4);
            Socket client = server.Accept();
            byte[] nhan = new byte[1024 * 60];
            int rec = client.Receive(nhan);
            string sNhan = Encoding.ASCII.GetString(nhan, 0, rec);
            Console.WriteLine("Client gui: " + sNhan);
            byte[] gui = Encoding.ASCII.GetBytes(readFile);
            client.Send(gui);
        }
    }
}
