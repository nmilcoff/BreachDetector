using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace TestApp.iOS
{ 
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    { 
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            var allGesturesRecognizer = new AllGesturesRecognizer(delegate
            {
                SessionManager.Instance.ExtendSession();
            });


            var result = base.FinishedLaunching(app, options);

            this.Window.AddGestureRecognizer(allGesturesRecognizer);

            return result;
        }

        // Use this to display a white frame when the app is in background
        public override void OnResignActivation(UIApplication uiApplication)
        {
            var view = new UIView(uiApplication.KeyWindow.Frame)
            {
                BackgroundColor = UIColor.Green,
                Tag = new nint(101)
            };
            uiApplication.KeyWindow.AddSubview(view);
            uiApplication.KeyWindow.BringSubviewToFront(view);
        }

        // when coming back from background, make sure the white frame is removed
        public override void OnActivated(UIApplication uiApplication)
        {
            var view = uiApplication.KeyWindow.ViewWithTag(new nint(101));
            view?.RemoveFromSuperview();
            base.OnActivated(uiApplication);
        }

        class AllGesturesRecognizer : UIGestureRecognizer
        {
            public delegate void OnTouchesEnded();

            private OnTouchesEnded touchesEndedDelegate;

            public AllGesturesRecognizer(OnTouchesEnded touchesEnded)
            {
                this.touchesEndedDelegate = touchesEnded;
            }

            public override void TouchesEnded(NSSet touches, UIEvent evt)
            {
                this.State = UIGestureRecognizerState.Failed;

                this.touchesEndedDelegate();

                base.TouchesEnded(touches, evt);
            }
        }
    } 
}
