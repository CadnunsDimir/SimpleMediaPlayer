﻿using System;
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

        private MediaStatus _status = MediaStatus.Stoped;

        public MediaStatus status
        {
            get
            {
                return _status;
            }
        }


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
            wmp.Ctlenabled = false;
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

        public void PlayMedia(string filePath)
        {
            if (this.currentFilePath != filePath)
            {

                this.currentFilePath = filePath;
                wmp.URL = filePath;
                wmp.settings.autoStart = true;
                _status = MediaStatus.Playing;
            }
            else if(_status == MediaStatus.Paused)
            {
                this.PauseMedia();
            }
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

            if (e.newState == 1 && _status != MediaStatus.Stoped)//end execution
            {   
                wmp.Ctlcontrols.currentPosition = wmp.currentMedia.duration - .001;
                wmp.Ctlcontrols.play();
                wmp.Ctlcontrols.pause();
            }
        }

        private bool FileIsImage()
        {
            if (currentFilePath != null)
            {
                var extensions = new List<string>
                {
                    ".jpg",
                    ".png"
                };
                return extensions.Any(x => currentFilePath.ToLower().Contains(x));
            }
            return false;
        }

        public void StopMedia()
        {
            _status = MediaStatus.Stoped;
            wmp.Ctlcontrols.stop();
            currentFilePath = null;
        }

        public void PauseMedia()
        {
            if (!FileIsImage())
            {
                if (_status == MediaStatus.Playing)
                {
                    _status = MediaStatus.Paused;
                    wmp.Ctlcontrols.pause();
                }
                else if (_status == MediaStatus.Paused)
                {
                    _status = MediaStatus.Playing;
                    wmp.Ctlcontrols.play();
                }
            }
        }
    }
}
