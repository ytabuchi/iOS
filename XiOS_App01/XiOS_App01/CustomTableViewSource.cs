using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using CoreGraphics;

using XiOS_App01.Models;

namespace XiOS_App01
{
    public class CustomTableViewSource : UITableViewSource
    {
        public List<TableItem> Items { get; } = new List<TableItem>();

        public CustomTableViewSource()
        {
            
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (CustomTableViewCell)tableView.DequeueReusableCell(nameof(CustomTableViewCell), indexPath);
            var item = Items[indexPath.Row];
            cell.Update(item);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Items.Count;
        }
    }
}
