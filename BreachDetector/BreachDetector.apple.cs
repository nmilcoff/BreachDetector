using System;
using System.Collections.Generic;
using System.Text;
using Foundation;

namespace Plugin.BreachDetector
{
    /// <summary>
    /// Interface for BreachDetector
    /// </summary>
    public class BreachDetectorImplementation : IBreachDetector
    {
        public bool? InDebugMode()
        {
            return Securing.IOSSecuritySuiteProxy.AmIDebugged() || System.Diagnostics.Debugger.IsAttached;
        }

        public bool? InstalledFromStore()
        {
            try
            {
                var file = NSData.FromFile(NSBundle.MainBundle.PathForResource("embedded", "mobileprovision"));
                // If file doesn't exist, the installation is from AppStore
                if (file == null)
                {
                    return true;
                }
            }
            catch
            {
            }

            return false;
        }

        public bool? IsRooted()
        {
            return Securing.IOSSecuritySuiteProxy.AmIJailbroken();
        }

        public bool? IsRunningOnVirtualDevice()
        {
            return Securing.IOSSecuritySuiteProxy.AmIRunInEmulator();
        }
    }
}
