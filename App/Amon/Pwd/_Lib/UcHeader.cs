using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.Util;

namespace Me.Amon.Pwd._Lib
{
    public partial class UcHeader : UserControl, ILibEdit
    {
        private LibEditer _LibEdit;
        private Me.Amon.Pwd.Lib _LibHeader;

        public UcHeader()
        {
            InitializeComponent();
        }

        public UcHeader(LibEditer libEdit)
        {
            _LibEdit = libEdit;

            InitializeComponent();
        }

        public void Init()
        {
            TbText.MaxLength = DBConst.APWD0306_SIZE;
            TbMemo.MaxLength = DBConst.APWD0308_SIZE;
        }

        public void Show(Me.Amon.Pwd.Lib header)
        {
            _LibHeader = header;

            TbText.Text = _LibHeader.Text;
            TbMemo.Text = _LibHeader.Memo;
        }

        public void Save()
        {
            string text = TbText.Text;
            if (!CharUtil.IsValidate(text))
            {
                return;
            }

            _LibHeader.Name = "";
            _LibHeader.Text = text;
            _LibHeader.Memo = TbMemo.Text;

            _LibEdit.SaveHeader(_LibHeader);
            Show(new Me.Amon.Pwd.Lib());
        }
    }
}
