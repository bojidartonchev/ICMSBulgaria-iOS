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

            Title.Frame = new CGRect(25, 20, ContentView.Bounds.Width - 25, 20);
            Description.Frame = new CGRect(15, 30, ContentView.Bounds.Width - 15, 160);
            Location.Frame = new CGRect(15, 200, ContentView.Bounds.Width - 15, 20);
            Date.Frame = new CGRect(15, 225, ContentView.Bounds.Width - 15, 20);

            Description.Lines = 0;

            this.Title.Text = Model.Title;
            this.Description.Text = Model.Content;
            this.Location.Text = Model.Location;
            this.Date.Text = Model.Date;
        }
    }
}

