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
    public partial class HomeScreen : Form
    {
        private PlayerFullScreen player;

        private readonly List<string> listItens = new List<string>();

        public HomeScreen()
        {
            InitializeComponent();
            StartFullScreenPlayer();
            filesListBox.Items.Clear();
        }

        private void StartFullScreenPlayer()
        {
            player = PlayerFullScreen.GetPlayer();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                //openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file

                    filesListBox.Items.Clear();
                    listItens.Clear();

                    openFileDialog.FileNames.ToList().ForEach(x=>
                    {
                        listItens.Add(x);
                        var filename = x.Split(new[] { "\\" }, StringSplitOptions.None).LastOrDefault();
                        filesListBox.Items.Add(filename);
                    });

                    

                    //Read the contents of the file into a stream
                    //var fileStream = openFileDialog.OpenFile();

                    //using (StreamReader reader = new StreamReader(fileStream))
                    //{
                    //    fileContent = reader.ReadToEnd();
                    //}
                }
            }
        }

        private void FilesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            player.StopMedia();
            PlayMediaByIndex(this.filesListBox.IndexFromPoint(e.Location));
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            PlayMediaByIndex(filesListBox.SelectedIndex);
        }

        private void PlayMediaByIndex(int index)
        {
            if (index != ListBox.NoMatches)
            {
                var filePath = listItens[index];
                player.PlayMedia(filePath);
                pauseBtn.Text = "Pause";
                filePlayingNameLbl.Text = filesListBox.Items[index].ToString();
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            player.StopMedia();
            pauseBtn.Text = "Pause";
            filePlayingNameLbl.Text = "";
        }

        private void PauseBtn_Click(object sender, EventArgs e)
        {
            player.PauseMedia();
            pauseBtn.Text = player.status == PlayerFullScreen.MediaStatus.Paused ? "Paused" : "Pause";
        }
    }
}
