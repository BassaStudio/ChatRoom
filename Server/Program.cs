using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTCP;

namespace Server
{
    class Program
    {
        SimpleTcpServer serverf;

        static string ipadress = "192.168.0.1";
        static int port = 8910;

        static void Main(string[] args)
        {
            Console.WriteLine("IP: " + ipadress + ":" + port);
            sserver servers = new sserver(ipadress, port);
            sserver.begin();
            while (sserver.IsRunning) {

            };
            sserver.end();
        }
    }

    class sserver
    {
        static SimpleTcpServer serverf;

        static long m_ip;
        static int m_port;

        public static bool IsRunning
        {
            get { return serverf.IsStarted; }
        }

        public sserver(string ip, int port)
        {
            long.TryParse(ip, out m_ip);

            serverf = new SimpleTcpServer();
            serverf.Delimiter = 0x13; // enter
            serverf.StringEncoder = Encoding.Unicode;
            serverf.DataReceived += Serverf_DataReceived;

        }

        public static void begin()
        {
            System.Net.IPAddress b_ip = new System.Net.IPAddress(m_ip);
            Console.WriteLine("Starting server..");
            serverf.Start(b_ip, m_port);
        }

        public static void end()
        {
            if(serverf.IsStarted)
            {
                serverf.Stop();
            }
        }

        private void Serverf_DataReceived(object sender, Message e)
        {
            Console.WriteLine(e.TcpClient + ": " + e.MessageString);
        }

        
    }
}
