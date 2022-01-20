using System;
using System.Collections.Generic;
using System.Text;

namespace MamaStalker.Common.MessageProtocol
{
    public enum MessageTypes
    {
        Header = 0,
        data = 1
    }
    public class PacketMaker
    {
        public byte[] CreatePacket(MessageTypes type, object data)
        {
            switch(type)
            {
                case MessageTypes.Header:
                    return GetHeader(data);
                case MessageTypes.data:
                    return GetDataPacket((byte[])data);
                default:
                    return null;
            }
        }

        private byte[] GetDataPacket(byte[] data)
        {
            throw new NotImplementedException();
        }

        private byte[] GetHeader(object data)
        {
            byte[] buffer = new byte[MessageProtocolSettings.Default.defualtPacketSize];
            buffer[0] = (byte)MessageTypes.Header;
            throw new NotImplementedException();
        }
    }
}
