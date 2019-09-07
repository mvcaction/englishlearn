using Android.Media;
using learnenglish.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace learnenglish.Model
{
    class MyMp3Player : AudioPlayerInterface
    {
        public void AudioPlayer(string FileName)
        {
            var player = new MediaPlayer();

            var fd = global::Android.App.Application.Context.Assets.OpenFd(FileName);
            player.Prepared += (s, e) =>
            {
                player.Start();
            };
            player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
            player.Prepare();
        }
    }
}
