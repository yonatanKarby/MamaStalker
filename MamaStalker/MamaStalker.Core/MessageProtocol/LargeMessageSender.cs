using MamaStalker.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace MamaStalker.Common.MessageProtocol
{
    public class LargeMessageSender
    {
        private ITcpConnection _connection;
        private const int BATCH_SIZE= 1024;
        private PacketMaker _packetmaker = new PacketMaker();
        public void SendMessage(byte[] data, object headerDto)
        {
            var batches = data.Length / BATCH_SIZE;
            var slicedBatches = BatchSlice(data, batches);
            var packets = new List<PacketInfo>();
            packets.Add(_packetmaker.CreatePacket(PacketType.Header, headerDto));
            foreach(var batch in slicedBatches)
            {
                packets.Add(_packetmaker.CreatePacket(PacketType.data, batch));
            }

            Send(packets.ToArray());
        }
        private void Send(PacketInfo[] packets)
        {
            foreach(var packet in packets)
            {
                if(_connection.IsRunning())
                {
                    _connection.Write(packet.data);
                }
            }
        }
        private byte[][] BatchSlice(byte[] data, int batches)
        {
            throw new NotImplementedException();
        }
    }
}
