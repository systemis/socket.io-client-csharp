﻿using SocketIOClient.Transport;
using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace SocketIOClient.Windows7
{
    public sealed class ClientWebSocketManaged : IClientWebSocket
    {
        public ClientWebSocketManaged()
        {
            _ws = new System.Net.WebSockets.Managed.ClientWebSocket();
            _sendLock = new SemaphoreSlim(1, 1);
        }

        readonly System.Net.WebSockets.Managed.ClientWebSocket _ws;
        readonly SemaphoreSlim _sendLock;

        public Action<object> ConfigOptions { get; set; }

        public WebSocketState State => _ws.State;

        public async Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
        {
            await _ws.CloseAsync(closeStatus, statusDescription, cancellationToken).ConfigureAwait(false);
        }

        public async Task ConnectAsync(Uri uri, CancellationToken cancellationToken)
        {
            ConfigOptions?.Invoke(_ws.Options);
            await _ws.ConnectAsync(uri, cancellationToken).ConfigureAwait(false);
        }

        public async Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken)
        {
            return await _ws.ReceiveAsync(buffer, cancellationToken).ConfigureAwait(false);
        }

        public async Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
        {
            try
            {
                await _sendLock.WaitAsync().ConfigureAwait(false);
                await _ws.SendAsync(buffer, messageType, endOfMessage, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _sendLock.Release();
            }
        }

        public void SetRequestHeader(string headerName, string headerValue)
        {
            _ws.Options.SetRequestHeader(headerName, headerValue);
        }

        public void Dispose()
        {
            _ws.Dispose();
        }
    }
}
