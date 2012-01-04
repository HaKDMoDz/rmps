using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Msec.Uc.DoUi
{
    class SstreamDef : Sstream
    {
        public SstreamDef(Main main, Do od)
            : base(main, od)
        {
        }

        public override void InitKey(string key)
        {
            _Do.CbType.SelectedIndex = 0;

            _Do.LbMask.Visible = false;
            _Do.CbMask.Visible = false;
            _Do.BtMask.Visible = false;
        }

        public override void ChangedType(Item type)
        {
            _Do.TbData.Text = "";
        }

        public override bool Check()
        {
            if (_Type.K == OUTPUT_FILE || _Type.K == OUTPUT_FILE_TXT || _Type.K == OUTPUT_FILE_BIN)
            {
                if (string.IsNullOrWhiteSpace(_Do.TbData.Text))
                {
                    _Main.ShowAlert("请选择输出路径！");
                    _Do.TbData.Focus();
                    return false;
                }
                return true;
            }
            return true;
        }

        public override void Begin()
        {
        }

        public override void End()
        {
        }
    }
}
