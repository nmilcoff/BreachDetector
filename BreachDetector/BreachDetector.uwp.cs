using System;
using System.Diagnostics;
using Windows.Security.ExchangeActiveSyncProvisioning;

namespace Plugin.BreachDetector
{
    /// <summary>
    /// Interface for BreachDetector
    /// </summary>
    public class BreachDetectorImplementation : IBreachDetector
    {
        public bool? IsRooted()
        {
            return null;
        }

        public bool? IsRunningOnVirtualDevice()
        {
            try
            {
                var deviceInfo = new EasClientDeviceInformation();
                var systemProductName = deviceInfo.SystemProductName;
                
                return systemProductName.Contains("Virtual") || systemProductName == "HMV domU"; 
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get UWP Device type {ex.Message}");
                return null;
            }
        }

        public bool? InDebugMode()
        {
            return System.Diagnostics.Debugger.IsAttached;
        }

        public bool? InstalledFromStore()
        {
            // shame there isn't a way even to detect if the app is sideloaded :(
            return null;
        }

        public DeviceSecurityLockScreenType GetDeviceLocalSecurityType()
        {
            return DeviceSecurityLockScreenType.Unknown;
        }
    }
}
