using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System;


public class Server : MonoBehaviour
{
    Socket socket;
    byte[] buffer = new byte[1024];
    // Start is called before the first frame update
    void Start()
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Bind(new IPEndPoint(IPAddress.Any, 6666));
        socket.Listen(0);

        StartAccept();
    }

    void StartAccept()
    {
        print("StartAccept");

        socket.BeginAccept(AcceptCallback, null);
    }
    void AcceptCallback(IAsyncResult res)
    {
        print("AcceptCallback");

        Socket client = socket.EndAccept(res);
 
        StartReceive(client);
        StartAccept();

    }
    void StartReceive(Socket client)
    {
        print("StartReceive");

        client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, client);
    }
    void ReceiveCallback(IAsyncResult res)
    {
        print("ReceiveCallback");

        Socket client = res.AsyncState as Socket;
        int len = client.EndReceive(res);
        if (len == 0)
            return;

        string str = Encoding.UTF8.GetString(buffer, 0, len);
        print(str);
        StartReceive(client);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
