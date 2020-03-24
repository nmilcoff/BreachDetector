using System.Linq;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Com.Scottyab.Rootbeer;
using Diff.Strazzere.Anti.Debugger;
using Diff.Strazzere.Anti.Emulator;

namespace Plugin.BreachDetector
{
    /// <summary>
    /// Interface for BreachDetector
    /// </summary>
    public class BreachDetectorImplementation : IBreachDetector
    {
        private readonly string[] _stores =
        {
            "com.android.vending",
            "com.google.android.feedback",
            "com.amazon.venezia",
            "com.sec.android.app.samsungapps"
        };

        public bool? InDebugMode()
        { 
            bool tracer = false;
            try
            {
                tracer = FindDebugger.HasTracerPid;
            }
            catch 
            {
            }

            return Debug.IsDebuggerConnected
                    || tracer
                    || Application.Context.ApplicationInfo.Flags.HasFlag(ApplicationInfoFlags.Debuggable)
                    || System.Diagnostics.Debugger.IsAttached;
        }

        public bool? InstalledFromStore()
        {
            var installer = Application.Context.PackageManager.GetInstallerPackageName(Application.Context.PackageName);

            return !string.IsNullOrEmpty(installer) && _stores.Contains(installer);
        }

        public bool? IsRooted()
        {
            var rootBeer = new RootBeer(Application.Context);
            
            return rootBeer.IsRooted;
        }

        // reference: Anti-Emulator + https://github.com/flutter/plugins/blob/master/packages/device_info/android/src/main/java/io/flutter/plugins/deviceinfo/MethodCallHandlerImpl.java#L97
        public bool? IsRunningOnVirtualDevice()
        {
            return FindEmulator.HasEmulatorBuild(Application.Context)
                    || FindEmulator.HasPipes
                    || FindEmulator.HasQEmuDrivers
                    || FindEmulator.HasEmulatorAdb
                    || FindEmulator.HasQEmuFiles
                    || FindEmulator.HasGenyFiles
                    || (Build.Brand.StartsWith("generic") && Build.Device.StartsWith("generic"))
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
