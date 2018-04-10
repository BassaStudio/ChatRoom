using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObooltNet;

namespace ChatProgram
{
    public partial class Chat : Form
    {
        string m_name;
        string m_ipadress;
        int m_port;

        NetConnection m_sender;
        NetConnection m_resiver;

        login loginc;

        static string[] dCom = new string[] { ":" };

        public Chat()
        {
            InitializeComponent();
        }

        int myportr = 8081;

        public void startup(string name, string ipadress, int port)
        {

            m_name = name;
            m_ipadress = ipadress;
            m_port = port;

            this.Text = "Chat" + " : " + m_name; 


            m_sender = new NetConnection();
            m_sender.OnConnect += Client_OnConnect;
            m_sender.OnDisconnect += Client_OnDisconnect;

            m_resiver = new NetConnection();
            m_resiver.OnDataReceived += Resiver_OnDataReceived;

            Random r = new Random();
            myportr = r.Next(8000, 10000);

            try
            {
                m_sender.Connect(m_ipadress, m_port);
                m_resiver.Start(myportr);
                connectToolStripMenuItem.Text = "Exit";
            }
            catch
            {
                MessageBox.Show("can't find the server");
            }
        }

        private void Resiver_OnDataReceived(object sender, NetConnection connection, byte[] e)
        {
            string text = Encoding.UTF8.GetString(e) + "\n";
            logtxt.AppendText(text);
        }


        private void Client_OnConnect(object sender, NetConnection connection)
        {
            string text = "Connect to " + connection.RemoteEndPoint.ToString() + "\n";
            logtxt.AppendText(text);
            this.m_sender.Send(Encoding.UTF8.GetBytes("C$gi" + "fl&" + m_name + "fl&" + myportr.ToString()));
        }

        private void Client_OnDisconnect(object sender, NetConnection connection)
        {
            string text = "\n" + "disconect from " + connection.RemoteEndPoint.ToString() + "\n";
            logtxt.AppendText(text);
        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void send(string Message)
        {
            try
            {
                m_sender.Send(Encoding.UTF8.GetBytes(Message));
                holdertxt.Text = "";

            }
            catch (Exception e)
            {
                string text = "can't send this message\n";
               logtxt.AppendText(text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            send(holdertxt.Text);
        }

        private void holdertxt_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            e.SuppressKeyPress = false;
            

            if(e.KeyCode == Keys.Enter)
            {
                send(holdertxt.Text);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connectToolStripMenuItem.Text == "connect") {
                loginc = new login(this);
                loginc.ShowDialog();
            } else if(connectToolStripMenuItem.Text == "Exit")
            {
                Application.Exit();
            }
        }
    }
}
