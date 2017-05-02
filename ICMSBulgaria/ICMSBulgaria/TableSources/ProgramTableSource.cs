using Foundation;
using ICMSBulgaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace ICMSBulgaria
{
    public class ProgramTableSource : UITableViewSource
    {

        ProgramEvent[] TableItems;
        Dictionary<string, List<ProgramEvent>> eventDict;
        string CellIdentifier = "ProgramCell";

        public ProgramTableSource(ProgramEvent[] items)
        {
            TableItems = items;

            var listOfItems = new List<ProgramEvent>(TableItems);
            eventDict = listOfItems
                             .GroupBy(x => x.Date)
                             .ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            ProgramEvent item = eventDict[eventDict.Keys.ElementAt((int)indexPath.Section)].ElementAt(indexPath.Row);

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            { cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier); }

            cell.TextLabel.Text = item.Title;
            cell.DetailTextLabel.Text = item.Location + " at " + item.Time;
            cell.BackgroundColor = UIColor.Clear;

            return cell;
        }
        
        //public override string TitleForFooter(UITableView tableView, nint section)
        //{
        //    var listOfItems = new List<ProgramEvent>(TableItems);
        //    var count = listOfItems.Where(x => x.Date == TableItems[section].Date);
        //
        //    return count.Count() + " events";
        //}

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return eventDict == null ? string.Empty : eventDict.Keys.ElementAt((int)section);
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return eventDict.Keys.Count;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return eventDict[eventDict.Keys.ElementAt((int)section)].Count;
        }

        public override string[] SectionIndexTitles(UITableView tableView)
        {
            return eventDict.Keys.ToArray();
        }
    }
}
