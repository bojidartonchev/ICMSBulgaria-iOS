using Foundation;
using ICMSBulgaria.Models;
using ICMSBulgaria.Utils;
using System;
using System.Collections.Generic;
using UIKit;

namespace ICMSBulgaria
{
    public partial class SpeakersViewController : UITableViewController
    {
        private List<Speaker> speakers;
        private LoadingOverlay loadingOverlay;

        public SpeakersViewController (IntPtr handle) : base (handle)
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

            speakers = new List<Speaker>(LocalDatabaseManager.GetSpeakers());
            TableView.Source = new SpeakersTableSource(speakers.ToArray(), this);
            TableView.ReloadData();
            TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;

            if (loadingOverlay != null)
            {
                loadingOverlay.Hide();
            }
        }

        public void RowSelected(string url)
        {
            var webView = new UIWebView(View.Bounds);
            View.AddSubview(webView);
            webView.LoadRequest(new NSUrlRequest(new NSUrl(url)));
            webView.ScalesPageToFit = true;
        }
    }
}