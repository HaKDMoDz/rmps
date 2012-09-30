using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;
using Me.Amon.Apwd.Const;
using Me.Amon.Apwd.Effect;
using Me.Amon.Apwd.Model;
using Me.Amon.Apwd.Utils;
using Me.Amon.Apwd.Views.Bean;
using Me.Amon.Apwd.Win.Pro;
using Me.Amon.Apwd.Win.Wiz;

namespace Me.Amon.Apwd.Win
{
    public partial class Awin : UserControl, IView
    {
        private string _Token = "";
        private TreeViewItem _CatRoot;
        private UserModel _UserModel;
        private SafeModel _SafeModel;
        private IAttEdit _AttEdit;
        private Hotkey _HotKeys;
        private MainPage _Main;
        private FlipProjection _Effect;

        #region 构造函数
        public Awin()
            : this(null)
        {
        }

        public Awin(UserModel userMdl)
        {
            _UserModel = userMdl;
            _SafeModel = new SafeModel(_UserModel);

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public string ViewName
        {
            get
            {
                return "Mpwd";
            }
        }

        public bool InitView(MainPage main)
        {
            if (_SafeModel == null || !CharUtil.isValidateCode(_SafeModel.Code))
            {
                return false;
            }

            _Main = main;
            _Main.Show(this);
            return true;
        }

        public void InitData()
        {
            //Border border = new Border();
            //border.BorderBrush = new SolidColorBrush();

            //NewKey.BorderThickness = new Thickness(0);
            //CatTree.BorderBrush = Silver;
            //AttGrid.BorderBrush = null;

            _CatRoot = new TreeViewItem();
            _CatRoot.Header = new CatItem { Cat = new Cat { Id = "130f0000magicpwd", Text = "魔方密码", Icon = "130f0000magicpwd" } };
            CatTree.Items.Add(_CatRoot);

            Post("&o=cat", new UploadStringCompletedEventHandler(CatDownloadStringCompleted));

            ChangeView(_UserModel.View);
            _AttEdit.ShowData(null);

            Hotkey.RegisterHandler(Hotkey.ATT_COPY, new HotkeyEnventHandler(AttCopy));
            Hotkey.RegisterHandler(Hotkey.ATT_SAVE, new HotkeyEnventHandler(AttSave));
            ChangeHkey();

            FindKeyTxt.Focus();
        }
        #endregion

        #region 页面初始化
        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            ModifierKeys mod = Keyboard.Modifiers;
            if (mod == ModifierKeys.None)
            {
                return;
            }
            HotkeyEnventHandler handler = _HotKeys.GetHotKey(mod, e.Key);
            if (handler != null)
            {
                handler.Invoke();
            }
        }
        #endregion

        #region 目录
        /// <summary>
        /// 请求回调事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatDownloadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            List<Cat> catList = new List<Cat>();

            string xml = e.Result;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<error>") > 0)
                {
                    BeanUtil.HideLoading();
                    reader.ReadToFollowing("error");
                    BeanUtil.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                if (reader.ReadToFollowing("cats"))
                {
                    while (reader.ReadToFollowing("Id"))
                    {
                        //创建一个新的Item对象，后面把数据保存到Item对象中
                        Cat cat = new Cat();
                        cat.Id = reader.ReadElementContentAsString();
                        cat.Parent = reader.ReadElementContentAsString();
                        cat.Icon = reader.ReadElementContentAsString();
                        cat.Text = reader.ReadElementContentAsString();
                        cat.Tips = reader.ReadElementContentAsString();
                        cat.Value = reader.ReadElementContentAsString();
                        catList.Add(cat);
                    }
                }
            }

            InitCat(_CatRoot, "0", catList);

            BeanUtil.HideLoading();
        }

        /// <summary>
        /// 添加节点到目录
        /// </summary>
        /// <param name="pKey"></param>
        /// <param name="root"></param>
        private void InitCat(TreeViewItem root, string pKey, List<Cat> list)
        {
            foreach (Cat cat in list)
            {
                if (cat.Parent != pKey)
                {
                    continue;
                }

                TreeViewItem node = new TreeViewItem();
                node.Header = new CatItem { Cat = cat };

                //此样式将会添加的所有叶子结点上
                //node.ItemContainerStyle = this.Resources["RedItemStyle"] as Style;

                root.Items.Add(node);
                InitCat(node, cat.Id, list);
            }
        }

