﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace SocketIOClient.Test.SocketIOTests.V2Http
{
    [TestClass]
    public class OffAnyV2Test : OnAnyTest
    {
        public OffAnyV2Test()
        {
            SocketIOCreator = new SocketIOV2Creator();
        }

        protected override ISocketIOCreateable SocketIOCreator { get; }

        [TestMethod]
        public override async Task Test()
        {
            await base.Test();
        }
    }
}
