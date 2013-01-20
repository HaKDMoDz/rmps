using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd._Lib
{
    public partial class UcHeader : UserControl, ILibEdit
    {
        private LibEditer _LibEdit;
        private Lib _LibHeader;

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
        }

        public void Show(Lib header)
        {
            _LibHeader = header;

            TbText.Text = _LibHeader.Text;
            TbScript.Text = _LibHeader.Script;
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
            _LibHeader.Script = TbScript.Text;
            _LibHeader.Memo = TbMemo.Text;

            _LibEdit.SaveHeader(_LibHeader);
            Show(new Lib());
        }
    }
}
