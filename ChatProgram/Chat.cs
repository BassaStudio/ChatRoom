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

        NetConnection client;

        public Chat()
        {
            InitializeComponent();
        }

        public void startup(string name, string ipadress, int port)
        {
            m_name = name;
            m_ipadress = ipadress;
            m_port = port;

            client = new NetConnection();
            client.OnConnect += Client_OnConnect;
            client.OnDataReceived += Client_OnDataReceived;
            client.OnDisconnect += Client_OnDisconnect;
            try
            {
                client.Connect(m_ipadress, m_port);
            } catch
            {
                MessageBox.Show(m_ipadress + ":" + m_port + " has no server");
            }
        }



        private void Client_OnConnect(object sender, NetConnection connection)
        {
            string text = "Connect to " + connection.RemoteEndPoint.ToString() + "\n";
            logtxt.AppendText(text);
        }

        private void Client_OnDataReceived(object sender, NetConnection connection, byte[] e)
        {
            string text = "\n" + "message from server " + Encoding.UTF8.GetString(e);
            logtxt.AppendText(text);
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
                client.Send(Encoding.UTF8.GetBytes(Message));
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
    }
}
