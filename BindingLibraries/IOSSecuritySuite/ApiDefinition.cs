using Foundation;

namespace Securing
{
	// @interface IOSSecuritySuiteProxy : NSObject
	[BaseType(typeof(NSObject))]
	interface IOSSecuritySuiteProxy
	{
		// +(BOOL)amIJailbroken __attribute__((warn_unused_result));
		[Static]
		[Export("amIJailbroken")]
		bool AmIJailbroken();

		// +(JailBreakResult * _Nonnull)amIJailbrokenWithFailMessage __attribute__((warn_unused_result));
		[Static]
		[Export("amIJailbrokenWithFailMessage")]
		JailBreakResult AmIJailbrokenWithFailMessage();

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

	// @interface JailBreakResult : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface JailBreakResult
	{
		// @property (readonly, nonatomic) BOOL jailbroken;
		[Export("jailbroken")]
		bool Jailbroken { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull failMessage;
		[Export("failMessage")]
		string FailMessage { get; }
	}
}
