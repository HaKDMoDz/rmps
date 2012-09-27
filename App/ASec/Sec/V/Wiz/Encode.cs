using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Sec.V.Wiz
{
    class Encode : ICrypto
    {
        public Encode()
        {
            //_AFile = file;
            //_AText = text;
        }

        public void Init()
        {
            if (IsText)
            {
                return;
            }

            //_AFile.ClSrc.HeaderText = "输入文件";
            //_AFile.ClDst.HeaderText = "输出文件";
        }

        public bool IsText { get; set; }

        public string Algorithm { get; set; }

        public bool DoCrypto(string pass)
        {
            //if (IsText)
            //{
            //    if (string.IsNullOrEmpty(_AText.TbSrc.Text))
            //    {
            //        Main.ShowAlert("请输入您要加密的文本！");
            //        _AText.TbSrc.Focus();
            //        return false;
            //    }

            //    pass = "";
            //}

            //if (_AFile.FileList == null || _AFile.FileList.Count < 1)
            //{
            //    Main.ShowAlert("请选择您要加密的文件！");
            //    _AFile.GvFile.Focus();
            //    return false;
            //}

            //using (SymmetricAlgorithm alg = SymmetricAlgorithm.Create(Algorithm))
            //{
            //    alg.Key = Encoding.UTF8.GetBytes(SafeUtil.GenPass(pass, 32));
            //    alg.IV = Encoding.UTF8.GetBytes(SafeUtil.GenPass(pass, 16));

            //    if (IsText)
            //    {
            //        EncryptText(alg);
            //    }
            //    else
            //    {
            //        EncryptFile(alg);
            //    }
            //}
            return true;
        }

        private bool EncryptFile(SymmetricAlgorithm alg)
        {
            //Items item;
            //for (int i = 0; i < _AFile.FileList.Count; i += 1)
            //{
            //    item = _AFile.FileList[i];
            //    item.D = item.V + ".bin";
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
            //        CryptoStream cStream = new CryptoStream(oStream, alg.CreateEncryptor(), CryptoStreamMode.Write);
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

            //    if (i < _AFile.GvFile.Rows.Count)
            //    {
            //        _AFile.GvFile.Rows[i].Cells[1].Value = item.D;
            //    }
            //}
            return true;
        }

        private bool EncryptText(SymmetricAlgorithm alg)
        {
            //string src = _AText.TbSrc.Text;
            //if (string.IsNullOrEmpty(src))
            //{
            //    return false;
            //}

            //byte[] buf;
            //MemoryStream mStream = new MemoryStream();
            //using (CryptoStream cStream = new CryptoStream(mStream, alg.CreateEncryptor(), CryptoStreamMode.Write))
            //{
            //    buf = Encoding.UTF8.GetBytes(src);
            //    cStream.Write(buf, 0, buf.Length);
            //    cStream.FlushFinalBlock();
            //}
            //buf = mStream.ToArray();
            //_AText.TbDst.Text = CharUtil.EncodeString(buf);
            //mStream.Close();
            return true;
        }
    }
}