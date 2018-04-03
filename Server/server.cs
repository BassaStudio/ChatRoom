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
        //static string ipadress = "192.168.1.2";
        static int port = 8080;
        static NetConnection server;
        static List<user> users = new List<user>();

        static bool isRunning = true;

        static string[] msgC = new string[] { "fl&" };
        static string[] dCom = new string[] { ":" };

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

            string user = connection.RemoteEndPoint.ToString();
            string[] usera = user.Split(dCom, StringSplitOptions.None);
            try { Int32.TryParse(usera[1], out port); }catch { balog.Info("can't not converte port this to a number"); }
            for (int i = 0; i < users.Count; i++)
            {
                if(users[i].port == port)
                {
                    users.RemoveAt(i);
                    users.Sort();
                    break;
                }
            }
        }

        private static void Server_OnDataReceived(object sender, NetConnection connection, byte[] e)
        {
            string msg = Encoding.UTF8.GetString(e);
            //balog.Info(msg);

            string[] msga = msg.Split(msgC, StringSplitOptions.None);

            string host = connection.RemoteEndPoint.ToString();
            string[] hosta = host.Split(dCom, StringSplitOptions.None);
            Int32.TryParse(hosta[1], out int p);

            if(msga[0] == "C$gi")
            {
                int clientP = 8081;

                try { Int32.TryParse(msga[2], out clientP);}
                catch (Exception) { balog.Error("can't convete " + msga[2].ToString() + "to a number"); }

                users.Add(new user { name = msga[1], ip = hosta[0], port = p, c = new NetConnection() });
                balog.Info(users[users.Count-1].name + "[" + users[users.Count-1].ip + ":" + clientP + "] " + "is connect");
                users[users.Count - 1].c.Connect(hosta[0], clientP);
            } else
            {
                foreach(var user in users)
                {
                    if(user.port == p)
                    {
                        send(user.name, msg);
                        break;
                    }
                }
            }

            balog.Info("Message from " + connection.RemoteEndPoint + " : " + Encoding.UTF8.GetString(e));
        }

        private static void Server_OnConnect(object sender, NetConnection connection)
        {
            balog.Info("Connect from " + connection.RemoteEndPoint.ToString());
            

        }

        private static void send(string from , string msg)
        {

            foreach (var client in users)
            {
                client.c.Send(Encoding.UTF8.GetBytes(from + ": " + msg));
            }
        }

        static void commandtest()
        {
            while (isRunning)
            {
                string command = Console.ReadLine();
                string[] stringSeparators = new string[] { " " };
                string[] result = command.Split(stringSeparators, StringSplitOptions.None);

                switch(result[0])
                {
                    case "end":
                        isRunning = false;
                        balog.Info("Closing server");
                        break;
                    case "send":
                        string mess = "";
                        for (int i = 1; i < result.Length; i++)
                        {
                            mess += result[i] + " "; 
                        }
                        send("Server", mess);

                        balog.Warn("You sendt: " + mess);
                        break;
                    case "online":
                        balog.Info("online: " + users.Count);
                        for (int i = 0; i < users.Count; i++)
                        {
                            balog.Info(i + " " + users[i].name);
                        }
                        break;

                    default:
                        balog.Info("This is not a command");
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

    class user
    {
        public string name { get; set; }
        public string ip { get; set; }
        public int port { get; set; }
        public NetConnection c { get; set; }
    }
}
