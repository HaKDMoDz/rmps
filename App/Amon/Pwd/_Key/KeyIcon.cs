using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.C;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd._Key
{
    public partial class KeyIcon : Form
    {
        #region 全局变量
        private UserModel _UserModel;
        private DirEditer _DirEdit;
        private IcoEditer _IcoView;
        private Control _Control;
        private string _RootDir;
        private string _HomeDir;
        private int _LastIdx;
        #endregion

        #region 构造函数
        public KeyIcon()
        {
            InitializeComponent();
        }

        public KeyIcon(UserModel userModel, string rootDir)
        {
            _UserModel = userModel;
            _RootDir = rootDir;
            _HomeDir = rootDir;

            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }
        #endregion

        #region 公有函数
        public int IcoSize { get; set; }

        public string HomeDir { get { return _HomeDir; } }

        public AmonHandler<Png> CallBackHandler { get; set; }

        public void UpdateDir(Dir item)
        {
            bool update = CharUtil.IsValidateHash(item.Id);
            _UserModel.DBA.SaveVcs(item);
            if (update)
            {
                LsDir.Items[LsDir.SelectedIndex] = item;
            }
            else
            {
                item.Path = HashUtil.UtcTimeInHex();
                Directory.CreateDirectory(Path.Combine(_RootDir, item.Path));
                LsDir.Items.Add(item);
                LsDir.SelectedItem = item;
            }
        }

        public void CallBack(Png png)
        {
            if (CallBackHandler != null)
            {
                png.Path = (LsDir.Items[_LastIdx] as Dir).Path;
                CallBackHandler(png);
            }
            Close();
        }
        #endregion

        #region 事件处理
        private void KeyIcon_Load(object sender, EventArgs e)
        {
            ShowIcoView();

            LsDir.Items.Add(new Dir { Id = "0", Text = "默认分类", Tips = "默认分类", Path = "." });
            foreach (Dir dir in _UserModel.DBA.ListDir())
            {
                LsDir.Items.Add(dir);
            }

            LsDir.SelectedIndex = 0;
            _IcoView.ShowData(_HomeDir);
        }

        private void LsDir_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index <= -1 || e.Index >= LsDir.Items.Count)
            {
                return;
            }
            Dir dir = LsDir.Items[e.Index] as Dir;
            if (dir == null)
            {
                return;
            }

            SizeF s = e.Graphics.MeasureString(dir.Text, Font);
            int x = (e.Bounds.Width - (int)s.Width) >> 1;
            int y = (e.Bounds.Height - (int)s.Height) >> 1;
            e.Graphics.DrawString(dir.Text, Font, Brushes.Black, e.Bounds.X + x, e.Bounds.Y + y);
        }

        #region 界面事件
        private void LsDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_LastIdx == LsDir.SelectedIndex)
            {
                return;
            }
            _LastIdx = LsDir.SelectedIndex;

            if (_Control is DirEditer)
            {
                ShowIcoView();
            }

            Dir item = LsDir.SelectedItem as Dir;
            if (item == null)
            {
                return;
            }

            _HomeDir = CharUtil.IsValidateHash(item.Path) ? Path.Combine(_RootDir, item.Path) : _RootDir;
            if (!Directory.Exists(_HomeDir))
            {
                return;
            }
            _IcoView.ShowData(_HomeDir);
        }
        #endregion

        #region 选单事件
        private void MiAppend_Click(object sender, EventArgs e)
        {
            if (_Control is IcoEditer)
            {
                ShowDirEdit();
            }
            _DirEdit.ShowData(new Dir());
        }

        private void MiUpdate_Click(object sender, EventArgs e)
        {
            Dir item = LsDir.SelectedItem as Dir;
            if (item == null || item.Id == "0")
            {
                return;
            }

            if (_Control is IcoEditer)
            {
                ShowDirEdit();
            }
            _DirEdit.ShowData(item);
        }

        private void MiDelete_Click(object sender, EventArgs e)
        {
            Dir item = LsDir.SelectedItem as Dir;
            if (item == null || item.Id == "0")
            {
                return;
            }

            if (DialogResult.Yes != MessageBox.Show("确认要删除吗？", "", MessageBoxButtons.YesNo))
            {
                return;
            }

            _UserModel.DBA.DeleteVcs(item);
            if (Directory.Exists(HomeDir))
            {
                Directory.Delete(HomeDir, true);
            }

            LsDir.Items.Remove(item);
        }
        #endregion
        #endregion

        #region 私有函数
        private void ShowDirEdit()
        {
            if (_DirEdit == null)
            {
                _DirEdit = new DirEditer(this);
                _DirEdit.Init();
                _DirEdit.Location = new Point(138, 12);
                _DirEdit.Size = new Size(248, 249);
                _DirEdit.TabIndex = 1;
            }
            if (_IcoView != null)
            {
                Controls.Remove(_IcoView);
            }
            Controls.Add(_DirEdit);
            _Control = _DirEdit;
        }

        private void ShowIcoView()
        {
            if (_IcoView == null)
            {
                _IcoView = new IcoEditer(this);
                _IcoView.InitOnce();
                _IcoView.Location = new Point(138, 12);
                _IcoView.Size = new Size(248, 249);
                _IcoView.TabIndex = 1;
            }
            if (_DirEdit != null)
            {
                Controls.Remove(_DirEdit);
            }
            Controls.Add(_IcoView);
            _Control = _IcoView;
        }
        #endregion
    }
}
