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
using System.Text.RegularExpressions;

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
                    SignPk(context, writer);
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
            string d = context.Request["d"];
            if (!CharUtil.IsValidate(d))
            {
                SendError(writer, "请输入【登录用户】！");
                return;
            }
            if (!CharUtil.IsValidateName(d))
            {
                SendError(writer, "【登录用户】应在 4 到 32 个字符之间，且仅能为大小写字母、下划线及英文点号！");
                return;
            }

            DBAccess dba = new DBAccess();
            dba.AddTable(DBConst.C3010400);
            dba.AddColumn(DBConst.C3010402);
            dba.AddWhere(DBConst.C3010405, d);
            DataTable dt = dba.ExecuteSelect();
            if (dt.Rows.Count != 1)
            {
                SendError(writer, "请确认您输入的【登录用户】或【登录口令】是否正确！");
                return;
            }
            string code = dt.Rows[0][DBConst.C3010402] as string;
            if (!CharUtil.IsValidateCode(code))
            {
                SendError(writer, "请确认您输入的【登录用户】或【登录口令】是否正确！");
                return;
            }

            dba.ReInit();
            dba.AddTable(DBConst.APWD0000);
            dba.AddColumn(DBConst.APWD0002);
            dba.AddColumn(DBConst.APWD0003);
            dba.AddWhere(DBConst.APWD0001, code);
            dba.AddSort(DBConst.APWD0002, true);
            dt = dba.ExecuteSelect();

            writer.WriteStartElement("User");
            writer.WriteElementString("Code", code);
            foreach (DataRow row in dt.Rows)
            {
                if ("Data" == row[DBConst.APWD0002] as string)
                {
                    writer.WriteElementString("Data", row[DBConst.APWD0003] as string);
                    continue;
                }
                if ("Info" == row[DBConst.APWD0002] as string)
                {
                    writer.WriteElementString("Info", row[DBConst.APWD0003] as string);
                    continue;
                }
                if ("Main" == row[DBConst.APWD0002] as string)
                {
                    writer.WriteElementString("Main", row[DBConst.APWD0003] as string);
                    continue;
                }
                if ("Safe" == row[DBConst.APWD0002] as string)
                {
                    writer.WriteElementString("Safe", row[DBConst.APWD0003] as string);
                    continue;
                }
            }
            writer.WriteEndElement();
        }

        private void SignUp(HttpContext context, XmlWriter writer)
        {
            writer.WriteStartElement("User");

            string d = context.Request["d"];
            if (!CharUtil.IsValidate(d))
            {
                SendError(writer, "网络异常1，请稍后再试！");
                return;
            }

            d = Decrypt(HttpUtil.FromBase64String(d));
            string[] tmp = d.Split('\n');
            if (tmp.Length != 3)
            {
                SendError(writer, "网络异常2，请稍后再试！");
                return;
            }

            string name = HttpUtil.Text2Db(tmp[0]);
            string mail = HttpUtil.Text2Db(tmp[1]);
            string pass = tmp[2];
            UserModel model = new UserModel();
            if (0 != model.WpSignUp(name, pass, mail))
            {
                return;
            }
            model.WsSignUp(name, pass, writer);

            writer.WriteEndElement();
        }

        private void SignPk(HttpContext context, XmlWriter writer)
        {
            string d = context.Request["d"];
            if (!CharUtil.IsValidate(d))
            {
                SendError(writer, "网络异常1，请稍后再试！");
                return;
            }

            d = Decrypt(HttpUtil.FromBase64String(d));
            string[] tmp = d.Split('\n');
            if (tmp.Length != 3)
            {
                SendError(writer, "网络异常2，请稍后再试！");
                return;
            }

            string name = HttpUtil.Text2Db(tmp[0]);
            string oldPass = tmp[1];
            string newPass = tmp[2];
            UserModel userModel = UserModel.Current(context.Session);
            userModel.WpSignPk(oldPass, newPass);
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

        private byte[] Encrypt(byte[] data)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(File.ReadAllText("D:\\rsa.key"));
                return rsa.Encrypt(data, false);
            }
        }

        private string Decrypt(byte[] data)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(File.ReadAllText("D:\\rsa.key"));
                data = rsa.Decrypt(data, false);
            }
            return Encoding.UTF8.GetString(data);
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}