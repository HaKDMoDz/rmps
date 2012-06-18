using System.Windows.Forms;
using Me.Amon.Pwd;
using Me.Amon.Model.Sec;
using Me.Amon.Uc;

namespace Me.Amon.Sec.V.Pro.Uc
{
    public abstract class ADo
    {
        protected const string OUTPUT_TEXT = "text";
        protected const string OUTPUT_FILE = "file";
        protected const string OUTPUT_FILE_TXT = "txtf";
        protected const string OUTPUT_FILE_BIN = "binf";
        protected const string USER_CHARSET = "30";

        #region 构造函数
        protected APro _APro;
        protected DataModel _DataModel;
        protected Do _Do;

        public ADo(APro apro, Do od)
        {
            _APro = apro;
            _Do = od;
        }
        #endregion

        #region 用户交互
        public static Item _TypeDef = new Item { K = "0", V = "请选择" };
        public static Udc _MaskDef = new Udc { Id = "0", Name = "默认", Data = "" };
        protected static Item _Type;
        protected static Udc _Udc;

        public abstract void InitOpt();

        public abstract void InitKey(string key);

        public abstract void ChangedType(Item type);

        public abstract void MoreData();

        public abstract void ChangedMask(Udc udc);

        public abstract void MoreMask();

        public void DragDrop(DragEventArgs e)
        {
            if (_Type.K == OUTPUT_FILE || _Type.K == OUTPUT_FILE_BIN || _Type.K == OUTPUT_FILE_TXT)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] dat = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                    if (dat.Length > 0)
                    {
                        _Do.TbData.Text = dat[0];
                    }
                }
                return;
            }

            if (_Type.K == OUTPUT_TEXT)
            {
                string dat;
                if (e.Data.GetDataPresent(DataFormats.Text))
                {
                    dat = (string)e.Data.GetData(DataFormats.Text, false);
                    _Do.UserData.Clear().Append(dat);
                    _Do.ShowData();
                    return;
                }

                if (e.Data.GetDataPresent(DataFormats.Html))
                {
                    dat = (string)e.Data.GetData(DataFormats.Html, false);
                    _Do.UserData.Clear().Append(dat);
                    _Do.ShowData();
                }

                return;
            }
        }

        public void DragEnter(DragEventArgs e)
        {
            if (_Type.K == OUTPUT_FILE || _Type.K == OUTPUT_FILE_BIN || _Type.K == OUTPUT_FILE_TXT)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                return;
            }

            if (_Type.K == OUTPUT_TEXT)
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
        protected static char[] _CharBuf = new char[8192];
        protected static System.IO.Stream _Stream;
        protected static System.IO.TextWriter _Writer;

        public abstract bool Check();

        public abstract void Begin();

        public abstract void Write(byte[] buffer, int offset, int count);

        public abstract void End();
        #endregion
    }
}