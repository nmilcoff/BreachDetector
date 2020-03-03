using Foundation;

namespace Securing
{
	// @interface IOSSecuritySuite : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC16IOSSecuritySuite16IOSSecuritySuite")]
	interface IOSSecuritySuite
	{
		// +(BOOL)amIJailbroken __attribute__((warn_unused_result));
		[Static]
		[Export("amIJailbroken")]
		bool AmIJailbroken();

		// +(BOOL)amIRunInEmulator __attribute__((warn_unused_result));
		[Static]
		[Export("amIRunInEmulator")]
		bool AmIRunInEmulator();

		// +(BOOL)amIDebugged __attribute__((warn_unused_result));
		[Static]
		[Export("amIDebugged")]
		bool AmIDebugged();

		// +(void)denyDebugger;
		[Static]
		[Export("denyDebugger")]
		void DenyDebugger();

		// +(BOOL)amIReverseEngineered __attribute__((warn_unused_result));
		[Static]
		[Export("amIReverseEngineered")]
		bool AmIReverseEngineered();
	}
} 
