using System.IO;
using System.Security.Cryptography;
using System.Text;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Sec.V.Wiz
{
    class Digest : ICrypto
    {
        private AFile _AFile;
        private AText _AText;

        public Digest(AFile file, AText text)
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
            if (IsText)
            {
                return DigestText();
            }

            if (_AFile.FileList == null || _AFile.FileList.Count < 1)
            {
                return false;
            }

            Item item;
            for (int i = 0; i < _AFile.FileList.Count; i += 1)
            {
                item = _AFile.FileList[i];
                if (DigestFile(item))
                {
                }
            }
            return true;
        }

        private bool DigestFile(Item item)
        {
            string src = Path.Combine(item.K, item.V);
            if (!File.Exists(src))
            {
                return false;
            }

            using (HashAlgorithm alg = HashAlgorithm.Create(Algorithm))
            {
                FileStream stream = File.OpenRead(src);
                byte[] buf = alg.ComputeHash(stream);
                stream.Close();
                item.D = CharUtil.EncodeString(buf);
            }
            return true;
        }

        private bool DigestText()
        {
            string src = _AText.TbSrc.Text;
            if (string.IsNullOrEmpty(src))
            {
                return false;
            }

            using (HashAlgorithm alg = HashAlgorithm.Create(Algorithm))
            {
                byte[] buf = Encoding.UTF8.GetBytes(src);
                buf = alg.ComputeHash(buf);
                _AText.TbDst.Text = CharUtil.EncodeString(buf);
            }
            return true;
        }
    }
}
