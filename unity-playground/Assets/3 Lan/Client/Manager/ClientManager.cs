using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketGameProtocol;
using System.Net.Sockets;
using System;
using System.Net;

public class ClientManager : BaseManager
{
    Socket socket;
    Message message;
    public ClientManager(GameFace face) : base(face) { }
    public override void OnInit()
    {
        base.OnInit();
        message = new Message();
        InitSocket();
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
    }
    void InitSocket()
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Connect(new IPEndPoint(IPAddress.Any, 6666));
        StartReceive();
    }
    void CloseSocket()
    {
        socket?.Close();
    }
    void StartReceive()
    {
        socket?.BeginReceive(message.Buffer, message.StartIndex, message.RemainSize, SocketFlags.None, ReceiveCallback, null);
    }
    void ReceiveCallback(IAsyncResult res)
    {

    }
    void HandleResponse() { }
    public void Send(MainPack pack)
    {        
        socket?.Send(message.PackData(pack));
    }
}
