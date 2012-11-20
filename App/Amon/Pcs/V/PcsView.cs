using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.C;
using Me.Amon.Open;
using Me.Amon.Pcs.C;
using Me.Amon.Pcs.M;

namespace Me.Amon.Pcs.V
{
    public partial class PcsView : UserControl
    {
        private WPcs _WPcs;
        private MPcs _MPcs;
        private UserModel _UserModel;
        private DataModel _DataModel;
        private PcsClient _PcsClient;
        private NddEngine _NddEngine;
        private TreeNode _TnFav;
        private TreeNode _TnPub;
        private TreeNode _TnAll;
        private TreeNode _TnSns;
        private TreeNode _TnApp;
        private TreeNode _TnBin;
        private static ImageList IlPath;
        private static ImageList IlMetaLarge;
        private static ImageList IlMetaSmall;
        private TreeNode _CurrentNode;
        private AMeta _CurrentMeta;

        #region 构造函数
        public PcsView()
        {
            InitializeComponent();
        }

        public PcsView(WPcs wPcs, MPcs mPcs, PcsClient pcsClient, UserModel userModel, DataModel dataModel)
        {
            _WPcs = wPcs;
            _MPcs = mPcs;
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

            foreach (var fav in _DataModel.ListMeta(_MPcs.ServerType, _MPcs.UserId))
            {
                _TnFav.Nodes.Add(GenNode(fav));
            }

            _NddEngine = new NddEngine();
            _NddEngine.Init(_MPcs.LocalRoot);
        }

        public MetaUri MetaUri { get; set; }

        public void ShowInfo()
        {
            if (MetaUri != null && _CurrentMeta != null)
            {
                MetaUri.Text = _PcsClient.Name;
                MetaUri.Path = _PcsClient.Display(_CurrentMeta.GetMetaPath());
                MetaUri.Icon = _PcsClient.Icon;
            }
        }

        #region 公共函数
        public void CutMeta()
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

            LvMeta.Items.Remove(item);
            _WPcs.SelectedMeta = meta;
            _WPcs.Operation = EPcs.Cut;
        }

        public void CopyMeta()
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

            _WPcs.SelectedMeta = meta;
            _WPcs.Operation = EPcs.Copy;
        }

        public void PasteMeta()
        {
            if (_WPcs.Operation == EPcs.Cut)
            {
                AMeta meta = _WPcs.SelectedMeta;

                if (_PcsClient.Parent(meta.GetMetaPath()) != _PcsClient.Root)
                {
                    string path = _PcsClient.Combine(_PcsClient.Root, meta.GetMetaName());
                    _PcsClient.Moveto(meta, _PcsClient.Root);
                }

                var item = GenItem(meta);
                LvMeta.Items.Add(item);
                item.Selected = true;

                _WPcs.SelectedMeta = null;
                return;
            }
            if (_WPcs.Operation == EPcs.Copy)
            {
                AMeta meta = _WPcs.SelectedMeta;

                if (_PcsClient.Parent(meta.GetMetaPath()) == _PcsClient.Root)
                {
                    meta.SetMetaName("复件 " + _WPcs.SelectedMeta.GetMetaName());
                }

                string path = _PcsClient.Combine(_PcsClient.Root, meta.GetMetaName());
                _PcsClient.Copyto(meta, path);
                meta.SetMetaPath(path);

                var item = GenItem(meta);
                LvMeta.Items.Add(item);
                item.Selected = true;
                return;
            }
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

            _PcsClient.Moveto(meta, name);
            _NddEngine.Moveto(meta, name);
            meta.SetMetaName(name);
            item.Text = name;
        }

        public void AddFav(string name)
        {
            var meta = _WPcs.SelectedMeta.ToMeta(name);
            meta.ServerType = _MPcs.ServerType;
            meta.ServerUser = _MPcs.UserId;
            meta.UserCode = _UserModel.Code;
            _DataModel.SaveMeta(meta);
            _TnFav.Nodes.Add(GenNode(_WPcs.SelectedMeta));
        }

        public void CreateFolder()
        {
            string name = "";
            while (true)
            {
                name = Main.ShowInput("请输入目录名称：", name);
                if (name == null)
                {
                    return;
                }
                if (!string.IsNullOrWhiteSpace(name))
                {
                    break;
                }
            }
            AMeta meta = _PcsClient.CreateFolder(_CurrentMeta.GetMetaPath(), name);
            if (meta == null)
            {
                return;
            }
            LvMeta.Items.Add(GenItem(meta));
            _NddEngine.CreateFolder(_CurrentMeta.GetMetaPath(), name);
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

        public TaskThread NewThread()
        {
            return new TaskThread(_PcsClient, _NddEngine);
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

            _CurrentMeta = _CurrentNode.Tag as AMeta;
            if (_CurrentMeta == null)
            {
                return;
            }

            ShowInfo();

            if (string.IsNullOrWhiteSpace(_CurrentMeta.GetMetaPath()))
            {
                return;
            }

            if (_CurrentMeta.GetMetaPath()[0] == '*')
            {
                switch (_CurrentMeta.GetMetaPath())
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
            else if (_CurrentMeta.GetMetaPath()[0] == ':')
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
            ListViewItem item = LvMeta.SelectedItems[0];
            var meta = item.Tag as AMeta;
            if (meta == null)
            {
                return;
            }
            _WPcs.SelectedMeta = meta;
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
            var meta = _WPcs.SelectedMeta;
            if (meta.GetMetaType() == CPcs.META_TYPE_FOLDER)
            {
                _Handler = new VoidHandler(ListMeta);
                BwWorker.RunWorkerAsync();
            }
        }

        private void LvMeta_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void LvMeta_DragDrop(object sender, DragEventArgs e)
        {

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
            var metas = _PcsClient.ListMeta(_CurrentMeta.GetMetaPath());
            LvMeta.Items.Clear();
            foreach (AMeta meta in metas)
            {
                LvMeta.Items.Add(GenItem(meta));
                //if (meta.Type == CPcs.META_TYPE_FOLDER)
                //{
                //    root.Nodes.Add(GenNode(meta));
                //}
            }
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
