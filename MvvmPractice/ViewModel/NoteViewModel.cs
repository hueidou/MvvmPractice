using MvvmPractice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace MvvmPractice.ViewModel
{
    public class NoteViewModel : ViewModelBase
    {
        Note _note;

        public Note Note
        {
            get { return _note; }
            set
            {
                _note = value;
            }
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return Note.Title; }
            set
            {
                if (Note.Title != value)
                {
                    Note.Title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return Note.Content; }
            set
            {
                if (Note.Content != value)
                {
                    Note.Content = value;
                    RaisePropertyChanged("Content");
                }
            }
        }
    }
}
