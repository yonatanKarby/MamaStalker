using MamaStalker.Common.DataMaker;
using MamaStalker.Common.Interfaces;
using System.Collections.Generic;

namespace MamaStalker.Common.DataParser.MessageParser
{
    public class KnownLengthReader : PacketParsers.DataParser
    {
        private readonly ITcpConnection _connection;
        public byte[] Read(ImagePacketHeader dto)
        {
            var data = new List<byte>();
            for (int i = 0; i < dto.NumberOfPackets; i++)
            {
                var packet = _connection.Read();
                var currentData = Parse(packet);
                data.AddRange((byte[])currentData);
            }
            return data.ToArray();
        }
    }
}
