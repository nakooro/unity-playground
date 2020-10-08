using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using SocketGameProtocol;
using UnityEngine;

namespace Assets._3_Lan
{
    class LanServer
    {
        Socket socket;
        List<LanClient> clients = new List<LanClient>();
        ControllerManager controllerManager;

        public LanServer(int port)
        {           
            controllerManager = new ControllerManager(this);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any, port));
            socket.Listen(0);

            StartAccept();
        }
        void StartAccept()
        {
            Debug.Log("StartAccept");
            socket.BeginAccept(AcceptCallback, null);
        }
        void AcceptCallback(IAsyncResult res)
        {
            try
            {
                Debug.Log("AcceptCallback");
                Socket client = socket.EndAccept(res);
                clients.Add(new LanClient(client, this));

                // StartAccept();

            }
            catch (Exception e)
            {
                Debug.Log(e.Message);

            }
        }

        public void HandleRequest(MainPack pack, LanClient lanClient)
        {            
            controllerManager.HandleRequest(pack, lanClient);
        }
    }
}
