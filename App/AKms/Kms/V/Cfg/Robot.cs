using System.Windows.Forms;
using Me.Amon.Properties;
using Me.Amon.Util;

namespace Me.Amon.Kms.V.Cfg
{
    public partial class Robot : UserControl, IConfig
    {
        public Robot()
        {
            InitializeComponent();
        }

        #region IConfig 成员

        public void Init()
        {
            TbRobot.Text = Settings.Default.RobotName;
            TbOwner.Text = Settings.Default.OwnerName;
        }

        public bool Save()
        {
            string robotName = TbRobot.Text.Trim();
            if (!CharUtil.IsValidate(robotName))
            {
                MessageBox.Show(this, "请输入一个有效的名字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TbRobot.Focus();
                return false;
            }

            string ownerName = TbOwner.Text.Trim();
            if (!CharUtil.IsValidate(ownerName))
            {
                MessageBox.Show(this, "请输入一个有效的名字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TbOwner.Focus();
                return false;
            }

            Settings.Default.RobotName = robotName;
            Settings.Default.OwnerName = ownerName;
            Settings.Default.Save();

            return true;
        }

        public UserControl UserControl
        {
            get { return this; }
        }

        #endregion
    }
}
