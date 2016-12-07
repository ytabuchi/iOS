using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;
using XiOS_App01.Models;

namespace XiOS_App01.ViewModels
{
    public class SpeakersViewModel
    {
        public bool IsBusy { get; set; }
        public List<Speaker> Speakers { get; set; } = new List<Speaker>();

        public SpeakersViewModel()
        {
        }

        public async Task GetSpeakers()
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
                    var items = JsonConvert.DeserializeObject<List<Speaker>>(json);

                    Speakers.Clear();
                    foreach (var item in items)
                        Speakers.Add(item);

                    System.Diagnostics.Debug.WriteLine(Speakers.Count);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

        }

    }
}
