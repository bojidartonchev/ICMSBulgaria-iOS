using CoreGraphics;
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

            //SetupButtons();
        }

        private void SetupButtons()
        {
            var imageSize = NewsButton.ImageView.Frame.Size;
            var titleSize = NewsButton.TitleLabel.Frame.Size;
            var totalHeight = (imageSize.Height + titleSize.Height + 10);
            NewsButton.Frame = new CGRect(20, 50, 200, 50);
            NewsButton.SetImage(UIImage.FromFile("Assets/news.png"), UIControlState.Normal);
            NewsButton.ImageEdgeInsets = new UIEdgeInsets(-(totalHeight - imageSize.Height),
                                            0.0f,
                                            0.0f,
                                            -titleSize.Width);

            NewsButton.TitleEdgeInsets = new UIEdgeInsets(0.0f,
                                                    -imageSize.Width,
                                                    -(totalHeight - titleSize.Height),
                                                    0.0f);

            NewsButton.ContentEdgeInsets = new UIEdgeInsets(0.0f,
                                                    0.0f,
                                                    titleSize.Height,
                                                    0.0f);
        }
    }
}