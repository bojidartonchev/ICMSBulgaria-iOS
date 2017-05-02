using Foundation;
using ICMSBulgaria.Models;
using ICMSBulgaria.TableCells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace ICMSBulgaria
{
    public class NetworkingTableSource : UITableViewSource
    {

        Networking[] TableItems;
        string CellIdentifier = "NetworkingCell";

        public NetworkingTableSource(Networking[] items)
        {
            TableItems = items;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            Networking item = TableItems[indexPath.Row];

            var cell = (NetworkingCell)tableView.DequeueReusableCell(NetworkingCell.Key);
            if (cell == null)
            {
                cell = NetworkingCell.Create();
            }
            cell.Model = item;
            
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return TableItems.Length;
        }
    }
}