        /// <summary>
        /// 目录选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem node = (TreeViewItem)e.NewValue;
            if (node == null)
            {
                CatEditTab.Visibility = Visibility.Collapsed;
                return;
            }

            CatEditTab.Visibility = Visibility.Visible;
            CatItem item = (CatItem)node.Header;
            Cat cat = item.Cat;

            Post("&o=key&m=0&d=" + cat.Id, new UploadStringCompletedEventHandler(KeyDownloadStringCompleted));

            if (_LastGrid != null && _LastGrid != KeyList)
            {
                _Effect.FlipTo(_LastGrid, KeyList, _LastGrid == KeyMajor ? FlipDirection.Left : FlipDirection.Right);
                _LastGrid = KeyList;
                _Effect.Begin();
            }
        }

        /// <summary>
        /// 新增目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatAppendBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 更新目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatUpdateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatRemoveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatMoveDownBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatMoveUpBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region 列表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyDownloadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            InitKey(e.Result);
        }

        public void InitKey(string xml)
        {
            KeyList.Items.Clear();

            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<error>") > 0)
                {
                    BeanUtil.HideLoading();
                    reader.ReadToFollowing("error");
                    BeanUtil.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                if (reader.ReadToFollowing("keys"))
                {
                    while (reader.ReadToFollowing("Id"))
                    {
                        Key key = new Key();
                        key.FromXml(reader);
                        KeyList.Items.Add(new KeyItem() { Key = key });
                    }
                }
            }

            BeanUtil.HideLoading();
        }

        /// <summary>
        /// 口令选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count < 1)
            {
                KeyEditTab.Visibility = Visibility.Collapsed;
                return;
            }

            KeyEditTab.Visibility = Visibility.Visible;
            KeyItem item = (KeyItem)e.AddedItems[0];
            _SafeModel.Key = item.Key;
            _AttEdit.ShowData(_SafeModel.Key);
        }

        /// <summary>
        /// 添加口令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyLabelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_Effect == null)
            {
                _Effect = new FlipProjection();
                _LastGrid = KeyList;
            }
            if (_LastGrid != KeyLabel)
            {
                _Effect.FlipTo(_LastGrid, KeyLabel, _LastGrid == KeyList ? FlipDirection.Left : FlipDirection.Right);
                _LastGrid = KeyLabel;
            }
            else
            {
                _Effect.FlipTo(KeyLabel, KeyList, FlipDirection.Right);
                _LastGrid = KeyList;
            }
            _Effect.Begin();
        }

        /// <summary>
        /// 更新口令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyMajorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_Effect == null)
            {
                _Effect = new FlipProjection();
                _LastGrid = KeyList;
            }
            if (_LastGrid != KeyMajor)
            {
                _Effect.FlipTo(_LastGrid, KeyMajor, _LastGrid == KeyList ? FlipDirection.Right : FlipDirection.Left);
                _LastGrid = KeyMajor;
            }
            else
            {
                _Effect.FlipTo(KeyMajor, KeyList, FlipDirection.Left);
                _LastGrid = KeyList;
            }
            _Effect.Begin();
        }
        private ListBox _LastGrid;

        /// <summary>
        /// 删除口令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Post("&o=cat", new UploadStringCompletedEventHandler(KeyUpdateUploadStringCompleted));
        }

        /// <summary>
        /// 删除口令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            KeyRemove();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyUpdateUploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            List<Cat> catList = new List<Cat>();

            string xml = e.Result;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<error>") > 0)
                {
                    BeanUtil.HideLoading();
                    reader.ReadToFollowing("error");
                    BeanUtil.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                if (reader.ReadToFollowing("cats"))
                {
                    while (reader.ReadToFollowing("Id"))
                    {
                        //创建一个新的Item对象，后面把数据保存到Item对象中
                        Cat cat = new Cat();
                        cat.Id = reader.ReadElementContentAsString();
                        cat.Parent = reader.ReadElementContentAsString();
                        cat.Icon = reader.ReadElementContentAsString();
                        cat.Text = reader.ReadElementContentAsString();
                        cat.Tips = reader.ReadElementContentAsString();
                        cat.Value = reader.ReadElementContentAsString();
                        catList.Add(cat);
                    }
                }
            }

            BeanUtil.HideLoading();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttAppendBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttUpdateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttRemoveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttMoveUpBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttMoveDownBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region 编辑
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KvpCopyBtn_Click(object sender, RoutedEventArgs e)
        {
            AttCopy();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KvpSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            AttSave();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KvpDropBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region 键盘事件
        /// <summary>
        /// 
        /// </summary>
        public void KeyAppend()
        {
            if (_SafeModel.Key != null && _SafeModel.Key.Modified)
            {
                BeanUtil.ShowAlert("请保存您已修改的数据！");
            }
            _AttEdit.Append();
        }

        /// <summary>
        /// 
        /// </summary>
        public void KeyUpdate()
        {
            if (_SafeModel.Key == null)
            {
                return;
            }

            if (!_SafeModel.Key.IsUpdate)
            {
                TreeViewItem node = (TreeViewItem)CatTree.SelectedValue;
                if (node == null)
                {
                    BeanUtil.ShowAlert("请选择目录！");
                    CatTree.Focus();
                    return;
                }

                CatItem item = (CatItem)node.Header;
                if (item == null)
                {
                    BeanUtil.ShowAlert("请选择目录！");
                    CatTree.Focus();
                    return;
                }
                _SafeModel.Key.CatId = item.Cat.Id;
            }

            _AttEdit.Update();
        }

        /// <summary>
        /// 
        /// </summary>
        public void KeyRemove()
        {
            Key key = KeyList.SelectedItem as Key;
            if (key == null)
            {
                return;
            }
            _AttEdit.Delete();
        }

        /// <summary>
        /// 
        /// </summary>
        public void AttCopy()
        {
            _AttEdit.CopyAtt();
        }

        /// <summary>
        /// 
        /// </summary>
        public void AttSave()
        {
            _AttEdit.SaveAtt();
        }

        /// <summary>
        /// 
        /// </summary>
        public void AttDrop()
        {
            _AttEdit.DropAtt();
        }
        #endregion

        #region 按钮事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindKey_Click(object sender, RoutedEventArgs e)
        {
            string text = FindKeyTxt.Text;
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            Post("&o=key&m=1&d=" + text.Trim(), new UploadStringCompletedEventHandler(KeyDownloadStringCompleted));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindKeyTxt_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter)
            {
                return;
            }
            string text = FindKeyTxt.Text;
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            Post("&o=key&m=1&d=" + text.Trim(), new UploadStringCompletedEventHandler(KeyDownloadStringCompleted));
        }

        /// <summary>
        /// 快捷键设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HotKey_Click(object sender, RoutedEventArgs e)
        {
            Akey mkey = new Akey(_UserModel);
            mkey.Show();
            Post("&o=hkey&m=1&d=");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewPtn_Click(object sender, RoutedEventArgs e)
        {
            _AttEdit.HideView(LayoutRoot);
            ChangeView(1 - _UserModel.View);
            _AttEdit.ShowData(_SafeModel.Key);
            Post("&o=view&m=1&d=" + _UserModel.View);
        }

        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewKey_Click(object sender, RoutedEventArgs e)
        {
            KeyAppend();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveKey_Click(object sender, RoutedEventArgs e)
        {
            KeyUpdate();
        }

        private void ChangeHkey()
        {
            _HotKeys = Hotkey.GetInstance("chrome");
        }

        private void ChangeView(int viewModel)
        {
            if (viewModel == 1)
            {
                _AttEdit = new Apro(this, _SafeModel);
                AttEditTab.Visibility = System.Windows.Visibility.Visible;
                KvpEditTab.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                _AttEdit = new Awiz(this, _SafeModel);
                AttEditTab.Visibility = System.Windows.Visibility.Collapsed;
                KvpEditTab.Visibility = System.Windows.Visibility.Collapsed;
            }
            _AttEdit.InitView(LayoutRoot);

            _UserModel.View = viewModel;
        }
        #endregion

        #region 数据交互
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Post(string data)
        {
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.UploadStringAsync(new Uri(EnvConst.SERVER_PATH), "POST", "c=" + _UserModel.Code + "&t=" + _Token + data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="handler"></param>
        public void Post(string data, UploadStringCompletedEventHandler handler)
        {
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.UploadStringCompleted += handler;
            client.UploadStringAsync(new Uri(EnvConst.SERVER_PATH), "POST", "c=" + _UserModel.Code + "&t=" + _Token + data);

            BeanUtil.ShowLoading();
        }
        #endregion

        private void CatTree_Drop(object sender, DragEventArgs e)
        {
            IDataObject dataObject = e.Data as IDataObject;
            object obj = dataObject.GetData(typeof(KeyItem));
        }
    }
}
