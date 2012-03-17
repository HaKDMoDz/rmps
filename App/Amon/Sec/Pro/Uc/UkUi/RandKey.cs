using Me.Amon.Uc;
using Me.Amon.Util;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;

namespace Me.Amon.Sec.Pro.Uc.UkUi
{
    public class RandKey : AUk
    {
        public RandKey(APro apro, Uk uk)
            : base(apro, uk)
        {
        }

        #region 接口实现
        public override void InitOpt()
        {
            _Uk.Enabled = true;

            _Uk.LbPass.Text = "用户(&K)";

            _Uk.LbSalt.Text = "网站(&V)";
            _Uk.LbSalt.Visible = false;
            _Uk.TbSalt.Visible = false;
            _Uk.BtSalt.Visible = false;
        }

        public override void InitDir(string dir)
        {
        }

        public override void InitAlg(string alg)
        {
            BeanUtil.Clear(_Uk.CbSize);
            _Uk.CbSize.SelectedIndex = 0;

            _SizeDef.D = "8";
            //0 .. 256
            for (int i = 6; i <= 32; i += 2)
            {
                _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
            }

            _Uk.LbSize.Enabled = true;
            _Uk.CbSize.Enabled = true;
        }

        public override void MorePass()
        {
        }

        public override void MoreSalt()
        {
        }

        public override bool Check()
        {
            return true;
        }

        public override ICipherParameters GenParam()
        {
            return null;
        }

        public void GenAkey()
        {
            //RSA密钥对的构造器  
            RsaKeyPairGenerator keyGenerator = new RsaKeyPairGenerator();

            //RSA密钥构造器的参数  
            RsaKeyGenerationParameters param = new RsaKeyGenerationParameters(
                Org.BouncyCastle.Math.BigInteger.ValueOf(3),
                new Org.BouncyCastle.Security.SecureRandom(),
                1024,   //密钥长度  
                25);
            //用参数初始化密钥构造器  
            keyGenerator.Init(param);
            //产生密钥对  
            AsymmetricCipherKeyPair keyPair = keyGenerator.GenerateKeyPair();
            //获取公钥和密钥  
            AsymmetricKeyParameter publicKey = keyPair.Public;
            AsymmetricKeyParameter privateKey = keyPair.Private;

            _Uk.TbPass.Text = publicKey.ToString();
            _Uk.TbSalt.Text = privateKey.ToString();
        }
        #endregion
    }
}
