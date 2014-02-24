using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TwitchThingy
{
    
    class StreamContainer
    {
        public static Dictionary<string,Stream> streamObjects = new Dictionary<string,Stream>();
        public StreamContainer(){
            
        }

        public static void populateStreamsDictionary(ListBox streamsList)
        {
            string username="farrk";
            System.Net.WebClient wc = new System.Net.WebClient();
            try {
                string webData = wc.DownloadString("https://api.twitch.tv/kraken/users/" + username + "/follows/channels?direction=DESC&limit=250&offset=0");
                    JObject streams = JObject.Parse(webData);
                    if ((int)streams["_total"] > 250)
                    {
                        streams["_total"] = 250;
                    }
                    for (int i = 0; i < (int)streams["_total"]; i++)
                    {
                        string streamToAdd = (string)streams["follows"][i]["channel"]["name"];
                        StreamContainer.streamObjects.Add(streamToAdd, new Stream(streamToAdd));
                        StreamContainer.streamObjects[streamToAdd].offline_image_url = (string)streams["follows"][i]["channel"]["video_banner"];
                        StreamContainer.streamObjects[streamToAdd].offline_status = (string)streams["follows"][i]["channel"]["status"];
                        streamsList.Items.Add(streamToAdd);
                    }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(username+" does not exist.");
            }
        }
        public int getStreamsAmount()
        {
            int amountOfStreams = 0;


            return amountOfStreams;
        }

    }
}
