using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Pwd._Lib
{
    public partial class LibDetail : UserControl, ILibEdit
    {
        private LibEdit _LibEdit;
        private Me.Amon.Model.LibDetail _LibDetail;

        public LibDetail()
        {
            InitializeComponent();
        }

        public LibDetail(LibEdit libEdit)
        {
            _LibEdit = libEdit;

            InitializeComponent();

            CbType.Items.Add(new Item { K = "0", V = "请选择" });
            CbType.Items.Add(new Item { K = AAtt.TYPE_TEXT.ToString(), V = "文本" });
            CbType.Items.Add(new Item { K = AAtt.TYPE_PASS.ToString(), V = "口令" });
            CbType.Items.Add(new Item { K = AAtt.TYPE_LINK.ToString(), V = "链接" });
            CbType.Items.Add(new Item { K = AAtt.TYPE_MAIL.ToString(), V = "邮件" });
            CbType.Items.Add(new Item { K = AAtt.TYPE_DATE.ToString(), V = "日期" });
            CbType.Items.Add(new Item { K = AAtt.TYPE_DATA.ToString(), V = "数值" });
            CbType.Items.Add(new Item { K = AAtt.TYPE_LIST.ToString(), V = "列表" });
            CbType.Items.Add(new Item { K = AAtt.TYPE_MEMO.ToString(), V = "附注" });
            CbType.Items.Add(new Item { K = AAtt.TYPE_FILE.ToString(), V = "文件" });
            CbType.Items.Add(new Item { K = AAtt.TYPE_LINE.ToString(), V = "分组" });
        }

        public void Show(Me.Amon.Model.LibDetail detail)
        {
            _LibDetail = detail;

            CbType.SelectedItem = new Item { K = detail.Type.ToString() };
            TbName.Text = _LibDetail.Name;
            TbData.Text = _LibDetail.Data;
            TbMemo.Text = _LibDetail.Memo;
        }

        public void Save()
        {
            Item item = CbType.SelectedItem as Item;
            if (item == null)
            {
                MessageBox.Show("");
                return;
            }
            string name = TbName.Text;
            if (!CharUtil.IsValidate(name))
            {
                return;
            }

            _LibDetail.Type = int.Parse(item.K);
            _LibDetail.Name = name;
            _LibDetail.Data = TbData.Text;
            _LibDetail.Memo = TbMemo.Text;

            _LibEdit.SaveDetail(_LibDetail);
            Show(new Me.Amon.Model.LibDetail());
        }
    }
}
