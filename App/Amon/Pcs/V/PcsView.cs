using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.M;
using Me.Amon.Open;
using Me.Amon.Pcs.C;
using Me.Amon.Pcs.M;

namespace Me.Amon.Pcs.V
{
    public partial class PcsView : UserControl
    {
        private WPcs _WPcs;
        private MPcs _MPcs;
        private DataModel _DataModel;
        private PcsClient _PcsClient;
        private NddEngine _NddEngine;
        private TreeNode _TnFav;
        private TreeNode _TnPub;
        private TreeNode _TnAll;
        private TreeNode _TnSns;
        private TreeNode _TnBin;
        private static ImageList IlPath;
        private static ImageList IlMetaLarge;
        private static ImageList IlMetaSmall;
        private Cat _SelectedCat;

        #region 构造函数
        static PcsView()
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

            LoadIcon(@"D:\Temp\i1", IlPath);
            LoadIcon(@"D:\Temp\i2", IlMetaLarge);
        }

        public PcsView()
        {
            InitializeComponent();
        }

        public PcsView(WPcs wPcs, MPcs mPcs, PcsClient pcsClient)
        {
            _WPcs = wPcs;
            _MPcs = mPcs;
            _PcsClient = pcsClient;

            InitializeComponent();
        }
        #endregion

        public void Init()
        {
            TvPath.ImageList = IlPath;
            LvMeta.LargeImageList = IlMetaLarge;
            LvMeta.SmallImageList = IlMetaSmall;

            _TnFav = new TreeNode();
            _TnFav.Text = "收藏";
            _TnFav.ImageKey = "_fav";
            _TnFav.Tag = new Cat { Meta = CPcs.PATH_FAVORITES, Text = "收藏" };
            TvPath.Nodes.Add(_TnFav);

            _TnPub = new TreeNode();
            _TnPub.Text = "公共";
            _TnPub.ImageKey = "_lib";
            _TnPub.Tag = new Cat { Meta = CPcs.PATH_LIBRARIES, Text = "公共" };
            TvPath.Nodes.Add(_TnPub);

            TreeNode node = new TreeNode();
            node.Text = "文档";
            node.ImageKey = "icon";
            node.Tag = new Cat { Meta = _PcsClient.GetPath(CPcs.PATH_DOCUMENTS), Text = "文档" };
            _TnPub.Nodes.Add(node);

            node = new TreeNode();
            node.Text = "图片";
            node.ImageKey = "icon";
            node.Tag = new Cat { Meta = _PcsClient.GetPath(CPcs.PATH_PICTURES), Text = "图片" };
            _TnPub.Nodes.Add(node);

            node = new TreeNode();
            node.Text = "音乐";
            node.ImageKey = "icon";
            node.Tag = new Cat { Meta = _PcsClient.GetPath(CPcs.PATH_AUDIOS), Text = "音乐" };
            _TnPub.Nodes.Add(node);

            node = new TreeNode();
            node.Text = "视频";
            node.ImageKey = "icon";
            node.Tag = new Cat { Meta = _PcsClient.GetPath(CPcs.PATH_VIDEOS), Text = "视频" };
            _TnPub.Nodes.Add(node);

            _TnAll = new TreeNode();
            _TnAll.Text = "所有";
            _TnAll.ImageKey = "_all";
            _TnAll.Tag = new Cat { Meta = CPcs.PATH_STORAGE, Text = "所有" };
            TvPath.Nodes.Add(_TnAll);

            _TnSns = new TreeNode();
            _TnSns.Text = "分享";
            _TnSns.ImageKey = "_sns";
            _TnSns.Tag = new Cat { Meta = _PcsClient.GetPath(CPcs.PATH_SHARES), Text = "分享" };
            TvPath.Nodes.Add(_TnSns);

            _TnBin = new TreeNode();
            _TnBin.Text = "回收站";
            _TnBin.ImageKey = "_bin";
            _TnBin.Tag = new Cat { Meta = _PcsClient.GetPath(CPcs.PATH_RECYCLE), Text = "回收站" };
            TvPath.Nodes.Add(_TnBin);

            _NddEngine = new NddEngine();
            _NddEngine.Init(_MPcs.LocalRoot);
        }

        public MetaUri MetaUri { get; set; }

