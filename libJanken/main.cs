namespace mei1161
{
    public class libJanken
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

        private int player1_choice = 0;
        private bool player1_status = false;
        private int player2_choice = 0;
        private bool player2_status = false;
        private ResultDelegate result_delegate;

        public delegate void ResultDelegate(int player2_choice, int result);

        public libJanken(ResultDelegate result_delegate)
        {
            this.result_delegate = result_delegate;
        }

        public void SetPlayer1(int value)
        {
            player1_choice = value;
            player1_status = true;
            PlayButtle();
        }

        public void SetPlayer2(int value)
        {
            player2_choice = value;
            player2_status = true;
            PlayButtle();
        }



        public void PlayButtle()
        {
            if (player1_status && player2_status)
            {
                result_delegate(player2_choice, (player2_choice - player1_choice + 3) % 3);
                player1_status = player2_status = false;
            }
        }
    }
}
