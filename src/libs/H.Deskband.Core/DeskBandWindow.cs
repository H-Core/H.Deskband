﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using H.Utilities;

namespace H.Deskband.Core
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class DeskBandWindow : Form
    {
        #region Constants

        /// <summary>
        /// 
        /// </summary>
        public new const string CompanyName = "HomeCenter.NET";

        #endregion

        #region Events

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<Exception>? ExceptionOccurred;
        
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<string>? CommandSent;

        private void OnExceptionOccurred(Exception exception)
        {
            ExceptionOccurred?.Invoke(this, exception);
        }

        private void OnCommandSent(string command)
        {
            CommandSent?.Invoke(this, command);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public DeskBandWindow()
        {
            InitializeComponent();

            #region Auto Complete

            var storage = new CommandsStorage(CompanyName);
            storage.Load();

            var collection = new AutoCompleteStringCollection();
            collection.AddRange(storage.Select(i => i.Key).ToArray());
            InputTextBox.AutoCompleteCustomSource = collection;

            #endregion

            UpdateHistory();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theme"></param>
        public void ApplyTheme(ColorTheme theme)
        {
            InputPanel.BackColor = theme.BackgroundColor;
            InputTextBox.BackColor = theme.BackgroundColor;
            InputTextBox.ForeColor = theme.TextColor;

            foreach (TabPage page in TabControl.TabPages)
            {
                page.BackColor = theme.BackgroundColor;
                page.ForeColor = theme.TextColor;

                foreach (Control control in page.Controls)
                {
                    control.BackColor = theme.BackgroundColor;
                    control.ForeColor = theme.TextColor;
                }
            }
        }

        #endregion

        #region Private methods

        private void UpdateHistory()
        {
            try
            {
                HistoryListBox.Items.Clear();

                var history = new CommandsHistory(CompanyName).Load();
                foreach (var command in history)
                {
                    HistoryListBox.Items.Add(command);
                }
            }
            catch (Exception exception)
            {
                OnExceptionOccurred(exception);
            }
        }

        private void DeskBandWindow_Deactivate(object sender, EventArgs e)
        {
            try
            {
                Hide();
            }
            catch (Exception exception)
            {
                OnExceptionOccurred(exception);
            }
        }

        private void DeskBandWindow_Activated(object sender, EventArgs e)
        {
            try
            {
                UpdateHistory();

                InputTextBox.Focus();
                //deskBandControl1.Focus();
            }
            catch (Exception exception)
            {
                OnExceptionOccurred(exception);
            }
        }

        private async Task RunAsync(string command, CancellationToken cancellationToken = default)
        {
            try
            {
                OnCommandSent(command);
                Hide();

                await Task.Delay(1000, cancellationToken); // TODO: fix

                UpdateHistory();
            }
            catch (Exception exception)
            {
                OnExceptionOccurred(exception);
            }
        }

        private async void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter)
                {
                    return;
                }

                var command = InputTextBox.Text;

                InputTextBox.Clear();

                await RunAsync(command);
            }
            catch (Exception exception)
            {
                OnExceptionOccurred(exception);
            }
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            try
            {
                InputTextBox.Focus();
            }
            catch (Exception exception)
            {
                OnExceptionOccurred(exception);
            }
        }

        private async void HistoryListBox_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!(HistoryListBox.SelectedItem is string item))
                {
                    return;
                }

                await RunAsync(item);
            }
            catch (Exception exception)
            {
                OnExceptionOccurred(exception);
            }
        }

        private void ClearHistoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                new CommandsHistory(CompanyName).Clear();
                UpdateHistory();
            }
            catch (Exception exception)
            {
                OnExceptionOccurred(exception);
            }
        }

        #endregion
    }
}
