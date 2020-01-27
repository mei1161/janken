using System;
using System.Net;
using System.Windows.Forms;
using static mei1161.LibJanken;
using static mei1161.LibUDP;

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
        ListenerResponseDelegate listener_result_delegate;


        public JankenForm(ShowConfigFormDelegate show_config, IPAddress address)
        {
            InitializeComponent();
            this.show_config = show_config;
            lbl_result.Text = "";
            lbl_player1.Text = "";
            lbl_player2.Text = "";
            ResultDelegate result_delegate = new ResultDelegate(JankenResponse);
            this.bt = new LibJanken(result_delegate);
            this.random = new Random(1000);

            network = new LibUDP();
            peer_address = address;


            listener_result_delegate = new ListenerResponseDelegate(ListenerResponse);
            network.ListenMessage(GAME_PORT, listener_result_delegate);
        }
 
        //グーを選択した場合
        private void SelectRock(object sender, EventArgs e)
        {
            if (!bt.SetPlayer1(Choice.グー))
            {
                LockSelect();
            }
            network.SendMessage(GAME_PORT, peer_address, "0");
        }
        //チョキを選択した場合
        private void SelectScissors(object sender, EventArgs e)
        {
            if (!bt.SetPlayer1(Choice.チョキ))
            {
                LockSelect();
            }
            network.SendMessage(GAME_PORT, peer_address, "1");
        }
        //パーを選択した場合
        private void SelectPaper(object sender, EventArgs e)
        {
            
            if (!bt.SetPlayer1(Choice.パー))
            {
                LockSelect();
            }

            network.SendMessage(GAME_PORT, peer_address, "2");

        }
        //1度選んだら、じゃんけんが終了するまで変更ができないようにする
        private void LockSelect()
        {
            btn_rock.Enabled = false;
            btn_scissors.Enabled = false;
            btn_paper.Enabled = false;
        }
        //じゃんけん終了後、もう一度選択可能にする
        private void UnlockSelect()
        {
            btn_rock.Enabled = true;
            btn_scissors.Enabled = true;
            btn_paper.Enabled = true;
        }

        private void JankenResponse(Choice player1_choice, Choice player2_choice, Result result)
        {
            //じゃんけんの結果を返す(非同期的に実行する)
            BeginInvoke(new SetResultDelegate(SetResult), new object[] { player1_choice, player2_choice, result });
        }
        //じゃんけんの結果を設定する
        private void SetResult(Choice player1_choice, Choice player2_choice, Result result)
        {
            //結果をテキストに設定
            lbl_result.Text = result.ToString();
            //プレイヤー1,2の選択をテキストに設定
            lbl_player1.Text = player1_choice.ToString();
            lbl_player2.Text = player2_choice.ToString();
            //選択の初期化(もう一度選択ができるようになる)
            UnlockSelect();
        }

        public void ListenerResponse(String response, IPEndPoint peer_endpoint)
        {
            if(response == "9")
            {
                //スレッドを終了させる
                network.CloseListener();
                //フォームを閉じる
                this.Close();
            }
            //プレイヤー2の設定をする
            bt.SetPlayer2((Choice)int.Parse(response));
            try
            {
                network.ListenMessage(GAME_PORT, listener_result_delegate);
            }catch(Exception e)
            {
                BeginInvoke(new ShowMessageDelegate(ShowMessage), new object[] { e.Message });
            }
        }

        private void JankenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //スレッドを終了させる
            network.SendMessage(GAME_PORT, peer_address, "9");
            network.CloseListener();
            //configフォームを表示
            show_config();
        }
        //メッセージボックスを表示
        private void ShowMessage(String message)
        {
            MessageBox.Show(message);
        }

        
    }
}
