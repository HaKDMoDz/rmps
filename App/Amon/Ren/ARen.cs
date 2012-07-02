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
        private Renamer _Renamer;
        private List<TRen> _FileList;

        #region 构造函数
        public ARen()
        {
            InitializeComponent();
        }

        public ARen(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }
        #endregion

        #region 接口实现
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

        #region 公共函数
        public void ShowEcho(string msg)
        {
            LbEcho.Text = msg;
            TpTips.SetToolTip(LbEcho, msg);
        }
        #endregion

        #region 事件处理
        private void ARen_Load(object sender, EventArgs e)
        {
            GvName.AutoGenerateColumns = false;
            _FileList = new List<TRen>();

            _Renamer = new Renamer();

            LtInfo.Text = "一些特殊字符（:|*?\"<>\\/）在命名表达式中的含义：";
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
            dt.Rows.Add("|<ab:c:def>", "单词的运算方式：表示循环计算ab、c、def等单词");
            dt.Rows.Add("*<a:b>", "将文件名中的a替换为b");
            dt.Rows.Add("?<a:b>", "将扩展名中的a替换为b");
            GvInfo.DataSource = dt;

            foreach (MRen ren in _UserModel.DBA.ListRen())
            {
                LsRule.Items.Add(ren);
            }
        }

        private void PbSelect_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != FdBrowser.ShowDialog(this))
            {
                return;
            }

            int index = 0;
            foreach (string file in Directory.GetFiles(FdBrowser.SelectedPath))
            {
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
            MiSaveas.Enabled = !string.IsNullOrEmpty(TbRule.Text);
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
            if (DialogResult.OK != Main.ShowOpenFileDialog(this, "重命名模板文件|*.arxml", "", false))
            {
                return;
            }
            string file = Main.OpenFileDialog.FileName;
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
            if (DialogResult.OK != Main.ShowSaveFileDialog(this, "重命名模板文件|*.arxml", ""))
            {
                return;
            }
            string file = Main.SaveFileDialog.FileName;
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

        private void GvName_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void GvName_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                object obj = e.Data.GetData(DataFormats.FileDrop);
                if (obj == null)
                {
                    return;
                }
                string[] arr = obj as string[];

                AddFiles(arr);
            }
            catch (Exception ex)
            {
                Main.ShowError(ex);
            }
        }

        private void GvName_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }
            int idx = e.RowIndex;
            if (idx < 0)
            {
                return;
            }

            GvName.Rows[idx].Selected = true;
            CmFile.Show(MousePosition);
        }

        private void BgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void BgWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void BgWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }

        private void MiAppend_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != Main.ShowOpenFileDialog(this, EApp.FILE_OPEN_ALL, "", true))
            {
                return;
            }
            AddFiles(Main.OpenFileDialog.FileNames);
        }

        private void MiRemove_Click(object sender, EventArgs e)
        {
            if (GvName.SelectedRows.Count < 1)
            {
                return;
            }
            DataGridViewRow row = GvName.SelectedRows[0];
            GvName.Rows.RemoveAt(row.Index);
        }

        private void MiMoveUp_Click(object sender, EventArgs e)
        {
            if (GvName.SelectedRows.Count < 1)
            {
                return;
            }
            DataGridViewRow row = GvName.SelectedRows[0];
            //获取当前行
            int idx = row.Index;

            //如果当前行不是第一行
            if (idx < 1)
            {
                return;
            }

            //获取当前行的上一行的索引
            int tmp = idx - 1;

            //当前行绑定的数据对象
            TRen currRen = _FileList[idx];
            //下一行绑定的数据对象
            TRen nextRen = _FileList[tmp];

            //将数据对象位置互换
            _FileList[idx] = nextRen;
            _FileList[tmp] = currRen;

            GvName.Rows.RemoveAt(idx);
            GvName.Rows.Insert(tmp, row);
            GvName.Rows[tmp].Selected = true;

            GvName.FirstDisplayedScrollingRowIndex = tmp;
        }

        private void MiMoveDown_Click(object sender, EventArgs e)
        {
            if (GvName.SelectedRows.Count < 1)
            {
                return;
            }
            DataGridViewRow row = GvName.SelectedRows[0];
            //获取当前行
            int idx = row.Index;

            //如果当前行不是第一行
            if (idx > _FileList.Count - 2)
            {
                return;
            }

            //获取当前行的上一行的索引
            int tmp = idx + 1;

            //当前行绑定的数据对象
            TRen currRen = _FileList[idx];
            //下一行绑定的数据对象
            TRen nextRen = _FileList[tmp];

            //将数据对象位置互换
            _FileList[idx] = nextRen;
            _FileList[tmp] = currRen;

            GvName.Rows.RemoveAt(idx);
            GvName.Rows.Insert(tmp, row);
            GvName.Rows[tmp].Selected = true;

            GvName.FirstDisplayedScrollingRowIndex = tmp;
        }

        private void MiClear_Click(object sender, EventArgs e)
        {
            GvName.Rows.Clear();
            _FileList.Clear();
        }
        #endregion

        #region 私有函数
        private void AddFiles(string[] files)
        {
            if (files == null)
            {
                return;
            }

            int idx;
            foreach (string file in files)
            {
                if (!File.Exists(file))
                {
                    continue;
                }

                if (GetDup(file) != null)
                {
                    continue;
                }

                idx = file.LastIndexOf(Path.DirectorySeparatorChar);
                if (idx < 0)
                {
                    continue;
                }

                TRen ren = new TRen { File = file, Path = file.Substring(0, idx), SrcName = Path.GetFileName(file) };
                _FileList.Add(ren);
                GvName.Rows.Add(ren.SrcName, "");
            }
        }

        private TRen GetDup(string file)
        {
            foreach (TRen item in _FileList)
            {
                if (item.File == file)
                {
                    return item;
                }
            }
            return null;
        }

        private FileAttributes GetAtt(string file)
        {
            //if (CkArchive.Checked)
            //{
            //    return File.GetAttributes(file);
            //}

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
            return att;
        }

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

            if (_FileList.Count < 1)
            {
                Main.ShowAlert("请选择您要重命名的对象！");
                PbSelect.Focus();
                return false;
            }

            ShowEcho("正在计算重命名……");

            if (!_Renamer.Init(rule))
            {
                ShowEcho(_Renamer.Error);
                return false;
            }

            Dictionary<string, int> dic = new Dictionary<string, int>();
            int idx = 0;
            int nc = 0;//无效命名数量
            int ec = 0;//重复命名数量
            foreach (TRen ren in _FileList)
            {
                ren.DstName = _Renamer.Update(ren.File);
                if (string.IsNullOrEmpty(ren.DstName))
                {
                    //;
                    GvName.Rows[idx++].DefaultCellStyle.BackColor = Color.Blue;
                    nc += 1;
                    continue;
                }
                if (dic.ContainsKey(ren.DstName))
                {
                    GvName.Rows[idx].Cells[""].Value = ren;
                    GvName.Rows[idx++].DefaultCellStyle.BackColor = Color.Red;
                    ec += 1;
                    continue;
                }

                dic[ren.DstName] = idx;
                GvName.Rows[idx].Cells[1].Value = ren.DstName;
                GvName.Rows[idx++].DefaultCellStyle.BackColor = Color.White;
            }
            if (nc > 0 || ec > 0)
            {
                ShowEcho(string.Format("存在命名冲突，请调整命名规则后重试！", nc, ec));
                return false;
            }
            ShowEcho("您可以进行重命名了……");
            return true;
        }

        private void DoRename()
        {
            ShowEcho("正在进行重命名……");
            string tmp = string.Format(ERen.TMP_PREFIX, DateTime.Now.ToFileTimeUtc());

            // 原有文件名更改为临时文件名
            foreach (TRen ren in _FileList)
            {
                if (!File.Exists(ren.File))
                {
                    ren.Temp = null;
                    continue;
                }
                if (ren.SrcName == ren.DstName)
                {
                    ren.Temp = null;
                    continue;
                }

                ren.Temp = Path.Combine(ren.Path, tmp + ren.SrcName);
                ren.FileAtt = File.GetAttributes(ren.Path);
                File.Move(ren.File, ren.Temp);
            }

            FileAttributes att = GetAtt("");

            // 临时文件名更改为目标文件名
            foreach (TRen ren in _FileList)
            {
                if (string.IsNullOrEmpty(ren.Temp))
                {
                    continue;
                }
                if (!File.Exists(ren.Temp))
                {
                    continue;
                }

                tmp = Path.Combine(ren.Path, ren.DstName);
                File.Move(ren.Temp, tmp);
                File.SetAttributes(tmp, att);
            }

            ShowEcho("恭喜，全部重命名成功！");
        }
        #endregion
    }
}