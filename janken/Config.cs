using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mei1161
{
    public partial class Config : Form
    {
        libNetwork network;
        public Config()
        {
            InitializeComponent();
            network = new libNetwork();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            network.SendBroadcastMessage(10000, "Hello");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            libNetwork.BroadcastResponseDelegate result_delegate = new libNetwork.BroadcastResponseDelegate(Response);
            network.ListenBroadcastMessage(10000, result_delegate);
        }

        public void Response(String message, IPEndPoint endpoint)
        {
            MessageBox.Show(message);
            
        }
    }
}
