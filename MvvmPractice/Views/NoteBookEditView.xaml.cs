using System;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MvvmPractice.Messages;

namespace MvvmPractice.Views
{
    /// <summary>
    /// Description for NoteBookEditView.
    /// </summary>
    public partial class NoteBookEditView : Window
    {
        /// <summary>
        /// Initializes a new instance of the NoteBookEditView class.
        /// </summary>
        public NoteBookEditView()
        {
            InitializeComponent();

            // 注册消息
            RegisterMessage();
        }

        /// <summary>
        /// 注册消息
        /// </summary>
        private void RegisterMessage()
        {
            // 消息：笔记本编辑完成
            Messenger.Default.Register<NoteBookEditDoneMessage>(this,
                (NoteBookEditDoneMessage message) =>
                {
                    Close();
                }
            );
        }
    }
}