using System.Security.Cryptography;
using Me.Amon.Sec.M;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;

namespace Me.Amon.Sec.V.Wiz
{
    class Sstream : ICrypto<byte, byte>
    {
        private MSec _MSec;
        private IBlockCipher _Engine;
        private BufferedBlockCipher _Cipher;

        public Sstream()
        {
        }

        #region 接口实现
        public void Init(MSec msec, string pass)
        {
            _MSec = msec;
        }

        public bool DoCrypto(string pass)
        {
            //if (IsText)
            //{
            //    if (string.IsNullOrEmpty(_AText.TbSrc.Text))
            //    {
            //        Main.ShowAlert("请输入您要解密的文本！");
            //        _AText.TbSrc.Focus();
            //        return false;
            //    }

            //    pass = "";
            //}

            //if (_AFile.FileList == null || _AFile.FileList.Count < 1)
            //{
            //    Main.ShowAlert("请选择您要解密的文件！");
            //    _AFile.GvFile.Focus();
            //    return false;
            //}

            //using (SymmetricAlgorithm alg = SymmetricAlgorithm.Create(Algorithm))
            //{
            //    alg.Key = Encoding.UTF8.GetBytes(SafeUtil.GenPass(pass, 32));
            //    alg.IV = Encoding.UTF8.GetBytes(SafeUtil.GenPass(pass, 16));

            //    if (IsText)
            //    {
            //        DecryptText(alg);
            //    }
            //    else
            //    {
            //        DecryptFile(alg);
            //    }
            //}
            return true;
        }
        #endregion

        #region 私有函数
        #endregion

        private bool DecryptFile(SymmetricAlgorithm alg)
        {
            //Items item;
            //for (int i = 0; i < _AFile.FileList.Count; i += 1)
            //{
            //    item = _AFile.FileList[i];
            //    if (item.V.ToLower().EndsWith(".bin"))
            //    {
            //        item.D = item.V.Substring(0, item.V.Length - 4);
            //    }
            //    if (!File.Exists(item.K))
            //    {
            //        continue;
            //    }

            //    FileStream iStream = null;
            //    FileStream oStream = null;
            //    try
            //    {
            //        iStream = File.OpenRead(item.K);
            //        oStream = File.OpenWrite(Path.Combine(Path.GetDirectoryName(item.K), item.D));
            //        CryptoStream cStream = new CryptoStream(oStream, alg.CreateDecryptor(), CryptoStreamMode.Write);
            //        byte[] buf = new byte[4096];
            //        int len = iStream.Read(buf, 0, buf.Length);
            //        while (len > 0)
            //        {
            //            cStream.Write(buf, 0, len);
            //            len = iStream.Read(buf, 0, buf.Length);
            //        }
            //        cStream.FlushFinalBlock();
            //    }
            //    catch (Exception exp)
            //    {
            //        Main.ShowError(null, exp);
            //    }
            //    finally
            //    {
            //        if (oStream != null)
            //        {
            //            oStream.Close();
            //        }
            //        if (iStream != null)
            //        {
            //            iStream.Close();
            //        }
            //    }
            //    alg.Clear();

            //    if (i < _AFile.GvFile.Rows.Count)
            //    {
            //        _AFile.GvFile.Rows[i].Cells[1].Value = item.D;
            //    }
            //}
            return true;
        }

        private bool DecryptText(SymmetricAlgorithm alg)
        {
            //string src = _AText.TbSrc.Text;
            //if (!File.Exists(src))
            //{
            //    return false;
            //}

            //byte[] buf;
            //MemoryStream mStream = new MemoryStream();
            //using (CryptoStream cStream = new CryptoStream(mStream, alg.CreateDecryptor(), CryptoStreamMode.Write))
            //{
            //    buf = CharUtil.DecodeString(src);
            //    cStream.Write(buf, 0, buf.Length);
            //    cStream.FlushFinalBlock();
            //}
            //buf = mStream.ToArray();
            //_AText.TbDst.Text = Encoding.UTF8.GetString(buf);
            //mStream.Close();
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