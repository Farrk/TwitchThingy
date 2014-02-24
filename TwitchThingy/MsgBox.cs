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
    public partial class MsgBox : Form
    {
        public MsgBox()
        {
            InitializeComponent();
        }
        public MsgBox(string msg, string btn1, string btn2)
        {
            InitializeComponent();
            label1.Text = msg;
            button1.Text = btn1;
            button2.Text = btn2;
        }
    }
}
