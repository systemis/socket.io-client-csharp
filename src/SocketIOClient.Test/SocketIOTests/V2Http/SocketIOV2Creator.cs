﻿using System.Collections.Generic;

namespace SocketIOClient.Test.SocketIOTests.V2Http
{
    public class SocketIOV2Creator : ISocketIOCreateable
    {
        public SocketIO Create(bool reconnection = false)
        {
            return new SocketIO(Url, new SocketIOOptions
            {
                Reconnection = reconnection,
                Transport = Transport.TransportProtocol.Polling,
                EIO = EIO,
                Query = new Dictionary<string, string>
                {
                    { "token", Token }
                }
            });
        }

        public string Prefix => "V2: ";
        public string Token => "V2";
        public string Url => "http://localhost:11002";
        public int EIO => 3;
    }
}
