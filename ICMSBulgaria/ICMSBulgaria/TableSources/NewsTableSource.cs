using Foundation;
using ICMSBulgaria.Models;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace ICMSBulgaria
{
    public class NewsTableSource : UITableViewSource
    {

        News[] TableItems;
        AllNewsController Owner;
        string CellIdentifier = "TableCell";

        public NewsTableSource(News[] items, AllNewsController owner)
        {
            Owner = owner;
            TableItems = items;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return TableItems.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            News item = TableItems[indexPath.Row];

            var cell = (NewsCell)tableView.DequeueReusableCell(NewsCell.Key);
            if (cell == null)
            {
                cell = NewsCell.Create();
            }
            cell.Model = item;
            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {            
            Owner.RowSelected(tableView, indexPath);

            tableView.DeselectRow(indexPath, true);
        }
    }
}
