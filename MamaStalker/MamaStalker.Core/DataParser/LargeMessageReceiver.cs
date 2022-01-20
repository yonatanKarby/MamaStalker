using System;
using System.Collections.Generic;
using MamaStalker.Common.DataMaker;
using MamaStalker.Common.Interfaces;
using MamaStalker.Common.YKDataProtocolMaker;
using MamaStalker.Common.DataParser.PacketParsers;
using MamaStalker.Common.DataParser.MessageParser;

namespace MamaStalker.Common.DataParser
{
    public class LargeMessageReceiver
    {
        private readonly ITcpConnection _connection;
        private readonly IDictionary<PacketType, IPacketparser> Parsers = new Dictionary<PacketType, IPacketparser>()
        {
            { PacketType.Header, new HeaderParser()},
            { PacketType.Data, new PacketParsers.DataParser()}
        };
        public LargeMessageReceiver(ITcpConnection connection)
        {
            _connection = connection;
        }
        public byte[] Listen()
        {
            var headerPacket = _connection.Read();
            var header = ParseHeader(headerPacket);
            switch(header.type)
            {
                case MessageType.image:
                    return new KnownLengthReader().Read((ImagePacketHeader)header);
                default:
                    throw new Exception("Unsupported header type");
            }
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