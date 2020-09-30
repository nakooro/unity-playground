using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;



namespace Assets._3_Lan
{
    class LanClient
    {
        Socket socket;
        byte[] buffer = new byte[1024];
        int startIndex;
        int remainSize;
        public LanClient(Socket socket)
        {
            this.socket = socket;            
        }
        void ReadBuffer(int len)
        {
            if (len < 4)
                return;
            
        }
        void StartReceive()
        {
            socket.BeginReceive(buffer, startIndex, buffer.Length - startIndex, SocketFlags.None, ReceiveCallback, null);
        }
        void ReceiveCallback(IAsyncResult res)
        {

            int len = socket.EndReceive(res);

            if (len == 0)
                return;

            ReadBuffer(len);
            StartReceive();           

        }
    }
}
