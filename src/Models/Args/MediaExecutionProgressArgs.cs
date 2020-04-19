using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMediaPlayer.Models.Args
{
    public class MediaExecutionProgressArgs : EventArgs
    {
        public MediaExecutionProgressArgs(string currentTime, string totalTime)
        {
            CurrentTime = currentTime;
            TotalTime = totalTime;
        }

        public string CurrentTime { get; }
        public string TotalTime { get; }
    }
}
