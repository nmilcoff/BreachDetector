# BreachDetector

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

## :lock: Security considerations

- If possiblee, use AOT for your Xamarin.Android app (enabled by default in Xamarin.iOS, requires Enterprise license for Xamarin.Android). When using AOT, your IL code will be compiled into native instructions (x86, ARM instructions).
- Be aware Proguard will only shrink the code of your Xamarin.Android app, obfuscation only works on the Java end. 
- To learn more about mobile security, I would highly recommend you start with the [OWASP Mobile Application Security Verification Standard](https://github.com/OWASP/owasp-masvs) .

## :bulb: Examples

```c#
using Plugin.BreachDetector;

var isRootOrJailbreak = CrossBreachDetector.Current.IsRooted();
var isVirtualDevice = CrossBreachDetector.Current.IsRunningOnVirtualDevice();
var inDebug = CrossBreachDetector.Current.InDebugMode();
var fromStore = CrossBreachDetector.Current.InstalledFromStore(); 
```

## :construction_worker: Contributions

Yes, please! [Issues](https://github.com/nmilcoff/BreachDetector/issues) are open and PRs are very much welcome.

## :bow: Acknowledgements
- Many iOS features are implemented through a binding library of [IOSSecuritySuite](https://github.com/nmilcoff/IOSSecuritySuite) (MIT)
- Root detection on Android is implemented through a binding library of [rootbeer](https://github.com/nmilcoff/rootbeer) (MIT)

## :scroll: License

BreachDetector is licensed under [MIT](https://github.com/nmilcoff/BreachDetector/blob/master/LICENSE).
