using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchThingy
{
    class Settings
    {
        public string username { get; set; }
        public int defQuality { get; set; }
        public int defAction { get; set; }
        public bool showOffline { get; set; }
        public bool desktopNotify { get; set; }
        public int notificationsTimeout { get; set; }
        public string livestreamerDir { get; set; }
        public Settings()
        {

        }
    }
}
