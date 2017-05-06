using CoreGraphics;
using Foundation;
using ICMSBulgaria.Models;
using ICMSBulgaria.Utils;
using System;
using System.Collections.Generic;
using UIKit;

namespace ICMSBulgaria
{
    public partial class NetworkingViewController : UITableViewController
    {
        private List<Networking> events;
        private LoadingOverlay loadingOverlay;

        public NetworkingViewController (IntPtr handle) : base (handle)
        {
            var bounds = UIScreen.MainScreen.Bounds;

            // show the loading overlay on the UI thread using the correct orientation sizing
            loadingOverlay = new LoadingOverlay(bounds);
            View.Add(loadingOverlay);
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            events = new List<Networking>(LocalDatabaseManager.GetNetworking());
            TableView.Source = new NetworkingTableSource(events.ToArray());
            TableView.ReloadData();

            if (loadingOverlay != null)
            {
                loadingOverlay.Hide();
            }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            // Initialize table
            TableView.RowHeight = 210f;
            TableView.EstimatedRowHeight = 210f;
            TableView.ReloadData();

            TableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;

            var image = new UIImageView();
            image.Frame = new CGRect(0, 0, View.Bounds.Width, View.Bounds.Height);
            image.Image = UIImage.FromFile("Assets/backgroundsecondary.jpg");
            TableView.BackgroundView = image;

            this.NavigationController.NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            this.NavigationController.NavigationBar.ShadowImage = new UIImage();
            this.NavigationController.NavigationBar.Translucent = false;
        }
    }
}