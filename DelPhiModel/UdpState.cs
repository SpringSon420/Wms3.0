using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace WmsModel
{
    public class UdpState
    {
        public byte[] buffer = new byte[1024];
        public const int BufferSize = 1024;
        public int counter;
        public IPEndPoint ipEndPoint;
        public UdpClient udpClient;
    }
}
