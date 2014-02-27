using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.ComponentModel;

namespace TwitchThingy
{
    class Stream
    {
        public static System.Timers.Timer updater;
        public System.Timers.Timer streamUpdater;
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
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = false;
            bw.WorkerSupportsCancellation = false;
            bw.DoWork += new DoWorkEventHandler(
                delegate(object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;
                checkStatus(streamName);
                //System.Windows.Forms.MessageBox.Show(streamName + ":" + streamStatus);
                bw.Dispose();
            });
            bw.RunWorkerAsync();
            streamUpdater = new System.Timers.Timer(60000);
            streamUpdater.Elapsed += new ElapsedEventHandler(refreshStatus);
            streamUpdater.Enabled = true;
        }
        public void initUpdateTimer(object source, ElapsedEventArgs e)
        {
            checkStatus(streamName);

            updater.Enabled = false;
            updater.Dispose();
            System.Windows.Forms.MessageBox.Show(streamName);
        }
        public void refreshStatus(object source, ElapsedEventArgs e)
        {
            streamUpdater.Stop();
            checkStatus(streamName);
            //System.Windows.Forms.MessageBox.Show(streamName);
            streamUpdater.Start();
        }
        public void checkStatus(string streamName)
        {
            //System.Windows.Forms.MessageBox.Show(streamName);
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
