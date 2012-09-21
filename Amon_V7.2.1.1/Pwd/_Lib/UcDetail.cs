using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.Pwd;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Pwd._Lib
{
    public partial class UcDetail : UserControl, ILibEdit
    {
        private LibEditer _LibEdit;
        private Me.Amon.Pwd.LibDetail _LibDetail;

        public UcDetail()
        {
            InitializeComponent();
        }

        public UcDetail(LibEditer libEdit)
        {
            _LibEdit = libEdit;

            InitializeComponent();
        }

        public void Init()
        {
            CbType.Items.Add(new Items { K = "0", V = "请选择" });
            CbType.Items.Add(new Items { K = Att.TYPE_TEXT.ToString(), V = "文本" });
            CbType.Items.Add(new Items { K = Att.TYPE_PASS.ToString(), V = "口令" });
            CbType.Items.Add(new Items { K = Att.TYPE_LINK.ToString(), V = "链接" });
            CbType.Items.Add(new Items { K = Att.TYPE_MAIL.ToString(), V = "邮件" });
            CbType.Items.Add(new Items { K = Att.TYPE_DATE.ToString(), V = "日期" });
            CbType.Items.Add(new Items { K = Att.TYPE_DATA.ToString(), V = "数值" });
            CbType.Items.Add(new Items { K = Att.TYPE_CALL.ToString(), V = "电话" });
            //CbType.Items.Add(new Item { K = AAtt.TYPE_LIST.ToString(), V = "列表" });
            CbType.Items.Add(new Items { K = Att.TYPE_MEMO.ToString(), V = "附注" });
            CbType.Items.Add(new Items { K = Att.TYPE_FILE.ToString(), V = "文件" });
            //CbType.Items.Add(new Item { K = AAtt.TYPE_LINE.ToString(), V = "分组" });

            TbName.MaxLength = DBConst.APWD0306_SIZE;
            TbData.MaxLength = DBConst.APWD0307_SIZE;
            TbMemo.MaxLength = DBConst.APWD0308_SIZE;
        }

        public void Show(Me.Amon.Pwd.LibDetail detail)
        {
            _LibDetail = detail;

            CbType.SelectedItem = new Items { K = detail.Type.ToString() };
            TbName.Text = _LibDetail.Text;
            TbData.Text = _LibDetail.Data;
            TbMemo.Text = _LibDetail.Memo;
        }

        public void Save()
        {
            Items item = CbType.SelectedItem as Items;
            if (item == null)
            {
                MessageBox.Show("请选择属性类型！");
                CbType.Focus();
                return;
            }
            string text = TbName.Text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("请输入属性名称！");
                TbName.Focus();
                return;
            }

            _LibDetail.Type = int.Parse(item.K);
            _LibDetail.Text = text;
            _LibDetail.Data = TbData.Text;
            _LibDetail.Memo = TbMemo.Text;

            _LibEdit.SaveDetail(_LibDetail);
            Show(new Me.Amon.Pwd.LibDetail());
        }
    }
}
