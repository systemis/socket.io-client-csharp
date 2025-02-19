﻿using System.Collections.Generic;

namespace SocketIOClient.Test.SocketIOTests.V3Http
{
    public class SocketIOV3Creator : ISocketIOCreateable
    {
        public SocketIO Create(bool reconnection = false)
        {
            return new SocketIO(Url, new SocketIOOptions
            {
                Reconnection = reconnection,
                Transport = Transport.TransportProtocol.Polling,
                Query = new Dictionary<string, string>
                {
                    { "token", Token }
                }
            });
        }

        public string Prefix => "V3: ";
        public string Token => "V3";
        public string Url => "http://localhost:11003";
        public int EIO => 4;
    }
}
