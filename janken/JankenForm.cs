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
    public partial class JankenForm : Form
    {
        LibJanken bt;
        Random random;
        const int GAME_PORT = 4096;
        IPAddress peer_address;
        ShowConfigFormDelegate show_config;
        LibUDP network;
        LibUDP.ListenerResponseDelegate listener_result_delegate;


        public JankenForm(ShowConfigFormDelegate show_config, IPAddress address)
        {
            InitializeComponent();
            this.show_config = show_config;
            lbl_result.Text = "";
            lbl_player2.Text = "";
            LibJanken.ResultDelegate result_delegate = new LibJanken.ResultDelegate(SetResult);
            this.bt = new LibJanken(result_delegate);
            this.random = new Random(1000);

            network = new LibUDP();
            peer_address = address;


            listener_result_delegate = new LibUDP.ListenerResponseDelegate(ListenerResponse);
            network.ListenMessage(GAME_PORT, listener_result_delegate);
        }
 
        private void SelectRock(object sender, EventArgs e)
        {
            bt.SetPlayer1(LibJanken.Choice.グー);
            network.SendMessage(GAME_PORT, peer_address, "0");
            LockSelect();
        }
        private void SelectScissors(object sender, EventArgs e)
        {
            bt.SetPlayer1(LibJanken.Choice.チョキ);
            network.SendMessage(GAME_PORT, peer_address, "1");
            LockSelect();
        }

        private void SelectPaper(object sender, EventArgs e)
        {
            bt.SetPlayer1(LibJanken.Choice.パー);
            network.SendMessage(GAME_PORT, peer_address, "2");
            LockSelect();

        }

        private void LockSelect()
        {
            btn_rock.Enabled = false;
            btn_scissors.Enabled = false;
            btn_paper.Enabled = false;
        }
        private void UnlockSelect()
        {
            btn_rock.Enabled = true;
            btn_scissors.Enabled = true;
            btn_paper.Enabled = true;
            network.ListenMessage(GAME_PORT, listener_result_delegate);
        }


        private void SetResult(LibJanken.Choice player1_choice, LibJanken.Choice player2_choice, LibJanken.Result result)
        {

            lbl_result.Text = Enum.GetName(typeof(LibJanken.Result), result);

            lbl_player2.Text = Enum.GetName(typeof(LibJanken.Choice), player2_choice);
        }
        
        public void ListenerResponse(String response, IPEndPoint peer_endpoint)
        {
            if(response == "9"){
                this.Close();
            }
            bt.SetPlayer2((LibJanken.Choice)int.Parse(response));
            UnlockSelect();
        }

        private void JankenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            show_config();
        }

        
    }
}
