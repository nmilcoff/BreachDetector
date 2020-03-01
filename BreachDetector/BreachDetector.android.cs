using Android.App;
using Com.Scottyab.Rootbeer;
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
            RootBeer rootBeer = new RootBeer(Application.Context);
            
            return rootBeer.IsRooted;
        }

        public bool? IsRunningOnVirtualDevice()
        {
            throw new NotImplementedException();
        }
    }
}
