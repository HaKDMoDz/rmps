using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Gtd;
using Me.Amon.Properties;
using Me.Amon.Pwd.M;
using Me.Amon.Pwd.V;
using Me.Amon.Util;

namespace Me.Amon.Pwd._Key
{
    public partial class KeyList : UserControl, IKeyList
    {
        #region 全局变量
        private WPwd _WPwd;
        private DataModel _DataModel;
        private ViewModel _ViewModel;

        #region 上次操作
        private const int LAST_OPT_LIST = 0;
        private const int LAST_OPT_FIND = 1;
        private const int LAST_OPT_TASK = 10;
        private const int LAST_OPT_TASK_EXP = 11;
        private const int LAST_OPT_TASK_FIX = 12;
        private int _LastOpt;
        private string _LastMeta;
        private int _LastData;
        #endregion
        #endregion

        #region 构造函数
        public KeyList()
        {
            InitializeComponent();
        }

        public KeyList(WPwd wPwd, DataModel dataModel, ViewModel viewModel)
        {
            _WPwd = wPwd;
            _DataModel = dataModel;
            _ViewModel = viewModel;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public Control Control { get { return this; } }

        public ContextMenuStrip PopupMenu { get; set; }

        public IAttView AttView { get; set; }

        public Key SelectedKey { get; set; }

        public void Clear()
        {
            LbKey.Items.Clear();
        }

        public void ListKeys(string catId)
        {
            LbKey.Items.Clear();

            DoInitKey(_DataModel.ListKey(catId));

            _LastOpt = LAST_OPT_LIST;
            _LastMeta = catId;
        }

        public void ListKeysByLabel(int label)
        {
        }

        public void ListKeysByMajor(int major)
        {
        }

        public void ListKeysByGtd()
        {
            DateTime now = DateTime.Now;

            LbKey.Items.Clear();

            IList<Gtd.M.MGtd> gtds = _DataModel.ListGtdWithRef();
            List<Key> keys = new List<Key>(gtds.Count);
            foreach (Gtd.M.MGtd gtd in gtds)
            {
                gtd.Test(now, 43200);// 60 * 60 * 12
                if (gtd.Status > CGtd.STATUS_NORMAL)
                {
                    keys.Add(_DataModel.ReadKey(gtd.RefId));
                }
            }
            DoInitKey(keys);

            _LastOpt = LAST_OPT_TASK;
        }

        public void ListKeysByGtd(int status)
        {
            DateTime now = DateTime.Now;

            LbKey.Items.Clear();

            IList<Gtd.M.MGtd> gtds = _DataModel.ListGtdWithRef();
            List<Key> keys = new List<Key>(gtds.Count);
            foreach (Gtd.M.MGtd gtd in gtds)
            {
                gtd.Test(now, 0);
                if (gtd.Status == status)
                {
                    keys.Add(_DataModel.ReadKey(gtd.RefId));
                }
            }
            DoInitKey(keys);

            _LastOpt = LAST_OPT_TASK_EXP;
            _LastData = status;
        }

        public void ListKeysByGtd(DateTime time, int seconds)
        {
            LbKey.Items.Clear();

            IList<Gtd.M.MGtd> gtds = _DataModel.ListGtdWithRef();
            List<Key> keys = new List<Key>(gtds.Count);
            foreach (Gtd.M.MGtd gtd in gtds)
            {
                gtd.Test(time, seconds);
                if (gtd.Status == CGtd.STATUS_ONTIME)
                {
                    keys.Add(_DataModel.ReadKey(gtd.RefId));
                }
            }
            DoInitKey(keys);

            _LastOpt = LAST_OPT_TASK_FIX;
            _LastData = seconds;
        }

        public void FindKeys(string meta)
        {
            LbKey.Items.Clear();
            if (string.IsNullOrEmpty(meta))
            {
                return;
            }

            meta = Regex.Replace(meta, "[+＋\\s]+", " ");
            if (string.IsNullOrEmpty(meta))
            {
                Main.ShowAlert("您输入的查询条件无效！");
                return;
            }

            DoInitKey(_DataModel.FindKey(meta));

            _LastOpt = LAST_OPT_FIND;
            _LastMeta = meta;
        }

        public void LastKeys()
        {
            switch (_LastOpt)
            {
                case LAST_OPT_LIST:
                    ListKeys(_LastMeta);
                    break;
                case LAST_OPT_FIND:
                    FindKeys(_LastMeta);
                    break;
                case LAST_OPT_TASK:
                    ListKeysByGtd();
                    break;
                case LAST_OPT_TASK_EXP:
                    ListKeysByGtd(_LastData);
                    break;
                case LAST_OPT_TASK_FIX:
                    ListKeysByGtd(DateTime.Now, _LastData);
                    break;
            }
            LbKey.SelectedItem = SelectedKey;
        }

        public void RemoveSelected()
        {
            if (LbKey.SelectedIndex > -1)
            {
                LbKey.Items.RemoveAt(LbKey.SelectedIndex);
                SelectedKey = null;
            }
        }

        public void UpdateSelected(Key key)
        {
            LbKey.Items[LbKey.SelectedIndex] = key;
            //SelectedKey = key;
            this.UpdateBounds();
        }

        public void ChangeKeyLabel(int label)
        {
            if (SelectedKey == null || label < 0 || label > 9)
            {
                return;
            }

            SelectedKey.Label = label;
            SelectedKey.LabelIcon = _ViewModel.GetImage(CPwd.KEY_LABEL + label);
            _DataModel.SaveVcs(SelectedKey);

            LbKey.Refresh();
        }

        public void ChangeKeyMajor(int major)
        {
            if (SelectedKey == null || major < -2 || major > 2)
            {
                return;
            }

            SelectedKey.Major = major;
            SelectedKey.MajorIcon = _ViewModel.GetImage(CPwd.KEY_MAJOR + (major + 2));
            _DataModel.SaveVcs(SelectedKey);

            LbKey.Refresh();
        }
        #endregion

        #region 事件处理
        private void LbKey_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index <= -1 || e.Index >= LbKey.Items.Count)
            {
                return;
            }
            Key key = LbKey.Items[e.Index] as Key;
            if (key == null)
            {
                return;
            }

