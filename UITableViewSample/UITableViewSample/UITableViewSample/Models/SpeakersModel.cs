using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UITableViewSample.Models
{
    public class SpeakersModel
    {
        #region PropertyChangedを使用する場合
        //public event PropertyChangedEventHandler PropertyChanged;

        //private bool _isBusy;
        //public bool IsBusy
        //{
        //    get { return _isBusy; }
        //    set
        //    {
        //        if (_isBusy != value)
        //        {
        //            _isBusy = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        #endregion

        public bool IsBusy { get; set; }
        public ObservableCollection<Speaker> Speakers { get; set; } = new ObservableCollection<Speaker>();

        public SpeakersModel()
        {
        }


        public async Task GetSpeakersAsync()
        {
            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;

                using (var client = new HttpClient())
                {
                    // サーバーから json を取得します
                    var json = await client.GetStringAsync("http://demo4404797.mockable.io/speakers");
                    var items = JsonConvert.DeserializeObject<ObservableCollection<Speaker>>(json);

                    Speakers.Clear();
                    foreach (var item in items)
                        Speakers.Add(item);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }
        }

        #region PropertyChangedを使用する場合
        //void OnPropertyChanged([CallerMemberName] string name = null) =>
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion
    }
}
