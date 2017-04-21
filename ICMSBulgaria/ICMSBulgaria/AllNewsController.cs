using Foundation;
using ICMSBulgaria.Models;
using Parse;
using System;
using System.Collections.Generic;
using UIKit;

namespace ICMSBulgaria
{
    public partial class AllNewsController : UITableViewController
    {
        private List<News> news;

        public AllNewsController(IntPtr handle) : base (handle)
        {
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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            news = new List<News>(ParseObjectManager.GetTasks());
            TableView.Source = new NewsTableSource(news.ToArray());
            TableView.ReloadData();
        }
    }
}