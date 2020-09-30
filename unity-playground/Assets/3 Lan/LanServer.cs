using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Assets._3_Lan
{
    class LanServer
    {
        Socket socket;
        List<LanClient> clients = new List<LanClient>();
        public LanServer(int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any, port));
            socket.Listen(0);
        }
        void StartAccept()
        {
            socket.BeginAccept(AcceptCallback, null);
        }
        void AcceptCallback(IAsyncResult res)
        {
            Socket client = socket.EndAccept(res);
            clients.Add(new LanClient(client));
        }
    }
}
