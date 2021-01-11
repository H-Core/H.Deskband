using System.Runtime.InteropServices;
using H.Deskband.Core;
using SharpShell.Attributes;
using SharpShell.SharpDeskBand;

namespace H.Deskband
{
    /// <summary>
    /// 
    /// </summary>
    [ComVisible(true)]
    [DisplayName("H.Deskband")]
    [Guid("AE9E11C0-E4FD-4F96-B9B6-66CC76C2B45D")]
    [ProgId("H.Deskband")]
    public sealed class HDeskband : SharpDeskBand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override System.Windows.Forms.UserControl CreateDeskBand()
        {
            var control = new DeskBandControl
            {
                PipeName = "H.Deskband",
            };
            //control.Running += async (_, _) =>
            //{
            //    var applicationName = "HomeCenter.NET";
            //    if (Process.GetProcessesByName(applicationName).Any())
            //    {
            //        return;
            //    }

            //    var path = Startup.GetFilePath($"{applicationName}.exe");
            //    if (path == null || string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            //    {
            //        MessageBox.Show(@"H.Control application is not running and it was not found in startup.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    Process.Start(path);

            //    await Task.Delay(TimeSpan.FromSeconds(1));
            //};

            return control;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override BandOptions GetBandOptions()
        {
            return new()
            {
                HasVariableHeight = true,
                IsSunken = false,
                ShowTitle = true,
                Title = "H.Deskband",
                UseBackgroundColour = false,
                AlwaysShowGripper = true,
            };
        }
    }
}
