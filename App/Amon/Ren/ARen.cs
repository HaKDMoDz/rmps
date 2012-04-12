using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Ce;
using Me.Amon.Model;

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

            LtInfo.Text = "充分利用文件名中的禁用字符:|*?\"<>\\/来代表不同的含义：";
            DataTable dt = new DataTable();
            dt.Columns.Add("KeyCode", typeof(string));
            dt.Columns.Add("KeyInfo", typeof(string));
            dt.Rows.Add(":", "代表数字");
            dt.Rows.Add("|", "代表字母");
            dt.Rows.Add("*", "代表文件名");
            dt.Rows.Add("?", "代表扩展名");
            dt.Rows.Add("\"", "代表单个原有字符");
            dt.Rows.Add("<>", "用于限制以上特殊含义字符的取值空间");
            dt.Rows.Add("/", "正向转义字符");
            dt.Rows.Add("/*", "将文件名转换为小写");
            dt.Rows.Add("/?", "将扩展名转换为小写");
            dt.Rows.Add("/\"", "将原有字符转换为小写");
            dt.Rows.Add("/:", "代表文件修改时间，默认时间格式为<yyyyMMddHHmmss>");
            dt.Rows.Add("\\", "反向转义字符");
            dt.Rows.Add("\\*", "将文件名转换为大写");
            dt.Rows.Add("\\?", "将扩展名转换为大写");
            dt.Rows.Add("\\\"", "将原有字符转换为大写");
            dt.Rows.Add("\\:", "代表文件创建时间，默认时间格式为<yyyyMMddHHmmss>");
            dt.Rows.Add(":<a,b,c,d>", "数值的运算方式：起始值a，步增量b，结果按定长c显示，不足时填充字符d");
            dt.Rows.Add("|<abc>", "字符的运算方式：表示循环计算abc等字符");
            dt.Rows.Add("*<a:b>", "将文件名中的a替换为b");
            dt.Rows.Add("?<a:b>", "将扩展名中的a替换为b");
            GvInfo.DataSource = dt;

            foreach (MRen ren in _UserModel.DBA.ListRen())
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
        private void PbSelect_Click(object sender, EventArgs e)
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
            MiSaveas.Visible = true;
            MiSep0.Visible = true;
            MiSep1.Visible = true;
            MiExport.Visible = true;
            MiImport.Visible = true;

            MiSortUp.Visible = false;
            MiSortDown.Visible = false;
            MiSep1.Visible = false;
            MiDelete.Visible = false;

            CmMenu.Show(PbMenu, 0, PbMenu.Height);
        }

        private void LsRule_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            MiSaveas.Visible = false;
            MiSep0.Visible = false;
            MiSep1.Visible = false;
            MiExport.Visible = false;
            MiImport.Visible = false;

            MiSortUp.Visible = true;
            MiSortDown.Visible = true;
            MiSep1.Visible = true;
            MiDelete.Visible = true;

            CmMenu.Show(LsRule, e.Location);
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

        private void MiSaveas_Click(object sender, EventArgs e)
        {
            string name = Main.ShowInput("请输入模板名称：", "");
            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            MRen ren = new MRen();
            ren.Order = LsRule.Items.Count;
            ren.Name = name;
            ren.Command = TbRule.Text;
            _UserModel.DBA.SaveVcs(ren);
            LsRule.Items.Add(ren);
        }

        private void MiImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "重命名模板文件|*.arxml";
            if (DialogResult.OK != fd.ShowDialog(this))
            {
                return;
            }
            string file = fd.FileName;
            if (!File.Exists(file))
            {
                return;
            }

            using (StreamReader sr = new StreamReader(file))
            {
                using (XmlReader reader = XmlReader.Create(sr))
                {
                    MRen ren;
                    while (reader.ReadToFollowing("Ren"))
                    {
                        ren = new MRen();
                        if (!ren.FromXml(reader))
                        {
                            continue;
                        }
                        _UserModel.DBA.SaveVcs(ren);
                        LsRule.Items.Add(ren);
                    }
                }

                sr.Close();
            }
        }

        private void MiExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "重命名模板文件|*.arxml";
            if (DialogResult.OK != fd.ShowDialog(this))
            {
                return;
            }
            string file = fd.FileName;
            if (string.IsNullOrEmpty(file))
            {
                return;
            }

            using (StreamWriter sw = new StreamWriter(file, false))
            {
                using (XmlWriter writer = XmlWriter.Create(sw))
                {
                    writer.WriteStartElement("Amon");
                    writer.WriteElementString("App", "ARen");
                    writer.WriteElementString("Ver", "1");
                    writer.WriteStartElement("Rens");
                    foreach (MRen ren in _UserModel.DBA.ListRen())
                    {
                        ren.ToXml(writer);
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.Flush();
                }

                sw.Close();
            }
        }

        private void MiSortUp_Click(object sender, EventArgs e)
        {
            MRen currRen = LsRule.SelectedItem as MRen;
            if (currRen == null)
            {
                return;
            }
            int currIdx = LsRule.SelectedIndex;
            if (currIdx < 1)
            {
                return;
            }

            int prevIdx = currIdx - 1;
            MRen prevRen = LsRule.Items[prevIdx] as MRen;
            if (prevRen == null)
            {
                return;
            }

            currRen.Order = prevIdx;
            _UserModel.DBA.SaveVcs(currRen);
            prevRen.Order = currIdx;
            _UserModel.DBA.SaveVcs(prevRen);

            LsRule.Items[prevIdx] = currRen;
            LsRule.Items[currIdx] = prevRen;

            LsRule.SelectedItem = currRen;
        }

        private void MiSortDown_Click(object sender, EventArgs e)
        {
            MRen currRen = LsRule.SelectedItem as MRen;
            if (currRen == null)
            {
                return;
            }
            int currIdx = LsRule.SelectedIndex;
            if (currIdx > LsRule.Items.Count - 2)
            {
                return;
            }

            int nextIdx = currIdx + 1;
            MRen nextRen = LsRule.Items[nextIdx] as MRen;
            if (nextRen == null)
            {
                return;
            }

            currRen.Order = nextIdx;
            _UserModel.DBA.SaveVcs(currRen);
            nextRen.Order = currIdx;
            _UserModel.DBA.SaveVcs(nextRen);

            LsRule.Items[nextIdx] = currRen;
            LsRule.Items[currIdx] = nextRen;

            LsRule.SelectedItem = currRen;
        }

        private void MiDelete_Click(object sender, EventArgs e)
        {
            MRen ren = LsRule.SelectedItem as MRen;
            if (ren == null)
            {
                Main.ShowAlert("请选择您要删除的模板！");
                return;
            }

            if (DialogResult.Yes != Main.ShowConfirm(string.Format("确认要删除模板 {0} 吗？", ren.Name)))
            {
                return;
            }

            _UserModel.DBA.DeleteVcs(ren);
            LsRule.Items.Remove(ren);
        }
        #endregion

        #region 私有函数
        private bool DoReview()
        {
            ShowEcho("");

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
                PbSelect.Focus();
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
                dst = _Renamer.Update(FdBrowser.SelectedPath, src);
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
            ShowEcho("");

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
                        tmp2 = Repeat(src, tmp);
                    }
                }
                File.Move(tmp1, tmp2);
                File.SetAttributes(tmp2, att);
            }

            Directory.Delete(dst);
            ShowEcho("恭喜，全部重命名成功！");
        }

        private string Repeat(string path, string file)
        {
            string pre = Path.GetFileNameWithoutExtension(file);
            string ext = Path.GetExtension(file);
            int i = 1;
            do
            {
                file = string.Format("{0} ({1}){2}", pre, i++, ext);
            } while (File.Exists(Path.Combine(path, file)));


            return file;
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