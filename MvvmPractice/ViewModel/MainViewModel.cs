using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;

/*
  ViewModel需要继承ViewModelBase（来自MvvmLight库）
*/

namespace MvvmPractice.ViewModel
{
    /// <summary>
    /// MainViewModel
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region 字段
        string _title;
        ObservableCollection<NoteBookViewModel> _noteBooks = new ObservableCollection<NoteBookViewModel>();
        NoteBookViewModel _currentNoteBook;
        #endregion

        #region 属性
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }

        /// <summary>
        /// 笔记本集合
        /// </summary>
        public ObservableCollection<NoteBookViewModel> NoteBooks
        {
            get { return _noteBooks; }
            set { _noteBooks = value; }
        }

        /// <summary>
        /// 当前笔记本
        /// </summary>
        public NoteBookViewModel CurrentNoteBook
        {
            get { return _currentNoteBook; }
            set
            {
                _currentNoteBook = value;
            }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            Title = "记事本";

            AddNoteBookExecute("初始化记事本");
        }
        #endregion

        #region 命令
        /// <summary>
        /// 添加笔记本
        /// </summary>
        /// <param name="noteBookName">笔记本名称</param>
        void AddNoteBookExecute(string noteBookName)
        {
            if (_noteBooks == null)
            {
                return;
            }

            var noteBook = new NoteBookViewModel { Name = noteBookName };
            _noteBooks.Add(noteBook);
        }

        bool CanAddNoteBookExecute(string noteBookName)
        {
            return true;
        }

        public ICommand AddNoteBook
        {
            get
            {
                return new RelayCommand<string>(AddNoteBookExecute, CanAddNoteBookExecute);
            }
        }

        /// <summary>
        /// 删除笔记本
        /// </summary>
        /// <param name="noteBook">笔记本</param>
        void DelNoteBookExecute(NoteBookViewModel noteBook)
        {
            if (_noteBooks == null)
            {
                return;
            }

            _noteBooks.Remove(noteBook);
        }

        bool CanDelNoteBookExecute(NoteBookViewModel noteBook)
        {
            return true;
        }

        public ICommand DelNoteBook
        {
            get
            {
                return new RelayCommand<NoteBookViewModel>(DelNoteBookExecute, CanDelNoteBookExecute);
            }
        }

        /// <summary>
        /// 选择笔记本
        /// </summary>
        /// <param name="noteBookName">笔记本名称</param>
        void SelectNoteBookExecute(string noteBookName)
        {
            if (_noteBooks == null)
            {
                return;
            }

            var noteBook = _noteBooks.Single(model => model.Name == noteBookName);
            _currentNoteBook = noteBook;
        }

        bool CanSelectNoteBookExecute(string noteBookName)
        {
            return true;
        }

        public ICommand SelectNoteBook
        {
            get
            {
                return new RelayCommand<string>(SelectNoteBookExecute, CanSelectNoteBookExecute);
            }
        }
        #endregion
    }
}