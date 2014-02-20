using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TwitchThingy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StreamContainer.populateStreamsDictionary(listBox1);
            makeLabelsTransparent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //todo vlc button
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //web browser button
            System.Diagnostics.Process.Start("http://twitch.tv/" + listBox1.SelectedItem.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(Convert.ToString(StreamContainer.streamObjects[listBox1.SelectedItem.ToString()].streamStatus));
            System.Windows.Forms.MessageBox.Show(StreamContainer.streamObjects[listBox1.SelectedItem.ToString()].image_url_huge);
            System.Windows.Forms.MessageBox.Show(Convert.ToString(StreamContainer.streamObjects[listBox1.SelectedItem.ToString()].channel_count));
            //options button
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //StreamContainer.streamObjects.Add(listBox1.SelectedItem.ToString(),new Stream(listBox1.SelectedItem.ToString()));
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                pictureBox1.Load(StreamContainer.streamObjects[listBox1.SelectedItem.ToString()].screen_cap_url_huge);
                label7.Text = StreamContainer.streamObjects[listBox1.SelectedItem.ToString()].status;
                label4.Text = "Name:"+StreamContainer.streamObjects[listBox1.SelectedItem.ToString()].streamName;
                label5.Text = "Game:"+StreamContainer.streamObjects[listBox1.SelectedItem.ToString()].meta_game;
                label6.Text = "Viewers:"+Convert.ToString(StreamContainer.streamObjects[listBox1.SelectedItem.ToString()].channel_count);
            }
            catch
            {
                try
                {
                    pictureBox1.Load(StreamContainer.streamObjects[listBox1.SelectedItem.ToString()].offline_image_url);
                }
                catch
                {
                    pictureBox1.Image = pictureBox1.ErrorImage;
                }
                label7.Text = StreamContainer.streamObjects[listBox1.SelectedItem.ToString()].offline_status;
                label4.Text = "Name:" + StreamContainer.streamObjects[listBox1.SelectedItem.ToString()].streamName;
                label5.Text = "Game:offline";
                label6.Text = "Viewers:-";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void makeLabelsTransparent()
        {
            var pos = this.PointToScreen(label1.Location);
            pos = pictureBox1.PointToClient(pos);
            label1.Parent = pictureBox1;
            label1.Location = pos;
            label1.BackColor = Color.Transparent;

            pos = this.PointToScreen(label2.Location);
            pos = pictureBox1.PointToClient(pos);
            label2.Parent = pictureBox1;
            label2.Location = pos;
            label2.BackColor = Color.Transparent;

            pos = this.PointToScreen(label3.Location);
            pos = pictureBox1.PointToClient(pos);
            label3.Parent = pictureBox1;
            label3.Location = pos;
            label3.BackColor = Color.Transparent;

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
    }
}
