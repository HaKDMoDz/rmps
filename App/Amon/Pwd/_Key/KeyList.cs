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
        #endregion

        public void ListKeys(string catId)
        {
            DoInitKey(_DataModel.ListKey(catId));
        }

        public void FindKeys(string meta)
        {
            meta = Regex.Replace(meta, "[+＋\\s]+", " ");
            if (string.IsNullOrEmpty(meta))
            {
                Main.ShowAlert("您输入的查询条件无效！");
                return;
            }

            DoInitKey(_DataModel.FindKey(meta));
            //TvCatTree.SelectedNode = null;
        }

        public void RemoveSelected()
        {
            LbKey.Items.RemoveAt(LbKey.SelectedIndex);
            SelectedKey = null;
        }

        public void ListGtdExpired()
        {
            IList<Gtd.M.MGtd> gtds = _DataModel.FindGtdExpired();
            List<Key> keys = new List<Key>(gtds.Count);
            foreach (Gtd.M.MGtd gtd in gtds)
            {
                keys.Add(_DataModel.ReadKey(gtd.RefId));
            }
            DoInitKey(keys);
        }

        public void ListGtd(DateTime time, int seconds)
        {
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

            if (!CharUtil.IsValidateHash(key.Id))
            {
                Main.ShowAlert("系统异常，请稍后重试！");
                return;
            }

            if (!_WPwd.CanChange(key))
            {
                LbKey.SelectedItem = SelectedKey;
                return;
            }

            SelectedKey = key;
            _WPwd.ShowKey();
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
                //if (_SafeModel.Modified && DialogResult.Yes != Main.ShowConfirm("您当前的数据尚未保存，要丢弃吗？"))
                //{
                //    return;
                //}

                //_SafeModel.Modified = false;
                LbKey.SelectedIndex = idx;
            }

            if (PopupMenu != null)
            {
                PopupMenu.Show(LbKey, e.Location);
            }
        }
        #endregion

        private void InitKey()
        {
        }

        private void DoInitKey(IList<Key> keys)
        {
            LbKey.Items.Clear();

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

        public void ListKeysWithGtd(int status)
        {
        }

        public void ListKeysWithGtd(DateTime time, int seconds)
        {
        }
    }
}
