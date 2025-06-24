using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace YourProjectName
{
    public static class DesignModeHelper
    {
        // Evaluated only once at application start and cached for future use
        private static readonly Lazy<bool> _isInDesignMode = new Lazy<bool>(() =>
            // Checks if running in Visual Studio designer or design-time mode
            LicenseManager.UsageMode == LicenseUsageMode.Designtime ||
            Process.GetCurrentProcess().ProcessName.Equals("devenv", StringComparison.OrdinalIgnoreCase)
        );

        /// <summary>
        /// General usage: Checks whether the code is running in design mode.
        /// </summary>
        public static bool IsInDesignMode() => _isInDesignMode.Value;

        /// <summary>
        /// More reliable design mode check for a specific control instance.
        /// </summary>
        /// <param name="control">The control instance to check</param>
        public static bool IsInDesignMode(Control control)
        {
            // Returns true if app is in design mode globally or the control's Site.DesignMode is true
            return _isInDesignMode.Value || (control?.Site?.DesignMode ?? false);
        }
    }
}
