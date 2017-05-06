// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ICMSBulgaria
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ContactsButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView MainMenuImageBackground { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton NetworkingButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton NewsButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ProgramButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton WorkshopsButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ContactsButton != null) {
                ContactsButton.Dispose ();
                ContactsButton = null;
            }

            if (MainMenuImageBackground != null) {
                MainMenuImageBackground.Dispose ();
                MainMenuImageBackground = null;
            }

            if (NetworkingButton != null) {
                NetworkingButton.Dispose ();
                NetworkingButton = null;
            }

            if (NewsButton != null) {
                NewsButton.Dispose ();
                NewsButton = null;
            }

            if (ProgramButton != null) {
                ProgramButton.Dispose ();
                ProgramButton = null;
            }

            if (WorkshopsButton != null) {
                WorkshopsButton.Dispose ();
                WorkshopsButton = null;
            }
        }
    }
}