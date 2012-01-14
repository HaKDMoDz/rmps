using System;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.Pwd._Cat
{
    public partial class CatEdit : Form
    {
        private Cat _Cat;

        public CatEdit()
        {
            InitializeComponent();
        }

        public void Init()
        {
            TbName.MaxLength = IDat.C2010205_SIZE;
            TbTips.MaxLength = IDat.C2010206_SIZE;
            TbMeta.MaxLength = IDat.C2010208_SIZE;
            TbMemo.MaxLength = IDat.C2010209_SIZE;
        }

        public AmonHandler<Model.Cat> CallBackHandler { get; set; }

        public void Show(IWin32Window owner, Cat cat)
        {
            this.Show(owner);
            ShowData(cat);
        }

        private void ShowData(Cat cat)
        {
            _Cat = cat;
            TbName.Text = _Cat.Text;
            TbTips.Text = _Cat.Tips;
            TbMeta.Text = _Cat.Meta;
            TbMemo.Text = _Cat.Memo;
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            string name = TbName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("请输入类别名称！");
                TbName.Focus();
                return;
            }
            if (!CharUtil.IsValidate(name, 1, IDat.C2010104_SIZE))
            {
                MessageBox.Show("类别名称不能多于" + IDat.C2010104_SIZE + "个字符！");
                TbName.Focus();
                return;
            }

            if (_Cat == null)
            {
                _Cat = new Cat();
            }

            _Cat.Icon = "";
            _Cat.Text = name;
            _Cat.Tips = TbTips.Text;
            _Cat.Meta = TbMeta.Text;
            _Cat.Memo = TbMemo.Text;

            if (CallBackHandler != null)
            {
                CallBackHandler.Invoke(_Cat);
            }
            Close();
        }

        private void BtNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PbIcon_Click(object sender, EventArgs e)
        {

        }
    }
}
