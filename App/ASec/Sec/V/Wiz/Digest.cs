using System.IO;
using System.Security.Cryptography;
using Me.Amon.Sec.M;
using Me.Amon.Uc;
using Me.Amon.Util;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Me.Amon.Sec.V.Wiz
{
    class Digest : ICrypto<byte, byte>
    {
        private MSec _MSec;
        private IDigest _Cipher;

        public Digest()
        {
        }

        #region 接口实现
        public void Init(MSec msec, string pass)
        {
            _MSec = msec;
        }
        #endregion

        private void CreateEngine()
        {
            switch (_MSec.Algorithm)
            {
                case ESec.DIGEST_GOST3411:
                    _Cipher = new Gost3411Digest();
                    break;
                case ESec.DIGEST_MD2:
                    _Cipher = new MD2Digest();
                    break;
                case ESec.DIGEST_MD4:
                    _Cipher = new MD4Digest();
                    break;
                case ESec.DIGEST_MD5:
                    _Cipher = new MD5Digest();
                    break;
                case ESec.DIGEST_NULL:
                    _Cipher = new NullDigest();
                    break;
                case ESec.DIGEST_RIPEMD128:
                    _Cipher = new RipeMD128Digest();
                    break;
                case ESec.DIGEST_RIPEMD160:
                    _Cipher = new RipeMD160Digest();
                    break;
                case ESec.DIGEST_RIPEMD256:
                    _Cipher = new RipeMD256Digest();
                    break;
                case ESec.DIGEST_RIPEMD320:
                    _Cipher = new RipeMD320Digest();
                    break;
                case ESec.DIGEST_SHA1:
                    _Cipher = new Sha1Digest();
                    break;
                case ESec.DIGEST_SHA224:
                    _Cipher = new Sha224Digest();
                    break;
                case ESec.DIGEST_SHA256:
                    _Cipher = new Sha256Digest();
                    break;
                case ESec.DIGEST_SHA384:
                    _Cipher = new Sha384Digest();
                    break;
                case ESec.DIGEST_SHA512:
                    _Cipher = new Sha512Digest();
                    break;
                case ESec.DIGEST_TIGER:
                    _Cipher = new TigerDigest();
                    break;
                case ESec.DIGEST_WHIRLPOOL:
                    _Cipher = new WhirlpoolDigest();
                    break;
            }
        }

        private bool DigestFile(Items item)
        {
            _Cipher.BlockUpdate(null, 0, 0);
            if (!File.Exists(item.K))
            {
                return false;
            }

            using (HashAlgorithm alg = HashAlgorithm.Create(_MSec.Algorithm))
            {
                FileStream stream = File.OpenRead(item.K);
                byte[] buf = alg.ComputeHash(stream);
                stream.Close();
                item.D = CharUtil.EncodeString(buf);
            }
            return true;
        }

        private bool DigestText()
        {
            //string src = _AText.TbSrc.Text;
            //if (string.IsNullOrEmpty(src))
            //{
            //    return false;
            //}

            //using (HashAlgorithm alg = HashAlgorithm.Create(Algorithm))
            //{
            //    byte[] buf = Encoding.UTF8.GetBytes(src);
            //    buf = alg.ComputeHash(buf);
            //    _AText.TbDst.Text = CharUtil.EncodeString(buf);
            //}
            return true;
        }


        public int Process(byte[] srcArray, int srcFrom, int length, byte[] dstArray, int dstFrom)
        {
            throw new System.NotImplementedException();
        }

        public int DoFinal(byte[] output, int outOff)
        {
            throw new System.NotImplementedException();
        }
    }
}
