using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mei1161
{
    public class LibTCP
    {
        Thread server_thread;
        int port;
        IPAddress adress;
        Socket server_socket;

        void ServerListen()
        {

            server_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEndPointReceive = new IPEndPoint(IPAddress.Parse("0.0.0.0"), port);
            server_socket.Bind(iPEndPointReceive);
            server_socket.Listen(10);
            while (true)
            {
                Socket temp = null;
                temp = server_socket.Accept();
                byte[] messageReceivedByServer = new byte[100];
                int sizeOfReceivedMessage = temp.Receive(messageReceivedByServer, SocketFlags.None);
                Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                string str = sjisEnc.GetString(messageReceivedByServer);
            }
        }


    }
}
