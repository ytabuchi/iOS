using System;
using System.Net.Http;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using XiOS_App01.Models;

namespace XiOS_App01
{
    public partial class CustomTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("CustomTableViewCell");
        public static readonly UINib Nib;

        static CustomTableViewCell()
        {
            Nib = UINib.FromName("CustomTableViewCell", NSBundle.MainBundle);
        }

        protected CustomTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        // データを流し込むためのUpdateメソッドを用意します。
        public void Update(TableItem item)
        {
            NameLabel.Text = item.Name;
            TitleLabel.Text = item.Title;
            AvatorImage.Image = item.Image;
        }
    }
}
