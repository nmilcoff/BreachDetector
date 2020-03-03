https://docs.microsoft.com/en-us/xamarin/ios/platform/binding-swift/walkthrough

Clone https://github.com/securing/IOSSecuritySuite

In Xcode, project -> target framework -> Build settings
- Always Embed Swift Standard Libraries = true
- Enable bitcode = false
- Change schema to Release

cp -R "Release-iphonesimulator/IOSSecuritySuite.framework/Modules/IOSSecuritySuite.swiftmodule/" "Release-fat/IOSSecuritySuite.framework/Modules/SwiftFrameworkProxy.swiftmodule/"

lipo -create -output "Release-fat/IOSSecuritySuite.framework/IOSSecuritySuite" "Release-iphoneos/IOSSecuritySuite.framework/IOSSecuritySuite" "Release-iphonesimulator/IOSSecuritySuite.framework/IOSSecuritySuite"

lipo -info "Release-fat/IOSSecuritySuite.framework/IOSSecuritySuite"

sharpie bind --sdk=iphoneos13.2 --output="XamarinApiDef" --namespace="Binding" --scope="Release-fat/IOSSecuritySuite.framework/Headers/" "Release-fat/IOSSecuritySuite.framework/Headers/IOSSecuritySuite-Swift.h"