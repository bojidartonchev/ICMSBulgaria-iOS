using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace ICMSBulgaria
{
    public partial class ContactsViewController : UIViewController
    {
        public ContactsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //Background
            var image = new UIImageView();
            image.Frame = new CGRect(0, 0, View.Bounds.Width, View.Bounds.Height);
            image.Image = UIImage.FromFile("Assets/backgroundsecondary.jpg");
            View.AddSubview(image);

            //Logo
            var newsImage = new UIImageView();
            newsImage.Image = UIImage.FromFile("Assets/icmsbg.png");
            newsImage.Frame = new CGRect(15, 90, View.Bounds.Width - 30, 150);
            newsImage.ContentMode = UIViewContentMode.ScaleAspectFit;
            newsImage.ClipsToBounds = true;
            newsImage.Layer.CornerRadius = 5;
            newsImage.Layer.MasksToBounds = true;
            View.AddSubview(newsImage);

            var newsDate = new UILabel();
            newsDate.Frame = new CGRect(15, 250, View.Bounds.Width - 30, 30);
            newsDate.Font = UIFont.PreferredSubheadline;
            newsDate.Text = String.Format("Email:aaaa@abv.bg");
            newsDate.TextAlignment = UITextAlignment.Center;
            View.AddSubview(newsDate);

        }
    }
}