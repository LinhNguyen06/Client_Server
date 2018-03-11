using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            client.Connect(ipServer);
            string cGui = "Send File Text1";
            byte[] gui = Encoding.ASCII.GetBytes(cGui);
            client.Send(gui);
            byte[] nhan = new byte[1024 * 60];
            int rec = client.Receive(nhan);
            string cNhan = Encoding.ASCII.GetString(nhan, 0, rec);
            StreamWriter sw = new StreamWriter("..//..//TextFile1.txt");
            sw.Write(cNhan);
            sw.Close();
            Console.WriteLine("Server gui: " + cNhan);
        }
    }
}
