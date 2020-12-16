﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using H.Core.Utilities;
using H.Deskband.Core.Extensions;
using H.Utilities;

namespace H.SearchDeskBand
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class DeskBandControl : UserControl, IDisposable
    {
        #region Constants

        /// <summary>
        /// 
        /// </summary>
        public const string ApplicationName = "HomeCenter.NET";

        #endregion

        #region Properties
        
        /// <summary>
        /// 
        /// </summary>
        public static ColorTheme DarkTheme { get; } = new()
        {
            TextColor = Color.White,
            BackgroundColor = Color.Black,
            ActiveColor = Color.White,
            InactiveColor = Color.Gray,
            MouseOverColor = Color.DarkSlateBlue,
        };

        /// <summary>
        /// 
        /// </summary>
        public static ColorTheme LightTheme { get; } = new()
        {
            TextColor = Color.Black,
            BackgroundColor = Color.White,
            ActiveColor = Color.RoyalBlue,
            InactiveColor = Color.Gray,
            MouseOverColor = Color.PowderBlue,
        };

        /// <summary>
        /// 
        /// </summary>
        public ColorTheme ColorTheme { get; } = DarkTheme;

        /// <summary>
        /// 
        /// </summary>
        public string PipeName { get; set; } = string.Empty;

        private IpcService? IpcService { get; set; }
        private DeskBandWindow Window { get; }
        private Dictionary<string, Action<string?>> ActionDictionary { get; } = new ();

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public DeskBandControl()
        {
            InitializeComponent();

            AddAction("start", _ => 
                RecordButton.InvokeIfRequired(c => c.BackColor = ColorTheme.ActiveColor));
            AddAction("stop", _ => 
                RecordButton.InvokeIfRequired(c => c.BackColor = ColorTheme.BackgroundColor));
            AddAction("preview", message => 
                Label.InvokeIfRequired(c => c.Text = message));
            AddAction("clear-preview", _ => 
                Label.InvokeIfRequired(c => c.Text = @"Enter Command Here"));

            Window = new DeskBandWindow();
            Window.ExceptionOccurred += (_, exception) => OnExceptionOccurred(exception);
            Window.CommandSent += Window_OnCommandSent;
            Window.VisibleChanged += (_, _) => Label.Visible = !Window.Visible;
        }

        #endregion

        #region Event handlers

        private static void OnExceptionOccurred(Exception exception)
        {
            MessageBox.Show(exception.ToString(), @"Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void Window_OnCommandSent(object? sender, string command)
        {
            try
            {
                await RunAsync(command);
            }
            catch (Exception exception)
            {
                OnExceptionOccurred(exception);
            }
        }

        private void IpcService_OnConnected(object? sender, EventArgs e)
        {
            Label.ForeColor = ColorTheme.ActiveColor;
            RecordButton.IconColor = ColorTheme.ActiveColor;
            RecordButton.BackColor = ColorTheme.BackgroundColor;
        }

        private void IpcService_OnDisconnected(object? sender, EventArgs e)
        {
            Label.ForeColor = ColorTheme.ActiveColor;
            RecordButton.IconColor = ColorTheme.ActiveColor;
            RecordButton.BackColor = ColorTheme.BackgroundColor;
        }

        private void IpcService_OnMessageReceived(string message)
        {
            try
            {
                var values = message.SplitOnlyFirst(' ');
                var key = values[0];
                if (!ActionDictionary.TryGetValue(key, out var action))
                {
                    return;
                }

                action?.Invoke(values[1]);
            }
            catch (Exception exception)
            {
                OnExceptionOccurred(exception);
            }
        }

        private void OnClick(object sender, EventArgs e)
        {
            try
            {
                Window.Visible = !Window.Visible;
                var location = PointToScreen(Point.Empty);
                Window.Location = location;
                Window.Top -= Window.Height;
                Window.Top += Height;

                // Bottom border
                Window.Top -= 2;
            }
            catch (Exception exception)
            {
                OnExceptionOccurred(exception);
            }
        }

        private async void DeskBandControl_Load(object sender, EventArgs e)
        {
            ApplyTheme(ColorTheme);

            try
            {
                IpcService = new IpcService(PipeName);
                IpcService.Connected += IpcService_OnConnected;
                IpcService.Disconnected += IpcService_OnDisconnected;
                IpcService.MessageReceived += (_, text) => IpcService_OnMessageReceived(text);
                IpcService.ExceptionOccurred += (_, exception) => OnExceptionOccurred(exception);
                
                await IpcService.StartAsync();
            }
            catch (Exception exception)
            {
                OnExceptionOccurred(exception);
            }
        }

        private async void RecordButton_Click(object sender, EventArgs e)
        {
            try
            {
                await RunAsync("start-record");
            }
            catch (Exception exception)
            {
                OnExceptionOccurred(exception);
            }
        }

        private async void UiButton_Click(object sender, EventArgs e)
        {
            try
            {
                await RunAsync("show-ui");
            }
            catch (Exception exception)
            {
                OnExceptionOccurred(exception);
            }
        }

        private async void MenuButton_Click(object sender, EventArgs e)
        {
            try
            {
                await RunAsync("show-commands");
            }
            catch (Exception exception)
            {
                OnExceptionOccurred(exception);
            }
        }

        private async void SettingsButton_Click(object sender, EventArgs e)
        {
            try
            {
                await RunAsync("show-settings");
            }
            catch (Exception exception)
            {
                OnExceptionOccurred(exception);
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// 
        /// </summary>
        public new void Dispose()
        {
            Window.Dispose();

            IpcService.DisposeAsync().AsTask().Wait();

            base.Dispose();
        }

        #endregion

        #region Private methods

        private void ApplyTheme(ColorTheme theme)
        {
            Window.ApplyTheme(ColorTheme);

            RecordButton.BackColor = theme.BackgroundColor;
            BackColor = theme.BackgroundColor;
            ForeColor = theme.TextColor;

            RecordButton.IconColor = ColorTheme.TextColor;
            MenuButton.IconColor = ColorTheme.TextColor;
            SettingsButton.IconColor = ColorTheme.TextColor;
            ShowMainApplicationButton.IconColor = ColorTheme.TextColor;
            
            RecordButton.FlatAppearance.MouseDownBackColor = theme.ActiveColor;
            MenuButton.FlatAppearance.MouseDownBackColor = theme.ActiveColor;
            SettingsButton.FlatAppearance.MouseDownBackColor = theme.ActiveColor;
            ShowMainApplicationButton.FlatAppearance.MouseDownBackColor = theme.ActiveColor;

            RecordButton.FlatAppearance.MouseOverBackColor = theme.MouseOverColor;
            MenuButton.FlatAppearance.MouseOverBackColor = theme.MouseOverColor;
            SettingsButton.FlatAppearance.MouseOverBackColor = theme.MouseOverColor;
            ShowMainApplicationButton.FlatAppearance.MouseOverBackColor = theme.MouseOverColor;
        }

        private async Task RunAsync(string command, CancellationToken cancellationToken = default)
        {
            try
            {
                if (!Process.GetProcessesByName(ApplicationName).Any())
                {
                    var path = Startup.GetFilePath($"{ApplicationName}.exe");
                    if (path == null || string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                    {
                        MessageBox.Show(@"H.Control application is not running and it was not found in startup.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Process.Start(path);

                    await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
                }

                await IpcService.WriteAsync(command, cancellationToken);
            }
            catch (Exception exception)
            {
                OnExceptionOccurred(exception);
            }
        }

        private void AddAction(string key, Action<string?> action)
        {
            try
            {
                ActionDictionary[key.ToLowerInvariant()] = action;
            }
            catch (Exception exception)
            {
                OnExceptionOccurred(exception);
            }
        }

        #endregion
    }
}
