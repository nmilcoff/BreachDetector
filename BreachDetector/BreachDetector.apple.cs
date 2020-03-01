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
        public bool? IsRooted()
        {
            return Securing.IOSSecuritySuiteProxy.AmIJailbroken();
        }
    }
}
