namespace mei1161
{
    public class LibJanken
    {
        public enum Result : int
        {
            引き分け = 0,
            勝ち = 1,
            負け = 2
        }
        public enum Choice : int
        {
            グー = 0,
            チョキ = 1,
            パー = 2
        }

        private Choice player1_choice = 0;
        private bool player1_status = false;
        private Choice player2_choice = 0;
        private bool player2_status = false;
        private ResultDelegate result_delegate;

        //じゃんけんの結果を返すコールバック関数
        public delegate void ResultDelegate(Choice player1_choice, Choice player2_choice, Result result);

        //コンストラクタ
        public LibJanken(ResultDelegate result_delegate)
        {
            this.result_delegate = result_delegate;
        }

        //Player1の設定をする
        public bool SetPlayer1(Choice value)
        {
            player1_choice = value;
            player1_status = true;
            bool status = (player1_status && player2_status);
            PlayButtle();
            return status;
        }

        //Player2の設定をする
        public bool SetPlayer2(Choice value)
        {
            player2_choice = value;
            player2_status = true;
            bool status = (player1_status && player2_status);
            PlayButtle();
            return status;
        }

        //じゃんけんの結果を返し、ステータスを初期化する
        public void PlayButtle()
        {
            if (player1_status && player2_status)
            {
                result_delegate(player1_choice, player2_choice, (Result)((player2_choice - player1_choice + 3) % 3));
                //ステータス初期化
                player1_status = player2_status = false;
            }
        }
    }
}
