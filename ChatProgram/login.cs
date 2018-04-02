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
        Chat Chat = new Chat();

        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        //debug
            nametxt.Text = "bassa";
            iptxt.Text = "localhost";
            porttxt.Text = "8080";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Chat.startup(nametxt.Text, iptxt.Text, Convert.ToInt32(porttxt.Text));
            Chat.Show();
            this.Hide();
        }
    }
}
