using Me.Amon.Pwd;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Sec.V.Pro.Uc.DoUi
{
    public class RandKey : ADo
    {
        public RandKey(APro apro, Do od)
            : base(apro, od)
        {
        }

        #region 接口实现
        #region 用户交互
        public override void InitOpt()
        {
            _Do.Enabled = true;

            BeanUtil.Clear(_Do.CbType);
            _Do.CbType.Items.Add(new Item { K = OUTPUT_FILE, V = "剪贴板" });
            _Do.CbType.Items.Add(new Item { K = OUTPUT_TEXT, V = "文本" });
            _Do.CbType.Enabled = true;

            _Do.LbMask.Visible = false;
            _Do.CbMask.Visible = false;
            _Do.BtMask.Visible = false;
        }

        public override void InitKey(string key)
        {
        }

        public override void ChangedType(Item type)
        {
        }

        public override void MoreData()
        {
        }

        public override void ChangedMask(Udc udc)
        {
        }

        public override void MoreMask()
        {
        }
        #endregion

        #region 数据处理
        public override bool Check()
        {
            return true;
        }

        public override void Begin()
        {
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
        }

        public override void End()
        {
        }
        #endregion
        #endregion
    }
}
