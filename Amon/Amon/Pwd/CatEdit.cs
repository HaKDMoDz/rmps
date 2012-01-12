using System;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Model;

namespace Me.Amon.Pwd
{
    public partial class CatEdit : Form
    {
        private Cat _Cat;

        public CatEdit()
        {
            InitializeComponent();
        }

        public void Init(Cat cat)
        {
            _Cat = cat;
        }

        public AmonHandler<Cat> CallBackHandler { get; set; }

        public void Show(IWin32Window owner, Cat cat)
        {
            _Cat = cat;
            this.Show(owner);
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            if (_Cat == null)
            {
                _Cat = new Cat();
            }

            _Cat.Icon = "";
            _Cat.Text = TbName.Text;
            _Cat.Tips = TbTips.Text;
            _Cat.Value = TbValue.Text;

            if (CallBackHandler != null)
            {
                CallBackHandler.Invoke(_Cat);
            }
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
