using Me.Amon.Uc;
using Me.Amon.Util;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;

namespace Me.Amon.Sec.V.Pro.Uc.CmUi
{
    public class Acrypto : ACm
    {
        public Acrypto(APro apro, Cm cm)
            : base(apro, cm)
        {
        }

        public Org.BouncyCastle.Crypto.BufferedAsymmetricBlockCipher Cipher { get; set; }


        public override void InitOpt()
        {
            _Cm.Enabled = true;

            BeanUtil.Clear(_Cm.CbName);
            _Cm.CbName.Items.Add(new Item { K = ESec.ACRYPTO_ELGAMAL, V = "ElGamal" });
            _Cm.CbName.Items.Add(new Item { K = ESec.ACRYPTO_NACCACHESTERN, V = "NaccacheStern" });
            _Cm.CbName.Items.Add(new Item { K = ESec.ACRYPTO_RSABLINDED, V = "RsaBlinded" });
            _Cm.CbName.Items.Add(new Item { K = ESec.ACRYPTO_RSABLINDING, V = "RsaBlinding" });
            _Cm.CbName.Items.Add(new Item { K = ESec.ACRYPTO_RSA, V = "Rsa" });
            _Cm.CbName.Enabled = false;

            BeanUtil.Clear(_Cm.CbMode);
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
                case ESec.ACRYPTO_ELGAMAL:
                    _Engine = new ElGamalEngine();
                    break;
                case ESec.ACRYPTO_NACCACHESTERN:
                    _Engine = new NaccacheSternEngine();
                    break;
                case ESec.ACRYPTO_RSABLINDED:
                    _Engine = new RsaBlindedEngine();
                    break;
                case ESec.ACRYPTO_RSABLINDING:
                    _Engine = new RsaBlindingEngine();
                    break;
                case ESec.ACRYPTO_RSA:
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