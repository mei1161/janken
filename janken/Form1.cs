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
        Buttle bt = new Buttle();
        private int choice;
        public int getChoice()
        {
            return choice;
        }

       
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            choice = 1;
            set_buttle();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            choice = 2;
            set_buttle();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            choice = 3;
            set_buttle();
        }
        private void set_buttle()
        {
            bt.buttle(getChoice());
            label1.Text = bt.show_Result();
            label2.Text = bt.show_Opponent();
        }


    }
}
