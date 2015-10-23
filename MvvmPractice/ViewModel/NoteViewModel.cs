using MvvmPractice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

/*
  ViewModel需要继承ViewModelBase（来自MvvmLight库）
*/

namespace MvvmPractice.ViewModel
{
    /// <summary>
    /// 笔记ViewModel
    /// </summary>
    public class NoteViewModel : ViewModelBase
    {
        #region 字段
        Note _note;
        #endregion

        #region 属性
        /// <summary>
        /// 笔记
        /// </summary>
        public Note Note
        {
            get { return _note; }
            set { _note = value; }
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
        #endregion

        public NoteViewModel()
        {
            _note = new Note { Title="", Content="" };
        }
    }
}
