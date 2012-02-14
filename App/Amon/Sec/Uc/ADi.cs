using System.Windows.Forms;
using Me.Amon.Uc;

namespace Me.Amon.Sec.Uc
{
    public abstract class ADi
    {
        protected const string INPUT_TEXT = "text";
        protected const string INPUT_FILE = "file";
        protected const string INPUT_FILE_TXT = "txtf";
        protected const string INPUT_FILE_BIN = "binf";
        protected const string USER_CHARSET = "30";

        #region 构造函数
        protected ASec _ASec;
        protected Di _Di;

        public ADi(ASec asec, Di di)
        {
            _ASec = asec;
            _Di = di;
        }
        #endregion

        #region 用户交互
        public static Item _TypeDef = new Item { K = "0", V = "请选择" };
        public static Item _MaskDef = new Item { K = "0", V = "默认" };
        protected static Item _Type;
        protected static Item _Mask;
        protected string _Key;

        public abstract void InitOpt();

        public abstract void InitKey(string key);

        public abstract void ChangedType(Item type);

        public abstract void MoreData();

        public abstract void ChangedMask(Item mask);

        public abstract void MoreMask();

        public void DragDrop(DragEventArgs e)
        {
            if (_Type.K == INPUT_FILE || _Type.K == INPUT_FILE_BIN || _Type.K == INPUT_FILE_TXT)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] dat = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                    if (dat.Length > 0)
                    {
                        _Di.TbData.Text = dat[0];
                    }
                }
                return;
            }

            if (_Type.K == INPUT_TEXT)
            {
                string dat;
                if (e.Data.GetDataPresent(DataFormats.Text))
                {
                    dat = (string)e.Data.GetData(DataFormats.Text, false);
                    _Di.UserData.Clear().Append(dat);
                    _Di.ShowData();
                    return;
                }

                if (e.Data.GetDataPresent(DataFormats.Html))
                {
                    dat = (string)e.Data.GetData(DataFormats.Html, false);
                    _Di.UserData.Clear().Append(dat);
                    _Di.ShowData();
                }

                return;
            }
        }

        public void DragEnter(DragEventArgs e)
        {
            if (_Type.K == INPUT_FILE || _Type.K == INPUT_FILE_BIN || _Type.K == INPUT_FILE_TXT)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                return;
            }

            if (_Type.K == INPUT_TEXT)
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                return;
            }

            e.Effect = DragDropEffects.None;
        }
        #endregion

        #region 数据处理
        protected static Ce.Wrapper _Wrapper = new Ce.Wrapper();
        protected static char[] _CharBuf = new char[1024];
        protected static System.IO.Stream _Stream;
        protected static System.IO.TextReader _Reader;

        public abstract bool Check();

        public abstract void Begin();

        public abstract int Read(byte[] buffer, int offset, int count);

        public abstract void End();
        #endregion
    }
}