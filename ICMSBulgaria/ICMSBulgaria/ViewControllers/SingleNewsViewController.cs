using CoreGraphics;
using Foundation;
using ICMSBulgaria.Models;
using System;
using UIKit;

namespace ICMSBulgaria
{
    public partial class SingleNewsViewController : UIViewController
    {
        public News NewsObject { get; set; }

        public SingleNewsViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var image = new UIImageView();
            image.Frame = new CGRect(0, 0, View.Bounds.Width, View.Bounds.Height);
            image.Image = UIImage.FromFile("Assets/backgroundsecondary.jpg");
            View.AddSubview(image);            

            var newsImage = new UIImageView();            
            newsImage.Image = FromUrl(NewsObject.Image);
            newsImage.Frame = new CGRect(15, 90, View.Bounds.Width - 30, 150);
            newsImage.ContentMode = UIViewContentMode.ScaleAspectFill;
            newsImage.ClipsToBounds = true;
            newsImage.Layer.CornerRadius = 5;
            newsImage.Layer.MasksToBounds = true;
            View.AddSubview(newsImage);

            var NewsTitle = new UILabel();
            NewsTitle.Frame = new CGRect(30, 30, View.Bounds.Width - 60, 25);
            NewsTitle.Font = UIFont.PreferredTitle1;
            NewsTitle.Text = NewsObject.Title;
            NewsTitle.TextAlignment = UITextAlignment.Center;
            NewsTitle.Lines = 0; // 0 means unlimited
            View.AddSubview(NewsTitle);

            var newsDate = new UILabel();
            newsDate.Frame = new CGRect(30, 60, View.Bounds.Width - 60, 25);
            newsDate.Font = UIFont.PreferredSubheadline;
            newsDate.Text = String.Format("{0:dd/MM/yy HH:mm}", NewsObject.Date);
            newsDate.TextAlignment = UITextAlignment.Center;
            View.AddSubview(newsDate);

            var content = new UITextView();
            content.Frame = new CGRect(15, newsImage.Frame.Y + newsImage.Frame.Height + 20, View.Bounds.Width - 30, 250);
            content.Text = NewsObject.Content;
            content.TextAlignment = UITextAlignment.Left;
            content.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 50);
            content.Layer.CornerRadius = 5;
            content.Layer.MasksToBounds = true;
            content.Editable = false;
            View.AddSubview(content);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);           
            
        }

        static UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }
    }
}