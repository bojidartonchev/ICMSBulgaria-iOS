using Foundation;
using ICMSBulgaria.Models;
using ICMSBulgaria.Utils;
using Parse;
using System;
using System.Collections.Generic;
using UIKit;

namespace ICMSBulgaria
{
    public partial class ProgramController : UITableViewController
    {
        private List<ProgramEvent> events;
        private LoadingOverlay loadingOverlay;

        public ProgramController(IntPtr handle) : base (handle)
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

            events = new List<ProgramEvent>(LocalDatabaseManager.GetProgramEvents());
            TableView.Source = new ProgramTableSource(events.ToArray());
            TableView.ReloadData();

            if(loadingOverlay != null)
            {
                loadingOverlay.Hide();
            }
        }
    }
}