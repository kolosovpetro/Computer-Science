using System.Collections.Generic;
using System.Threading;

namespace Task3
{
    internal class Mp3Player
    {
        private readonly List<Song> _playList = new List<Song>();

        public void Add(Song track)
        {
            _playList.Add(track);
        }

        public void Remove(int songNumber)
        {
            _playList.RemoveAt(songNumber);
        }

        public void Play(int songNumber)
        {
            _playList[songNumber].Play();
        }

        public void PlaylistPlay()
        {
            foreach (var item in _playList)
            {
                Thread.Sleep(2000);
                item.Play();
            }
        }



    }
}
