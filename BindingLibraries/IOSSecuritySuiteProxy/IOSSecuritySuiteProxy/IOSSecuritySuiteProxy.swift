//
//  IOSSecuritySuiteProxy.swift
//  IOSSecuritySuiteProxy
//
//  Created by Nico Milcoff on 29/02/2020.
//  Copyright © 2020 nmilcoff. All rights reserved.
//

import Foundation
import UIKit
import IOSSecuritySuite

@objc(IOSSecuritySuiteProxy)
public class IOSSecuritySuiteProxy : NSObject {

    @objc public static func amIJailbroken() -> Bool {
        return IOSSecuritySuite.amIJailbroken()
    }
    
    @objc public static func amIJailbrokenWithFailMessage() -> JailBreakResult {
        let (jailbroken, failMessage) = IOSSecuritySuite.amIJailbrokenWithFailMessage()
        return JailBreakResult(jailbroken: jailbroken,failMessage: failMessage)
    }
    
//    @objc public static func amIJailbrokenWithFailedChecks() -> JailBreakResultWithChecks {
//        let (jailbroken, failedChecks) = IOSSecuritySuite.amIJailbrokenWithFailedChecks()
//
//        var failed: [FailedCheck] = []
//        for failedCheck in failedChecks {
//            failed.append(FailedCheck(check: failedCheck.check, failMessage: failedCheck.failMessage))
//        }
//
//        return JailBreakResultWithChecks(jailbroken: jailbroken, failedChecks: failed)
//    }
    
    @objc public static func amIRunInEmulator() -> Bool {
        return IOSSecuritySuite.amIRunInEmulator()
    }
    
    @objc public static func amIDebugged() -> Bool {
        return IOSSecuritySuite.amIDebugged()
    }
    
    @objc public static func denyDebugger() {
        return IOSSecuritySuite.denyDebugger()
    }
    
    @objc public static func amIReverseEngineered() -> Bool {
        return IOSSecuritySuite.amIReverseEngineered()
    }
}

@objc(JailBreakResult)
public class JailBreakResult: NSObject {
    @objc public let jailbroken: Bool
    @objc public let failMessage: String

    init(jailbroken: Bool, failMessage: String) {
        self.jailbroken = jailbroken
        self.failMessage = failMessage
    }
}

//@objc(JailBreakResultWithChecks)
//public class JailBreakResultWithChecks: NSObject {
//    let jailbroken: Bool
//    let failedChecks: [FailedCheck]
//
//    init(jailbroken: Bool, failedChecks: [FailedCheck]) {
//        self.jailbroken = jailbroken
//        self.failedChecks = failedChecks
//    }
//}
//
//@objc(FailedCheck)
//public class FailedCheck: NSObject {
//    let check: JailbreakCheck
//    let failMessage: String
//
//    init(check: JailbreakCheck, failMessage: String) {
//        self.check = check
//        self.failMessage = failMessage
//    }
//}
