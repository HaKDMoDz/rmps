using System.Windows.Controls;
using Me.Amon.Lot.C;
using Me.Amon.Lot.M;
using Me.Amon.Lot.V;

namespace Me.Amon.Lot
{
    public partial class ALot : UserControl
    {
        private MLot _MLot;
        private VLot _VLot;
        private CLot _CLot;

        public ALot()
        {
            InitializeComponent();
        }

        private void ALot_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            string key = "";

            GenM(key);
            GenV(key);
            GenC(key);

            _VLot.Control.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            _VLot.Control.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            LayoutRoot.Children.Add(_VLot.Control);
        }

        private void ALot_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == _MLot.Fav.Run)
            {
                _CLot.Run();
                return;
            }
            if (e.Key == _MLot.Fav.AmonMe)
            {
                _CLot.AmonMe();
                return;
            }
            if (e.Key == _MLot.Fav.KeepOn)
            {
                _CLot.KeepOn();
                return;
            }
            if (e.Key == _MLot.Fav.End)
            {
                _CLot.End();
                return;
            }
        }

        #region 私有函数
        private MLot GenM(string key)
        {
            _MLot = new MLot();

            _MLot.Title = "Demo";
            _MLot.Nodes = new System.Collections.Generic.List<Node>();

            Node node = new Node();
            node.Items = new System.Collections.Generic.List<Item>();
            _MLot.Nodes.Add(node);

            Item item = new Item { Key = "demo", Value = "Demo" };
            node.Items.Add(item);

            item = new Item { Key = "test", Value = "Test" };
            node.Items.Add(item);

            item = new Item { Key = "foo", Value = "Foo" };
            node.Items.Add(item);

            item = new Item { Key = "bar", Value = "Bar" };
            node.Items.Add(item);

            item = new Item { Key = "中文", Value = "中文" };
            node.Items.Add(item);

            item = new Item { Key = "测试", Value = "测试" };
            node.Items.Add(item);

            item = new Item { Key = "演示", Value = "演示" };
            node.Items.Add(item);

            LotCfg cfg = new LotCfg();
            cfg.RowCount = 3;
            cfg.ColCount = 2;
            cfg.Speed = 30;
            _MLot.Cfg = cfg;

            LotFav fav = new LotFav();
            fav.Run = System.Windows.Input.Key.R;
            fav.AmonMe = System.Windows.Input.Key.Space;
            fav.KeepOn = System.Windows.Input.Key.Enter;
            fav.End = System.Windows.Input.Key.S;
            _MLot.Fav = fav;

            return _MLot;
        }

        private VLot GenV(string key)
        {
            _VLot = new V.V01.Vc01();
            _VLot.Init(_MLot.Cfg);
            return _VLot;
        }

        private CLot GenC(string key)
        {
            _CLot = new C.C01.Cc01();
            _CLot.Init(_MLot, _VLot);
            return _CLot;
        }
        #endregion
    }
}
