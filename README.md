# BreachDetector

[![Build status](https://dev.azure.com/nicolasmilcoff/BreachDetector/_apis/build/status/nmilcoff.BreachDetector)](https://dev.azure.com/nicolasmilcoff/BreachDetector/_build/latest?definitionId=2)
[![NuGet](https://img.shields.io/nuget/v/Plugin.BreachDetector.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.BreachDetector/)


## :wrench: Setup

Grab the latest NuGet package and install in your solution:

    Install-Package BreachDetector

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
- iOS 10+
- Android API +16
- UWP Build 10240+

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


## :construction_worker: Contributions

Yes, please! [Issues](https://github.com/nmilcoff/BreachDetector/issues) are open for bugs/ideas and PRs are also welcome.

## :bow: Acknowledgements
- Many iOS features are implemented through a binding library of [IOSSecuritySuite](https://github.com/nmilcoff/IOSSecuritySuite) (MIT)
- Root detection on Android is implemented through a binding library of [rootbeer](https://github.com/nmilcoff/rootbeer) (MIT)

## :scroll: License

BreachDetector is licensed under [MIT](https://github.com/nmilcoff/BreachDetector/blob/master/LICENSE).
