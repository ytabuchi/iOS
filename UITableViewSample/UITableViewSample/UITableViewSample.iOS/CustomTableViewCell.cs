using System;

using Foundation;
using UIKit;
using UITableViewSample.iOS.Models;

namespace UITableViewSample.iOS
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

        /// <summary>
        /// データを流し込むためのUpdateメソッド
        /// </summary>
        /// <param name="item"></param>
        public void Update(TableItem item)
        {
            NameLabel.Text = item.Name;
            TitleLabel.Text = item.Title;
            AvatorImage.Image = item.Image;

            AvatorImage.Layer.CornerRadius = AvatorImage.Bounds.Height / 2;
            AvatorImage.Layer.BorderWidth = 2;
            AvatorImage.Layer.BorderColor = UIColor.FromRGB(0x34, 0x98, 0xdb).CGColor;
            AvatorImage.ClipsToBounds = true;
        }
    }
}
