using System;
using System.Threading;
using System.Threading.Tasks;
using H.Pipes;

namespace H.Deskband.Core
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class IpcService : IAsyncDisposable
    {
        #region Properties

        private PipeServer<string> PipeServer { get; }

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
        public IpcService(string pipeName)
        {
            pipeName = pipeName ?? throw new ArgumentNullException(nameof(pipeName));

            PipeServer = new PipeServer<string>(pipeName);
            PipeServer.ClientConnected += (_, _) => OnConnected();
            PipeServer.ClientDisconnected += (_, _) => OnDisconnected();
            PipeServer.MessageReceived += (_, args) => OnMessageReceived(args.Message ?? string.Empty);
            PipeServer.ExceptionOccurred += (_, args) => OnExceptionOccurred(args.Exception);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            await PipeServer.StartAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task WriteAsync(string message, CancellationToken cancellationToken = default)
        {
            await PipeServer.WriteAsync(message, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async ValueTask DisposeAsync()
        {
            await PipeServer.DisposeAsync().ConfigureAwait(false);
        }

        #endregion
    }
}
