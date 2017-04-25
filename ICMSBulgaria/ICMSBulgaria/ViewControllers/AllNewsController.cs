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
            var query = ParseObject.GetQuery("News").OrderBy("CreatedAt");
            IEnumerable<ParseObject> tasks = await query.FindAsync();
            foreach (ParseObject task in tasks)
            {
                results.Add(new News
                {
                    ID = task.ObjectId,
                    Title = task.Get<string>("title"),
                    Content = task.Get<string>("content")
                });
            }

            news = new List<News>(results);
            TableView.Source = new NewsTableSource(news.ToArray());
            TableView.ReloadData();

            if(loadingOverlay != null)
            {
                loadingOverlay.Hide();
            }
        }
    }
}