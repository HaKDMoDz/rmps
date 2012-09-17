using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Ce;
using Me.Amon.M;
using Me.Amon.Ren.M;
using Me.Amon.Uc;
using Me.Amon.Uw;

namespace Me.Amon.Ren
{
    public partial class ARen : Form, IApp
    {
        private UserModel _UserModel;
        private Renamer _Renamer;
        private List<TRen> _FileList;
        private XmlMenu<ARen> _XmlMenu;
        private string _LastRule;
        private bool _Reviewed;

        #region 构造函数
        public ARen()
        {
            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }
        #endregion

        #region 公共函数
        public int AppId
        {
            get;
            set;
        }

        public Form Form
        {
            get { return this; }
        }

        public void ShowTips(Control control, string caption)
        {
            TpTips.SetToolTip(control, caption);
        }

        public void ShowEcho(string message)
        {
            LlEcho.Text = message;
            TpTips.SetToolTip(LlEcho, message);
        }

        public void ShowEcho(string message, int delay)
        {
            LlEcho.Text = message;
        }

        public bool WillExit()
        {
            return true;
        }

        public bool SaveData()
        {
            return true;
        }

        public bool Review()
        {
            _Reviewed = false;

            string rule = TbRule.Text;
            if (string.IsNullOrEmpty(rule))
            {
                Main.ShowAlert(this, "请输入或选择命名规则！");
                if (!TbRule.ReadOnly)
                {
                    TbRule.Focus();
                }
                return false;
            }

            if (_FileList.Count < 1)
            {
                Main.ShowAlert(this, "请选择您要重命名的对象！");
                PbRule.Focus();
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
                    GvFile.Rows[idx].Cells[1].Value = "";
                    GvFile.Rows[idx++].Cells[1].Style.BackColor = Color.Blue;
                    nc += 1;
                    continue;
                }
                if (dic.ContainsKey(ren.DstName))
                {
                    GvFile.Rows[idx].Cells[1].Value = ren.DstName;
                    GvFile.Rows[idx++].Cells[1].Style.BackColor = Color.Red;
                    ec += 1;
                    continue;
                }

                dic[ren.DstName] = idx;
                GvFile.Rows[idx].Cells[1].Value = ren.DstName;
                GvFile.Rows[idx++].Cells[1].Style.BackColor = Color.White;
            }
            if (nc > 0)
            {
                ShowEcho(string.Format("无法对所有文件进行重命名，请调整命名规则后重试！", nc, ec));
                return false;
            }
            if (ec > 0)
            {
                ShowEcho(string.Format("存在命名冲突，请调整命名规则后重试！", nc, ec));
                return false;
            }

            _Reviewed = true;
            _LastRule = rule;
            ShowEcho("您可以进行重命名了……");
            return true;
        }

        public void Rename()
        {
            ShowEcho("正在进行重命名……");
            string tmp = string.Format(ERen.TMP_PREFIX, DateTime.Now.ToFileTimeUtc());

            // 原有文件名更改为临时文件名
            try
            {
                foreach (TRen ren in _FileList)
                {
                    if (!File.Exists(ren.File))
                    {
                        ren.Temp = null;
                        continue;
                    }

                    ren.FileAtt = File.GetAttributes(ren.File);
                    File.SetAttributes(ren.File, FileAttributes.Normal);

                    if (ren.SrcName == ren.DstName)
                    {
                        ren.Temp = null;
                        continue;
                    }

                    ren.Temp = Path.Combine(ren.Path, tmp + ren.SrcName);
                    File.Move(ren.File, ren.Temp);
                }
            }
            catch (Exception exp)
            {
                ShowEcho(exp.Message);
            }

            // 临时文件名更改为目标文件名
            try
            {
                int idx = 0;
                foreach (TRen ren in _FileList)
                {
                    if (string.IsNullOrEmpty(ren.Temp) || !File.Exists(ren.Temp))
                    {
                        idx += 1;
                        continue;
                    }

                    tmp = GenDup(ren);

                    File.Move(ren.Temp, tmp);
                    File.SetAttributes(tmp, GetAtt(ren.FileAtt));

                    ren.SrcName = ren.DstName;
                    ren.File = Path.Combine(ren.Path, ren.SrcName);
                    GvFile.Rows[idx++].Cells[0].Value = ren.SrcName;
                }
            }
            catch (Exception exp)
            {
                ShowEcho(exp.Message);
            }

            ShowEcho("恭喜，全部重命名成功！");
        }

