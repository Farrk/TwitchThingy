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
        //public static Stream[] streamObjects = new Stream[55];
        public static Dictionary<string,Stream> streamObjects = new Dictionary<string,Stream>();
        public StreamContainer(){
            
        }

        public static void populateStreamsDictionary(ListBox streamsList)
        {
            //System.Windows.Forms.MessageBox.Show("lol at least entered function");
            string username="czemac";
            System.Net.WebClient wc = new System.Net.WebClient();
            string webData = wc.DownloadString("https://api.twitch.tv/kraken/users/"+username+"/follows/channels");
            if (!webData.Contains("does not exist")){
                JObject streams = JObject.Parse(webData);
                for (int i = 0; i < (int)streams["_total"]; i++)
                {
                    string streamToAdd = (string)streams["follows"][i]["channel"]["name"];
                    StreamContainer.streamObjects.Add(streamToAdd, new Stream(streamToAdd));
                    StreamContainer.streamObjects[streamToAdd].offline_image_url = (string)streams["follows"][i]["channel"]["video_banner"];
                    StreamContainer.streamObjects[streamToAdd].offline_status = (string)streams["follows"][i]["channel"]["status"];
                    streamsList.Items.Add(streamToAdd);
                    //System.Windows.Forms.MessageBox.Show(streamToAdd);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("contains 'does not exist'");
            }
        }
        private static void SomeMethod(ListBox listBox, string testing)
        {
            listBox.Items.Add("Some element");
        }
        public int getStreamsAmount()
        {
            int amountOfStreams = 0;


            return amountOfStreams;
        }

    }
}
