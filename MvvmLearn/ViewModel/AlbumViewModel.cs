using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MvvmLearn.ViewModel
{
    public class AlbumViewModel : ViewModelBase
    {
        ObservableCollection<string> _songs = new ObservableCollection<string>();
        string _currentSong;

        public AlbumViewModel()
        {
            Songs.Add("Song1");
            Songs.Add("Song2");
            Songs.Add("Song3");
        }

        public ObservableCollection<string> Songs
        {
            get { return _songs; }
            set { _songs = value; }
        }

        /// <summary>
        /// 当前歌曲
        /// </summary>
        public string CurrentSong
        {
            get { return _currentSong; }
            set
            {
                if (_currentSong != value)
                {
                    _currentSong = value;
                    RaisePropertyChanged("CurrentSong");
                }

            }
        }

    }
}
