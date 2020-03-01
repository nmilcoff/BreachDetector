using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.BreachDetector
{
    public interface IBreachDetector
    {
        /// <summary>
        /// Detect jailbreak / root conditions
        /// </summary>
        /// <returns>True if device is jailbreak/root, false otherwise</returns>
        bool? IsRooted();

        /// <summary>
        /// Determine on what environment is your app running
        /// </summary>
        /// <returns>True if running on an emulator/simulator, false otherwise</returns>
        bool? IsRunningOnVirtualDevice();

        /// <summary>
        /// Detect if a debugger is attached
        /// NOTE: On Android the method will return true if the debuggable flag is present in the AndroidManifest
        /// </summary>
        /// <returns>True if being debugged, false otherwise</returns>
        bool? InDebugMode();

        /// <summary>
        /// For Android, check if installed from Google Play, Amazon App Store or Samsung Galaxy Apps
        /// For iOS, check if installed from App Store
        /// </summary>
        /// <returns>True if installed from an official App Store, false otherwise</returns>
        bool? InstalledFromStore();
    }
}