            e.Graphics.DrawImage(key.Icon, e.Bounds.X + 3, e.Bounds.Y + 3, 24, 24);

            //最后把要显示的文字画在背景图片上
            int y = e.Bounds.Y + 2;
            e.Graphics.DrawString(key.Title, LbKey.Font, Brushes.Black, e.Bounds.X + 30, y);

            y = e.Bounds.Y + e.Bounds.Height;
            e.Graphics.DrawString(key.AccessTime, LbKey.Font, Brushes.Gray, e.Bounds.X + 30, y - 14);

            int x = e.Bounds.X + e.Bounds.Width;
            y -= 16;
            if (key.GtdIcon != null)
            {
                e.Graphics.DrawImage(key.GtdIcon, x - 48, y);
            }
            if (key.LabelIcon != null)
            {
                e.Graphics.DrawImage(key.LabelIcon, x - 32, y);
            }
            if (key.MajorIcon != null)
            {
                e.Graphics.DrawImage(key.MajorIcon, x - 16, y);
            }
        }

        private void LbKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            Main.LogInfo("LbKeyList_SelectedIndexChanged");
            Key key = LbKey.SelectedItem as Key;
            if (key == null || SelectedKey == key)
            {
                return;
            }
            SelectedKey = key;

            if (!CharUtil.IsValidateHash(key.Id))
            {
                Main.ShowAlert("系统异常，请稍后重试！");
                return;
            }

            if (!_WPwd.CanChange())
            {
                LbKey.SelectedItem = SelectedKey;
                return;
            }

            _WPwd.ShowKey(key);
        }

        private void LbKey_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void LbKey_MouseUp(object sender, MouseEventArgs e)
        {
            Main.LogInfo("LbKeyList_MouseUp");
            if (e.Button != MouseButtons.Right)
            {
                return;
            }
            int idx = LbKey.IndexFromPoint(e.Location);
            if (idx >= LbKey.Items.Count)
            {
                return;
            }
            if (LbKey.SelectedIndex != idx)
            {
                if (!_WPwd.CanChange())
                {
                    return;
                }

                LbKey.SelectedIndex = idx;
            }

            if (PopupMenu != null)
            {
                PopupMenu.Show(LbKey, e.Location);
            }
        }
        #endregion

        #region 私有函数
        private void InitKey()
        {
        }

        private void DoInitKey(IList<Key> keys)
        {
            foreach (Key key in keys)
            {
                LbKey.Items.Add(key);

                if (CharUtil.IsValidateHash(key.IcoName))
                {
                    if (CharUtil.IsValidateHash(key.IcoPath))
                    {
                        key.Icon = BeanUtil.ReadImage(Path.Combine(_DataModel.KeyDir, key.IcoPath, key.IcoName + CApp.IMG_KEY_LIST_EXT), BeanUtil.NaN24);
                    }
                    else
                    {
                        key.Icon = BeanUtil.ReadImage(Path.Combine(_DataModel.KeyDir, key.IcoName + CApp.IMG_KEY_LIST_EXT), BeanUtil.NaN24);
                    }
                }
                else
                {
                    key.Icon = BeanUtil.NaN24;
                }

                key.LabelIcon = _ViewModel.GetImage(CPwd.KEY_LABEL + key.Label);
                key.MajorIcon = _ViewModel.GetImage(CPwd.KEY_MAJOR + (key.Major + 2));
                key.GtdIcon = CharUtil.IsValidateHash(key.GtdId) ? Resources.Hint : BeanUtil.NaN16;
            }
        }
        #endregion
    }
}
