namespace Msec
{
    public class IData
    {
        /// <summary>
        /// 数据散列
        /// </summary>
        public const string OPT_DIGEST = "digest";
        /// <summary>
        /// 随机口令
        /// </summary>
        public const string OPT_RANDKEY = "randkey";
        /// <summary>
        /// 掩码转换
        /// </summary>
        public const string OPT_WRAPPER = "wrapper";
        /// <summary>
        /// 混淆处理
        /// </summary>
        public const string OPT_CONFUSE = "confuse";
        /// <summary>
        /// 对称块加密
        /// </summary>
        public const string OPT_SCRYPTO = "scrypto";
        /// <summary>
        /// 对称流加密
        /// </summary>
        public const string OPT_SSTREAM = "sstream";
        /// <summary>
        /// 非对称加密
        /// </summary>
        public const string OPT_ACRYPTO = "acrypto";
        /// <summary>
        /// 文图转换
        /// </summary>
        public const string OPT_TXT2IMG = "txt2img";

        public const string DIR_ENC = "enc";
        public const string DIR_DEC = "dec";

        public const string ACRYPTO_ELGAMAL = "ElGamal";
        public const string ACRYPTO_NACCACHESTERN = "NaccacheStern";
        public const string ACRYPTO_RSABLINDED = "RsaBlinded";
        public const string ACRYPTO_RSABLINDING = "RsaBlinding";
        public const string ACRYPTO_RSA = "Rsa";

        public const string DIGEST_GOST3411 = "Gost3411";
        public const string DIGEST_MD2 = "MD2";
        public const string DIGEST_MD4 = "MD4";
        public const string DIGEST_MD5 = "MD5";
        public const string DIGEST_NULL = "Null";
        public const string DIGEST_RIPEMD128 = "RipeMD128";
        public const string DIGEST_RIPEMD160 = "RipeMD160";
        public const string DIGEST_RIPEMD256 = "RipeMD256";
        public const string DIGEST_RIPEMD320 = "RipeMD320";
        public const string DIGEST_SHA1 = "Sha1";
        public const string DIGEST_SHA224 = "Sha224";
        public const string DIGEST_SHA256 = "Sha256";
        public const string DIGEST_SHA384 = "Sha384";
        public const string DIGEST_SHA512 = "Sha512";
        public const string DIGEST_TIGER = "Tiger";
        public const string DIGEST_WHIRLPOOL = "Whirlpool";

        public const string SCRYPTO_AES = "Aes";
        public const string SCRYPTO_AESFAST = "AesFast";
        public const string SCRYPTO_AESLIGHT = "AesLight";
        public const string SCRYPTO_BLOWFISH = "Blowfish";
        public const string SCRYPTO_CAMELLIA = "Camellia";
        public const string SCRYPTO_CAMELLIALIGHT = "CamelliaLight";
        public const string SCRYPTO_CAST5 = "Cast5";
        public const string SCRYPTO_CAST6 = "Cast6";
        public const string SCRYPTO_DES = "Des";
        public const string SCRYPTO_DESEDE = "DesEde";
        public const string SCRYPTO_GOST28147 = "Gost28147";
        public const string SCRYPTO_NOEKEON = "Noekeon";
        public const string SCRYPTO_NULL = "Null";
        public const string SCRYPTO_RC2 = "RC2";
        public const string SCRYPTO_RC532 = "RC532";
        public const string SCRYPTO_RC564 = "RC564";
        public const string SCRYPTO_RC6 = "RC6";
        public const string SCRYPTO_RIJNDAEL = "Rijndael";
        public const string SCRYPTO_SEED = "Seed";
        public const string SCRYPTO_SERPENT = "Serpent";
        public const string SCRYPTO_SKIPJACK = "Skipjack";
        public const string SCRYPTO_TEA = "Tea";
        public const string SCRYPTO_TWOFISH = "Twofish";
        public const string SCRYPTO_XTEA = "Xtea";

        public const string SSTREAM_HC128 = "HC128";
        public const string SSTREAM_HC256 = "HC256";
        public const string SSTREAM_ISAAC = "Isaac";
        public const string SSTREAM_RC4 = "RC4";
        public const string SSTREAM_SALSA20 = "Salsa20";
        public const string SSTREAM_VMPC = "Vmpc";
        public const string SSTREAM_VMPCKSA3 = "VmpcKsa3";

        public const int BUF_SIZE = 1024;
    }
}