using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ObooltNet;

namespace Server
{
    class Program
    {
        static string ipadress = "192.168.1.2";
        static int port = 8080;
        static NetConnection server;

        static bool isRunning = true;

        static void Main(string[] args)
        {
            server = new NetConnection();

            server.OnConnect += Server_OnConnect;
            server.OnDataReceived += Server_OnDataReceived;
            server.OnDisconnect += Server_OnDisconnect;
            Thread c = new Thread(commandtest);
            try { 
                server.Start(port);
                balog.Info("Starting server on " + port);
                c.Start();
            }catch(Exception e)
            {
                balog.Error(e.ToString());
            }
            while (isRunning) ;
        }

        private static void Server_OnDisconnect(object sender, NetConnection connection)
        {
            balog.Info("Disconnect from " + connection.RemoteEndPoint.ToString());
        }

        private static void Server_OnDataReceived(object sender, NetConnection connection, byte[] e)
        {
            balog.Info("Message from " + connection.RemoteEndPoint + " : " + Encoding.UTF8.GetString(e));
        }

        private static void Server_OnConnect(object sender, NetConnection connection)
        {
            balog.Info("Connect from " + connection.RemoteEndPoint.ToString());
        }

        static void commandtest()
        {
            while (isRunning)
            {
                string command = Console.ReadLine();
                switch(command)
                {
                    case "end":
                        isRunning = false;
                        balog.Info("Closing server");
                        break;

                    default:
                        balog.Info("Thos is not a command");
                        break;
                }
            }
        }
    }

    class balog
    {
        public static void Info(string txt)
        {
            Console.ForegroundColor = ConsoleColor.White;
            string mes = "\r[Info] " + txt;
            Console.WriteLine(mes);
            Console.ResetColor();
            Console.Write("\r>");
        }

        public static void Warn(string txt)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string mes = "\r[Warn] " + txt;
            Console.WriteLine(mes);
            Console.ResetColor();
            Console.Write("\r>");
        }

        public static void Error(string txt)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string mes = "\r[Error] " + txt;
            Console.WriteLine(mes);
            Console.ResetColor();
            Console.Write("\r>");
        }
    }
}
