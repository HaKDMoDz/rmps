using System.Collections.Generic;
using System.Windows.Controls;
using Me.Amon.Lot.M;

namespace Me.Amon.Lot.V.V01
{
    public partial class Vc01 : UserControl, VLot
    {
        private LotCfg _Cfg;
        private List<Uc1> _Ucs;

        public Vc01()
        {
            InitializeComponent();
        }

        #region 接口实现
        public void Init(LotCfg cfg)
        {
            _Cfg = cfg;

            TbTitle.Text = "Demo....";

            ShowView(GdPanel);
        }

        public UserControl Control
        {
            get
            {
                return this;
            }
        }

        public void Value(Item[] result, int length)
        {
            int max = length < _Ucs.Count ? length : _Ucs.Count;
            for (int i = 0; i < max; i += 1)
            {
                _Ucs[i].Item = result[i];
            }
        }
        #endregion

        #region 私有函数
        private void ShowView(Grid grid)
        {
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();
            grid.Children.Clear();

            for (int i = 0; i < _Cfg.ColCount; i += 1)
            {
                ColumnDefinition col = new ColumnDefinition();
                grid.ColumnDefinitions.Add(col);
            }

            for (int i = 0; i < _Cfg.RowCount; i += 1)
            {
                RowDefinition row = new RowDefinition();
                grid.RowDefinitions.Add(row);
            }

            _Ucs = new List<Uc1>(_Cfg.ColCount * _Cfg.RowCount);
            Uc1 uc;
            for (int i = 0; i < _Cfg.RowCount; i += 1)
            {
                for (int j = 0; j < _Cfg.ColCount; j += 1)
                {
                    uc = new Uc1();
                    uc.SetValue(Grid.RowProperty, i);
                    uc.SetValue(Grid.ColumnProperty, j);
                    grid.Children.Add(uc);
                    _Ucs.Add(uc);
                }
            }
        }
        #endregion
    }
}
