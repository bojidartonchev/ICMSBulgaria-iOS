using Foundation;
using ICMSBulgaria.Models;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace ICMSBulgaria
{
    public class SpeakersTableSource : UITableViewSource
    {
        SpeakersViewController mOwner;
        Speaker[] TableItems;
        string CellIdentifier = "SpeakerCell";

        public SpeakersTableSource(Speaker[] items, SpeakersViewController owner)
        {
            TableItems = items;
            mOwner = owner;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return TableItems.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            Speaker item = TableItems[indexPath.Row];

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            { cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier); }

            cell.TextLabel.Text = item.Name;
            cell.DetailTextLabel.Text = item.Possition;
            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

            cell.ImageView.Image = UIImage.FromFile(item.Image);


            cell.ImageView.Layer.CornerRadius = 15;
            cell.ImageView.Layer.MasksToBounds = true;
            // if you want a border
            cell.ImageView.Layer.BorderColor = UIColor.Blue.CGColor;
            cell.ImageView.Layer.BorderWidth = 1.1f;

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var url = TableItems[indexPath.Row].Url;
            mOwner.RowSelected(url);

            tableView.DeselectRow(indexPath, true);
        }
    }
}
