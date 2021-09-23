﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RichardSzalay.MockHttp;
using SocketIOClient.Transport;
using SocketIOClient.UriConverters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketIOClient.UnitTest.TransportTests
{
    [TestClass]
    public class HttpTransportTest
    {
        [TestMethod]
        public async Task TextWithBinaryTest()
        {
            string uri = "http://localhost:11003/socket.io/?token=V3&EIO=4&transport=polling";

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When(uri)
                .Respond("text/plain", "452-[\"2 params\",{\"_placeholder\":true,\"num\":0},{\"code\":64,\"msg\":{\"_placeholder\":true,\"num\":1}}]bCjAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMAoxMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTEKMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyCjMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMwo0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQKNTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1CjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2Ngo3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3NzcKODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4Cjk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OQpBbWVyaWNhbkFtZXJpY2FuQW1lcmljYW5BbWVyaWNhbkFtZXJpY2FuQW1lcmljYW5BbWVyaWNhbkFtZXJpY2FuQW1lcmljYW5BbWVyaWNhbkFtZXJpY2FuQW1lcmljYW5BbWUK5L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2gCuOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBrgphYmM=bCjAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMAoxMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExMTEKMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyCjMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMzMwo0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQKNTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1NTU1CjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2Ngo3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3NzcKODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4ODg4Cjk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OQpBbWVyaWNhbkFtZXJpY2FuQW1lcmljYW5BbWVyaWNhbkFtZXJpY2FuQW1lcmljYW5BbWVyaWNhbkFtZXJpY2FuQW1lcmljYW5BbWVyaWNhbkFtZXJpY2FuQW1lcmljYW5BbWUK5L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2g5aW95L2gCuOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBruOBrgp4eXo=");
            var httpClient = mockHttp.ToHttpClient();

            var clientWebSocket = new Mock<IClientWebSocket>();

            var uriConverter = new Mock<IUriConverter>();
            uriConverter
                .Setup(x => x.GetHandshakeUri(It.IsAny<Uri>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<IEnumerable<KeyValuePair<string, string>>>()))
                .Returns(new Uri(uri));

            string resultText = null;
            var bytes = new List<byte[]>();
            var transport = new HttpTransport(httpClient, 4)
            {
                OnTextReceived = text => resultText = text,
                OnBinaryReceived = b => bytes.Add(b)
            };
            await transport.GetAsync(uri, CancellationToken.None);

            await Task.Delay(100);

            string longString = @"
000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111
222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222
333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333
444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444
555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555
666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666
777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777
888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999
AmericanAmericanAmericanAmericanAmericanAmericanAmericanAmericanAmericanAmericanAmericanAmericanAme
你好你好你好你好你好你好你好你好你好你好你好你好你好你好你好你好你好你好你好你好你好你好你好你好你好你好你好你好你好你好你
ののののののののののののののののののののののののののののののののののののののののののののののののののののののののののののの
";

            Assert.AreEqual("452-[\"2 params\",{\"_placeholder\":true,\"num\":0},{\"code\":64,\"msg\":{\"_placeholder\":true,\"num\":1}}]", resultText);
            Assert.AreEqual(2, bytes.Count);
            string str1 = longString + "abc";
            string str2 = Encoding.UTF8.GetString(bytes[0]);
            int c1 = CultureInfo.CurrentCulture.CompareInfo.Compare(str1, str2, CompareOptions.IgnoreSymbols);
            string str3 = longString + "xyz";
            string str4 = Encoding.UTF8.GetString(bytes[1]);
            int c2 = CultureInfo.CurrentCulture.CompareInfo.Compare(str1, str2, CompareOptions.IgnoreSymbols);
            Assert.AreEqual(0, c1);
            Assert.AreEqual(0, c2);
        }

        [TestMethod]
        public async Task Eio3HttpConnectedTest()
        {
            string uri = "http://localhost:11002/socket.io/?token=V3&EIO=3&transport=polling";

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When(uri)
                .Respond("text/plain", "2:40");
            var httpClient = mockHttp.ToHttpClient();

            var clientWebSocket = new Mock<IClientWebSocket>();

            var uriConverter = new Mock<IUriConverter>();
            uriConverter
                .Setup(x => x.GetHandshakeUri(It.IsAny<Uri>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<IEnumerable<KeyValuePair<string, string>>>()))
                .Returns(new Uri(uri));

            var result = new List<string>();
            var transport = new HttpTransport(httpClient, 3)
            {
                OnTextReceived = text => result.Add(text)
            };
            await transport.GetAsync(uri, CancellationToken.None);

            await Task.Delay(100);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("40", result[0]);
        }
    }
}
