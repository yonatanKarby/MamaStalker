using MamaStalker.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MamaStalker.Common.MessageProtocol
{
    public class LargeMessageSender
    {
        private ITcpConnection _connection;
        private const int BATCH_SIZE= 1024;
        public void SendMessage(byte[] data, object headerDto)
        {
            var batches = data.Length / BATCH_SIZE;
        }

        private byte[][] BatchSlice(byte[] data, int batches)
        {
            throw new NotImplementedException();
        }
    }
}
