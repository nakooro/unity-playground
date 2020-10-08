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
        message = null;
        CloseSocket();
    }
    void InitSocket()
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            socket.Connect("127.0.0.1", 6666);
            StartReceive();

        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    void CloseSocket()
    {
        socket.Close();
    }
    void StartReceive()
    {
        socket.BeginReceive(message.Buffer, message.StartIndex, message.RemainSize, SocketFlags.None, ReceiveCallback, null);
    }
    void ReceiveCallback(IAsyncResult res)
    {
        if (socket == null || socket.Connected == false)
            return;

        int len = socket.EndReceive(res);
        if (len == 0)
        {
            CloseSocket();
            return;
        }

        message.ReadBuffer(len, HandleResponse);
        StartReceive();
    }
    void HandleResponse(MainPack pack)
    {
        GameFace.Instance.HandleResponse(pack);
    }
    public void Send(MainPack pack)
    {        
        socket.Send(message.PackData(pack));
    }
}
