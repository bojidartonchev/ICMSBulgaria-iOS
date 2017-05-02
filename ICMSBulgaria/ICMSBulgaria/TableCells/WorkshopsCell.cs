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
            
            Title.Frame = new CGRect(25, 20, ContentView.Bounds.Width - 25, 20);
            Description.Frame = new CGRect(15, 30, ContentView.Bounds.Width - 15, 160);
            Location.Frame = new CGRect(15, 200, ContentView.Bounds.Width - 15, 20);
            Date.Frame = new CGRect(15, 225, ContentView.Bounds.Width - 15, 20);

            Description.Lines = 0;

            this.Title.Text = Model.Title;
            this.Description.Text = Model.Content;
            this.Location.Text = Model.Location;
            this.Date.Text = String.Format("{0:dd/MM/yy H:mm}", Model.Date);            
        }
    }
}
