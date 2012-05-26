using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SimpleTokenRingNetworkSimulator.Core
{
    public sealed class TokenRingNetworkSimulator
    {
        private const int MAX_TIME_TOKEN = 9000;
        private const int MIN_TIME_TOKEN = 1500;

        public Boolean IsTokenManager { get; private set; }

        private List<Message> messagesToSend;
        private Object synObjMsgToSend;

        private System.Threading.Timer tokenManagerTimer;
        private Object synObjSendPack;

        private IPEndPoint hopConfiguration1;
        private IPEndPoint hopConfiguration2;
        private IPEndPoint hopConfiguration3;
        private HopNumbers nextHopNumber;

        private bool hideToken;

        public event Action<Message> MessageReceived;
        public event Action<Message> DuplicateTokenReceived;
        public event Action<Message> TokenHidden;

        private Action sendTokenDelegate;

        public void AddFileToSend(FileInfo file, HopNumbers hopNumToSendFile)
        {
            //TODO: ADD the CRC calc and store on each message. Please notice that you need to add a new member into the message to store the CRC.
            IEnumerable<Message> newMessages = new Message[] { new Message(CurrentHopConfig, GetHopConfigByNumber(hopNumToSendFile), File.ReadAllBytes(file.FullName)) };

            lock (synObjMsgToSend)
            {
                messagesToSend.AddRange(newMessages);
            }

        }

        private Message GetNextMessageToSend()
        {
            lock (synObjMsgToSend)
            {
                return messagesToSend.Any() ? messagesToSend[0] : null;
            }
        }

        private IPEndPoint GetHopConfigByNumber(HopNumbers hopNumber)
        {
            switch (hopNumber)
            {
                case HopNumbers.One:
                    return hopConfiguration1;
                case HopNumbers.Two:
                    return hopConfiguration2;
                default:
                    return hopConfiguration3;
            }
        }

        private IPEndPoint CurrentHopConfig
        {
            get
            {
                switch (nextHopNumber)
                {
                    case HopNumbers.One:
                        return hopConfiguration3;
                    case HopNumbers.Two:
                        return hopConfiguration1;
                    default:
                        return hopConfiguration2;
                }
            }
        }

        private IPEndPoint NextHopConfig
        {
            get
            {
                switch (nextHopNumber)
                {
                    case HopNumbers.One:
                        return hopConfiguration1;
                    case HopNumbers.Two:
                        return hopConfiguration2;
                    default:
                        return hopConfiguration3;
                }
            }
        }

        private IPEndPoint PreviousHopConfig
        {
            get
            {
                switch (nextHopNumber)
                {
                    case HopNumbers.One:
                        return hopConfiguration2;
                    case HopNumbers.Two:
                        return hopConfiguration3;
                    default:
                        return hopConfiguration1;
                }
            }
        }

        public TokenRingNetworkSimulator(Boolean isTokenManager, IPEndPoint hopConfiguration1, IPEndPoint hopConfiguration2, IPEndPoint hopConfiguration3, HopNumbers nextHopNum)
        {
            this.IsTokenManager = isTokenManager;
            this.hopConfiguration1 = hopConfiguration1;
            this.hopConfiguration2 = hopConfiguration2;
            this.hopConfiguration3 = hopConfiguration3;
            this.nextHopNumber = nextHopNum;
            this.synObjMsgToSend = new Object();
            this.messagesToSend = new List<Message>();
            this.synObjSendPack = new Object();
        }

        public void Start(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using (UdpClient sendSocketNextHop = new UdpClient(NextHopConfig.Address.ToString(), NextHopConfig.Port))
            using (UdpClient receiveSocket = new UdpClient(CurrentHopConfig.Port))
            {
                Stopwatch tokenManagerMinTimeStopwatch = null;

                sendTokenDelegate = () => SendToken(cancellationToken, sendSocketNextHop, NextHopConfig);

                if (IsTokenManager)
                {
                    SendToken(cancellationToken, sendSocketNextHop, NextHopConfig);

                    this.tokenManagerTimer = new Timer((state) => { SendToken(cancellationToken, sendSocketNextHop, NextHopConfig); this.tokenManagerTimer.Change(MAX_TIME_TOKEN, Timeout.Infinite); }, null, MAX_TIME_TOKEN, Timeout.Infinite);

                    tokenManagerMinTimeStopwatch = Stopwatch.StartNew();
                }

                while (true)
                {

                    Message messageReceived = ReceiveMessage(cancellationToken, receiveSocket, Timeout.Infinite);

                    Thread.Sleep(1000);

                    if (messageReceived != null)
                    {
                        if (messageReceived.Type == MessageTypes.Token)
                        {
                            if (IsTokenManager)
                            {
                                tokenManagerMinTimeStopwatch.Stop();
                            }

                            if (hideToken)
                            {
                                hideToken = false;

                                if (TokenHidden != null)
                                    TokenHidden(messageReceived);
                            }
                            else if (IsTokenManager && tokenManagerMinTimeStopwatch.ElapsedMilliseconds < MIN_TIME_TOKEN)
                            {
                                if (DuplicateTokenReceived != null)
                                    DuplicateTokenReceived(messageReceived);
                            }
                            else
                            {
                                Message nextMessageToSend = GetNextMessageToSend();
                                if (nextMessageToSend != null)
                                {
                                    SendMessage(cancellationToken, sendSocketNextHop, nextMessageToSend);
                                }
                                else
                                {
                                    SendToken(cancellationToken, sendSocketNextHop, NextHopConfig);
                                }
                            }

                            if (IsTokenManager)
                            {
                                tokenManagerMinTimeStopwatch.Restart();
                            }
                        }
                        else
                        {
                            if (!messageReceived.ReceiverEndPoint.Equals(CurrentHopConfig))
                            {
                                SendMessage(cancellationToken, sendSocketNextHop, messageReceived);
                            }
                            else if (messageReceived.Type == MessageTypes.Ack)
                            {
                                lock (synObjMsgToSend)
                                {
                                    messagesToSend.RemoveAt(0);
                                }

                                SendToken(cancellationToken, sendSocketNextHop, NextHopConfig);
                            }
                            else if (messageReceived.Type == MessageTypes.Data)
                            {
                                //TODO: CRC check
                                SendMessage(cancellationToken, sendSocketNextHop, new Message(CurrentHopConfig, messageReceived.SenderEndPoint, MessageTypes.Ack));
                            }
                        }

                        if (MessageReceived != null)
                            MessageReceived(messageReceived);
                    }

                    if (cancellationToken.IsCancellationRequested)
                    {
                        //cleanup
                        cancellationToken.ThrowIfCancellationRequested();
                    }
                }
            }
        }

        private void SendToken(CancellationToken cancellationToken, UdpClient sendSocketNextHop, IPEndPoint endPointNextHop)
        {
            SendMessage(cancellationToken, sendSocketNextHop, new Message(CurrentHopConfig, endPointNextHop, MessageTypes.Token));
        }

        private Message ReceiveMessage(CancellationToken cancellationToken, UdpClient receiveSocket, int timeout)
        {
            IPEndPoint senderIp = new IPEndPoint(IPAddress.Any, CurrentHopConfig.Port);

            Task<byte[]> asyncReceiveTask = Task<byte[]>.Factory.FromAsync((requestCallback, state) => receiveSocket.BeginReceive(requestCallback, state), (asyncResult) => !cancellationToken.IsCancellationRequested ? receiveSocket.EndReceive(asyncResult, ref senderIp) : null, null);

            asyncReceiveTask.Wait(cancellationToken);
            
            return new Message(asyncReceiveTask.Result);
        }

        private void SendMessage(CancellationToken cancellationToken, UdpClient sendSocket, Message message)
        {
            byte[] sendBytes = message.ToArray();

            lock (synObjSendPack)
            {
                Task<int> asyncSendTask = Task<int>.Factory.FromAsync((requestCallback, state) => sendSocket.BeginSend(sendBytes, sendBytes.Length, requestCallback, state), (x) => !cancellationToken.IsCancellationRequested ? sendSocket.EndSend(x) : 0, null);
            }

        }

        public void SendToken()
        {
            sendTokenDelegate();
        }

        public void HideToken()
        {
            hideToken = true;
        }

    }
}
