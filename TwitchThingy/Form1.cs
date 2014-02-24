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


namespace TwitchThingy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StreamContainer.populateStreamsDictionary(listBox1);
            makeLabelsTransparent();
            System.Timers.Timer UIrefresher = new System.Timers.Timer(10000);
            UIrefresher.Elapsed += new ElapsedEventHandler(callUIRefresh);
            UIrefresher.Enabled = true;
            GC.KeepAlive(UIrefresher);
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
        private void browser()
        {
            System.Diagnostics.Process.Start("http://twitch.tv/" + listBox1.SelectedItem.ToString());
        }
        private void VLC()
        {
            //stuffs
            System.Windows.Forms.MessageBox.Show("VLC button pressed.");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.MessageBox.Show(Convert.ToString(StreamContainer.streamObjects[listBox1.SelectedItem.ToString()].streamStatus));
                System.Windows.Forms.MessageBox.Show(StreamContainer.streamObjects[listBox1.SelectedItem.ToString()].image_url_huge);
                System.Windows.Forms.MessageBox.Show(Convert.ToString(StreamContainer.streamObjects[listBox1.SelectedItem.ToString()].channel_count));
            
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("No stream selected.");
            }
            //options button
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            MsgBox box = new MsgBox("Where would you like to open the stream?", "Browser", "VLC");
            DialogResult DResult = box.ShowDialog();
            if(DResult==DialogResult.OK){
                browser();
            }
            else if (DResult == DialogResult.Yes)
            {
                VLC();
            }
            else
            {
                //nothing
            }
        }
    }
}
