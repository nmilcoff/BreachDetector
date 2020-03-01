using System;
using System.Collections.Generic;
using System.Text;

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
