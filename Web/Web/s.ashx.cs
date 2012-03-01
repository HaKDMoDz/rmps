using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;
using Me.Amon.Bean;
using Me.Amon.Da;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon
{
    /// <summary>
    /// s 的摘要说明
    /// </summary>
    public class s : IHttpHandler
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
            dba.AddTable(DBConst.AUDC0100);
            dba.AddColumn(DBConst.AUDC0103);
            dba.AddColumn(DBConst.AUDC0104);
            dba.AddColumn(DBConst.AUDC0105);
            dba.AddColumn(DBConst.AUDC0106);
            dba.AddColumn(DBConst.AUDC0107);
            dba.AddWhere(DBConst.AUDC0102, code);
            dba.AddSort(DBConst.AUDC0101, true);

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
        private void SyncCat(DBAccess dba, XmlReader reader, string code)
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
            if (dt.Rows.Count < 1)
            {
                writer.WriteElementString("Error", "请确认您是否已经开通密码箱的功能！");
                return;
            }

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
            string t = context.Request["t"];
            if (!CharUtil.IsValidateHash(t))
            {
                SendError(writer, "无效的句柄！");
                return;
            }
            string d = context.Request["d"];
            if (!CharUtil.IsValidate(d))
            {
                SendError(writer, "无效的密文！");
                return;
            }

            d = Decrypt(t, HttpUtil.FromBase64String(d));
            string[] tmp = d.Split('\n');
            if (tmp.Length != 3)
            {
                SendError(writer, "无效的密文！");
                return;
            }

            string name = HttpUtil.Text2Db(tmp[0]);
            string mail = HttpUtil.Text2Db(tmp[1]);
            string pass = tmp[2];
            UserModel model = new UserModel();
            if (IMsg.MSG_SIGNUP_SUCCESS != model.WpSignUp(name, pass, mail))
            {
                SendError(writer, "系统处理异常，请稍后重试！");
                return;
            }

            writer.WriteStartElement("User");
            model.WsSignUp(name, pass, writer);
            writer.WriteEndElement();
        }

        private void SignPk(HttpContext context, XmlWriter writer)
        {
            string t = context.Request["t"];
            if (!CharUtil.IsValidateHash(t))
            {
                SendError(writer, "无效的句柄！");
                return;
            }
            string d = context.Request["d"];
            if (!CharUtil.IsValidate(d))
            {
                SendError(writer, "无效的密文！");
                return;
            }

            d = Decrypt(t, HttpUtil.FromBase64String(d));
            string[] tmp = d.Split('\n');
            if (tmp.Length != 3)
            {
                SendError(writer, "无效的密文！");
                return;
            }

            string name = HttpUtil.Text2Db(tmp[0]);
            string oldPass = tmp[1];
            string newPass = tmp[2];
            UserModel userModel = new UserModel();
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
            string t = HashUtil.UtcTimeInHex();

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            DBAccess dba = new DBAccess();
            dba.AddTable(DBConst.C3010000);
            dba.AddParam(DBConst.C3010001, t);
            dba.AddParam(DBConst.C3010002, DBConst.SQL_NOW, false);
            dba.AddParam(DBConst.C3010003, CharUtil.Text2DB(rsa.ToXmlString(true)));
            dba.AddParam(DBConst.C3010004, 0);
            dba.ExecuteInsert();

            writer.WriteStartElement("RSA");
            writer.WriteElementString("t", t);
            writer.WriteElementString("k", rsa.ToXmlString(false));
            writer.WriteEndElement();
        }

        private byte[] Encrypt(string t, byte[] data)
        {
            DBAccess dba = new DBAccess();
            dba.AddTable(DBConst.C3010000);
            dba.AddColumn(DBConst.C3010003);
            dba.AddWhere(DBConst.C3010001, CharUtil.Text2DB(t));
            dba.AddWhere(DBConst.C3010004, "0");
            DataTable dt = dba.ExecuteSelect();
            if (dt.Rows.Count != 1)
            {
                return null;
            }
            string key = dt.Rows[0][0] as string;

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(key);
                data = rsa.Encrypt(data, false);
            }

            dba.ReInit();
            dba.AddTable(DBConst.C3010000);
            dba.AddParam(DBConst.C3010004, 1);
            dba.AddWhere(DBConst.C3010001, CharUtil.Text2DB(t));
            dba.AddWhere(DBConst.C3010004, "0", false);
            dba.ExecuteUpdate();

            return data;
        }

        private string Decrypt(string t, byte[] data)
        {
            DBAccess dba = new DBAccess();
            dba.AddTable(DBConst.C3010000);
            dba.AddColumn(DBConst.C3010003);
            dba.AddWhere(DBConst.C3010001, CharUtil.Text2DB(t));
            dba.AddWhere(DBConst.C3010004, "0", false);
            DataTable dt = dba.ExecuteSelect();
            if (dt.Rows.Count != 1)
            {
                return null;
            }
            string key = dt.Rows[0][0] as string;

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(key);
                data = rsa.Decrypt(data, false);
            }

            dba.ReInit();
            dba.AddTable(DBConst.C3010000);
            dba.AddParam(DBConst.C3010004, 1);
            dba.AddWhere(DBConst.C3010001, CharUtil.Text2DB(t));
            dba.AddWhere(DBConst.C3010004, "0", false);
            dba.ExecuteUpdate();

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

        #region 共用函数
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
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}