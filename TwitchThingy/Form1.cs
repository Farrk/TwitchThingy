using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace TwitchThingy
{
    public partial class Form1 : Form
    {
        SettingsForm options;
        public Form1()
        {
            InitializeComponent();
            options = new SettingsForm();
            SettingsContainer.loadSettings();
            StreamContainer.populateStreamsDictionary(listBox1);
            makeLabelsTransparent();
            System.Timers.Timer UIrefresher = new System.Timers.Timer(10000);
            UIrefresher.Elapsed += new ElapsedEventHandler(callUIRefresh);
            UIrefresher.Enabled = true;
            GC.KeepAlive(UIrefresher);
            Application.ApplicationExit += new EventHandler(SettingsContainer.saveSettings);
        }
        private void callUIRefresh(object source, ElapsedEventArgs e)
        {
            refreshUI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //todo vlc button
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //web browser button
            //System.Diagnostics.Process.Start("http://twitch.tv/" + listBox1.SelectedItem.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string temp = SettingsContainer.appSettings.username;
            try
            {
                options.populateForm(SettingsContainer.appSettings.username
                , SettingsContainer.appSettings.showOffline
            , SettingsContainer.appSettings.desktopNotify
            , SettingsContainer.appSettings.notificationsTimeout
            , SettingsContainer.appSettings.defAction
            , SettingsContainer.appSettings.defQuality,
            SettingsContainer.appSettings.livestreamerDir);
                options.ShowDialog();
                if (!temp.Equals(SettingsContainer.appSettings.username))
                {
                    //gui refresh for new name section
                    StreamContainer.populateStreamsDictionary(listBox1);
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("derp.");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            axVLCPlugin21.playlist.items.clear();
            axVLCPlugin21.playlist.stop();
            axVLCPlugin21.SendToBack();
            refreshUI();
        }
        private void refreshUI(){
            string selectedItem="";
            if (!InvokeRequired)
            {
                try
                {
                    selectedItem = listBox1.SelectedItem.ToString();
                    pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    if (StreamContainer.streamObjects[selectedItem].streamStatus == true)
                    {
                        try
                        {
                            pictureBox1.Load(StreamContainer.streamObjects[selectedItem].screen_cap_url_huge);
                            label7.Text = StreamContainer.streamObjects[selectedItem].status;
                            label4.Text = "Name:" + StreamContainer.streamObjects[selectedItem].streamName;
                            label5.Text = "Game:" + StreamContainer.streamObjects[selectedItem].meta_game;
                            label6.Text = "Viewers:" + Convert.ToString(StreamContainer.streamObjects[selectedItem].channel_count);

                        }
                        catch
                        {
                            System.Windows.Forms.MessageBox.Show("Stream is live but something went wrong.");
                        }
                    }
                    else
                    {
                        try
                        {
                            pictureBox1.Load(StreamContainer.streamObjects[selectedItem].offline_image_url);
                        }
                        catch
                        {
                            pictureBox1.Image = pictureBox1.ErrorImage;
                        }
                        label7.Text = StreamContainer.streamObjects[selectedItem].offline_status;
                        label4.Text = "Name:" + StreamContainer.streamObjects[selectedItem].streamName;
                        label5.Text = "Game:offline";
                        label6.Text = "Viewers:-";
                    }
                }
                catch
                {

                }
            }
            else
            {
                Invoke(new Action(refreshUI));
            }
        }


        private void makeLabelsTransparent()
        {
            System.Drawing.Point pos;

            pos = this.PointToScreen(label4.Location);
            pos = pictureBox1.PointToClient(pos);
            label4.Parent = pictureBox1;
            label4.Location = pos;
            label4.BackColor = Color.Transparent;

            pos = this.PointToScreen(label5.Location);
            pos = pictureBox1.PointToClient(pos);
            label5.Parent = pictureBox1;
            label5.Location = pos;
            label5.BackColor = Color.Transparent;

            pos = this.PointToScreen(label6.Location);
            pos = pictureBox1.PointToClient(pos);
            label6.Parent = pictureBox1;
            label6.Location = pos;
            label6.BackColor = Color.Transparent;
            
            pos = this.PointToScreen(label7.Location);
            pos = pictureBox1.PointToClient(pos);
            label7.Parent = pictureBox1;
            label7.Location = pos;
            label7.BackColor = Color.Transparent;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(StreamContainer.streamObjects[listBox1.SelectedItem.ToString()].streamStatus))
            {
                System.Windows.Forms.MessageBox.Show(StreamContainer.streamObjects[listBox1.SelectedItem.ToString()].status, "Stream Title");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(StreamContainer.streamObjects[listBox1.SelectedItem.ToString()].offline_status, "Stream Title");
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (SettingsContainer.appSettings.defAction == 0)
            {
                MsgBox box = new MsgBox("Where would you like to open the stream?", "Browser", "VLC");
                DialogResult DResult = box.ShowDialog();
                if (DResult == DialogResult.OK)
                {
                    browser();
                }
                else if (DResult == DialogResult.Yes)
                {
                    if (File.Exists(SettingsContainer.appSettings.livestreamerDir + @"\Livestreamer.exe"))
                    {
                        VLC();
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Livestreamer.exe not present in selected folder, please select a folder where you installed Livestreamer in program settings.");
                    }
                }
                else
                {
                    //nothing
                }
            }
            else if (SettingsContainer.appSettings.defAction == 1)
            {
                //in-app
                if(File.Exists(SettingsContainer.appSettings.livestreamerDir+@"\Livestreamer.exe"))
                {
                    VLC();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Livestreamer.exe not present in selected folder, please select a folder where you installed Livestreamer in program settings.");
                }
               
            }
            else if (SettingsContainer.appSettings.defAction == 2)
            {
                //browser
                browser();
            }

        }
        private void browser()
        {
            System.Diagnostics.Process.Start("http://twitch.tv/" + listBox1.SelectedItem.ToString());
        }
        private void VLC()
        {
            //stuffs
            if(!StreamContainer.streamObjects[listBox1.SelectedItem.ToString()].streamStatus){
                System.Windows.Forms.MessageBox.Show("Can't watch offline streams, duh.");
                return;
            }
            //use livestreamer to acquire possible qualities along with links
            string VLCOpts = "--repeat --file-caching=15000";
            string jsonstuff;
            JObject qualities = new JObject();
            Dictionary<string,string> qua = new Dictionary<string,string>();
            Dictionary<string, string> quaDict = new Dictionary<string, string>();
            qua.Add("source", "");
            qua.Add("high", "");
            qua.Add("medium", "");
            qua.Add("best", "");
            qua.Add("worst", "");
            qua.Add("low", "");
            //System.Windows.Forms.MessageBox.Show("VLC button pressed.");
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C "+SettingsContainer.appSettings.livestreamerDir+@"\livestreamer.exe --json twitch.tv/" + listBox1.SelectedItem.ToString()+" > json.tmp";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            try
            {
                using (StreamReader sr = File.OpenText("json.tmp"))
                {
                    jsonstuff = sr.ReadToEnd();
                    //System.Windows.Forms.MessageBox.Show(jsonstuff);
                }
                qualities=JObject.Parse(jsonstuff);
                foreach(KeyValuePair<string,string> q in qua)
                {
                    try
                    {
                        quaDict.Add(q.Key,(string)qualities["streams"][q.Key]["url"]);
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Was unable to obtain stream URLs. derp!");
            }
            try
            {
                axVLCPlugin21.Show();
                axVLCPlugin21.BringToFront();
                //System.Windows.Forms.MessageBox.Show((string)qualities["streams"]["source"]["url"]);
                try
                {
                    string[] itoa = new string[6] { "best", "source", "high" , "medium","low","worst"};
                    axVLCPlugin21.playlist.add(quaDict[itoa[SettingsContainer.appSettings.defQuality]], "stream", VLCOpts);
                    axVLCPlugin21.playlist.play();
                }
                catch
                {
                    axVLCPlugin21.playlist.add(quaDict["best"], "stream", VLCOpts);
                    axVLCPlugin21.playlist.play();
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Something went wrong, try again.");
            }
        }
    }
}
