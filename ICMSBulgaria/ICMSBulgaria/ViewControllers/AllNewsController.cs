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
    public partial class AllNewsController : UITableViewController
    {
        private List<News> news;
        private LoadingOverlay loadingOverlay;

        public AllNewsController(IntPtr handle) : base (handle)
        {
            var bounds = UIScreen.MainScreen.Bounds;

            // show the loading overlay on the UI thread using the correct orientation sizing
            loadingOverlay = new LoadingOverlay(bounds);
            View.Add(loadingOverlay);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            //if (segue.Identifier == "TaskSegue")
            //{ // set in Storyboard
            //    var navctlr = segue.DestinationViewController as TaskDetailViewController;
            //    if (navctlr != null)
            //    {
            //        var source = TableView.Source as RootTableSource;
            //        var rowPath = TableView.IndexPathForSelectedRow;
            //        var item = source.GetItem(rowPath.Row);
            //        navctlr.SetTask(item);
            //    }
            //}
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            List<News> results = new List<News>();
            var query = ParseObject.GetQuery("News").OrderByDescending("createdAt");
            IEnumerable<ParseObject> tasks = await query.FindAsync();
            foreach (ParseObject task in tasks)
            {
                results.Add(new News
                {
                    ID = task.ObjectId,
                    Title = task.Get<string>("title"),
                    Content = task.Get<string>("content"),
                    Image = task.Get<ParseFile>("image").Url.ToString(),
                    Date = task.CreatedAt.Value
                });
            }

            news = new List<News>(results);
            TableView.Source = new NewsTableSource(news.ToArray(), this);
            TableView.ReloadData();

            if(loadingOverlay != null)
            {
                loadingOverlay.Hide();
            }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            // Initialize table
            TableView.RowHeight = 130f;
            TableView.EstimatedRowHeight = 130f;
            TableView.ReloadData();
            
            TableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLineEtched;
            
            var image = new UIImageView();
            image.Frame = new CGRect(0, 0, View.Bounds.Width, View.Bounds.Height);
            image.Image = UIImage.FromFile("Assets/backgroundsecondary.jpg");
            TableView.BackgroundView = image;

            this.NavigationController.NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            this.NavigationController.NavigationBar.ShadowImage = new UIImage();
            this.NavigationController.NavigationBar.Translucent = false;
        }

        public void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            News newsSelected = news[indexPath.Row];
            
            SingleNewsViewController ctrl = Storyboard.InstantiateViewController("SingleNewsViewController") as SingleNewsViewController;
            ctrl.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;
            ctrl.NewsObject = newsSelected;
            NavigationController.PushViewController(ctrl, true);
        }
    }
}