using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Open;
using Me.Amon.Pcs.C;
using Me.Amon.Pcs.M;

namespace Me.Amon.Pcs.V
{
    public partial class PcsView : UserControl
    {
        private WPcs _WPcs;
        private OAuthPcs _OPcs;
        private TreeNode _TnFav;
        private TreeNode _TnPub;
        private TreeNode _TnAll;
        private TreeNode _TnSns;
        private TreeNode _TnBin;
        private static ImageList IlPath;
        private static ImageList IlMetaLarge;
        private static ImageList IlMetaSmall;
        private PcEngine _PcEngine;
        private Image _Unknown;
        private Image _File;

        #region 构造函数
        static PcsView()
        {
            IlPath.ColorDepth = ColorDepth.Depth8Bit;
            IlPath.ImageSize = new Size(16, 16);

            IlMetaLarge.ColorDepth = ColorDepth.Depth32Bit;
            IlMetaLarge.ImageSize = new Size(48, 48);

            IlMetaSmall.ColorDepth = ColorDepth.Depth32Bit;
            IlMetaSmall.ImageSize = new Size(16, 16);
        }

        public PcsView()
        {
            InitializeComponent();
        }

        public PcsView(WPcs wPcs, OAuthPcs oPcs)
        {
            _WPcs = wPcs;
            _OPcs = oPcs;

            InitializeComponent();

            TvPath.ImageList = IlPath;
            LvMeta.LargeImageList = IlMetaLarge;
            LvMeta.SmallImageList = IlMetaSmall;
        }
        #endregion

        public void Init()
        {
            _TnFav = new TreeNode();
            _TnFav.Text = "收藏";
            _TnFav.Tag = "<favorites>";
            TvPath.Nodes.Add(_TnFav);

            _TnPub = new TreeNode();
            _TnPub.Text = "公共";
            _TnPub.Tag = "<libraries>";
            TvPath.Nodes.Add(_TnPub);

            TreeNode node = new TreeNode();
            node.Text = "文档";
            node.Tag = CPcs.PATH_DOCUMENTS;
            _TnPub.Nodes.Add(node);

            node = new TreeNode();
            node.Text = "图片";
            node.Tag = CPcs.PATH_PICTURES;
            _TnPub.Nodes.Add(node);

            node = new TreeNode();
            node.Text = "音乐";
            node.Tag = CPcs.PATH_AUDIOS;
            _TnPub.Nodes.Add(node);

            node = new TreeNode();
            node.Text = "视频";
            node.Tag = CPcs.PATH_VIDEOS;
            _TnPub.Nodes.Add(node);

            _TnAll = new TreeNode();
            _TnAll.Text = "所有";
            _TnAll.Tag = "<storage>";
            TvPath.Nodes.Add(_TnAll);

            _TnSns = new TreeNode();
            _TnSns.Text = "分享";
            _TnSns.Tag = CPcs.PATH_SHARES;
            TvPath.Nodes.Add(_TnSns);

            _TnBin = new TreeNode();
            _TnBin.Text = "回收站";
            _TnBin.Tag = CPcs.PATH_RECYCLE;
            TvPath.Nodes.Add(_TnBin);
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

            LvMeta.Items.Remove(list[0]);
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

                if (_OPcs.Parent(meta.Path) == _OPcs.Path)
                {
                    return;
                }

                string path = _OPcs.Combine(_OPcs.Path, meta.Name);
                _OPcs.Moveto(meta.Path, path);
                meta.Path = path;

                var item = new ListViewItem();
                item.Text = meta.Name;
                item.ImageKey = GetIcon(meta.Name);
                LvMeta.Items.Add(item);
                item.Selected = true;
                return;
            }
            if (_WPcs.Operation == EPcs.Copy)
            {
                CsMeta meta = _WPcs.SelectedMeta;

                if (_OPcs.Parent(meta.Path) == _OPcs.Path)
                {
                    meta.Name = "复件 " + _WPcs.SelectedMeta.Name;
                }

                string path = _OPcs.Combine(_OPcs.Path, meta.Name);
                _OPcs.Copyto(meta.Path, path);
                meta.Path = path;

                var item = new ListViewItem();
                item.Text = meta.Name;
                item.ImageKey = GetIcon(meta.Name);
                LvMeta.Items.Add(item);
                item.Selected = true;
                return;
            }
        }
        #endregion

        private string GetIcon(string key)
        {
            if (string.IsNullOrEmpty(key) || !IlMetaLarge.Images.ContainsKey(key))
            {
                return "";
            }

            int idx = 0;
            string ext;
            while (true)
            {
                idx = key.IndexOf('.', idx);
                if (idx < 0)
                {
                    return "file";
                }
                ext = key.Substring(idx + 1);
                if (IlMetaLarge.Images.ContainsKey(ext))
                {
                    return ext;
                }
            }
        }
    }
}
