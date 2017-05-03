using CoreGraphics;
using Foundation;
using ICMSBulgaria.Models;
using System;
using UIKit;

namespace ICMSBulgaria
{
    public partial class NewsCell : UITableViewCell
    {
        public static readonly UINib Nib = UINib.FromName("NewsCell", NSBundle.MainBundle);
        public static readonly NSString Key = new NSString("NewsCell");

        public News Model { get; set; }

        public NewsCell (IntPtr handle) : base (handle)
        {
            Image = new UIImageView();
        }

        public static NewsCell Create()
        {
            return (NewsCell)Nib.Instantiate(null, null)[0];
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            Image.Frame = new CGRect(15, 15, 100, 100);
            Image.ContentMode = UIViewContentMode.ScaleAspectFill;
            Title.Frame = new CGRect(130, 30, ContentView.Bounds.Width - 130, 25);
            Subtitle.Frame = new CGRect(130, 80, ContentView.Bounds.Width - 130, 25);

            this.Title.Text = Model.Title;
            this.Subtitle.Text = String.Format("{0:dd/MM/yy}", Model.Date);

            this.Image.Image = FromUrl(Model.Image);
        }

        static UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }
    }    
}