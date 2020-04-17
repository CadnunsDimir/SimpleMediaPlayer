using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMediaPlayer
{
    public partial class PlayerFullScreen : Form
    {
        private static PlayerFullScreen player;
        private string currentFilePath;

        public enum MediaStatus
        {
            Playing,
            Paused,
            Stoped
        }

        private MediaStatus status = MediaStatus.Stoped;


        private PlayerFullScreen()
        {
            InitializeComponent();
        }

        public static PlayerFullScreen GetPlayer()
        {
            if(player == null)
            {
                player = new PlayerFullScreen();
            }

            player.Show();
            player.MaximizeOnSecondDisplay();
            player.ConfigureWMP();

            return player;
        }

        private void ConfigureWMP()
        {
            wmp.Height = this.Height;
            wmp.Width = this.Width;
            wmp.Top = 0;
            wmp.Left = 0;
            wmp.enableContextMenu = false;
            wmp.uiMode = "none";
            wmp.stretchToFit = true;
        }

        public void MaximizeOnSecondDisplay()
        {
            if(Screen.AllScreens.Length > 1)
            {
                this.Location = Screen.AllScreens[1].WorkingArea.Location;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
        }

        internal void PlayMedia(string filePath)
        {
            this.currentFilePath = filePath;
            wmp.URL = filePath;
            wmp.settings.autoStart = true;
            status = MediaStatus.Playing;
        }

        private void Wmp_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 3)//Playing
            {
                //wmp.fullScreen = true;
                if (FileIsImage())
                {
                    wmp.Ctlcontrols.pause();
                }
            }

            if (e.newState == 1 && status != MediaStatus.Stoped)//end execution
            {   
                wmp.Ctlcontrols.currentPosition = wmp.currentMedia.duration - .001;
                wmp.Ctlcontrols.play();
                wmp.Ctlcontrols.pause();
            }
        }

        private bool FileIsImage()
        {
            var extensions = new List<string>
            {
                ".jpg",
                ".png"
            };
            return extensions.Any(x=> this.currentFilePath.ToLower().Contains(x));
        }

        internal void StopMedia()
        {
            status = MediaStatus.Stoped;
            wmp.Ctlcontrols.stop();
        }

        internal void PauseMedia()
        {
            wmp.Ctlcontrols.pause();
        }
    }
}
