using Foundation;
using System;
using UIKit;

namespace UITableViewSample.iOS
{
    public partial class DefaultTableViewController : UITableViewController
    {
        public DefaultTableViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            string[] items = { "test1", "test2", "test3" };

            DefaultTableSource.Source = new TableSource(items);
            DefaultTableSource.ReloadData();
        }
    }
}