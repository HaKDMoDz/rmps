using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;

namespace Msec.Uc.CmUi
{
    public class Sstream : ACm
    {
        private IStreamCipher _Engine;
        private BufferedStreamCipher _Cipher;

        public Sstream(Main main, Cm cm)
            : base(main, cm)
        {
        }

        public BufferedStreamCipher Cipher
        {
            get
            {
                return _Cipher;
            }
        }

        #region 接口实现
        public override void InitOpt()
        {
            _Cm.Enabled = true;

            Util.Clear(_Cm.CbName);
            _Cm.CbName.Items.Add(new Item { K = "HC128", V = "HC128", D = "128" });//128
            _Cm.CbName.Items.Add(new Item { K = "HC256", V = "HC256", D = "256" });//256
            _Cm.CbName.Items.Add(new Item { K = "Isaac", V = "Isaac", D = "32" });//32 .. 8192
            _Cm.CbName.Items.Add(new Item { K = "RC4", V = "RC4", D = "40" });//40 .. 2048
            _Cm.CbName.Items.Add(new Item { K = "Salsa20", V = "Salsa20", D = "128" });//128/256
            _Cm.CbName.Items.Add(new Item { K = "Vmpc", V = "Vmpc", D = "32" });//8 .. 6144
            _Cm.CbName.Items.Add(new Item { K = "VmpcKsa3", V = "VmpcKsa3", D = "32" });
            _Cm.CbName.Enabled = false;

            _Cm.LbMode.Visible = false;
            _Cm.CbMode.Visible = false;

            _Cm.LbPads.Visible = false;
            _Cm.CbPads.Visible = false;
        }

        public override void InitKey(string key)
        {
            _Cm.CbName.Enabled = key != "0";
        }

        public override void ChangeName(string name)
        {
            if (name == "0")
            {
                _Cipher = null;
                return;
            }

            switch (name)
            {
                case "HC128":
                    _Engine = new HC128Engine();
                    _KeySize = 16;//128
                    _IVSize = 16;
                    break;
                case "HC256":
                    _Engine = new HC256Engine();
                    _KeySize = 32;
                    _IVSize = 16;
                    break;
                case "Isaac":
                    _Engine = new IsaacEngine();
                    _KeySize = 10;
                    _IVSize = 0;
                    break;
                case "RC4":
                    _Engine = new RC4Engine();
                    _KeySize = 10;
                    _IVSize = 0;
                    break;
                case "Salsa20":
                    _Engine = new Salsa20Engine();
                    _KeySize = 16;
                    _IVSize = 8;
                    break;
                case "Vmpc":
                    _Engine = new VmpcEngine();
                    _KeySize = 10;
                    _IVSize = 16;
                    break;
                case "VmpcKsa3":
                    _Engine = new VmpcKsa3Engine();
                    _KeySize = 10;
                    _IVSize = 16;
                    break;
                default:
                    _Engine = null;
                    _KeySize = 0;
                    _IVSize = 0;
                    break;
            }

            _Cm.CbMode.SelectedIndex = 0;

            _Cm.CbPads.SelectedIndex = 0;

            _Cipher = new BufferedStreamCipher(_Engine);
        }

        public override void ChangeMode(string mode)
        {
        }

        public override void ChangePads(string pads)
        {
        }
        #endregion
    }
}