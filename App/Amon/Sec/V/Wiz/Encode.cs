using System.IO;
using System.Security.Cryptography;
using System.Text;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Sec.V.Wiz
{
    class Encode : ICrypto
    {
        private AFile _AFile;
        private AText _AText;

        public Encode(AFile file, AText text)
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
                    EncryptText(alg);
                }
                else
                {
                    EncryptFile(alg);
                }
            }
            return true;
        }

        private bool EncryptFile(SymmetricAlgorithm alg)
        {
            string src;
            Item item;
            for (int i = 0; i < _AFile.FileList.Count; i += 1)
            {
                item = _AFile.FileList[i];
                item.D = item.V + ".bin";
                src = Path.Combine(item.K, item.V);
                if (!File.Exists(src))
                {
                    continue;
                }

                FileStream iStream = File.OpenRead(src);
                FileStream oStream = File.OpenWrite(Path.Combine(item.K, item.D));
                using (CryptoStream cStream = new CryptoStream(oStream, alg.CreateEncryptor(), CryptoStreamMode.Write))
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

                if (i < _AFile.GvFile.Rows.Count)
                {
                    _AFile.GvFile.Rows[i].Cells[1].Value = item.D;
                }
            }
            return true;
        }

        private bool EncryptText(SymmetricAlgorithm alg)
        {
            string src = _AText.TbSrc.Text;
            if (string.IsNullOrEmpty(src))
            {
                return false;
            }

            byte[] buf;
            MemoryStream mStream = new MemoryStream();
            using (CryptoStream cStream = new CryptoStream(mStream, alg.CreateEncryptor(), CryptoStreamMode.Write))
            {
                buf = Encoding.UTF8.GetBytes(src);
                cStream.Write(buf, 0, buf.Length);
                cStream.FlushFinalBlock();
            }
            buf = mStream.ToArray();
            _AText.TbDst.Text = CharUtil.EncodeString(buf);
            mStream.Close();
            return true;
        }
    }
}
