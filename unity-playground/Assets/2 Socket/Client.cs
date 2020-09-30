using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;
using System.Text;


public class Client : MonoBehaviour
{    
    Socket socket;
    byte[] buffer = new byte[1024];

    void Start()
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Connect("127.0.0.1", 6666);
        StartReceive();
        Send();

    }

    void StartReceive()
    {
        socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, null);
    }

    void ReceiveCallback(IAsyncResult res)
    {
        // If length of result is 0, we return
        int len = socket.EndReceive(res);

        if (len == 0)
            return;

        string str = Encoding.UTF8.GetString(buffer, 0, len);
        print(str);

        StartReceive();

    }
    void Send()
    {
        socket.Send(Encoding.UTF8.GetBytes("身寸"));
    }
    void Update()
    {
        print(buffer.Length);

        if (Input.GetKeyDown(KeyCode.D))
            Send();

    }
}
