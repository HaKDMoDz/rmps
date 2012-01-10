using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Pwd
{
    public partial class APwd : Form
    {
        public APwd()
        {
            InitializeComponent();
        }

        private void LbKeyList_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)//如果选中该选项
            //{
            //Brush b = new TextureBrush(new Bitmap(@"../../../sj.bmp"));//读取背景图片,再转变成画刷
            ////就在背景里画图片
            //e.Graphics.FillRectangle(b, e.Bounds);//参数中,e.Bounds 表示当前选项在整个listbox中的区域
            //}
            //else//不是选中item
            //{
            //    e.Graphics.FillRectangle(Brushes.White, e.Bounds);//在背景上画空白
            //Brush b = new TextureBrush(new Bitmap(@"../../../Listline.bmp"));//底下线的图片
            ////在背景上画线
            //e.Graphics.FillRectangle(b, e.Bounds.X, e.Bounds.Y + 23, e.Bounds.Width, 1);//参数中,23和1是根据图片来的,因为需要在最下面显示线条
            //}

            if (e.Index <= -1 || e.Index >= LbKeyList.Items.Count)
            {
                return;
            }
            Key key = LbKeyList.Items[e.Index] as Key;
            if (key == null)
            {
                return;
            }

            //e.Graphics.DrawImage(null, 0, 0);

            //最后把要显示的文字画在背景图片上
            e.Graphics.DrawString(key.Title, this.Font, Brushes.Black, e.Bounds.X + 36, e.Bounds.Y + 2);

            e.Graphics.DrawString(key.VisitDate, this.Font, Brushes.Gray, e.Bounds.X + 36, e.Bounds.Y + 16);

            //e.Graphics.DrawImage(null, 0, 0);
        }

        private void TvCatView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        public void ChangeView(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            uc.Location = new Point(0, 0);
            uc.Size = new Size(460, 398);
            uc.TabIndex = 0;

            HSplit.Panel2.Controls.Clear();
            HSplit.Panel2.Controls.Add(uc);
        }

        private void CmiAppendCat_Click(object sender, System.EventArgs e)
        {

        }

        private void CmiUpdateCat_Click(object sender, System.EventArgs e)
        {

        }

        private void CmiDeleteCat_Click(object sender, System.EventArgs e)
        {

        }

        private void CmiEditIcon_Click(object sender, System.EventArgs e)
        {

        }

        private void CmiAppendKey_Click(object sender, System.EventArgs e)
        {

        }

        private void CmiUpdateKey_Click(object sender, System.EventArgs e)
        {

        }

        private void CmiDeleteKey_Click(object sender, System.EventArgs e)
        {

        }

        private void CmiChangeCat_Click(object sender, System.EventArgs e)
        {

        }
    }
}