        #region 命名规则
        public void ImportRule(string file)
        {
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
                        LbRule.Items.Add(ren);
                    }
                }

                sr.Close();
            }
        }

        public void ExportRule(string file)
        {
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
                    //foreach (MRen ren in _UserModel.DBA.ListRen())
                    {
                        //ren.ToXml(writer);
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.Flush();
                }

                sw.Close();
            }
        }

        public void DeleteSelectedRule()
        {
            int idx = LbRule.SelectedIndex;
            if (idx < 0 || idx >= LbRule.Items.Count)
            {
                Main.ShowAlert(this, "请选择您要删除的模板！");
                return;
            }

            MRen ren = _UserModel.GetRule(idx);
            string msg = string.Format("确认要删除模板 {0} 吗？", ren.Name);
            if (DialogResult.Yes != MessageBox.Show(this, msg, "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                return;
            }

            LbRule.Items.Remove(ren);
            _UserModel.RemoveRuleAt(idx);
        }

        public void MoveUpSelectedRule()
        {
            int currIdx = LbRule.SelectedIndex;
            if (currIdx < 1)
            {
                return;
            }

            int prevIdx = currIdx - 1;
            _UserModel.Sort(currIdx, prevIdx);

            LbRule.SelectedIndex = prevIdx;
        }

        public void MoveDownSelectedRule()
        {
            int currIdx = LbRule.SelectedIndex;
            if (currIdx > LbRule.Items.Count - 2)
            {
                return;
            }

            int nextIdx = currIdx + 1;
            _UserModel.Sort(currIdx, nextIdx);

            LbRule.SelectedIndex = nextIdx;
        }

        public void SaveRuleAs()
        {
            string rule = TbRule.Text.Trim();
            if (string.IsNullOrEmpty(rule))
            {
                return;
            }

            string name = Main.ShowInput(this, "请输入模板名称：", "");
            while (true)
            {
                if (name == null)
                {
                    return;
                }
                if (!_UserModel.RuleNameExists(name))
                {
                    break;
                }
                name = Main.ShowInput(this, "名称已存在，请重新输入：", name);
            }

            MRen ren = new MRen();
            ren.Order = LbRule.Items.Count;
            ren.Name = name;
            ren.Command = rule;

            _UserModel.AddRule(ren);
            LbRule.Items.Add(ren);

            _UserModel.SaveRules();
        }
        #endregion

        #region 文件列表
        public void AppendFile(string[] files)
        {
            if (files == null)
            {
                //ShowEcho("");
                return;
            }

            TRen ren;
            foreach (string file in files)
            {
                if (!File.Exists(file))
                {
                    continue;
                }

                if (HasDup(file))
                {
                    continue;
                }

                ren = new TRen { File = file, Path = Path.GetDirectoryName(file), SrcName = Path.GetFileName(file) };
                _FileList.Add(ren);
                GvFile.Rows.Add(ren.SrcName, "");
            }

            _Reviewed = false;
            ShowEcho("执行重命名前请记得预览一下结果哟！");
        }

        public void RemoveSelectedFile()
        {
            if (GvFile.SelectedRows.Count < 1)
            {
                return;
            }
            DataGridViewRow row = GvFile.SelectedRows[0];
            _FileList.RemoveAt(row.Index);
            GvFile.Rows.RemoveAt(row.Index);
            _Reviewed = false;
        }

        public void MoveUpSelectedFile()
        {
            if (GvFile.SelectedRows.Count < 1)
            {
                return;
            }
            DataGridViewRow row = GvFile.SelectedRows[0];
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

            GvFile.Rows.RemoveAt(idx);
            GvFile.Rows.Insert(tmp, row);
            GvFile.Rows[tmp].Selected = true;

            GvFile.FirstDisplayedScrollingRowIndex = tmp;
            _Reviewed = false;
        }

        public void MoveDownSelectedFile()
        {
            if (GvFile.SelectedRows.Count < 1)
            {
                return;
            }
            DataGridViewRow row = GvFile.SelectedRows[0];
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

            GvFile.Rows.RemoveAt(idx);
            GvFile.Rows.Insert(tmp, row);
            GvFile.Rows[tmp].Selected = true;

            GvFile.FirstDisplayedScrollingRowIndex = tmp;
            _Reviewed = false;
        }

        public void ClearAllFile()
        {
            GvFile.Rows.Clear();
            _FileList.Clear();
            _Reviewed = false;
        }
        #endregion

        /// <summary>
        /// 快捷键
        /// </summary>
        public void ShowShortCuts()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Key");
            dt.Columns.Add("Memo");
            foreach (KeyStroke<ARen> stroke in _XmlMenu.KeyStrokes)
            {
                dt.Rows.Add(stroke.Key, stroke.Memo);
            }

            HotKeys keys = new HotKeys(Me.Amon.Properties.Resources.Icon, dt);
            keys.ShowDialog(this);
        }
        #endregion

        #region 事件处理
        private void ARen_Load(object sender, EventArgs e)
        {
            _UserModel = new UserModel();
            _UserModel.Init();

            GvFile.AutoGenerateColumns = false;
            _FileList = new List<TRen>();

            _Renamer = new Renamer();

            GvInfo.AutoGenerateColumns = false;
            LlInfo.Text = "一些文件名中的禁用字符（:|*?\"<>\\/）在命名表达式中的用法：";
            DataTable dt = new DataTable();
            dt.Columns.Add("KeyCode", typeof(string));
            dt.Columns.Add("KeyInfo", typeof(string));
            dt.Rows.Add(":", "数字表达式：从数值1逐步累加");
            dt.Rows.Add(":<a,b,c,d>", "数字表达式：起始值a，步增量b，结果按定长c显示，不足时填充字符d");
            dt.Rows.Add("|", "字符表达式：大写英文字母循环累加");
            dt.Rows.Add("|<abc>", "字符表达式：表示循环计算abc等字符");
            dt.Rows.Add("|<ab:c:def>", "字符表达式：表示循环计算ab、c、def等单词");
            dt.Rows.Add("*", "文件名表达式：引用原文件名");
            dt.Rows.Add("*<ab:c>", "文件名表达式：将文件名中的ab替换为c");
            dt.Rows.Add("?", "扩展名表达式：引用原扩展名");
            dt.Rows.Add("?<ab:c>", "扩展名表达式：将扩展名中的ab替换为c");
            //dt.Rows.Add("\"", "字符表达式：对应位置的单个原有字符");
            dt.Rows.Add("<>", "区间表达式：用于限制以上特殊含义字符的取值空间");
            dt.Rows.Add("/", "正向转义字符，不能单独使用");
            dt.Rows.Add("/:", "转义：使用文件修改时间，默认格式为 yyyyMMddHHmmss");
            dt.Rows.Add("/:<yyyy-MM-dd HH.mm.ss>", "转义：使用文件修改时间，使用指定格式");
            dt.Rows.Add("/|<1,4>", "转义：字符裁剪，从第1个字符开始裁剪掉后续4个字符");
            dt.Rows.Add("/*", "转义：将文件名转换为小写");
            dt.Rows.Add("/?", "转义：将扩展名转换为小写");
            //dt.Rows.Add("/\"", "转义：将原有字符转换为小写");
            dt.Rows.Add("\\", "反向转义字符，不能单独使用");
            dt.Rows.Add("\\:", "转义：使用文件创建时间，默认时间格式为 yyyyMMddHHmmss");
            dt.Rows.Add("\\:<yyyy-MM-dd HH.mm.ss>", "转义：使用文件创建时间，使用指定格式");
            dt.Rows.Add("\\|<1,4>", "转义：字符截取，从第1个字符开始仅保留后续4个字符");
            dt.Rows.Add("\\*", "转义：将文件名转换为大写");
            dt.Rows.Add("\\?", "转义：将扩展名转换为大写");
            //dt.Rows.Add("\\\"", "转义：将原有字符转换为大写");
            GvInfo.DataSource = dt;

            foreach (MRen ren in _UserModel.LoadRules())
            {
                LbRule.Items.Add(ren);
            }

            #region 系统选单
            _XmlMenu = new XmlMenu<ARen>(this, null);
            if (_XmlMenu.Load(Path.Combine(_UserModel.DatHome, ERen.XML_MENU)))
            {
                _XmlMenu.GetStrokes("ARen", this);
                _XmlMenu.GetPopMenu("ARen", PmMenu);
                _XmlMenu.GetPopMenu("ARule", PmRule);
                _XmlMenu.GetPopMenu("AFile", PmFile);
            }
            #endregion
        }

        private void ARen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_UserModel.Modified)
            {
                _UserModel.SaveRules();
            }
        }

        private void PbMenu_Click(object sender, EventArgs e)
        {
            PmMenu.Show(PbMenu, 0, PbMenu.Height);
        }

        private void PbRule_Click(object sender, EventArgs e)
        {
            SaveRuleAs();
        }

        private void GvFile_DragEnter(object sender, DragEventArgs e)
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

        private void GvFile_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                object obj = e.Data.GetData(DataFormats.FileDrop);
                if (obj == null)
                {
                    return;
                }
                string[] arr = obj as string[];

                AppendFile(arr);
            }
            catch (Exception ex)
            {
                Main.ShowError(this, ex);
            }
        }

        private void GvFile_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
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

            GvFile.Rows[idx].Selected = true;
            PmFile.Show(MousePosition);
        }

        private void LbRule_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }

            e.DrawBackground();

            MRen ren = _UserModel.GetRule(e.Index);
            e.Graphics.DrawString(ren.Name, LbRule.Font, new SolidBrush(e.ForeColor), e.Bounds.X + 2, e.Bounds.Y + 4);
        }

        private void LbRule_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            PmRule.Show(LbRule, e.Location);
        }

        private void LbRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            MRen ren = LbRule.SelectedItem as MRen;
            if (ren == null)
            {
                return;
            }

            TbRule.Text = ren.Command;
        }

        private void BtReview_Click(object sender, EventArgs e)
        {
            Review();
        }

        private void BtRename_Click(object sender, EventArgs e)
        {
            if (_LastRule != TbRule.Text.Trim() || !_Reviewed)
            {
                if (!Review())
                {
                    return;
                }
            }
            Rename();
        }
        #endregion

        #region 私有函数
        private bool HasDup(string file)
        {
            foreach (TRen item in _FileList)
            {
                if (item.File == file)
                {
                    return true;
                }
            }
            return false;
        }

        private FileAttributes GetAtt(FileAttributes att)
        {
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

        private string GenDup(TRen ren)
        {
            string tmp = Path.Combine(ren.Path, ren.DstName);
            if (File.Exists(tmp))
            {
                string fn = Path.GetFileNameWithoutExtension(ren.DstName);
                string fe = Path.GetExtension(ren.DstName);
                int idx = 1;
                do
                {
                    ren.DstName = string.Format("{0} ({1}){2}", fn, idx++, fe);
                    tmp = Path.Combine(ren.Path, ren.DstName);
                } while (File.Exists(tmp));
            }
            return tmp;
        }
        #endregion
    }
}
