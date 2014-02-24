namespace TwitchThingy
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label7 = new TwitchThingy.CustomLabel();
            this.label4 = new TwitchThingy.CustomLabel();
            this.label5 = new TwitchThingy.CustomLabel();
            this.label6 = new TwitchThingy.CustomLabel();
            this.label1 = new TwitchThingy.CustomLabel();
            this.label2 = new TwitchThingy.CustomLabel();
            this.label3 = new TwitchThingy.CustomLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(0, 31);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(167, 259);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 21);
            this.button3.TabIndex = 3;
            this.button3.Text = "Options";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(173, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(515, 289);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(70, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(106, 19);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Show offline?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial Black", 10.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(173, 1);
            this.label7.Name = "label7";
            this.label7.OutlineForeColor = System.Drawing.Color.Black;
            this.label7.OutlineWidth = 3F;
            this.label7.Size = new System.Drawing.Size(97, 19);
            this.label7.TabIndex = 11;
            this.label7.Text = "streamTitle";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 12.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(173, 20);
            this.label4.Name = "label4";
            this.label4.OutlineForeColor = System.Drawing.Color.Black;
            this.label4.OutlineWidth = 3F;
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "blablaw";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Black", 12.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(173, 44);
            this.label5.Name = "label5";
            this.label5.OutlineForeColor = System.Drawing.Color.Black;
            this.label5.OutlineWidth = 3F;
            this.label5.Size = new System.Drawing.Size(66, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "blabla";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Black", 12.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(173, 68);
            this.label6.Name = "label6";
            this.label6.OutlineForeColor = System.Drawing.Color.Black;
            this.label6.OutlineWidth = 3F;
            this.label6.Size = new System.Drawing.Size(72, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "blalbal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Black", 12.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(204, 337);
            this.label1.Name = "label1";
            this.label1.OutlineForeColor = System.Drawing.Color.Black;
            this.label1.OutlineWidth = 3F;
            this.label1.Size = new System.Drawing.Size(69, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Black", 12.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(270, 296);
            this.label2.Name = "label2";
            this.label2.OutlineForeColor = System.Drawing.Color.Black;
            this.label2.OutlineWidth = 3F;
            this.label2.Size = new System.Drawing.Size(69, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Game:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Black", 12.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(348, 337);
            this.label3.Name = "label3";
            this.label3.OutlineForeColor = System.Drawing.Color.Black;
            this.label3.OutlineWidth = 3F;
            this.label3.Size = new System.Drawing.Size(91, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Viewers:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(689, 292);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBox1);
            this.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "SomeLivestreamingWebsiteThingy";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ListBox listBox1;
        private CustomLabel label1;
        private CustomLabel label2;
        private CustomLabel label3;
        private CustomLabel label4;
        private CustomLabel label5;
        private CustomLabel label6;
        private CustomLabel label7;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

