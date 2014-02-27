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
        public static Dictionary<string, Stream> streamObjects= new Dictionary<string, Stream>();
        public StreamContainer(){
            
        }

        public static void populateStreamsDictionary(ListBox streamsList)
        {
            foreach (KeyValuePair<string, Stream> entry in streamObjects)
            {
                entry.Value.streamUpdater.Dispose();
            }
            streamObjects = new Dictionary<string, Stream>();
            
            streamsList.Items.Clear();
            string username = SettingsContainer.appSettings.username;

            int counter = 0;
            int total = 0;
            int offset = 0;
            int i = 0;
            System.Net.WebClient wc = new System.Net.WebClient();
            try 
            {

                    string webData = wc.DownloadString("https://api.twitch.tv/kraken/users/" + username + "/follows/channels?direction=DESC&limit=250&offset=0");
                    JObject streams = JObject.Parse(webData);
                    total = (int)streams["_total"];
                    while (counter < total)
                    {
                        string streamToAdd = (string)streams["follows"][i]["channel"]["name"];
                        if (!streamObjects.ContainsKey(streamToAdd))
                        {
                            StreamContainer.streamObjects.Add(streamToAdd, new Stream(streamToAdd));
                            StreamContainer.streamObjects[streamToAdd].offline_image_url = (string)streams["follows"][i]["channel"]["video_banner"];
                            StreamContainer.streamObjects[streamToAdd].offline_status = (string)streams["follows"][i]["channel"]["status"];
                        }
                        streamsList.Items.Add(streamToAdd);
                        counter++;
                        i++;
                        if (i!=0 && i % 250 == 0)
                        {
                            offset++;
                            webData = wc.DownloadString("https://api.twitch.tv/kraken/users/" + username + "/follows/channels?direction=DESC&limit=250&offset="+250*offset);
                            streams = JObject.Parse(webData);
                            i = 0;
                        }
                        
                    }

                    //System.Windows.Forms.MessageBox.Show("Streams added:" + counter);
                    streamsList.SelectedIndex = 0;
            }
            catch
            {
                //System.Windows.Forms.MessageBox.Show(username+" does not exist or follows no one.");
            }
        }
        public int getStreamsAmount()
        {
            int amountOfStreams = 0;


            return amountOfStreams;
        }

    }
}
