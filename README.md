# BreachDetector

[![Build status](https://dev.azure.com/nicolasmilcoff/BreachDetector/_apis/build/status/nmilcoff.BreachDetector)](https://dev.azure.com/nicolasmilcoff/BreachDetector/_build/latest?definitionId=2)
[![NuGet](https://img.shields.io/nuget/v/Plugin.BreachDetector.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.BreachDetector/)


## :wrench: Setup

Grab the latest NuGet package and install in your solution:

    Install-Package Plugin.BreachDetector

In your iOS app, update the Info.plist and add the following URLs (those are queried as part of detecting jailbreak):

```xml
<key>LSApplicationQueriesSchemes</key>
<array>
	<string>cydia</string>
	<string>undecimus</string>
	<string>sileo</string>
	<string>zbra</string>
</array>
``` 

Additionally, if you want to use `GetDeviceLocalSecurityType()` method on iOS, you need to add an additional key to the Info.plist:

```xml
<key>NSFaceIDUsageDescription</key>
<string>Use a nice explanation here</string>
```

## :iphone: Platforms supported

- iOS +10
- Android API +21
- UWP Build +10240

## :key: Key features 

- Root/Jailbreak detection
- Debug mode detection
- Emulator/simulator detection
- Store installation detection
- Device local authentication method detection

## :bulb: Examples

```c#
using Plugin.BreachDetector;

var isRootOrJailbreak = CrossBreachDetector.Current.IsRooted();
var isVirtualDevice = CrossBreachDetector.Current.IsRunningOnVirtualDevice();
var inDebug = CrossBreachDetector.Current.InDebugMode();
var fromStore = CrossBreachDetector.Current.InstalledFromStore(); 
var localAuthentication = CrossBreachDetector.Current.GetDeviceLocalSecurityType(); // values: Unknown, None, Pass, Biometric
```

Note: For a method that returns `bool?`, you can expect the result to be null if the platform that is running doesn't have an appropiate representation (example: `IsRooted` will return `null` for UWP).

## :lock: Security considerations

- The approach of this library is to rely on "traditional" iOS/Android libraries as much as possible. The reason is simply that the size of those communities is bigger compared to Xamarin.
- Security is a cat and mouse game. Please be aware this library will try its best, but it might be defeated.
- If possible, use AOT for your Xamarin.Android app (enabled by default in Xamarin.iOS, requires Enterprise license for Xamarin.Android). When using AOT, your IL code will be compiled into native instructions (x86, ARM instructions) and your code will be more difficult to reverse engineer.
- Be aware ProGuard will only shrink the code of your Xamarin.Android app, obfuscation only works on the Java end. 
- Don't hardcode any of your keys in your mobile apps, those are really easy to spot using simple tools. In most cases you can serve them from your API.
- To learn more about mobile security, I would highly recommend you start with the [OWASP Mobile Application Security Verification Standard](https://github.com/OWASP/owasp-masvs) .

## Good practices (OWASP)

The sample app in this repository also contains some good practices implementations that are not part of the BreachDetector library, but that you can copy into your own code:

#### MSTG-ARCH-9: A mechanism for enforcing updates of the mobile app exists.

[Xamarin.Essentials VersionTracking](https://docs.microsoft.com/en-us/xamarin/essentials/version-tracking) to track the install versions of your app in the user device. If the current version is deprecated, you should take the user to a screen where it is asked to download the updated version. [Here](https://github.com/nmilcoff/BreachDetector/blob/develop/TestApp/TestApp/App.xaml.cs#L19) is an examlpe.

#### MSTG-STORAGE-9: The app removes sensitive data from views when moved to the background.

- On Android you can set the `Secure` flags for the Window, [here](https://github.com/nmilcoff/BreachDetector/blob/develop/TestApp/TestApp.Android/MainActivity.cs#L29) is an example. This will hide the content of the UI when the app is in background and also prevent the user from taking screenshots. Please be aware though the scope has [some limitations](https://github.com/commonsguy/cwac-security/blob/master/docs/FLAGSECURE.md) related to child windows.
- On iOS you can use the AppDelegate lifecycle methods to add / remove an image on top of your UI to hide the content (also note that on iOS you can't prevent the user from taking screenshots). [Here](https://github.com/nmilcoff/BreachDetector/blob/develop/TestApp/TestApp.iOS/AppDelegate.cs#L20) is an example for this implementation. It is also possible to identify when the user takes a screenshoot and trigger an event. [Here](https://github.com/nmilcoff/BreachDetector/blob/develop/TestApp/TestApp.iOS/AppDelegate.cs#L60) is an example for this implementation. 

#### Auto-logout due to user inactivity

The sample app in this repository has [this mechanism](https://stackoverflow.com/a/51727021/5000213) implemented. You can see it [here](https://github.com/nmilcoff/BreachDetector/blob/test-app/TestApp/TestApp/App.xaml.cs#L26).

## :construction_worker: Contributions

Yes, please! [Issues](https://github.com/nmilcoff/BreachDetector/issues) are open for bugs/ideas and PRs are also welcome.

## :bow: Acknowledgements

- Many iOS features are implemented through a binding library for [IOSSecuritySuite](https://github.com/nmilcoff/IOSSecuritySuite) (MIT)
- Root detection on Android is implemented through binding libraries for [rootbeer](https://github.com/nmilcoff/rootbeer) (MIT) and [Anti-Emulator](https://github.com/nmilcoff/anti-emulator) (Apache-2.0)

## :scroll: License

BreachDetector is licensed under [MIT](https://github.com/nmilcoff/BreachDetector/blob/master/LICENSE).
