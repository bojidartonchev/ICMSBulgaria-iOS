using CoreGraphics;
using Foundation;
using ICMSBulgaria.Models;
using ICMSBulgaria.Utils;
using Parse;
using System;
using System.Collections.Generic;
using UIKit;

namespace ICMSBulgaria
{
    public partial class WorkshopsController : UITableViewController
    {
        private List<Workshops> news;
        private LoadingOverlay loadingOverlay;

        public WorkshopsController (IntPtr handle) : base (handle)
        {
            var bounds = UIScreen.MainScreen.Bounds;

            // show the loading overlay on the UI thread using the correct orientation sizing
            loadingOverlay = new LoadingOverlay(bounds);
            View.Add(loadingOverlay);
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            try
            {
                List<Workshops> results = new List<Workshops>();
                var query = ParseObject.GetQuery("Workshops").OrderBy("date");
                IEnumerable<ParseObject> tasks = await query.FindAsync();
                foreach (ParseObject task in tasks)
                {
                    results.Add(new Workshops
                    {
                        ID = task.ObjectId,
                        Title = task.Get<string>("title"),
                        Content = task.Get<string>("content"),
                        Date = task.Get<DateTime>("date"),
                        Location = task.Get<string>("location")
                    });
                }

                news = new List<Workshops>(results);
                TableView.Source = new WorkshopsTableSource(news.ToArray());
                TableView.ReloadData();
            }
            catch (Exception e)
            {
            }
            finally
            {
                if (loadingOverlay != null)
                {
                    loadingOverlay.Hide();
                }
            }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            // Initialize table
            TableView.RowHeight = 250f;
            TableView.EstimatedRowHeight = 250f;
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