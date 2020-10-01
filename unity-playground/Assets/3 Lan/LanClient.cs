using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using SocketGameProtocol;
using Assets._3_Lan.DAO;
using Google.Protobuf;

namespace Assets._3_Lan
{
    class LanClient
    {
        Socket socket;

        UserData userData;
        public UserData GetUserData
        {
            get { return userData; }
        }

        const int HEADER_SIZE = 4;
        byte[] buffer = new byte[1024];
        int startIndex = 0;

        public LanClient(Socket socket)
        {
            this.userData = new UserData();    
            this.socket = socket;            
        }
        void ReadBuffer(int len)
        {
            startIndex += len;
            if (startIndex <= HEADER_SIZE)
                return;

            int count = BitConverter.ToInt32(buffer, 0);

            while (true)
            {
                if (startIndex >= count + HEADER_SIZE)
                {
                    MainPack pack = MainPack.Descriptor.Parser.ParseFrom(buffer, HEADER_SIZE, count) as MainPack;
                    Array.Copy(buffer, count + HEADER_SIZE, buffer, 0, buffer.Length - count - HEADER_SIZE);
                    startIndex -= len;
                }
                else
                {
                    break;
                }
            }
            
        }
        void StartReceive()
        {
            socket.BeginReceive(buffer, startIndex, buffer.Length - startIndex, SocketFlags.None, ReceiveCallback, null);
        }
        void ReceiveCallback(IAsyncResult res)
        {
            try
            {
                if (socket.Connected == false || socket == null)
                    return;
                
                int len = socket.EndReceive(res);
                if (len == 0)
                    return;

                ReadBuffer(len);
                StartReceive();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static byte[] PackData(MainPack pack)
        {
            byte[] data = pack.ToByteArray();
            byte[] head = BitConverter.GetBytes(data.Length);
            return head.Concat(data).ToArray();
        }
        public void Send(MainPack pack)
        {
            socket.Send(PackData(pack));
        }
    }
}
