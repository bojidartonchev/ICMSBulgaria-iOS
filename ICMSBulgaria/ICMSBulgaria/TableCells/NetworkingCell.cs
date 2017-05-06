using System;

using Foundation;
using UIKit;
using ICMSBulgaria.Models;
using CoreGraphics;

namespace ICMSBulgaria.TableCells
{
    public partial class NetworkingCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("NetworkingCell");
        public static readonly UINib Nib;

        public Networking Model { get; set; }

        static NetworkingCell()
        {
            Nib = UINib.FromName("NetworkingCell", NSBundle.MainBundle);
        }

        public static NetworkingCell Create()
        {
            return (NetworkingCell)Nib.Instantiate(null, null)[0];
        }

        protected NetworkingCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            Title.Frame = new CGRect(25, 20, ContentView.Bounds.Width - 25, 25);
            Location.Frame = new CGRect(15, 160, ContentView.Bounds.Width - 15, 20);
            Date.Frame = new CGRect(15, 185, ContentView.Bounds.Width - 15, 20);

            this.Title.Text = Model.Title;

            var Description = new UITextView();
            Description.Frame = new CGRect(15, 50, ContentView.Bounds.Width - 30, 100);
            Description.Text = Model.Content;
            Description.TextAlignment = UITextAlignment.Left;
            Description.BackgroundColor = UIColor.Clear;
            Description.Layer.CornerRadius = 5;
            Description.Layer.MasksToBounds = true;
            Description.Editable = false;
            ContentView.AddSubview(Description);

            var attchment = new NSTextAttachment();
            attchment.Image = UIImage.FromFile("Assets/locmarker.png");
            attchment.Bounds = new CGRect(0, -2, 14, 14);
            var newText = new NSMutableAttributedString();
            newText.Append(NSAttributedString.CreateFrom(attchment));
            NSAttributedString s = new NSAttributedString(Model.Location);
            newText.Append(s);
            this.Location.AttributedText = newText;

            var attchmentDate = new NSTextAttachment();
            attchmentDate.Image = UIImage.FromFile("Assets/clock.png");
            attchmentDate.Bounds = new CGRect(0, -2, 14, 14);
            var newTextDate = new NSMutableAttributedString();
            newTextDate.Append(NSAttributedString.CreateFrom(attchmentDate));
            NSAttributedString sDate = new NSAttributedString(Model.Date);
            newTextDate.Append(sDate);
            this.Date.AttributedText = newTextDate;            
        }
    }
}

