using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SocketGameProtocol;
using System.Linq;
using Google.Protobuf;
using System.Text;

public class Message
{
    byte[] buffer = new byte[1024];
    int startIndex = 0;
    public byte[] Buffer { get { return buffer; } }
    public int StartIndex { get { return startIndex; } }
    public int RemainSize { get { return buffer.Length - startIndex; } }
    public const int HEADER_SIZE = 4;

    public Message() { }

    public void ReadBuffer(int len, Action<MainPack> HandleRequest)
    {
        startIndex += len;
        if (startIndex <= HEADER_SIZE)
            return;

        int count = BitConverter.ToInt32(buffer, 0);

        while(true)
        {
            if (startIndex >= count + HEADER_SIZE)
            {
                MainPack pack = MainPack.Descriptor.Parser.ParseFrom(buffer, HEADER_SIZE, count) as MainPack;                             
                Array.Copy(buffer, count + HEADER_SIZE, buffer, 0, buffer.Length - count - HEADER_SIZE);
                startIndex -= count + HEADER_SIZE;
                HandleRequest(pack);
            }
            else
            {
                break;
            }
        }       
    }

    public byte[] PackData(MainPack pack)
    {
        byte[] data = pack.ToByteArray();
        byte[] head = BitConverter.GetBytes(data.Length);
        return data.Concat(head).ToArray();
    }
}

