using Me.Amon.C;
using Me.Amon.Open;
using Me.Amon.Pcs.C;
using Me.Amon.Pcs.M;
using Me.Amon.Pcs.V.Task;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Me.Amon.Pcs.V
{
    public partial class PcsView : UserControl
    {
        #region 全局变量
        #region 静态常量
        /// <summary>
        /// 目录图标
        /// </summary>
        private static ImageList IlPath;
        /// <summary>
        /// 元素大图标
        /// </summary>
        private static ImageList IlMetaLarge;
        /// <summary>
        /// 元素小图标
        /// </summary>
        private static ImageList IlMetaSmall;
        #endregion

        private WPcs _WPcs;
        private UserModel _UserModel;
        private DataModel _DataModel;
        private PcsClient _PcsClient;
        private NddEngine _NddEngine;

        #region 常用节点
        private TreeNode _TnFav;
        private TreeNode _TnPub;
        private TreeNode _TnAll;
        private TreeNode _TnSns;
        private TreeNode _TnApp;
        private TreeNode _TnBin;
        #endregion

        private string _MetaPath;
        /// <summary>
        /// 当前选择路径结点
        /// </summary>
        private TreeNode _CurrentNode;
        /// <summary>
        /// 当前路径
        /// </summary>
        private AMeta _CurrentPath;
        /// <summary>
        /// 当前选择元素结点
        /// </summary>
        private ListViewItem _CurrentItem;
        /// <summary>
        /// 当选选择对象
        /// </summary>
        private AMeta _CurrentMeta;
        /// <summary>
        /// 文件操作对象
        /// </summary>
        private AMeta _OperateMeta;
        /// <summary>
        /// 文件操作方式
        /// </summary>
        private EPcs _OperateType;
        #endregion

        #region 构造函数
        public PcsView()
        {
            InitializeComponent();
        }

        public PcsView(WPcs wPcs, MPcs mPcs, PcsClient pcsClient, UserModel userModel, DataModel dataModel)
        {
            _WPcs = wPcs;
            MPcs = mPcs;
            _UserModel = userModel;
            _DataModel = dataModel;
            _PcsClient = pcsClient;

            InitializeComponent();
        }
        #endregion

        public void Init()
        {
            if (IlPath == null)
            {
                IlPath = new ImageList();
                IlPath.ColorDepth = ColorDepth.Depth32Bit;
                IlPath.ImageSize = new Size(16, 16);

                IlMetaLarge = new ImageList();
                IlMetaLarge.ColorDepth = ColorDepth.Depth32Bit;
                IlMetaLarge.ImageSize = new Size(48, 48);

                IlMetaSmall = new ImageList();
                IlMetaSmall.ColorDepth = ColorDepth.Depth32Bit;
                IlMetaSmall.ImageSize = new Size(16, 16);

                LoadIcon(Path.Combine(_UserModel.ResHome, "Meta"), IlPath);
                LoadIcon(Path.Combine(_UserModel.ResHome, "Mime"), IlMetaLarge);
            }

            TvPath.ImageList = IlPath;
            LvMeta.LargeImageList = IlMetaLarge;
            LvMeta.SmallImageList = IlMetaSmall;

            var meta = new FolderMeta();
            meta.SetMetaPath(CPcs.PATH_FAV);
            meta.SetMetaName("收藏");
            _TnFav = GenNode(meta, CPcs.ICON_FAV);
            TvPath.Nodes.Add(_TnFav);

            meta = new FolderMeta();
            meta.SetMetaPath(CPcs.PATH_LIB);
            meta.SetMetaName("公共");
            _TnPub = GenNode(meta, CPcs.ICON_LIB);
            TvPath.Nodes.Add(_TnPub);

            meta = new FolderMeta();
            meta.SetMetaPath(_PcsClient.GetPath(CPcs.PATH_LIB_DOCUMENTS));
            meta.SetMetaName("文档");
            _TnPub.Nodes.Add(GenNode(meta, CPcs.ICON_LIB_DOCUMENTS));

            meta = new FolderMeta();
            meta.SetMetaPath(_PcsClient.GetPath(CPcs.PATH_LIB_PICTURES));
            meta.SetMetaName("图片");
            _TnPub.Nodes.Add(GenNode(meta, CPcs.ICON_LIB_PICTURES));

            meta = new FolderMeta();
            meta.SetMetaPath(_PcsClient.GetPath(CPcs.PATH_LIB_AUDIOS));
            meta.SetMetaName("音乐");
            _TnPub.Nodes.Add(GenNode(meta, CPcs.ICON_LIB_AUDIOS));

            meta = new FolderMeta();
            meta.SetMetaPath(_PcsClient.GetPath(CPcs.PATH_LIB_VIDEOS));
            meta.SetMetaName("视频");
            _TnPub.Nodes.Add(GenNode(meta, CPcs.ICON_LIB_VIDEOS));

            meta = new FolderMeta();
            meta.SetMetaPath(CPcs.PATH_ALL);
            meta.SetMetaName("所有");
            _TnAll = GenNode(meta, CPcs.ICON_ALL);
            TvPath.Nodes.Add(_TnAll);

            meta = new FolderMeta();
            meta.SetMetaPath(_PcsClient.GetPath(CPcs.PATH_SNS));
            meta.SetMetaName("分享");
            _TnSns = GenNode(meta, CPcs.ICON_SNS);
            TvPath.Nodes.Add(_TnSns);

            meta = new FolderMeta();
            meta.SetMetaPath(_PcsClient.GetPath(CPcs.PATH_APP));
            meta.SetMetaName("应用");
            _TnApp = GenNode(meta, CPcs.ICON_APP);
            TvPath.Nodes.Add(_TnApp);

            meta = new FolderMeta();
            meta.SetMetaPath(_PcsClient.GetPath(CPcs.PATH_BIN));
            meta.SetMetaName("回收站");
            _TnBin = GenNode(meta, CPcs.ICON_BIN);
            TvPath.Nodes.Add(_TnBin);

            foreach (var fav in _DataModel.ListMeta(MPcs.ServerType, MPcs.UserId))
            {
                _TnFav.Nodes.Add(GenNode(fav));
            }

            _NddEngine = new NddEngine();
            _NddEngine.Init(MPcs.LocalRoot);
        }

        public MPcs MPcs { get; private set; }

        public MetaUri MetaUri { get; set; }

        public void ShowInfo()
        {
            ShowInfo(_CurrentPath);
        }

        private void ShowInfo(AMeta meta)
        {
            if (MetaUri != null && meta != null)
            {
                MetaUri.Text = _PcsClient.Name;
                MetaUri.Path = _PcsClient.Display(meta.GetMeta());
                MetaUri.Icon = _PcsClient.Icon;
            }
        }

        #region 公共函数
        public void CutMeta()
        {
            LvMeta.Items.Remove(_CurrentItem);

            _OperateMeta = _CurrentMeta;
            _OperateType = EPcs.Cut;
            _WPcs.Operation = EPcs.Cut;
        }

        public void CopyMeta()
        {
            _OperateMeta = _CurrentMeta;
            _OperateType = EPcs.Copy;
            _WPcs.Operation = EPcs.Copy;
        }

        public void PasteMeta()
        {
            if (_OperateType == EPcs.Cut)
            {
                if (_OperateMeta.GetMetaPath() != _CurrentPath.GetMeta())
                {
                    _CurrentMeta = _PcsClient.Moveto(_OperateMeta, _CurrentPath.GetMeta(), _OperateMeta.GetMetaName());
                }

                var item = GenItem(_CurrentMeta);
                LvMeta.Items.Add(item);
                item.Selected = true;

                _OperateMeta = null;
                _OperateType = EPcs.None;
                _WPcs.Operation = EPcs.None;
                return;
            }
            if (_WPcs.Operation == EPcs.Copy)
            {
                string name = _OperateMeta.GetMetaName();
                if (_OperateMeta.GetMetaPath() == _CurrentPath.GetMeta())
                {
                    name = "复件 " + name;
                }
                name = GenDupName(name);

                _CurrentMeta = _PcsClient.Copyto(_OperateMeta, _CurrentPath.GetMeta(), name);

                var item = GenItem(_CurrentMeta);
                LvMeta.Items.Add(item);
                item.Selected = true;
                return;
            }
        }

        public string CopyAs()
        {
            return "";
        }

        public void CopyMetaRef()
        {
            var metaRef = _PcsClient.CopyRef(_CurrentMeta);

            if (metaRef != null)
            {
                new MetaRef(metaRef.GetMetaRef()).ShowDialog(_WPcs);
            }
        }
        public void PasteMetaAs()
        {
            PcsView lastView = _WPcs.LastView;
            if (lastView == null)
            {
                return;
            }
            // 冗余判断
            if (lastView.MPcs == MPcs)
            {
                return;
            }

            // 获取来源引用
            string metaRef = lastView.CopyAs();

            // 复制引用

            // 移动操作时，需要删除
            if (_OperateType == EPcs.Cut)
            {
                lastView.DeleteMeta();
            }
        }

        public void PasteMetaRef()
        {
            string metaRef = "";
            while (true)
            {
                metaRef = Main.ShowInput("请输入您的引用：", metaRef);
                if (metaRef == null)
                {
                    return;
                }
                if (!string.IsNullOrWhiteSpace(metaRef))
                {
                    break;
                }
            }

            // 复制引用
            _PcsClient.Copyto(metaRef, "/", "123.txt");
        }

        public void DeleteMeta()
        {
            var list = LvMeta.SelectedItems;
            if (list.Count < 1)
            {
                return;
            }

            var item = list[0] as ListViewItem;
            if (item == null)
            {
                return;
            }

            var meta = item.Tag as AMeta;
            if (meta == null)
            {
                return;
            }

            _PcsClient.Delete(meta.GetMetaPath(), meta.GetMetaName());
            LvMeta.Items.Remove(item);
        }

        public void RenameMeta()
        {
            var list = LvMeta.SelectedItems;
            if (list.Count < 1)
            {
                return;
            }

            var item = list[0] as ListViewItem;
            if (item == null)
            {
                return;
            }

            var meta = item.Tag as AMeta;
            if (meta == null)
            {
                return;
            }

            string name = meta.GetMetaName();
            while (true)
            {
                name = Main.ShowInput("请输入新的文件名称：", name);
                if (name == null)
                {
                    return;
                }
                if (!string.IsNullOrWhiteSpace(name))
                {
                    break;
                }
            }

            _PcsClient.Moveto(meta, meta.GetMetaPath(), name);
            _NddEngine.Moveto(meta, meta.GetMetaPath(), name);
            meta.SetMetaName(name);
            item.Text = name;
        }

        public void Backword()
        {
        }

        public void Foreword()
        {
        }

        public void Upword()
        {
            _MetaPath = _PcsClient.Parent(_CurrentPath.GetMeta());
            _Handler = new VoidHandler(ListMeta);
            _CurrentMeta = null;

            BwWorker.RunWorkerAsync();
        }

        public void AddFav()
        {
            if (_CurrentMeta == null || _CurrentMeta.GetMetaType() != CPcs.META_TYPE_FOLDER)
            {
                Main.ShowAlert("请选择一个目录！");
                return;
            }

            string name = _CurrentMeta.GetMetaName();
            while (true)
            {
                name = Main.ShowInput("请输入收藏名称：", name);
                if (name == null)
                {
                    return;
                }
                if (!string.IsNullOrWhiteSpace(name))
                {
                    break;
                }
            }

            var meta = _CurrentMeta.ToMeta(name);
            meta.ServerType = MPcs.ServerType;
            meta.ServerUser = MPcs.UserId;
            meta.UserCode = _UserModel.Code;
            _DataModel.SaveMeta(meta);
            _TnFav.Nodes.Add(GenNode(_CurrentMeta));
        }

        public void CreateFolder()
        {
            string name = Main.ShowInput("请输入目录名称：", "");
            while (true)
            {
                if (name == null)
                {
                    return;
                }
                if (string.IsNullOrWhiteSpace(name))
                {
                    name = Main.ShowInput("请输入一个有效的名称：", name);
                    continue;
                }
                if (FolderExists(name))
                {
                    name = Main.ShowInput("已存在同名目录，请重新输入！", name);
                    continue;
                }
                break;
            }
            AMeta meta = _PcsClient.CreateFolder(_CurrentPath.GetMeta(), name);
            if (meta == null)
            {
                return;
            }
            LvMeta.Items.Add(GenItem(meta));
            _NddEngine.CreateFolder(_CurrentPath.GetMeta(), name);
        }

        public TaskThread NewDownloadThread()
        {
            // 10M = 1024*1024*10
            if (_CurrentMeta.GetSize() >= 10485760)
            {
                string msg = string.Format("您要下载的文件过大，为了获得最佳的体验效果建议使用官方客户端。{0}仍然要继续下载吗？", Environment.NewLine);
                if (DialogResult.Yes != MessageBox.Show(this, msg, "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
                {
                    return null;
                }
            }
            var task = new TaskThread(_PcsClient, _NddEngine);
            var meta = _CurrentMeta.GetMeta();
            task.InitDownload(meta, meta);
            return task;
        }

        public void DownloadMeta()
        {
            var list = LvMeta.SelectedItems;
            if (list.Count < 1)
            {
                return;
            }

            var item = list[0] as ListViewItem;
            if (item == null)
            {
                return;
            }

            var meta = item.Tag as AMeta;
            if (meta == null)
            {
                return;
            }
        }

        public void UploadMeta()
        {
        }

        public TaskThread NewUploadThread()
        {
            if (DialogResult.OK != Main.ShowOpenFileDialog(_WPcs, CApp.FILE_OPEN_ALL, "", false))
            {
                return null;
            }

            string file = Main.OpenFileDialog.FileName;
            FileInfo info = new FileInfo(file);
            // 2M = 1024*1024*2
            if (info.Length >= 2097152)
            {
                string msg = string.Format("您要上传的文件过大，为了获得最佳的体验效果建议使用官方客户端。{0}仍然要继续上传吗？", Environment.NewLine);
                if (DialogResult.Yes != MessageBox.Show(this, msg, "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
                {
                    return null;
                }
            }
            var task = new TaskThread(_PcsClient, _NddEngine);
            var meta = _CurrentPath.GetMeta();
            task.InitUpload(meta, file);
            return task;
        }
        #endregion

        #region 事件处理
        private void TvPath_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _CurrentNode = TvPath.SelectedNode;
            if (_CurrentNode == null)
            {
                return;
            }

            var meta = _CurrentNode.Tag as AMeta;
            if (meta == null)
            {
                return;
            }

            ShowInfo(meta);

            _MetaPath = meta.GetMeta();
            if (string.IsNullOrWhiteSpace(_MetaPath))
            {
                return;
            }

            if (_MetaPath[0] == '*')
            {
                switch (_MetaPath)
                {
                    case CPcs.PATH_FAV:
                        break;
                    case CPcs.PATH_LIB:
                        break;
                    case CPcs.PATH_ALL:
                        _Handler = new VoidHandler(ListMeta);
                        BwWorker.RunWorkerAsync();
                        break;
                    default:
                        break;
                }
                //node.Nodes.Clear();
            }
            else if (_MetaPath[0] == ':')
            {
            }
            else
            {
                _Handler = new VoidHandler(ListMeta);
                BwWorker.RunWorkerAsync();
            }
        }

        private void LvMeta_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (LvMeta.SelectedItems.Count < 1)
            {
                return;
            }
            _CurrentItem = LvMeta.SelectedItems[0];
            _CurrentMeta = _CurrentItem.Tag as AMeta;
        }

        private void LvMeta_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            _WPcs.SetPasteEnabled();

            var item = LvMeta.GetItemAt(e.X, e.Y);
            if (item == null)
            {
                _WPcs.SetEnabled("item-edit-enabled", false);
                _WPcs.SetVisible("item-edit-visible", false);
                _WPcs.SetVisible("none-edit-visible", true);
            }
            else
            {
                _WPcs.SetEnabled("item-edit-enabled", true);
                _WPcs.SetVisible("none-edit-visible", false);
                _WPcs.SetVisible("item-edit-visible", true);
            }
            _WPcs.PopupMenu.Show(LvMeta, e.Location);
        }

        private void LvMeta_DoubleClick(object sender, System.EventArgs e)
        {
            if (_CurrentMeta.GetMetaType() == CPcs.META_TYPE_FOLDER)
            {
                _MetaPath = _CurrentMeta.GetMeta();
                _Handler = new VoidHandler(ListMeta);
                _CurrentMeta = null;

                BwWorker.RunWorkerAsync();

                TvPath.SelectedNode = null;
            }
        }

        private void LvMeta_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void LvMeta_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string f in s)
            {
                //lbFilePath.Items.Add(f);
            }
        }
        #endregion

        #region 视图更新
        private static void LoadIcon(string path, ImageList list)
        {
            if (!Directory.Exists(path))
            {
                return;
            }

            Image img;
            string ext;
            foreach (string tmp in Directory.GetFiles(path, "*.png"))
            {
                ext = Path.GetFileNameWithoutExtension(tmp);
                if (string.IsNullOrWhiteSpace(ext))
                {
                    continue;
                }
                img = Image.FromFile(tmp);
                list.Images.Add(ext, img);
            }
        }

        private TreeNode GenNode(AMeta meta, string icon = "_def")
        {
            var node = new TreeNode();
            node.Text = meta.GetMetaName();
            node.ImageKey = icon;
            node.SelectedImageKey = icon;
            node.Tag = meta;
            return node;
        }

        private ListViewItem GenItem(AMeta meta)
        {
            var item = new ListViewItem();
            item.Text = meta.GetMetaName();
            item.ImageKey = GetIcon(meta);
            item.Tag = meta;
            return item;
        }

        private string GetIcon(AMeta meta)
        {
            if (meta == null || string.IsNullOrEmpty(meta.GetMetaName()))
            {
                return "unknown";
            }
            if (meta.GetMetaType() == CPcs.META_TYPE_FOLDER)
            {
                return "folder";
            }
            if (meta.GetMetaType() == CPcs.META_TYPE_FILE)
            {
                int idx = 0;
                string ext;
                while (true)
                {
                    idx = meta.GetMetaName().IndexOf('.', idx);
                    if (idx < 0)
                    {
                        return "file";
                    }
                    ext = meta.GetMetaName().Substring(++idx);
                    if (IlMetaLarge.Images.ContainsKey(ext))
                    {
                        return ext;
                    }
                }
            }
            return "unknown";
        }

        private void ListMeta()
        {
            _CurrentPath = _PcsClient.MetaData(_MetaPath);
            LvMeta.Items.Clear();
            foreach (AMeta meta in _CurrentPath.SubMetas())
            {
                LvMeta.Items.Add(GenItem(meta));
                //if (meta.Type == CPcs.META_TYPE_FOLDER)
                //{
                //    root.Nodes.Add(GenNode(meta));
                //}
            }
        }
        #endregion

        #region 私有函数
        private string GenDupName(string name)
        {
            string fn = System.IO.Path.GetFileNameWithoutExtension(name);
            string fe = System.IO.Path.GetExtension(name);
            int i = 0;
            foreach (ListViewItem item in LvMeta.Items)
            {
                var meta = item.Tag as AMeta;
                if (meta != null && meta.GetMetaName() == name)
                {
                    i += 1;
                    name = fn + string.Format(" ({0})", i) + fe;
                }
            }

            return name;
        }

        private bool FolderExists(string name)
        {
            name = name.ToLower();
            AMeta meta;
            foreach (ListViewItem item in LvMeta.Items)
            {
                meta = item.Tag as AMeta;
                if (meta == null || meta.GetMetaType() != CPcs.META_TYPE_FOLDER)
                {
                    continue;
                }
                if (name == meta.GetMetaName().ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 线程
        private VoidHandler _Handler;
        private void BwWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (_Handler != null)
            {
                _WPcs.ShowEcho("数据加载中，请稍候……");
                _Handler();
            }
        }

        private void BwWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void BwWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            _WPcs.ShowEcho("数据加载完成！");
        }
        #endregion
    }
}
