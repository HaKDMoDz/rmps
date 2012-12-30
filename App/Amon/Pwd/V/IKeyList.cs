using System;
using System.Windows.Forms;

namespace Me.Amon.Pwd.V
{
    public interface IKeyList
    {
        Control Control { get; }

        ContextMenuStrip PopupMenu { get; set; }

        IAttView AttView { get; set; }

        void ListKeys(string catId);

        void FindKeys(string meta);

        void RemoveSelected();

        void ListKeysWithGtd(int status);

        void ListKeysWithGtd(DateTime time, int seconds);

        void ChangeKeyLabel(int label);

        void ChangeKeyMajor(int major);
    }
}
