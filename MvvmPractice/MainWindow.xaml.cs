using MvvmPractice.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MvvmPractice
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenNoteBookEdit_Click(object sender, RoutedEventArgs e)
        {
            var noteBookEditView = new NoteBookEditView();
            noteBookEditView.Owner = this;
            noteBookEditView.ShowDialog();
        }

        private void OpenNoteEdit_Click(object sender, RoutedEventArgs e)
        {
            var noteEditView = new NoteEditView();
            noteEditView.Owner = this;
            noteEditView.ShowDialog();
        }
    }
}
