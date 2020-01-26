using System;
using static mei1161.LibJanken;

namespace mei1161
{
    public delegate void ShowConfigFormDelegate();
    public delegate void SetResultDelegate(Choice player1_choice, Choice player2_choice, Result result);
    public delegate void ShowMessageDelegate(String message);
}
