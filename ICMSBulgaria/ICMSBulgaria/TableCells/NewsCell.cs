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
        }

        public static NewsCell Create()
        {
            return (NewsCell)Nib.Instantiate(null, null)[0];
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            this.NewsCellTitle.Text = Model.Title;
            this.NewsCellDate.Text = String.Format("{0:dd/dd/yy}", Model.Date);

            this.NewsCellImage.Image = FromUrl(Model.Image.Url.ToString());
            this.NewsCellImage.SizeToFit();
        }

        static UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }
    }
}