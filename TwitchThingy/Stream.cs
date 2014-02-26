using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace TwitchThingy
{
    class Stream
    {
        private static System.Timers.Timer updater;
        public string streamName { get; set; } //login
        public bool streamStatus { get; set; } //in function
        public string meta_game { get; set; } // channel:meta_game
        public string screen_cap_url_huge { get; set; } // channel:screen_cap_url_huge
        public string image_url_huge { get; set; } //channel:image_url_huge
        public string status { get; set; } //channel:status
        public int channel_count { get; set; }
        public string offline_image_url { get; set; }
        public string offline_status { get; set; }
        public Stream(string channel){
            streamName = channel;
            updater = new System.Timers.Timer(1000);
            updater.Elapsed += new ElapsedEventHandler(refreshStatus);
            updater.Enabled = true;
            //checkStatus(channel);
            GC.KeepAlive(updater);
        }
        public void refreshStatus(object source, ElapsedEventArgs e)
        {
            updater.Interval = 60000;
            checkStatus(streamName);
        }
        public void checkStatus(string streamName)
        {
            string webData;
            System.Net.WebClient wc = new System.Net.WebClient();
            try
            {
                webData = wc.DownloadString("http://api.justin.tv/api/stream/list.json?channel=" + streamName);
            }
            catch
            {
                 webData = "[]";
            }
            if(Convert.ToBoolean(webData.CompareTo("[]"))==false){
                streamStatus = false;
            }else{
                streamStatus = true;
                webData = webData.Trim(new Char[] { '[', ']' });
                JObject streamData = JObject.Parse(webData);
                channel_count = (int)streamData["channel_count"];
                meta_game = (string)streamData["channel"]["meta_game"];
                screen_cap_url_huge = (string)streamData["channel"]["screen_cap_url_huge"];
                image_url_huge = (string)streamData["channel"]["image_url_huge"];
                status = (string)streamData["channel"]["status"];
            }
        }
    }
}
