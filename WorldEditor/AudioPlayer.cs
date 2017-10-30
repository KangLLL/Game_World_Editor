using System;
using System.Media;
using System.Runtime.InteropServices;

namespace WorldEditor
{
    public static class AudioPlayer
    {

        [DllImport("winmm.dll")]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int dwCallback);

        private static SoundPlayer soundPlayer;

        public static void PlayMidi(string filename)
        {
            mciSendString("Close Midi", null, 0, 0);
            mciSendString("Open " + filename + " type mpegvideo alias midi", null, 0, 0);
            mciSendString("Play Midi", null, 0, 0);
        }

        public static void CloseMidi()
        {
            mciSendString("Close Midi", null, 0, 0);
        }

        public static void PlayWave(string filename)
        {
            if (soundPlayer != null)
            {
                soundPlayer.Dispose();
            }
            soundPlayer = new SoundPlayer(filename);
            soundPlayer.Play();
        }

        public static void CloseWave()
        {
            if (soundPlayer != null)
            {
                soundPlayer.Stop();
                soundPlayer.Dispose();
                soundPlayer = null;
            }
        }
    }
}
