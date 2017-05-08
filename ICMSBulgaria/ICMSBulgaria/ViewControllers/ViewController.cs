using CoreGraphics;
using Foundation;
using System;

using UIKit;

namespace ICMSBulgaria
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {           
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            MainMenuImageBackground.Frame = new CGRect(0, 0, View.Bounds.Width, View.Bounds.Height);
            //MainMenuImageBackground.ContentMode = UIViewContentMode.ScaleAspectFill;

            this.NavigationController.NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            this.NavigationController.NavigationBar.ShadowImage = new UIImage();
            this.NavigationController.NavigationBar.Translucent = true;

            SetupButtons();
        }

        private void SetupButtons()
        {
            var buttonWidth = 50; //Square button 50x50;
            var buttonHeight = 75;

            var parentHeight = View.Bounds.Height;
            var parentWidth = View.Bounds.Width;

            var sectionHeight = (parentHeight / 5);
            var sectionWidth = (parentWidth / 3);

            var buttonPaddingX = (sectionWidth - buttonWidth) / 2;
            var buttonPaddingY = (sectionHeight - buttonWidth) / 2;

            //First line
            this.NewsButton.Frame = new CGRect(buttonPaddingX, sectionHeight + buttonPaddingY, buttonWidth, buttonHeight);

            this.ProgramButton.Frame = new CGRect(sectionWidth + buttonPaddingX, sectionHeight + buttonPaddingY, buttonWidth, buttonHeight);

            this.WorkshopsButton.Frame = new CGRect(2 *sectionWidth + buttonPaddingX, sectionHeight + buttonPaddingY, buttonWidth, buttonHeight);

            //Second Line
            this.SpeakersButton.Frame = new CGRect(buttonPaddingX, 2 *sectionHeight + buttonPaddingY, buttonWidth, buttonHeight);

            this.NetworkingButton.Frame = new CGRect(2 * sectionWidth + buttonPaddingX, 2 * sectionHeight + buttonPaddingY, buttonWidth, buttonHeight);

            //Third Line
            this.VenuesButton.Frame = new CGRect(buttonPaddingX, 3 * sectionHeight + buttonPaddingY, buttonWidth, buttonHeight);

            this.ContactsButton.Frame = new CGRect(2 * sectionWidth + buttonPaddingX, 3 * sectionHeight + buttonPaddingY, buttonWidth, buttonHeight);
        }
    }
}