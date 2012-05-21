using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace SimpleTokenRingNetworkSimulator.Core
{
    public class Message
    {
        private const int MAX_DATA_LENGTH = 30;
        public IPEndPoint ReceiverEndPoint { get; private set; }
        public IPEndPoint SenderEndPoint { get; private set; }
        public byte[] Data { get; private set; }
        public MessageTypes Type { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageData"></param>
        /// <param name="senderEndPoint"></param>
        /// <param name="receiverEndPoint"></param>
        /// <remarks>Use it before send the data packet through the network.</remarks>
        public Message(IPEndPoint senderEndPoint, IPEndPoint receiverEndPoint, byte[] messageData)
            : this(senderEndPoint, receiverEndPoint, MessageTypes.Data, messageData)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="senderEndPoint"></param>
        /// <param name="receiverEndPoint"></param>
        /// <remarks>Use it before send the ack/nack/token packet through the network.</remarks>
        public Message(IPEndPoint senderEndPoint, IPEndPoint receiverEndPoint, MessageTypes type)
            : this(senderEndPoint, receiverEndPoint, type, new byte[0])
        { }

        private Message(IPEndPoint senderEndPoint, IPEndPoint receiverEndPoint, MessageTypes type, byte[] messageData)
        {
            if (type == MessageTypes.Data)
            {
                if ((!messageData.Any()))
                    throw new ProtocolViolationException("You need to provide the data to send over.");

                if (messageData.Length > MAX_DATA_LENGTH)
                    throw new ProtocolViolationException(String.Format("The data size exceeded the maximum: {0}.", MAX_DATA_LENGTH));
            }

            this.SenderEndPoint = senderEndPoint;
            this.ReceiverEndPoint = receiverEndPoint;
            this.Data = messageData;
            this.Type = type;

        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        /// <param name="data"></param>
        /// <remarks>Use it after receive the packet.</remarks>
        public Message(byte[] data)
            : this(
            new IPEndPoint(new IPAddress(data.Take(4).ToArray()), BitConverter.ToInt32(data.Skip(4).Take(4).ToArray(), 0)),
            new IPEndPoint(new IPAddress(data.Skip(8).Take(4).ToArray()), BitConverter.ToInt32(data.Skip(12).Take(4).ToArray(), 0)),
            (MessageTypes)data.Skip(16).First(), data.Skip(17).ToArray())
        { }

        public byte[] ToArray()
        {
            return
                SenderEndPoint.Address.GetAddressBytes().
                Concat(
                  BitConverter.GetBytes(SenderEndPoint.Port)
                ).
                Concat(
                ReceiverEndPoint.Address.GetAddressBytes()
                ).
                Concat(
                  BitConverter.GetBytes(ReceiverEndPoint.Port)
                ).
                Concat(
                  new byte[] { (byte)Type }
                ).
                Concat(
                  Data
                ).
                ToArray();
        }
    }
}
