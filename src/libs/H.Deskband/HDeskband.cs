using System.Runtime.InteropServices;
using SharpShell.Attributes;
using SharpShell.SharpDeskBand;

namespace H.SearchDeskBand
{
    /// <summary>
    /// 
    /// </summary>
    [ComVisible(true)]
    [DisplayName("Home Center Search")]
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
            return new DeskBandControl
            {
                PipeName = "H.Deskband",
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override BandOptions GetBandOptions()
        {
            return new()
            {
                HasVariableHeight = false,
                IsSunken = false,
                ShowTitle = true,
                Title = "Home Center Search",
                UseBackgroundColour = false,
                AlwaysShowGripper = true
            };
        }
    }
}
