using Foundation;
using ICMSBulgaria.Models;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace ICMSBulgaria
{
    public class ProgramTableSource : UITableViewSource
    {

        ProgramEvent[] TableItems;
        string CellIdentifier = "ProgramCell";

        public ProgramTableSource(ProgramEvent[] items)
        {
            TableItems = items;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return TableItems.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            ProgramEvent item = TableItems[indexPath.Row];

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            { cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

            cell.TextLabel.Text = item.Title;

            return cell;
        }
    }
}
