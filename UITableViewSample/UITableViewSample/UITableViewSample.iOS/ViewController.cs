using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foundation;
using UIKit;
using SVProgressHUDBinding;
using UITableViewSample.iOS.Models;
using UITableViewSample.Models;

namespace UITableViewSample.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var vm = new UITableViewSample.Models.SpeakersModel();

            CustomTableView.RowHeight = 70;
            CustomTableView.RegisterNibForCellReuse(CustomTableViewCell.Nib, nameof(CustomTableViewCell));

            GetSpeakersButton.TouchUpInside += async (sender, e) =>
            {
                // ボタンを利用不可、グルグルを表示にします。
                GetSpeakersButton.Enabled = false;
                SVProgressHUD.Show();

                // vmのGetSpeakersメソッドを実行します。
                await vm.GetSpeakersAsync();

                // Name、Title、UIImageのプロパティを持つTableItemのListにデータを移し替えます。
                // 移し替える前にImageUrlをUIImageに変換して格納します。
                var tableItems = new List<TableItem>();
                foreach (var x in vm.Speakers)
                {
                    var image = await this.LoadImage(x.Avatar);
                    tableItems.Add(new TableItem(x.Name, x.Title, image));
                }

                // TableViewのSourceをCustomTableViewSourceでnewします。
                CustomTableView.Source = new CustomTableViewSource(tableItems);
                CustomTableView.ReloadData();

                // グルグルを非表示、ボタンを利用可にします。
                SVProgressHUD.Dismiss();
                GetSpeakersButton.Enabled = true;
            };

            #region PropertyChangedを使用する場合
            //vm.PropertyChanged += Vm_PropertyChanged;
            #endregion
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private async Task<UIImage> LoadImage(string imageUrl)
        {
            using (var client = new HttpClient())
            {
                // imageUrlからバイト配列を取得します。
                byte[] contents = await client.GetByteArrayAsync(imageUrl);
                // バイト配列のデータからUIImageを生成します。
                return UIImage.LoadFromData(NSData.FromArray(contents));
            }
        }

        #region PropertyChangedを使用する場合
        //private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    GetSpeakersButton.Enabled = !((SpeakersModel)sender).IsBusy;
        //}
        #endregion
    }
}

