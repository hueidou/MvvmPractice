﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace MvvmPractice.ViewModel
{
    public class NoteBookViewModel : ViewModelBase
    {
        #region 字段
        ObservableCollection<NoteViewModel> _notes = new ObservableCollection<NoteViewModel>();
        string _name;
        #endregion

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


        // 添加笔记本
        void AddNoteExecute(string title)
        {
            if (_notes == null)
            {
                return;
            }

            _notes.Add(new NoteViewModel { Title = title });
        }

        bool CanAddNoteExecute(string title)
        {
            return true;
        }

        public ICommand AddNote
        {
            get
            {
                return new RelayCommand<string>(AddNoteExecute, CanAddNoteExecute);
            }
        }

        // 删除笔记本
        void DelNoteExecute(string title)
        {
            if (_notes == null)
            {
                return;
            }

            var noteBook = _notes.Single(model => model.Title == title);
            _notes.Remove(noteBook);
        }

        bool CanDelNoteExecute(string title)
        {
            return true;
        }

        public ICommand DelNote
        {
            get
            {
                return new RelayCommand<string>(DelNoteExecute, CanDelNoteExecute);
            }
        }
    }
}