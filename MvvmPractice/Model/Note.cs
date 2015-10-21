using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace MvvmPractice.Model
{
    /// <summary>
    /// 笔记
    /// </summary>
    public class Note
    {
        #region 字段
        string _title;
        string _content;
        #endregion

        #region 属性
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        #endregion
    }
}
