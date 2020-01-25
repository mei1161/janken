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
    public class libNetwork
    {
        Thread Broadcast_thread;
        UdpClient sender_client;
        UdpClient listener_client;

        public delegate void BroadcastResponseDelegate(String response, IPEndPoint peer_endpoint);
        private delegate void BroadcastServerDelegate(int port, BroadcastResponseDelegate callback);

        public libNetwork()
        {

        }

        public void SendBroadcastMessage(int port, String message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            sender_client = new UdpClient(port);
            sender_client.EnableBroadcast = true;
            sender_client.Connect(new IPEndPoint(IPAddress.Broadcast, port));
            sender_client.Send(buffer, buffer.Length);
            sender_client.Close();
        }

        public void ListenBroadcastMessage(int port, BroadcastResponseDelegate callback)
        {
            Object[] param = { port, callback };
            ParameterizedThreadStart ts = new ParameterizedThreadStart(BroadcastServerStart);
            Broadcast_thread = new Thread(ts);
            Broadcast_thread.Start(param);
            Broadcast_thread.IsBackground = true;
        }

        public void CloseListener()
        {
            listener_client.Close();
            Broadcast_thread.Abort();
        }


        private void BroadcastServerStart(Object obj)
        {
                Object[] param = (Object[])obj;
                int port = (int)param[0];
                BroadcastResponseDelegate callback = (BroadcastResponseDelegate)param[1];
                // ブロードキャストを監視するエンドポイント
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

