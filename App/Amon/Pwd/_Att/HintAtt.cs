using System.Drawing;
using Me.Amon.Gtd;

namespace Me.Amon.Pwd._Att
{
    public class HintAtt : Att
    {
        public Image Icon { get; set; }
        public MGtd Gtd { get; set; }

        public HintAtt()
            : base(TYPE_HINT, "", "")
        {
            Order = "提醒";
        }

        public override void SetDefault()
        {
        }
    }
}
