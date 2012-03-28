using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Bean.Att;
using Me.Amon.Ce;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;
using Me.Amon.Ren.M;

namespace Me.Amon.Ren
{
    public partial class ARen : Form, IApp
    {
        private UserModel _UserModel;
        private DataTable _DataList;
        private Renamer _Renamer;
        private string _SrcPath;

        #region 构造函数
        public ARen()
        {
            InitializeComponent();
        }

        public ARen(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce()
        {
            _DataList = new DataTable();
            _DataList.Columns.Add("OldName", typeof(string));
            _DataList.Columns.Add("NewName", typeof(string));
            GvName.DataSource = _DataList;

            _Renamer = new Renamer();

            foreach (MRen ren in _UserModel.DBObject.ListRen())
            {
                LsRule.Items.Add(ren);
            }
        }

        public int AppId { get; set; }

        public Form Form
        {
            get { return this; }
        }

        public bool WillExit()
        {
            return true;
        }

        public bool SaveData()
        {
            return true;
        }
        #endregion

        #region 事件处理
        private void TcRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            TbRule.ReadOnly = (TcRule.SelectedTab != TpRuleInf);
        }

        private void PbSave_Click(object sender, EventArgs e)
        {
            MRen ren = new MRen();
            ren.Name = "renamer1";
            ren.Command = TbRule.Text;
            _UserModel.DBObject.SaveVcs(ren);
            LsRule.Items.Add(ren);
        }

        private void BtSelect_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != FdBrowser.ShowDialog(this))
            {
                return;
            }

            _SrcPath = FdBrowser.SelectedPath;
            _DataList.Rows.Clear();
            int index = 0;
            foreach (string file in Directory.GetFiles(_SrcPath))
            {
                _DataList.Rows.Add(Path.GetFileName(file), "");
                GvName.Rows[index++].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void BtReview_Click(object sender, EventArgs e)
        {
            DoReview();
        }

        private void BtRename_Click(object sender, EventArgs e)
        {
            if (DoReview())
            {
                DoRename();
            }
        }

        private void PbMenu_Click(object sender, EventArgs e)
        {
            CmMenu.Show(PbMenu, 0, PbMenu.Height);
        }

        private void LsRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            MRen ren = LsRule.SelectedItem as MRen;
            if (ren == null)
            {
                return;
            }

            TbRule.Text = ren.Command;
        }
        #endregion

        #region 私有函数
        private bool DoReview()
        {
            string rule = TbRule.Text;
            if (string.IsNullOrEmpty(rule))
            {
                Main.ShowAlert("请输入或选择命名规则！");
                if (!TbRule.ReadOnly)
                {
                    TbRule.Focus();
                }
                return false;
            }

            if (string.IsNullOrEmpty(_SrcPath))
            {
                Main.ShowAlert("请选择您要重命名的目录！");
                BtSelect.Focus();
                return false;
            }

            if (!_Renamer.Init(rule))
            {
                ShowEcho(_Renamer.Error);
                return false;
            }

            Dictionary<string, int> dic = new Dictionary<string, int>();
            string src;
            string dst;
            int idx = 0;
            int nc = 0;//无效命名数量
            int ec = 0;//重复命名数量
            foreach (DataRow row in _DataList.Rows)
            {
                src = row["OldName"] as string;
                dst = _Renamer.Update(src);
                if (string.IsNullOrEmpty(dst))
                {
                    //;
                    GvName.Rows[idx++].DefaultCellStyle.BackColor = Color.Blue;
                    nc += 1;
                    continue;
                }
                if (dic.ContainsKey(dst))
                {
                    row["NewName"] = dst;
                    GvName.Rows[idx++].DefaultCellStyle.BackColor = Color.Red;
                    ec += 1;
                    continue;
                }

                row["NewName"] = dst;
                dic[dst] = idx;
                GvName.Rows[idx++].DefaultCellStyle.BackColor = Color.White;
            }
            if (nc > 0 || ec > 0)
            {
                ShowEcho(string.Format("存在命名冲突，请调整命名规则后重试！", nc, ec));
                return false;
            }
            return true;
        }

        private void DoRename()
        {
            string src = FdBrowser.SelectedPath;
            string dst = NewDir(src);
            if (string.IsNullOrEmpty(dst))
            {
                Main.ShowAlert("请确认您是否拥有访问权限！");
                return;
            }

            Directory.CreateDirectory(dst);
            File.SetAttributes(dst, FileAttributes.Hidden);

            string tmp;
            string tmp1;
            string tmp2;
            foreach (DataRow row in _DataList.Rows)
            {
                tmp1 = Path.Combine(src, row["OldName"] as string);
                if (!File.Exists(tmp1))
                {
                    continue;
                }

                tmp = row["NewName"] as string;
                tmp2 = Path.Combine(dst, tmp);
                if (File.Exists(tmp2))
                {
                    string msg = string.Format("已存在名称为{0}且创建日期为{1}，\n文件大小为{2}的文件，确认要覆盖吗？", tmp, File.GetCreationTime(dst), Length(dst));
                    if (DialogResult.Yes != Main.ShowConfirm(msg))
                    {
                        continue;
                    }
                }
                File.Move(tmp1, tmp2);
            }

            FileAttributes att = FileAttributes.Normal;
            if (CkReadOnly.Checked)
            {
                att |= FileAttributes.ReadOnly;
            }
            if (CkHidden.Checked)
            {
                att |= FileAttributes.Hidden;
            }
            if (CkArchive.Checked)
            {
                att |= FileAttributes.Archive;
            }
            foreach (DataRow row in _DataList.Rows)
            {
                tmp1 = Path.Combine(dst, row["NewName"] as string);
                if (!File.Exists(tmp1))
                {
                    continue;
                }

                tmp = row["NewName"] as string;
                tmp2 = Path.Combine(src, tmp);
                if (File.Exists(tmp2))
                {
                    string msg = string.Format("已存在名称为{0}且创建日期为{1}，\n文件大小为{2}的文件，确认要覆盖吗？", tmp, File.GetCreationTime(dst), Length(dst));
                    if (DialogResult.Yes != Main.ShowConfirm(msg))
                    {
                        continue;
                    }
                }
                File.Move(tmp1, tmp2);
                File.SetAttributes(tmp2, att);
            }

            Directory.Delete(dst);
            ShowEcho("恭喜，全部重命名成功！");
        }

        private string Length(string path)
        {
            long size = new FileInfo(path).Length;
            if (size > 0x20000000)
            {
                size >>= 30;
                return size + "G";
            }
            if (size > 0x20000)
            {
                size >>= 20;
                return size + "M";
            }
            if (size > 0x200)
            {
                size >>= 10;
                return size + "K";
            }

            return size + "B";
        }

        private string NewDir(string path)
        {
            string tmp;
            for (int i = 0; i < 10; i += 1)
            {
                tmp = Path.Combine(path, "__amon__" + DateTime.UtcNow.ToFileTime().ToString() + "__amon__");
                if (!Directory.Exists(tmp))
                {
                    return tmp;
                }
            }
            return null;
        }

        private void ShowEcho(string msg)
        {
            LbEcho.Text = msg;
            TpTips.SetToolTip(LbEcho, msg);
        }
        #endregion
    }
}
