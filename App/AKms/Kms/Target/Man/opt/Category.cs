﻿using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;

namespace Me.Amon.Kms.Target.Man
{
    public partial class Category : UserControl, IOptions
    {
        private ManWindow _target;
        private MSentence _response;
        private DataModel _DataModel;

        #region 构造函数
        public Category()
        {
            InitializeComponent();
        }

        public Category(ManWindow target,DataModel dataModel)
        {
            _target = target;
            _DataModel = dataModel;

            InitializeComponent();
        }
        #endregion

        #region IOptions 成员

        public void Init()
        {
        }

        public void ReInit(MSentence question, MSentence response)
        {
            _response = response;
            CbCategory.Items.Clear();
            CbCategory.Items.AddRange(_DataModel.ListTags(response.P3100103).ToArray());
        }

        public UserControl GetControl()
        {
            return this;
        }

        #endregion

        #region 用户事件
        private void BtRemove_Click(object sender, System.EventArgs e)
        {
            MCategory cat = CbCategory.SelectedItem as MCategory;
            if (cat == null)
            {
                return;
            }

            if (DialogResult.Yes != _target.ShowConfirm("确认要移除此标签吗？"))
            {
                return;
            }

            _DataModel.RemoveTags(_response.P3100103, cat.C2010203);
            CbCategory.Items.Remove(cat);
        }

        private void BtDelete_Click(object sender, System.EventArgs e)
        {
            MCategory cat = CbCategory.SelectedItem as MCategory;
            if (cat == null)
            {
                return;
            }

            if (DialogResult.Yes != _target.ShowConfirm("确认要废弃此标签吗？"))
            {
                return;
            }

            _DataModel.RemoveTags(cat.C2010203);
            _DataModel.DropCategory(cat);
        }

        private void BtNa_Click(object sender, System.EventArgs e)
        {
            if (_target == null)
            {
                return;
            }
            _target.ShowOptions(EOptions.Default, "输入一个问题，看$robot_name$回答的怎么样：");
        }
        #endregion
    }
}
