using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.BreachDetector
{
    public interface IBreachDetector
    {
        bool? IsRooted();

        bool? IsRunningOnVirtualDevice();
    }
}
