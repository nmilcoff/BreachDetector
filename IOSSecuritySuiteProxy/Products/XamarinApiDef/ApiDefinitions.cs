using Foundation;
using IOSSecuritySuiteProxy;

namespace Binding
{
	// @interface IOSSecuritySuiteProxy : NSObject
	[BaseType (typeof(NSObject))]
	interface IOSSecuritySuiteProxy
	{
		// +(BOOL)amIJailbroken __attribute__((warn_unused_result));
		[Static]
		[Export ("amIJailbroken")]
		[Verify (MethodToProperty)]
		bool AmIJailbroken { get; }

		// +(JailBreakResult * _Nonnull)amIJailbrokenWithFailMessage __attribute__((warn_unused_result));
		[Static]
		[Export ("amIJailbrokenWithFailMessage")]
		[Verify (MethodToProperty)]
		JailBreakResult AmIJailbrokenWithFailMessage { get; }

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

	// @interface JailBreakResult : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface JailBreakResult
	{
		// @property (readonly, nonatomic) BOOL jailbroken;
		[Export ("jailbroken")]
		bool Jailbroken { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull failMessage;
		[Export ("failMessage")]
		string FailMessage { get; }
	}
}
