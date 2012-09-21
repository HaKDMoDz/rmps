using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.Kms.M;
using Me.Amon.Kms.Robot;

namespace Me.Amon.Kms.Target.Man
{
    public partial class ManWindow : Form
    {
        public ManWindow()
        {
            InitializeComponent();
        }

        public ManWindow(IRobot robot)
        {
            InitializeComponent();
        }

        #region IManTarget 成员

        public void ShowNotice(string notice)
        {
        }

        public void ShowOptions(Me.Amon.Kms.Enums.EOptions options, string notice)
        {
        }

        #endregion

        public void Start()
        {
        }

        public bool Prepare(List<MFunction> functions)
        {
            return true;
        }

        public void SendMessage(MSolution sln, string text)
        {
        }

        public bool Confirm(List<MFunction> functions)
        {
            return true;
        }
    }
}
