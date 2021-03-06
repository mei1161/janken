﻿using System;
using System.Net;
using System.Windows.Forms;
using static mei1161.LibUDP;

namespace mei1161
{
    public partial class ConfigForm : Form
    {
        const int SENDER_PORT = 1024;
        const int RECEVER_PORT = 2048;
        LibUDP network;
        bool button_state = true;
        JankenForm janken_form;
        IPAddress test;
        ListenerExceptionDelegate listener_exception_delegate;

        public delegate void JankenFormDelegate(IPAddress address);
        public delegate void ListenerEndDelegate();
        public delegate void SenderEndDelegate();

        public ConfigForm()
        {
            InitializeComponent();
            network = new LibUDP();
            listener_exception_delegate = new ListenerExceptionDelegate(ShowExceptionMessage);
            textBox1.Text = "";

        }

        private void ListenerClick(object sender, EventArgs e)
        {
            if (button_state)
            {
                ListenerStart();
            }
            else
            {
                ListenerEnd();
            }
        }

        private void SenderClick(object sender, EventArgs e)
        {
            if (button_state)
            {
                SenderStart();
            }
            else
            {
                SenderEnd();
            }
        }

        public void ListenerResponse(String message, IPEndPoint endpoint)
        {
            network.SendBroadcastMessage(RECEVER_PORT, "Hello");
            BeginInvoke(new JankenFormDelegate(ShowJankenForm), new object[] { endpoint.Address });
            BeginInvoke(new ListenerEndDelegate(ListenerEnd));
            network.CloseListener();
        }

        public void SenderResponse(String message, IPEndPoint endpoint)
        {
            BeginInvoke(new JankenFormDelegate(ShowJankenForm), new object[] { endpoint.Address });
            BeginInvoke(new SenderEndDelegate(SenderEnd));
            network.CloseListener();
        }

        public void ListenerStart()
        {
            button_state = false;
            btn_sender.Enabled = false;
            btn_recever.Text = "待ち受けを停止する";
            ListenerResponseDelegate result_delegate = new ListenerResponseDelegate(ListenerResponse);
            network.ListenMessage(SENDER_PORT, result_delegate, listener_exception_delegate);
        }

        public void ListenerEnd()
        {
            network.CloseListener();
            button_state = true;
            btn_recever.Text = "待ち受けを開始する";
            btn_sender.Enabled = true;
        }

        public void SenderStart()
        {
            button_state = false;
            btn_recever.Enabled = false;
            btn_sender.Text = "探すのをやめる";
            network.SendBroadcastMessage(SENDER_PORT, "Hello");
            LibUDP.ListenerResponseDelegate result_delegate = new ListenerResponseDelegate(SenderResponse);
            network.ListenMessage(RECEVER_PORT, result_delegate, listener_exception_delegate);
        }

        public void SenderEnd()
        {
            network.CloseListener();
            button_state = true;
            btn_recever.Enabled = true;
            btn_sender.Text = "対戦相手を探す";
        }

        public void ShowJankenForm(IPAddress address)
        {
            
            ShowConfigFormDelegate show_config = new ShowConfigFormDelegate(ShowConfigForm);
            janken_form = new JankenForm(show_config, address);
            janken_form.Show();
            this.Hide();
        }

        public void ShowConfigForm()
        {
            this.Show();
        }
        //メッセージボックスを表示
        private void ShowExceptionMessage(Exception e)
        {
            BeginInvoke(new ShowMessageDelegate(ShowMessage), new object[] { e.Message });
        }

        //メッセージボックスを表示
        private void ShowMessage(String message)
        {
            MessageBox.Show(message);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress address;
            if(IPAddress.TryParse(textBox1.Text, out address))
            {
                ShowJankenForm(address);
            }
            else
            {
                MessageBox.Show("つながらない");
            }
            
        }

    }
}
