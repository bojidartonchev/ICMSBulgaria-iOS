using System;

using Foundation;
using UIKit;
using ICMSBulgaria.Models;
using CoreGraphics;
using System.Drawing;

namespace ICMSBulgaria.TableCells
{
    public partial class WorkshopsCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("WorkshopsCell");
        public static readonly UINib Nib;

        public Workshops Model { get; set; }

        static WorkshopsCell()
        {
            Nib = UINib.FromName("WorkshopsCell", NSBundle.MainBundle);
        }

        protected WorkshopsCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public static WorkshopsCell Create()
        {
            return (WorkshopsCell)Nib.Instantiate(null, null)[0];
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            
            Title.Frame = new CGRect(25, 20, ContentView.Bounds.Width - 25, 25);
            
            Location.Frame = new CGRect(15, 200, ContentView.Bounds.Width - 15, 20);
            Date.Frame = new CGRect(15, 225, ContentView.Bounds.Width - 15, 20);

            var Description = new UITextView();
            Description.Frame = new CGRect(15, 50, ContentView.Bounds.Width - 30, 100);
            Description.Text = Model.Content;
            Description.TextAlignment = UITextAlignment.Left;
            Description.BackgroundColor = UIColor.Clear;
            Description.Layer.CornerRadius = 5;
            Description.Layer.MasksToBounds = true;
            Description.Editable = false;
            ContentView.AddSubview(Description);

            this.Title.Text = Model.Title;

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
            NSAttributedString sDate = new NSAttributedString(String.Format("{0:dd/MM/yy H:mm}", Model.Date));
            newTextDate.Append(sDate);
            this.Date.AttributedText = newTextDate;
        }
    }
}
