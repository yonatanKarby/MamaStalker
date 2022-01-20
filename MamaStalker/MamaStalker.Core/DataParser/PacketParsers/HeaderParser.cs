using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using MamaStalker.Common.DataMaker;

namespace MamaStalker.Common.DataParser.PacketParsers
{
    public class HeaderParser : IPacketparser
    {
        private byte[] TakeFrom(byte[] arr, int startIndex, int length)
        {
            return arr.Where((b, index) => index >= startIndex && index < startIndex + length).ToArray();
        }

        public object Parse(byte[] buffer)
        {
            var lengthBytes = TakeFrom(buffer, 1, 5);
            int length = GetIntFromBytes(lengthBytes);
            var data = TakeFrom(buffer, 4, length);
            var json = Encoding.ASCII.GetString(data);
            return JsonConvert.DeserializeObject<PacketHeaderBase>(json);
        }

        private int GetIntFromBytes(byte[] lengthBytes)
        {
            return BitConverter.ToInt32(lengthBytes);
        }
    }
}
