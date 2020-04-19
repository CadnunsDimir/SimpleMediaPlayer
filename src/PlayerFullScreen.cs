using SimpleMediaPlayer.Models.Args;
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
        private Timer timer;

        public event EventHandler<MediaExecutionProgressArgs> MediaExecutionProgress;

        public enum MediaStatus
        {
            Playing,
            Paused,
            Stoped
        }

        public MediaStatus status { get; private set; } = MediaStatus.Stoped;


        private PlayerFullScreen()
        {
            InitializeComponent();
        }

        public static PlayerFullScreen GetPlayer()
        {
            if (player == null)
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
            if (Screen.AllScreens.Length > 1)
            {
                var controlBarZoomSize = 80;
                var width720resolution = 1280;
                var height720resolution = 760;

                var display = Screen.AllScreens[1].WorkingArea;
                FormBorderStyle = FormBorderStyle.None;
                //WindowState = FormWindowState.Maximized;

                Width = width720resolution - controlBarZoomSize;
                Height = height720resolution - controlBarZoomSize;

                this.Location = new Point()
                {
                    X = display.Location.X + 20,
                    Y = display.Location.Y + controlBarZoomSize
                };
            }
        }

        public void PlayMedia(string filePath)
        {
            if (this.currentFilePath != filePath)
            {
                this.currentFilePath = filePath;
                wmp.URL = filePath;
                wmp.settings.autoStart = true;
                status = MediaStatus.Playing;
                StartTimer();
            }
            else if (status == MediaStatus.Paused)
            {
                this.PauseMedia();
            }
        }

        private void StartTimer()
        {
            StopTimer();

            var zeroTime = "00:00";


            if (this.MediaExecutionProgress != null)
            {
                this.MediaExecutionProgress.Invoke(new { }, new MediaExecutionProgressArgs(zeroTime, zeroTime));

                if (!FileIsImage())
                {
                    timer = new Timer();
                    timer.Tick += (sender, e) =>
                    {
                        var args = new MediaExecutionProgressArgs(wmp.Ctlcontrols.currentPositionString, wmp.currentMedia.durationString);
                        this.MediaExecutionProgress.Invoke(this, args);
                    };
                    timer.Interval = 1500; // in miliseconds
                    timer.Start();
                }
            }
        }

        private void StopTimer()
        {
            if (timer != null)
            {
                timer.Stop();
                timer = null;
            }

            if (this.MediaExecutionProgress != null)
            {
                var zeroTime = "00:00";
                this.MediaExecutionProgress.Invoke(this, new MediaExecutionProgressArgs(zeroTime, zeroTime));
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

            if (e.newState == 1 && status != MediaStatus.Stoped)//end execution
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
            StopTimer();
            status = MediaStatus.Stoped;
            wmp.Ctlcontrols.stop();
            currentFilePath = null;
        }

        public void PauseMedia()
        {
            if (!FileIsImage())
            {
                if (status == MediaStatus.Playing)
                {
                    status = MediaStatus.Paused;
                    wmp.Ctlcontrols.pause();
                }
                else if (status == MediaStatus.Paused)
                {
                    status = MediaStatus.Playing;
                    wmp.Ctlcontrols.play();
                }
            }
        }
    }
}
