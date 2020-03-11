# BreachDetector

[![Build status](https://dev.azure.com/nicolasmilcoff/BreachDetector/_apis/build/status/nmilcoff.BreachDetector)](https://dev.azure.com/nicolasmilcoff/BreachDetector/_build/latest?definitionId=2)
[![NuGet](https://img.shields.io/nuget/v/BreachDetector.svg?label=NuGet)](https://www.nuget.org/packages/BreachDetector)


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

## :iphone: Platforms supported
- iOS 10+
- Android API +14
- UWP Build 10240+

## :key: Key features 

- Root/Jailbreak detection
- Debug mode detection
- Emulator/simulator detection
- Store installation detection

## :bulb: Examples

```c#
using Plugin.BreachDetector;

var isRootOrJailbreak = CrossBreachDetector.Current.IsRooted();
var isVirtualDevice = CrossBreachDetector.Current.IsRunningOnVirtualDevice();
var inDebug = CrossBreachDetector.Current.InDebugMode();
var fromStore = CrossBreachDetector.Current.InstalledFromStore(); 
```

## :lock: Security considerations
- The approach of this library is to rely on "traditional" iOS/Android libraries as much as possible. The reason is simply that the size of those communities is bigger compared to Xamarin.
- Security is a cat and mouse game. Please be aware this library will try its best, but it might be defeated.
- If possible, use AOT for your Xamarin.Android app (enabled by default in Xamarin.iOS, requires Enterprise license for Xamarin.Android). When using AOT, your IL code will be compiled into native instructions (x86, ARM instructions) and your code will be more difficult to reverse engineer.
- Be aware ProGuard will only shrink the code of your Xamarin.Android app, obfuscation only works on the Java end. 
- To learn more about mobile security, I would highly recommend you start with the [OWASP Mobile Application Security Verification Standard](https://github.com/OWASP/owasp-masvs) .


## :construction_worker: Contributions

Yes, please! [Issues](https://github.com/nmilcoff/BreachDetector/issues) are open and PRs are very much welcome.

## :bow: Acknowledgements
- Many iOS features are implemented through a binding library of [IOSSecuritySuite](https://github.com/nmilcoff/IOSSecuritySuite) (MIT)
- Root detection on Android is implemented through a binding library of [rootbeer](https://github.com/nmilcoff/rootbeer) (MIT)

## :scroll: License

BreachDetector is licensed under [MIT](https://github.com/nmilcoff/BreachDetector/blob/master/LICENSE).
