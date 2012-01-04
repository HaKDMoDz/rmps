using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;

namespace Msec.Uc.UkUi
{
    public class SecKey
    {
        public void ad()
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
            if (((RsaKeyParameters)publicKey).Modulus.BitLength < 1024)
            {
                Console.WriteLine("failed key generation (1024) length test");
            }

            //一个测试……………………  
            //输入，十六进制的字符串，解码为byte[]  
            //string input = "4e6f77206973207468652074696d6520666f7220616c6c20676f6f64206d656e";  
            //byte[] testData = Org.BouncyCastle.Utilities.Encoders.Hex.Decode(input);             
            string input = "popozh RSA test";
            byte[] testData = Encoding.UTF8.GetBytes(input);
            Console.WriteLine("明文:" + input + Environment.NewLine);
            //非对称加密算法，加解密用  
            IAsymmetricBlockCipher engine = new RsaEngine();
            //公钥加密  
            engine.Init(true, publicKey);
            try
            {
                testData = engine.ProcessBlock(testData, 0, testData.Length);
                Console.WriteLine("密文（base64编码）:" + Convert.ToBase64String(testData) + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed - exception " + Environment.NewLine + ex.ToString());
            }
            //私钥解密  
            engine.Init(false, privateKey);
            try
            {
                testData = engine.ProcessBlock(testData, 0, testData.Length);

            }
            catch (Exception e)
            {
                Console.WriteLine("failed - exception " + e.ToString());
            }
            if (input.Equals(Encoding.UTF8.GetString(testData)))
            {
                Console.WriteLine("解密成功");
            }
            Console.Read();
        }
    }
}
