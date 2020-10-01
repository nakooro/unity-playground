using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketGameProtocol;
using Google.Protobuf;

namespace Assets._3_Lan
{
    class Message
    {        
        byte[] buffer = new byte[1024];
        int startIndex = 0;        
        public byte[] Buffer { get { return buffer; } }
        public int StartIndex { get { return startIndex; } }
        public int RemainSize  { get { return buffer.Length - startIndex; } }
        public void ReadBuffer(int len) { }
        public void PackData(MainPack pack) { }
    }
}
