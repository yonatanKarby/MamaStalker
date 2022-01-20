﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MamaStalker.Common.DataParser.PacketParsers
{
    public class DataParser : IPacketparser
    {
        private byte[] TakeFrom(byte[] arr, int startIndex, int length)
        {
            return arr.Where((b, index) => index >= startIndex && index < startIndex + length).ToArray();
        }
        public object Parse(byte[] buffer)
        {
            var lengthBytes = TakeFrom(buffer, 0, 4);
            int length = GetIntFromBytes(lengthBytes);
            var data = TakeFrom(buffer, 4, length);
            return data;
        }

        private int GetIntFromBytes(byte[] lengthBytes)
        {
            throw new NotImplementedException();
        }
    }
}
