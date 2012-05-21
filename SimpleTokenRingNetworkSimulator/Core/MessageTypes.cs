using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTokenRingNetworkSimulator.Core
{
    public enum MessageTypes : byte
    {
        Ack,
        Data,
        Nack,
        Token
    }
}
