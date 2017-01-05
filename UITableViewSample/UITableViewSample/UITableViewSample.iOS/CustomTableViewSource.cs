using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using UITableViewSample.iOS.Models;

namespace UITableViewSample.iOS
{
    public class CustomTableViewSource : UITableViewSource
    {
        private List<TableItem> Items { get; set; } = new List<TableItem>();

        public CustomTableViewSource(List<TableItem> items)
        {
            this.Items = items;
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

