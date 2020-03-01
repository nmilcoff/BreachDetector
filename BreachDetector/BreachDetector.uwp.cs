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
            throw new NotImplementedException();
        }

        public bool? IsRunningOnVirtualDevice()
        {
            throw new NotImplementedException();
        }

        public bool? InDebugMode()
        {
            throw new NotImplementedException();
        }
    }
}
