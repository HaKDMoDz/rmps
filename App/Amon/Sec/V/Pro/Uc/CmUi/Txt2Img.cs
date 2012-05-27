using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Sec.V.Pro.Uc.CmUi
{
    public class Txt2Img : ACm
    {
        public Txt2Img(APro apro, Cm cm)
            : base(apro, cm)
        {
        }

        public override void InitOpt()
        {
            _Cm.Enabled = true;

            BeanUtil.Clear(_Cm.CbName);
            _Cm.CbName.Items.Add(new Item { K = "png", V = "PNG" });
            _Cm.CbName.Items.Add(new Item { K = "jpg", V = "JPG" });
            _Cm.CbName.Items.Add(new Item { K = "gif", V = "GIF" });
        }

        public override void InitKey(string key)
        {
        }

        public override void ChangeName(string name)
        {
        }

        public override void ChangeMode(string mode)
        {
        }

        public override void ChangePads(string pads)
        {
        }
    }
}