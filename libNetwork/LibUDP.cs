using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mei1161
{
    public class libUDP
    {
        Thread Broadcast_thread;
        UdpClient sender_client;
        UdpClient listener_client;

        public delegate void ListenerResponseDelegate(String response, IPEndPoint peer_endpoint);
        private delegate void BroadcastServerDelegate(int port, ListenerResponseDelegate callback);

        public void SendBroadcastMessage(int port, String message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            sender_client = new UdpClient();
            sender_client.EnableBroadcast = true;
            sender_client.Connect(new IPEndPoint(IPAddress.Broadcast, port));
            sender_client.Send(buffer, buffer.Length);
            sender_client.Close();
        }

        public void SendMessage(int port, IPAddress address, String message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            sender_client = new UdpClient();
            sender_client.EnableBroadcast = true;
            sender_client.Connect(new IPEndPoint(address, port));
            sender_client.Send(buffer, buffer.Length);
            sender_client.Close();
        }

        public void ListenMessage(int port, ListenerResponseDelegate callback)
        {
            Object[] param = { port, callback };
            ParameterizedThreadStart ts = new ParameterizedThreadStart(ListenerStart);
            Broadcast_thread = new Thread(ts);
            Broadcast_thread.Start(param);
            Broadcast_thread.IsBackground = true;
        }

        public void CloseListener()
        {
            listener_client.Close();
            Broadcast_thread.Abort();
        }


        private void ListenerStart(Object obj)
        {
                Object[] param = (Object[])obj;
                int port = (int)param[0];
                ListenerResponseDelegate callback = (ListenerResponseDelegate)param[1];
                // 通信を監視するエンドポイント
                IPEndPoint remote = new IPEndPoint(IPAddress.Any, port);

                // UdpClientを生成
                listener_client = new UdpClient(port);

                // データ受信を待機（同期処理なので受信完了まで処理が止まる）
                // 受信した際は、 remote にどの IPアドレス から受信したかが上書きされる
                byte[] buffer = listener_client.Receive(ref remote);

                // 受信データを変換
                String response = Encoding.UTF8.GetString(buffer);

                // 受信イベントを実行
                callback(response, remote);
                listener_client.Close();
        }
    }



}

