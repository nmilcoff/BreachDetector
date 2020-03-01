using Android.App;
using Android.Content.PM;
using Android.OS;
using Com.Scottyab.Rootbeer;

namespace Plugin.BreachDetector
{
    /// <summary>
    /// Interface for BreachDetector
    /// </summary>
    public class BreachDetectorImplementation : IBreachDetector
    {
        public bool? InDebugMode()
        {
            return Application.Context.ApplicationInfo.Flags.HasFlag(ApplicationInfoFlags.Debuggable)
                || System.Diagnostics.Debugger.IsAttached
                || Debug.IsDebuggerConnected;
        }

        public bool? IsRooted()
        {
            RootBeer rootBeer = new RootBeer(Application.Context);
            
            return rootBeer.IsRooted;
        }

        // reference: https://github.com/flutter/plugins/blob/master/packages/device_info/android/src/main/java/io/flutter/plugins/deviceinfo/MethodCallHandlerImpl.java#L97
        public bool? IsRunningOnVirtualDevice()
        {
            return (Build.Brand.StartsWith("generic") && Build.Device.StartsWith("generic"))
                    || Build.Fingerprint.StartsWith("generic")
                    || Build.Fingerprint.StartsWith("unknown")
                    || Build.Hardware.Contains("goldfish")
                    || Build.Hardware.Contains("ranchu")
                    || Build.Model.Contains("google_sdk")
                    || Build.Model.Contains("Emulator")
                    || Build.Model.Contains("Android SDK built for x86")
                    || Build.Manufacturer.Contains("Genymotion")
                    || Build.Product.Contains("sdk_google")
                    || Build.Product.Contains("google_sdk")
                    || Build.Product.Contains("sdk")
                    || Build.Product.Contains("sdk_x86")
                    || Build.Product.Contains("vbox86p")
                    || Build.Product.Contains("emulator")
                    || Build.Product.Contains("simulator");
        }
    }
}