        public void ShowInfo()
        {
            if (MetaUri != null && _SelectedCat != null)
            {
                MetaUri.Text = _PcsClient.Name;
                MetaUri.Path = _PcsClient.Display(_SelectedCat.Meta);
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

            var meta = item.Tag as CsMeta;
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

            var meta = item.Tag as CsMeta;
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
                CsMeta meta = _WPcs.SelectedMeta;

                if (_PcsClient.Parent(meta.Path) != _PcsClient.Root)
                {
                    string path = _PcsClient.Combine(_PcsClient.Root, meta.Name);
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
                CsMeta meta = _WPcs.SelectedMeta;

                if (_PcsClient.Parent(meta.Path) == _PcsClient.Root)
                {
                    meta.Name = "复件 " + _WPcs.SelectedMeta.Name;
                }

                string path = _PcsClient.Combine(_PcsClient.Root, meta.Name);
                _PcsClient.Copyto(meta, path);
                meta.Path = path;

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

            var meta = item.Tag as CsMeta;
            if (meta == null)
            {
                return;
            }

            _PcsClient.Delete(meta.Path, meta.Name);
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

            var meta = item.Tag as CsMeta;
            if (meta == null)
            {
                return;
            }

            string name = meta.Name;
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
            meta.Name = name;
            item.Text = name;
        }

        public void AddFav(string name)
        {
            //var meta = new Cat();
            //meta.Text = name;
            //meta.Meta = _WPcs.SelectedMeta.Path;
            //meta.FileId = _WPcs.SelectedMeta.FileId;
            //meta.Type = _WPcs.SelectedMeta.Type;
            //meta.Rev = _WPcs.SelectedMeta.Rev;

            //_TnFav.Nodes.Add(GenNode(meta));
            //_DataModel.SaveMeta(meta);
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
            CsMeta meta = _PcsClient.CreateFolder(_SelectedCat.Meta, name);
            if (meta == null)
            {
                return;
            }
            LvMeta.Items.Add(GenItem(meta));
            _NddEngine.CreateFolder(_SelectedCat.Meta, name);
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

            var meta = item.Tag as CsMeta;
            if (meta == null)
            {
                return;
            }
        }
        #endregion

        #region 事件处理
        private void TvPath_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = TvPath.SelectedNode;
            if (node == null)
            {
                return;
            }

            _SelectedCat = node.Tag as Cat;
            if (_SelectedCat == null)
            {
                return;
            }

            ShowInfo();

            if (_SelectedCat.Meta[0] == '?')
            {
                switch (_SelectedCat.Meta)
                {
                    case CPcs.PATH_FAVORITES:
                        break;
                    case CPcs.PATH_LIBRARIES:
                        break;
                    case CPcs.PATH_STORAGE:
                        ShowMeta(_PcsClient.ListMeta(_SelectedCat.Meta), node);
                        break;
                    default:
                        break;
                }
                //node.Nodes.Clear();
            }
            else if (!string.IsNullOrEmpty(_SelectedCat.Meta))
            {
                ShowMeta(_PcsClient.ListMeta(_SelectedCat.Meta), node);
            }
        }

        private void LvMeta_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (LvMeta.SelectedItems.Count < 1)
            {
                return;
            }
            ListViewItem item = LvMeta.SelectedItems[0];
            var meta = item.Tag as CsMeta;
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
            if (meta.Type == CPcs.META_TYPE_FOLDER)
            {
                ShowMeta(_PcsClient.ListMeta(meta), TvPath.SelectedNode);
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

        private void ShowMeta(List<CsMeta> metas, TreeNode root)
        {
            LvMeta.Items.Clear();

            foreach (CsMeta meta in metas)
            {
                LvMeta.Items.Add(GenItem(meta));
                //if (meta.Type == CPcs.META_TYPE_FOLDER)
                //{
                //    root.Nodes.Add(GenNode(meta));
                //}
            }
        }

        private TreeNode GenNode(CsMeta meta)
        {
            var node = new TreeNode();
            node.Text = meta.Name;
            node.ImageKey = "folder";
            node.Tag = meta;
            return node;
        }

        private ListViewItem GenItem(CsMeta meta)
        {
            var item = new ListViewItem();
            item.Text = meta.Name;
            item.ImageKey = GetIcon(meta);
            item.Tag = meta;
            return item;
        }

        private string GetIcon(CsMeta meta)
        {
            if (meta == null || string.IsNullOrEmpty(meta.Name))
            {
                return "unknown";
            }
            if (meta.Type == CPcs.META_TYPE_FOLDER)
            {
                return "folder";
            }
            if (meta.Type == CPcs.META_TYPE_FILE)
            {
                int idx = 0;
                string ext;
                while (true)
                {
                    idx = meta.Name.IndexOf('.', idx);
                    if (idx < 0)
                    {
                        return "file";
                    }
                    ext = meta.Name.Substring(++idx);
                    if (IlMetaLarge.Images.ContainsKey(ext))
                    {
                        return ext;
                    }
                }
            }
            return "unknown";
        }
        #endregion
    }
}
