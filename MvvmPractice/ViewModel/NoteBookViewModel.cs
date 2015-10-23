using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MvvmPractice.Messages;
using GalaSoft.MvvmLight.Messaging;

/*
  ViewModel需要继承ViewModelBase（来自MvvmLight库）
*/

namespace MvvmPractice.ViewModel
{
    /// <summary>
    /// 笔记本ViewModel
    /// </summary>
    public class NoteBookViewModel : ViewModelBase
    {
        #region 字段
        ObservableCollection<NoteViewModel> _notes = new ObservableCollection<NoteViewModel>();
        string _name;
        #endregion

        #region 属性
        /// <summary>
        /// 笔记
        /// </summary>
        public ObservableCollection<NoteViewModel> Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        /// <summary>
        /// 笔记本名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        #endregion

        #region 命令
        /// <summary>
        /// 添加笔记本
        /// </summary>
        /// <param name="title"></param>
        void AddNoteExecute(NoteViewModel note)
        {
            if (_notes == null)
            {
                return;
            }

            _notes.Add(note);

            Messenger.Default.Send<NoteEditDoneMessage>(null);
        }

        bool CanAddNoteExecute(NoteViewModel note)
        {
            return true;
        }

        public ICommand AddNote
        {
            get
            {
                return new RelayCommand<NoteViewModel>(AddNoteExecute, CanAddNoteExecute);
            }
        }

        /// <summary>
        /// 删除笔记本
        /// </summary>
        /// <param name="title"></param>
        void DelNoteExecute(NoteViewModel note)
        {
            if (_notes == null)
            {
                return;
            }
            
            _notes.Remove(note);
        }

        bool CanDelNoteExecute(NoteViewModel note)
        {
            return true;
        }

        public ICommand DelNote
        {
            get
            {
                return new RelayCommand<NoteViewModel>(DelNoteExecute, CanDelNoteExecute);
            }
        }
        #endregion
    }
}
