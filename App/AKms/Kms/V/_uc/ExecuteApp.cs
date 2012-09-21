using System;
using System.Windows.Forms;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;
using Me.Amon.Util;

namespace Me.Amon._uc
{
    public partial class ExecuteApp : UserControl, IFunction
    {
        private MFunction _function;

        public ExecuteApp()
        {
            InitializeComponent();
        }

        private void PbPath_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != FdFile.ShowDialog())
            {
                return;
            }
            TbPath.Text = FdFile.FileName;
        }

        #region IFunction 成员

        public MFunction UserFunction
        {
            get
            {
                return _function;
            }
            set
            {
                _function = value;
                TbPath.Text = _function.Param ?? "";
            }
        }

        public bool SaveFunction()
        {
            if (!CharUtil.IsValidate(TbPath.Text))
            {
                return false;
            }

            _function.Action = EAction.ExecuteApp;
            _function.Param = TbPath.Text.Trim();
            return true;
        }

        public UserControl UserControl
        {
            get
            {
                return this;
            }
        }

        #endregion
    }
}
