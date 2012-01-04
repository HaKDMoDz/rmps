using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;

namespace Msec.Uc.CmUi
{
    public class Acrypto : ACm
    {
        public Acrypto(Main main, Cm cm)
            : base(main, cm)
        {
        }

        public Org.BouncyCastle.Crypto.BufferedAsymmetricBlockCipher Cipher { get; set; }


        public override void InitOpt()
        {
            _Cm.Enabled = true;

            Util.Clear(_Cm.CbName);
            _Cm.CbName.Items.Add(new Item { K = "ElGamal", V = "ElGamal" });
            _Cm.CbName.Items.Add(new Item { K = "NaccacheStern", V = "NaccacheStern" });
            _Cm.CbName.Items.Add(new Item { K = "RsaBlinded", V = "RsaBlinded" });
            _Cm.CbName.Items.Add(new Item { K = "RsaBlinding", V = "RsaBlinding" });
            _Cm.CbName.Items.Add(new Item { K = "Rsa", V = "Rsa" });
            _Cm.CbName.Enabled = false;

            Util.Clear(_Cm.CbMode);
            _Cm.CbMode.Items.Add(new Item { K = "1", V = "CBC" });
            _Cm.CbMode.Items.Add(new Item { K = "1", V = "CCM" });
            _Cm.CbMode.Items.Add(new Item { K = "4", V = "CFB" });
            _Cm.CbMode.Items.Add(new Item { K = "2", V = "EAX" });
            _Cm.CbMode.Items.Add(new Item { K = "2", V = "ECB" });
            _Cm.CbMode.Items.Add(new Item { K = "2", V = "GCM" });
            _Cm.CbMode.Items.Add(new Item { K = "3", V = "GOFB" });
            _Cm.CbMode.Items.Add(new Item { K = "3", V = "OFB" });
            _Cm.CbMode.Items.Add(new Item { K = "5", V = "CTS" });
            _Cm.CbMode.Items.Add(new Item { K = "5", V = "OpenPgpCfb" });
            _Cm.CbMode.Items.Add(new Item { K = "5", V = "SIC" });
            _Cm.CbMode.Enabled = false;

            _Cm.LbMode.Visible = true;
            _Cm.CbMode.Visible = true;
            _Cm.CbMode.Enabled = false;

            _Cm.LbPads.Visible = true;
            _Cm.CbPads.Visible = true;
            _Cm.CbPads.Enabled = false;
        }

        public override void InitKey(string key)
        {
            bool b = key != "0";

            _Cm.CbName.Enabled = b;

            _Cm.CbMode.Enabled = b;
        }

        private IAsymmetricBlockCipher _Engine;
        public override void ChangeName(string name)
        {
            if (name == "0")
            {
                Cipher = null;
                return;
            }

            switch (name)
            {
                case "ElGamal":
                    _Engine = new ElGamalEngine();
                    break;
                case "NaccacheStern":
                    _Engine = new NaccacheSternEngine();
                    break;
                case "RsaBlinded":
                    _Engine = new RsaBlindedEngine();
                    break;
                case "RsaBlinding":
                    _Engine = new RsaBlindingEngine();
                    break;
                case "Rsa":
                    _Engine = new RsaEngine();
                    break;
            }

            _Cm.CbMode.SelectedIndex = 0;

            _Cm.CbPads.SelectedIndex = 0;
        }


        public override void ChangeMode(string mode)
        {
        }

        public override void ChangePads(string pads)
        {
        }
    }
}