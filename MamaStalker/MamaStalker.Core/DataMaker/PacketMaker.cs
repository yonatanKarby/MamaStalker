using System;
using System.Collections.Generic;
using MamaStalker.Common.YKDataProtocolMaker.PacketMakers;

namespace MamaStalker.Common.YKDataProtocolMaker
{
    public enum PacketType
    {
        Header = 0,
        data = 1
    }
    public class PacketMaker
    {
        private readonly Dictionary<PacketType, IPacketmaker> makers = new Dictionary<PacketType, IPacketmaker>()
        {
            { PacketType.Header, new HeaderPacketMaker() },
            { PacketType.data, new DataPacketMaker() }
        };
        public PacketInfo CreatePacket(PacketType type, object data)
        {
            if(makers.TryGetValue(type, out var maker))
            {
                return maker.makePacket(data);
            }
            else
            {
                throw new Exception("Unrecognized packet type");
            }
        }
    }
}