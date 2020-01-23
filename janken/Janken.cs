using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace mei1161
{
    public partial class Janken : Form
    {
        libJanken bt;
        Random random;


        public Janken()
        {
            InitializeComponent();
            lbl_result.Text = "";
            lbl_player2.Text = "";
            libJanken.ResultDelegate result_delegate = new libJanken.ResultDelegate(SetResult);
            this.bt = new libJanken(result_delegate);
            this.random = new Random(1000);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bt.SetPlayer1((int)libJanken.Choice.グー);
            bt.SetPlayer2(random.Next(1, 3));
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            bt.SetPlayer1((int)libJanken.Choice.チョキ);
            bt.SetPlayer2(random.Next(1, 3));
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            bt.SetPlayer1((int)libJanken.Choice.パー);
            bt.SetPlayer2(random.Next(1, 3));
        }


        private void SetResult(int player2_choice, int result)
        {

            lbl_result.Text = Enum.GetName(typeof(libJanken.Result), result);

            lbl_player2.Text = Enum.GetName(typeof(libJanken.Choice), player2_choice);
        }

    }
}
