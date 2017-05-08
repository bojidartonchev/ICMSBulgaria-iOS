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

            var adress = new UILabel();
            adress.Frame = new CGRect(15, 250, View.Bounds.Width - 30, 30);
            adress.Font = UIFont.PreferredSubheadline;
            adress.TextAlignment = UITextAlignment.Center;            
            var attchment = new NSTextAttachment();
            attchment.Image = UIImage.FromFile("Assets/locmarker.png");
            attchment.Bounds = new CGRect(0, -2, 14, 14);
            var newText = new NSMutableAttributedString();
            newText.Append(NSAttributedString.CreateFrom(attchment));
            NSAttributedString s = new NSAttributedString("1431 Bulgaria, Sofia 2 Zdrave Str.");
            newText.Append(s);
            adress.AttributedText = newText;
            View.AddSubview(adress);


            var phone = new UILabel();
            phone.Frame = new CGRect(15, 290, View.Bounds.Width - 30, 30);
            phone.Font = UIFont.PreferredSubheadline;
            phone.TextAlignment = UITextAlignment.Center;
            var attchment2 = new NSTextAttachment();
            attchment2.Image = UIImage.FromFile("Assets/phone_number_telephone-512.png");
            attchment2.Bounds = new CGRect(0, -2, 14, 14);
            var newText2 = new NSMutableAttributedString();
            newText2.Append(NSAttributedString.CreateFrom(attchment2));
            NSAttributedString s2 = new NSAttributedString("+359 887004467");
            newText2.Append(s2);
            phone.AttributedText = newText2;
            View.AddSubview(phone);

            var mail = new UILabel();
            mail.Frame = new CGRect(15, 330, View.Bounds.Width - 30, 30);
            mail.Font = UIFont.PreferredSubheadline;
            mail.TextAlignment = UITextAlignment.Center;
            var attchment3 = new NSTextAttachment();
            attchment3.Image = UIImage.FromFile("Assets/12633-200.png");
            attchment3.Bounds = new CGRect(0, -2, 14, 14);
            var newText3 = new NSMutableAttributedString();
            newText3.Append(NSAttributedString.CreateFrom(attchment3));
            NSAttributedString s3 = new NSAttributedString("info@icmsbg.org");
            newText3.Append(s3);
            mail.AttributedText = newText3;
            View.AddSubview(mail);
        }
    }
}