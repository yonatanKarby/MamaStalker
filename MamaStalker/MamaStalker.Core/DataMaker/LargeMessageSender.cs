using MamaStalker.Common.DataMaker;
using MamaStalker.Common.Interfaces;
using System.Collections.Generic;

namespace MamaStalker.Common.YKDataProtocolMaker
{
    public class LargeMessageSender
    {
        private ITcpConnection _connection;
        private const int BATCH_SIZE= 1024;
        private PacketMaker _packetmaker = new PacketMaker();

        public LargeMessageSender(ITcpConnection connection)
        {
            _connection = connection;
        }
        public void SendMessage(PacketHeaderBase headerDto, byte[] data)
        {
            var slicedBatches = BatchSlice(data, BATCH_SIZE);
            var packets = new List<PacketInfo>();
            packets.Add(_packetmaker.CreatePacket(PacketType.Header, headerDto));
            foreach(var batch in slicedBatches)
            {
                packets.Add(_packetmaker.CreatePacket(PacketType.Data, batch));
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
        private byte[][] BatchSlice(byte[] data, int batchSize)
        {
            var bacthes = new List<byte[]>();
            var current = new List<byte>();
            for(int i=0; i<data.Length; i++)
            {
                if(i % batchSize == 0 && i != 0)
                {
                    bacthes.Add(current.ToArray());
                    current = new List<byte>();
                }
                current.Add(data[i]);
            }
            bacthes.Add(current.ToArray());
            return bacthes.ToArray();
        }
    }
}