using MamaStalker.Common.DataParser.PacketParsers;
using MamaStalker.Common.Interfaces;
using MamaStalker.Common.YKDataProtocolMaker;
using System;
using System.Collections.Generic;
using System.Text;

namespace MamaStalker.Common.DataParser
{
    public class LargeMessageReceiver
    {
        private readonly ITcpConnection _connection;
        private readonly IDictionary<PacketType, IPacketparser> Parsers = new Dictionary<PacketType, IPacketparser>()
        { };
        public void Listen()
        {
                
        }
    }
}
