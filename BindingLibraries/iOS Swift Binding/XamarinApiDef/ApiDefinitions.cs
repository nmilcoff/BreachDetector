using Foundation;

namespace Binding
{
	// @interface IOSSecuritySuite : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC16IOSSecuritySuite16IOSSecuritySuite")]
	interface IOSSecuritySuite
	{
		// +(BOOL)amIJailbroken __attribute__((warn_unused_result));
		[Static]
		[Export ("amIJailbroken")]
		[Verify (MethodToProperty)]
		bool AmIJailbroken { get; }

		// +(BOOL)amIRunInEmulator __attribute__((warn_unused_result));
		[Static]
		[Export ("amIRunInEmulator")]
		[Verify (MethodToProperty)]
		bool AmIRunInEmulator { get; }

		// +(BOOL)amIDebugged __attribute__((warn_unused_result));
		[Static]
		[Export ("amIDebugged")]
		[Verify (MethodToProperty)]
		bool AmIDebugged { get; }

		// +(void)denyDebugger;
		[Static]
		[Export ("denyDebugger")]
		void DenyDebugger ();

		// +(BOOL)amIReverseEngineered __attribute__((warn_unused_result));
		[Static]
		[Export ("amIReverseEngineered")]
		[Verify (MethodToProperty)]
		bool AmIReverseEngineered { get; }
	}
}
