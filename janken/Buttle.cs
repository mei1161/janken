using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace janken
{
    class Buttle
    {
        private int player2 = 1;
        private string result;
        private string opponent;
        public string show_Result()
        {
            return result;
        }
        public string show_Opponent()
        {
            return opponent;
        }
        public void buttle(int choice)
        {
            if ((player2 - choice + 3) % 3 == 0)
            {
                result = "あいこ";
            }
            else if ((player2 - choice + 3) % 3 == 1)
            {
                result = "あなたのかち";
            }
            else if ((player2 - choice + 3) % 3 == 2)
            {
                result = "あなたのまけ";
            }
            switch (player2)
            {
                case 1: opponent= "相手:グー"; break;
                case 2: opponent = "相手:チョキ"; break;
                case 3: opponent = "相手:パー"; break;
            }

        }
    }
}
