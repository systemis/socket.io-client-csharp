﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace SocketIOClient.Test.SocketIOTests.V3
{
    [TestClass]
    public class OnErrorV3NspTest : OnErrorTest
    {
        public OnErrorV3NspTest()
        {
            SocketIOCreator = new SocketIOV3NspCreator();
        }

        protected override ISocketIOCreateable SocketIOCreator { get; }


        [TestMethod]
        public override async Task Test()
        {
            await base.Test();
        }
    }
}
