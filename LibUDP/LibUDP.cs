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
    public class LibUDP
    {
        //リスナー用スレッド
        Thread listener_thread;
        UdpClient sender_client;
        UdpClient listener_client;

        public delegate void ListenerResponseDelegate(String response, IPEndPoint peer_endpoint);
        public delegate void ListenerExceptionDelegate(Exception e);
        private delegate void BroadcastServerDelegate(int port, ListenerResponseDelegate callback, ListenerExceptionDelegate exception);

        public void SendBroadcastMessage(int port, String message)
        {
            //messageをutf8でByte列にする
            byte[] buffer = Encoding.UTF8.GetBytes(message);

            sender_client = new UdpClient();
            //ブロードキャストパケットの送信を許可する
            sender_client.EnableBroadcast = true;
            //IPブロードキャストアドレス、ポート番号を指定し接続を確立する
            sender_client.Connect(new IPEndPoint(IPAddress.Broadcast, port));
            //UDPデータグラムをリモートホストに送信
            sender_client.Send(buffer, buffer.Length);
            //UDP接続を終了
            sender_client.Close();
        }

        public void SendMessage(int port, IPAddress address, String message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            sender_client = new UdpClient();
            sender_client.EnableBroadcast = true;
            //アドレス、ポート番号を指定し、接続
            sender_client.Connect(new IPEndPoint(address, port));
            sender_client.Send(buffer, buffer.Length);
            sender_client.Close();
        }

        public void ListenMessage(int port, ListenerResponseDelegate callback, ListenerExceptionDelegate exception)
        {
            Object[] param = { port, callback, exception };
            //スレッド作成時にデータを渡す
            ParameterizedThreadStart ts = new ParameterizedThreadStart(ListenerStart);
            //スレッド作成
            listener_thread = new Thread(ts);
            listener_thread.Start(param);
            //バックグラウンドスレッドにする
            listener_thread.IsBackground = true;
        }

        public void CloseListener()
        {
            listener_client.Close();
            //スレッドを終了させる
            listener_thread.Abort();
        }


        private void ListenerStart(Object obj)
        {
            //キャスト
            Object[] param = (Object[])obj;
            //ポートを設定
            int port = (int)param[0];
            ListenerResponseDelegate callback = (ListenerResponseDelegate)param[1];
            ListenerExceptionDelegate exception = (ListenerExceptionDelegate)param[2];
            try
            {
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
            catch (ThreadAbortException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                exception(e);
            }
        }
    }
}