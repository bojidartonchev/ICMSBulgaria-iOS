using Foundation;
using ICMSBulgaria.Models;
using ICMSBulgaria.TableCells;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace ICMSBulgaria
{
    public class WorkshopsTableSource : UITableViewSource
    {

        Workshops[] TableItems;
        string CellIdentifier = "WorkshopTableCell";

        public WorkshopsTableSource(Workshops[] items)
        {
            TableItems = items;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return TableItems.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            Workshops item = TableItems[indexPath.Row];

            var cell = (WorkshopsCell)tableView.DequeueReusableCell(WorkshopsCell.Key);
            if (cell == null)
            {
                cell = WorkshopsCell.Create();
            }
            cell.Model = item;

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            Workshops newsSelected = TableItems[indexPath.Row];

            tableView.DeselectRow(indexPath, true);
        }
    }
}
