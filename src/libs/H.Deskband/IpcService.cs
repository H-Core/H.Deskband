using System;
using System.Threading;
using System.Threading.Tasks;
using H.Pipes;

namespace H.SearchDeskBand
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class IpcService : IAsyncDisposable
    {
        #region Properties

        private PipeClient<string> PipeClient { get; } = new ("H.Control");

        #endregion

        #region Events

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler? Connected;
        
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler? Disconnected;
        
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<string>? MessageReceived;
        
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<Exception>? ExceptionOccurred;

        private void OnConnected()
        {
            Connected?.Invoke(null, EventArgs.Empty);
        }

        private void OnDisconnected()
        {
            Disconnected?.Invoke(null, EventArgs.Empty);
        }

        private void OnMessageReceived(string message)
        {
            MessageReceived?.Invoke(null, message);
        }

        private void OnExceptionOccurred(Exception exception)
        {
            ExceptionOccurred?.Invoke(null, exception);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public IpcService()
        {
            PipeClient.Connected += (_, _) => OnConnected();
            PipeClient.Disconnected += (_, _) => OnDisconnected();
            PipeClient.MessageReceived += (_, args) => OnMessageReceived(args?.Message ?? string.Empty);
            PipeClient.ExceptionOccurred += (_, args) => OnExceptionOccurred(args.Exception);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task ConnectAsync(CancellationToken cancellationToken = default)
        {
            await PipeClient.ConnectAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task WriteAsync(string message, CancellationToken cancellationToken = default)
        {
            await PipeClient.WriteAsync(message, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async ValueTask DisposeAsync()
        {
            await PipeClient.DisposeAsync().ConfigureAwait(false);
        }

        #endregion
    }
}
