using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using SVProgressHUDBinding;
using XiOS_App01.Models;


namespace XiOS_App01
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var vm = new ViewModels.SpeakersViewModel();

            CustomTableView.EstimatedRowHeight = 70;
            CustomTableView.RegisterNibForCellReuse(CustomTableViewCell.Nib, nameof(CustomTableViewCell));
            CustomTableView.Source = new CustomTableViewSource();

            GetSpeakersButton.TouchUpInside += async (sender, e) =>
            {
                // ボタンを利用不可、グルグルを表示にします。
                GetSpeakersButton.Enabled = false;
                SVProgressHUD.Show();

                // vmのGetSpeakersメソッドを実行します。
                await vm.GetSpeakers();
                var items = vm.Speakers;

                // Name、Title、UIImageのプロパティを持つTableItemのListにデータを移し替えます。
                // 移し替える前にImageUrlをUIImageに変換して格納します。
                var tableItems = new List<TableItem>();
                foreach (var x in items)
                {
                    var image = await this.LoadImage(x.Avatar);
                    tableItems.Add(new TableItem(x.Name, x.Title, image));
                }

                // 用意してあるCustomListViewSourceを再度読み込み、一度クリアしてからデータを流し込み、再表示します。
                var src = CustomTableView.Source as CustomTableViewSource;
                src.Items.Clear();
                foreach (var x in tableItems)
                {
                    src.Items.Add(x);
                }
                CustomTableView.ReloadData();

                // グルグルを非表示、ボタンを利用可にします。
                SVProgressHUD.Dismiss();
                GetSpeakersButton.Enabled = true;
            };
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

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

    }
}
