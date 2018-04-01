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
    public partial class Chat : Form
    {
        string m_name;
        string m_ipadress;
        int m_port;

        public Chat(string name, string ipadress, int port)
        {
            InitializeComponent();

            m_name = name;
            m_ipadress = ipadress;
            m_port = port;
        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
