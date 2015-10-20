using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;

namespace MvvmPractice.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        string _title;
        ObservableCollection<NoteBookViewModel> _noteBooks = new ObservableCollection<NoteBookViewModel>();
        NoteBookViewModel _currentNoteBook;

        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }

        public ObservableCollection<NoteBookViewModel> NoteBooks
        {
            get { return _noteBooks; }
            set { _noteBooks = value; }
        }

        public NoteBookViewModel CurrentNoteBook
        {
            get { return _currentNoteBook; }
            set
            {
                _currentNoteBook = value;
            }
        }

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

        // 添加笔记本
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

        // 删除笔记本
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

        // 选择笔记本
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
    }
}