using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SocketGameProtocol;
using System.Linq;
using Google.Protobuf;


public class Message
{
    byte[] buffer = new byte[1024];
    int startIndex = 0;
    public byte[] Buffer { get { return buffer; } }
    public int StartIndex { get { return startIndex; } }
    public int RemainSize { get { return buffer.Length - startIndex; } }
    public const int HEADER_SIZE = 4;

    public Message() { }

    public void ReadBuffer(int len, Action<MainPack> HandleRequest) { }
    public byte[] PackData(MainPack pack)
    {
        byte[] data = pack.ToByteArray();
        byte[] head = BitConverter.GetBytes(data.Length);
        return data.Concat(head).ToArray();
    }
}

