using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatProgram
{
    public partial class login : Form
    {
        Chat m_chat;

        public login(Chat chat)
        {
            InitializeComponent();
            m_chat = chat;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        //debug
            nametxt.Text = "bassa";
            iptxt.Text = "localhost";
            numtxt.Value = 8080;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32.TryParse(numtxt.Value.ToString(), out int port);
            m_chat.startup(nametxt.Text, iptxt.Text, port);
            this.Close();
        
        }

       
    }
}
