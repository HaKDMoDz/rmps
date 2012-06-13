using System.IO;
using System.Security.Cryptography;
using System.Text;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Sec.V.Wiz
{
    class Decode : ICrypto
    {
        private AFile _AFile;
        private AText _AText;
        public Decode(AFile file, AText text)
        {
            _AFile = file;
            _AText = text;
        }

        public void Init()
        {
            if (IsText)
            {
                return;
            }

            _AFile.ClSrc.HeaderText = "输入文件";
            _AFile.ClDst.HeaderText = "输出文件";
            _AFile.LlData.Text = "口令(&K)";
        }

        public bool IsText { get; set; }

        public string Algorithm { get; set; }

        public bool DoCrypto()
        {
            if (IsText && string.IsNullOrEmpty(_AText.TbSrc.Text))
            {
                return false;
            }

            if (_AFile.FileList == null || _AFile.FileList.Count < 1)
            {
                return false;
            }

            using (SymmetricAlgorithm alg = SymmetricAlgorithm.Create(Algorithm))
            {
                alg.Key = null;
                alg.IV = null;

                if (IsText)
                {
                    DecryptFile(alg);
                }
                else
                {
                    DecryptText(alg);
                }
            }
            return true;
        }

        private bool DecryptFile(SymmetricAlgorithm alg)
        {
            string src;
            foreach (Item item in _AFile.FileList)
            {
                if (item.V.ToLower().EndsWith(".bin"))
                {
                    item.D = item.V.Substring(0, item.V.Length - 4);
                }
                src = Path.Combine(item.K, item.V);
                if (!File.Exists(src))
                {
                    continue;
                }

                FileStream iStream = File.OpenRead(src);
                FileStream oStream = File.OpenWrite(Path.Combine(item.K, item.D));
                using (CryptoStream cStream = new CryptoStream(oStream, alg.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    byte[] buf = new byte[4096];
                    int len = iStream.Read(buf, 0, buf.Length);
                    while (len > 0)
                    {
                        cStream.Write(buf, 0, len);
                    }
                    cStream.FlushFinalBlock();
                }
                oStream.Close();
                iStream.Close();
                alg.Clear();
            }
            return true;
        }

        private bool DecryptText(SymmetricAlgorithm alg)
        {
            string src = _AText.TbSrc.Text;
            if (!File.Exists(src))
            {
                return false;
            }

            byte[] buf;
            MemoryStream mStream = new MemoryStream();
            using (CryptoStream cStream = new CryptoStream(mStream, alg.CreateDecryptor(), CryptoStreamMode.Write))
            {
                buf = CharUtil.DecodeString(src);
                cStream.Write(buf, 0, buf.Length);
                cStream.FlushFinalBlock();
            }
            buf = mStream.ToArray();
            _AText.TbDst.Text = Encoding.UTF8.GetString(buf);
            mStream.Close();
            return true;
        }
    }
}
