using System;
using System.Windows.Forms;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V
{
    public interface IKeyList
    {
        Control Control { get; }

        ContextMenuStrip PopupMenu { get; set; }

        IAttView AttView { get; set; }

        Key SelectedKey { get; set; }

        void Clear();

        void ListKeys(string catId);

        void ListKeysByLabel(int label);

        void ListKeysByMajor(int major);

        /// <summary>
        /// 当前需要处理的任务
        /// </summary>
        void ListKeysByGtd();

        /// <summary>
        /// 指定状态的任务
        /// </summary>
        /// <param name="status"></param>
        void ListKeysByGtd(int status);

        /// <summary>
        /// 在指定时间内需要处理的任务
        /// </summary>
        /// <param name="time"></param>
        /// <param name="seconds"></param>
        void ListKeysByGtd(DateTime time, int seconds);

        void FindKeys(string meta);

        void LastKeys();

        void RemoveSelected();

        void UpdateSelected(Key key);

        void ChangeKeyLabel(int label);

        void ChangeKeyMajor(int major);
    }
}
