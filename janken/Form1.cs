using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace janken
{
    public partial class Form1 : Form
    {
        public int choice;
        public int player2 = 2; 
        private void battle()
        {
            if ((player2-choice +3) % 3 == 0)
            {
                label1.Text = "あいこ";
            }
            else if ((player2-choice +3) % 3 == 1)
            {
                label1.Text = "あなたのかち";
            }
            else if ((player2-choice+3) % 3 == 2)
            {
                label1.Text = "あなたのまけ";
            }
            switch (player2)
            {
                case 1: label2.Text = "相手:グー";break;
                case 2: label2.Text = "相手:チョキ";break;
                case 3: label2.Text = "相手:パー";break;
            }

        }
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            choice = 1;
            battle();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            choice = 2;
            battle();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            choice = 3;
            battle();
        }


    }
}
