using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;
using Me.Amon.Da;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon
{
    /// <summary>
    /// APwd 的摘要说明
    /// </summary>
    public class APwd : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            context.Response.Charset = "UTF-8";

            string c = context.Request["c"];//用户代码
            string o = context.Request["o"];//操作类型

            XmlWriter writer = XmlWriter.Create(context.Response.Output);
            writer.WriteStartElement("Amon");
            writer.WriteStartElement("APwd");

            switch (o)
            {
                case "rsa":
                    ProcessRSA(writer);
                    break;
                case "sin":
                    SignIn(context, writer);
                    break;
                case "sup":
                    SignUp(context, writer);
                    break;
                case "spk":
                    SignPk(context);
                    break;
                case "ssk":
                    SignSk(context);
                    break;
                case "sfk":
                    SignFk(context);
                    break;
                case "cat":
                    ProcessCat(context, writer, c);
                    break;
                case "lib":
                    ProcessLib(context, writer, c);
                    break;
                case "udc":
                    ProcessUdc(context, writer, c);
                    break;
                case "key":
                    ProcessKey(context, writer, c);
                    break;
                default:
                    writer.WriteElementString("Error", "无效的操作类型：" + o);
                    break;
            }

            writer.WriteEndElement();
            writer.WriteEndElement();

            writer.Flush();
            writer.Close();
        }

        #region 事件分发
        private void ProcessCat(HttpContext context, XmlWriter writer, string code)
        {
            string d = context.Request["d"];//操作数据
            ListCat(new DBAccess(), writer, code, d);
        }

        private void ProcessLib(HttpContext context, XmlWriter writer, string code)
        {
            ListLib(new DBAccess(), writer, code);
        }

        private void ProcessUdc(HttpContext context, XmlWriter writer, string code)
        {
            ListUdc(new DBAccess(), writer, code);
        }

        private void ProcessKey(HttpContext context, XmlWriter writer, string code)
        {
            string d = context.Request["d"];//操作数据
            ListKey(code, d);
        }
        #endregion

        #region 数据下载
        private void ListCat(DBAccess dba, XmlWriter writer, string code, string catId)
        {
            dba.ReInit();
            dba.AddTable(DBConst.ACAT0200);
            dba.AddColumn(DBConst.ACAT0201);
            dba.AddColumn(DBConst.ACAT0203);
            dba.AddColumn(DBConst.ACAT0204);
            dba.AddColumn(DBConst.ACAT0205);
            dba.AddColumn(DBConst.ACAT0206);
            dba.AddColumn(DBConst.ACAT0207);
            dba.AddColumn(DBConst.ACAT0208);
            dba.AddColumn(DBConst.ACAT0209);
            dba.AddWhere(DBConst.ACAT0202, code);
            if (catId == "0" || CharUtil.IsValidateHash(catId))
            {
                dba.AddWhere(DBConst.ACAT0204, catId);
            }
            dba.AddWhere(DBConst.ACAT020D, ">", Cat.OPT_DELETE.ToString(), false);

            writer.WriteStartElement("Cats");
            using (DataTable dt = dba.ExecuteSelect())
            {
                Cat cat = new Cat();
                foreach (DataRow row in dt.Rows)
                {
                    cat.Load(row);
                    cat.ToXml(writer);
                }
            }
            writer.WriteEndElement();
        }

        private void ListLib(DBAccess dba, XmlWriter writer, string code)
        {
            dba.ReInit();
            dba.AddTable(DBConst.APWD0300);
            dba.AddColumn(DBConst.APWD0304);
            dba.AddColumn(DBConst.APWD0306);
            dba.AddColumn(DBConst.APWD0308);
            dba.AddWhere(DBConst.APWD0302, "0");
            dba.AddWhere(DBConst.APWD0303, code);
            dba.AddSort(DBConst.APWD0301, true);

            writer.WriteStartElement("Libs");
            using (DataTable dt1 = dba.ExecuteSelect())
            {
                foreach (DataRow r1 in dt1.Rows)
                {
                    LibHeader header = new LibHeader();
                    header.Load(r1);

                    dba.ReInit();
                    dba.AddTable(DBConst.APWD0300);
                    dba.AddColumn(DBConst.APWD0302);
                    dba.AddColumn(DBConst.APWD0304);
                    dba.AddColumn(DBConst.APWD0306);
                    dba.AddColumn(DBConst.APWD0307);
                    dba.AddColumn(DBConst.APWD0308);
                    dba.AddWhere(DBConst.APWD0305, header.Id);
                    dba.AddWhere(DBConst.APWD0303, code);
                    dba.AddSort(DBConst.APWD0301, true);

                    DataTable dt2 = dba.ExecuteSelect();
                    foreach (DataRow r2 in dt2.Rows)
                    {
                        LibDetail detail = new LibDetail();
                        detail.Load(r2);
                        header.Details.Add(detail);
                    }
                    header.ToXml(writer);
                }
            }
            writer.WriteEndElement();
        }

        private void ListUdc(DBAccess dba, XmlWriter writer, string code)
        {
            dba.ReInit();
            dba.AddTable(DBConst.AUCS0100);
            dba.AddColumn(DBConst.AUCS0103);
            dba.AddColumn(DBConst.AUCS0104);
            dba.AddColumn(DBConst.AUCS0105);
            dba.AddColumn(DBConst.AUCS0106);
            dba.AddColumn(DBConst.AUCS0107);
            dba.AddWhere(DBConst.AUCS0102, code);
            dba.AddSort(DBConst.AUCS0101, true);

            writer.WriteStartElement("Udcs");
            using (DataTable dt = dba.ExecuteSelect())
            {
                foreach (DataRow row in dt.Rows)
                {
                    Udc item = new Udc();
                    item.Load(row);
                    item.ToXml(writer);
                }
            }
            writer.WriteEndElement();
        }

        private void ListKey(string code, string catId)
        {
            DBAccess dba = new DBAccess();
            dba.ReInit();
            dba.AddTable(DBConst.APWD0100);
            dba.AddWhere(DBConst.APWD0104, code);
            dba.AddWhere(DBConst.APWD0106, catId);
            dba.AddWhere(DBConst.APWD0115, "!=", Key.OPT_DELETE.ToString(), false);
            dba.AddSort(DBConst.APWD0101, false);
            using (DataTable d1 = dba.ExecuteSelect())
            {
                foreach (DataRow r1 in d1.Rows)
                {
                    Key key = new Key();
                    key.Load(r1);

                    dba.ReInit();
                    dba.AddTable(DBConst.APWD0200);
                    dba.AddColumn(DBConst.APWD0204);
                    dba.AddWhere(DBConst.APWD0202, code);
                    dba.AddWhere(DBConst.APWD0203, key.Id);
                    dba.AddSort(DBConst.APWD0201, true);
                    using (DataTable d2 = dba.ExecuteSelect())
                    {
                        StringBuilder buffer = new StringBuilder();
                        foreach (DataRow r2 in d2.Rows)
                        {
                            buffer.Append(r2[DBConst.APWD0204] as string);
                        }
                        key.Password = buffer.ToString();
                    }
                }
            }
        }
        #endregion

        #region 数据确认
        private Cat ReadCat(DBAccess dba, string code, string catId)
        {
            return null;
        }
        #endregion

        #region 数据同步
        private void SyncCat(DBAccess dba, XmlDocument reader, string code)
        {
            Cat newCat = new Cat();
            if (!newCat.FromXml(reader))
            {
                SendError(null, "类别数据解析错误！");
                return;
            }

            Cat oldCat = ReadCat(dba, code, newCat.Id);
            if (oldCat == null)
            {
                // 追加
                newCat.Save(dba, false);
                return;
            }

            // 版本过低
            if (newCat.Version <= oldCat.Version)
            {
                SendError(null, "类别数据版本冲突！");
                return;
            }

            newCat.Save(dba, true);
        }

        private void SyncLib(DBAccess dba, XmlDocument reader, string code)
        {
        }

        private void SyncUdc(DBAccess dba, XmlDocument reader, string code)
        {
        }

        private void SyncKey(DBAccess dba, XmlDocument reader, string code)
        {
        }
        #endregion

        #region 用户信息
        private void SignIn(HttpContext context, XmlWriter writer)
        {
        }

        private void SignUp(HttpContext context, XmlWriter writer)
        {
            string d = context.Request["d"];
            if (!CharUtil.IsValidate(d))
            {
                SendError(writer, "网络异常1，请稍后再试！");
                return;
            }

            #region 身份信息
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(File.ReadAllText("D:\\rsa.key"));
            byte[] b = rsa.Decrypt(HttpUtil.FromBase64String(d), false);
            d = Encoding.UTF8.GetString(b);
            string[] tmp = d.Split('\n');
            if (tmp.Length != 3)
            {
                SendError(writer, "网络异常2，请稍后再试！");
                return;
            }
            #endregion

            string code = "";
            string name = HttpUtil.Text2Db(tmp[0]);
            string mail = HttpUtil.Text2Db(tmp[1]);
            string pass = tmp[2];
            string info = "";
            UserModel model = new UserModel();
            if (!model.SignUp(name, pass, mail, out code, out info))
            {
                return;
            }

            model.SignWs(code, name, pass,out d);

            writer.WriteElementString("Code", code);
            writer.WriteElementString("Info", info);
            writer.WriteElementString("Data", d);
        }

        private void SignPk(HttpContext context)
        {
        }

        private void SignSk(HttpContext context)
        {
        }

        private void SignFk(HttpContext context)
        {
        }

        #endregion

        #region 安全处理
        private void ProcessRSA(XmlWriter writer)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string key = rsa.ToXmlString(true);
            File.WriteAllText("D:\\rsa.key", key);

            writer.WriteStartElement("RSA");
            writer.WriteElementString("t", DateTime.UtcNow.ToFileTime().ToString());
            writer.WriteElementString("k", rsa.ToXmlString(false));
            writer.WriteEndElement();
        }

        private byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Import the RSA Key information. This only needs
                    //toinclude the public key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Encrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                //Console.WriteLine(e.Message);

                return null;
            }

        }

        private byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    //Import the RSA Key information. This needs
                    //to include the private key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Decrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                //Console.WriteLine(e.ToString());

                return null;
            }

        }
        #endregion

        private static void SendError(XmlWriter writer, string error)
        {
            writer.WriteElementString("Error", error);
        }

        private static byte[] GenK(string name, string code, string pass)
        {
            return Digest(name + '@' + code + "&Amon.Me/" + pass);
        }

        private static byte[] GenV(string name, string code, string pass)
        {
            return Encoding.UTF8.GetBytes(code + "@Amon.Me");
        }

        private static string Digest(string name, string pass)
        {
            return Convert.ToBase64String(Digest(name + '%' + pass + "@Amon"));
        }

        private static byte[] Digest(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }
            byte[] temp = Encoding.UTF8.GetBytes(data);
            return HashAlgorithm.Create("SHA256").ComputeHash(temp);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}