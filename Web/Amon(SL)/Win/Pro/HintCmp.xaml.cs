﻿using System.Windows.Controls;
using Me.Amon.Model;

namespace Me.Amon.Win.Pro
{
    public partial class HintCmp : UserControl, IPropCmp
    {
        private Att _Att;
        private Apro _Mpro;
        private SafeModel _SafeModel;

        public HintCmp()
        {
            InitializeComponent();
        }

        public HintCmp(Apro mpro, SafeModel safeModel)
        {
            _Mpro = mpro;
            _SafeModel = safeModel;

            InitializeComponent();
        }

        #region 接口实现
        public void InitView(Border border)
        {
            border.Child = this;
        }

        public bool ShowData(Att att)
        {
            _Att = att;

            TbData.Text = _Att.Data;

            TbData.Focus();
            TbData.SelectAll();
            return true;
        }
        #endregion

        #region 按钮事件
        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Copy()
        {

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Save()
        {
            _Att.Data = TbData.Text;

            _Mpro.SelectNext();
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public new void Drop()
        {

        }
        #endregion

        private void TbName_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
