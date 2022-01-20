using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using MamaStalker.Common.MessageProtocol.PacketMakers;

namespace MamaStalker.Common.MessageProtocol
{
    public enum PacketType
    {
        Header = 0,
        data = 1
    }
    public class PacketMaker
    {
        IDictionary<PacketType, IPacketmaker> makers;
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
