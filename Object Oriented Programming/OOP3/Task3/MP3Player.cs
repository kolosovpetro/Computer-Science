using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Task3
{
    class MP3Player
    {
        List<Song> PlayList = new List<Song>();

        public void Add(Song track) { PlayList.Add(track); }

        public void Remove(int songNumber) { PlayList.RemoveAt(songNumber); }

        public void Play(int songNumber) { PlayList[songNumber].Play(); }

        public void PlaylistPlay()
        {
            foreach (Song item in PlayList)
            {
                Thread.Sleep(2000);
                item.Play();
            }
        }



    }
}
