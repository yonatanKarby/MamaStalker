using System;
using MamaStalker.Common.DataMaker;
using MamaStalker.Common.DataParser.PacketParsers;
using MamaStalker.Common.Interfaces;
using MamaStalker.Common.YKDataProtocolMaker;
using System.Collections.Generic;

namespace MamaStalker.Common.DataParser
{
    public class LargeMessageReceiver
    {
        private readonly ITcpConnection _connection;
        private readonly IDictionary<PacketType, IPacketparser> Parsers = new Dictionary<PacketType, IPacketparser>()
        { };
        public byte[] Listen()
        {
            //Get Header
            var headerPacket = _connection.Read();
            var header = ParseHeader(headerPacket);
            var data = new List<byte>();
            //Get Packets
            for(int i=0; i<header.NumberOfPackets; i++)
            {
                var packet = _connection.Read();
                var currentData = ParseData(packet);
                data.AddRange(currentData);
            }
            return data.ToArray();
        }

        private byte[] ParseData(byte[] packet)
        {
            if(Parsers.TryGetValue((PacketType)packet[0], out var parser))
            {
                return (byte[])parser.Parse(packet);
            }
            throw new ArgumentException("Parser not supported!");
        }

        private PacketHeaderBase ParseHeader(byte[] headerPacket)
        {
            if (Parsers.TryGetValue((PacketType)headerPacket[0], out var parser))
            {
                return (PacketHeaderBase)parser.Parse(headerPacket);
            }
            throw new ArgumentException("Packet parser type not supported");
        }
    }
}
