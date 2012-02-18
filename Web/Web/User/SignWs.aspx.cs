using System;
using System.Data;
using System.Text;
using System.Xml;
using Me.Amon.Da;
using Me.Amon.Model;

namespace Me.Amon.User
{
    public partial class SignWs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserModel userModel = UserModel.Current(Session);
            if (userModel.Rank < IUser.LEVEL_02)
            {
                Response.Redirect("~/Index.aspx");
                return;
            }

            if (IsPostBack)
            {
                return;
            }

            DBAccess dba = new DBAccess();
            dba.AddTable(DBConst.APWD0000);
            dba.AddColumn(DBConst.APWD0002);
            dba.AddColumn(DBConst.APWD0003);
            dba.AddWhere(DBConst.APWD0001, userModel.Code);
            dba.AddSort(DBConst.APWD0002, true);
            DataTable dt = dba.ExecuteSelect();
            if (dt.Rows.Count != 4)
            {
                TrRegInfo.Visible = false;
                return;
            }

            TrRegData1.Visible = false;
            TrRegData2.Visible = false;

            StringBuilder buffer = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(buffer);
            writer.WriteStartElement("Amon");
            writer.WriteStartElement("User");
            writer.WriteElementString("Code", userModel.Code);
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
            writer.WriteEndElement();
            writer.Flush();
            writer.Close();

            TBData.Text = buffer.Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"").ToString();
        }

        protected void BtSignWs_Click(object sender, EventArgs e)
        {
            string userPwds = TbPass1.Text;
            if (string.IsNullOrEmpty(userPwds))
            {
                LbErrMsg.Text = "请输入【登录口令】！";
                TrErrMsg.Attributes.Add("style", "display:;");
                TbPass1.Focus();
                return;
            }
            if (userPwds.Length < 4)
            {
                LbErrMsg.Text = "【登录口令】字符串长度不能小于 4 位！";
                TrErrMsg.Attributes.Add("style", "display:;");
                TbPass1.Focus();
                return;
            }
            if (userPwds != TbPass2.Text)
            {
                LbErrMsg.Text = "您两次输入的口令不一致，请重新输入！";
                TrErrMsg.Attributes.Add("style", "display:;");
                TbPass1.Text = "";
                TbPass2.Text = "";
                TbPass1.Focus();
                return;
            }

            StringBuilder buffer = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(buffer);
            writer.WriteStartElement("Amon");
            writer.WriteStartElement("User");

            UserModel userModel = UserModel.Current(Session);
            if (!userModel.WsSignUp(userModel.Name, userPwds, writer))
            {
                LbErrMsg.Text = "用户注册失败，请稍后重试！";
                TrErrMsg.Attributes.Add("style", "display:;");
                return;
            }

            #region 数据初始化
            DBAccess dba = new DBAccess();
            dba.AddTable(DBConst.ACAT0200);
            dba.AddWhere(DBConst.ACAT0202, userModel.Code);
            dba.AddDeleteBatch();

            dba.ReInit();
            dba.AddParam(DBConst.ACAT0201, DBConst.ACAT0201, false);
            dba.AddParam(DBConst.ACAT0202, userModel.Code);
            dba.AddParam(DBConst.ACAT0203, DBConst.ACAT0203, false);
            dba.AddParam(DBConst.ACAT0204, DBConst.ACAT0204, false);
            dba.AddParam(DBConst.ACAT0205, DBConst.ACAT0205, false);
            dba.AddParam(DBConst.ACAT0206, DBConst.ACAT0206, false);
            dba.AddParam(DBConst.ACAT0207, DBConst.ACAT0207, false);
            dba.AddParam(DBConst.ACAT0208, DBConst.ACAT0208, false);
            dba.AddParam(DBConst.ACAT0209, DBConst.ACAT0209, false);
            dba.AddParam(DBConst.ACAT020A, DBConst.ACAT020A, false);
            dba.AddParam(DBConst.ACAT020B, DBConst.ACAT020B, false);
            dba.AddParam(DBConst.ACAT020C, 1);
            dba.AddParam(DBConst.ACAT020D, 1);
            dba.AddWhere(DBConst.ACAT0202, IUser.AMON_CODE);
            dba.AddBackupBatch(DBConst.ACAT0200, DBConst.ACAT0200);

            dba.ReInit();
            dba.AddTable(DBConst.APWD0300);
            dba.AddWhere(DBConst.APWD0303, userModel.Code);
            dba.AddDeleteBatch();

            dba.ReInit();
            dba.AddParam(DBConst.APWD0301, DBConst.APWD0301, false);
            dba.AddParam(DBConst.APWD0302, DBConst.APWD0302, false);
            dba.AddParam(DBConst.APWD0303, userModel.Code);
            dba.AddParam(DBConst.APWD0304, DBConst.APWD0304, false);
            dba.AddParam(DBConst.APWD0305, DBConst.APWD0305, false);
            dba.AddParam(DBConst.APWD0306, DBConst.APWD0306, false);
            dba.AddParam(DBConst.APWD0307, DBConst.APWD0307, false);
            dba.AddParam(DBConst.APWD0308, DBConst.APWD0308, false);
            dba.AddParam(DBConst.APWD0309, DBConst.APWD0309, false);
            dba.AddParam(DBConst.APWD030A, DBConst.APWD030A, false);
            dba.AddParam(DBConst.APWD030B, 1);
            dba.AddParam(DBConst.APWD030C, 1);
            dba.AddWhere(DBConst.APWD0303, IUser.AMON_CODE);
            dba.AddBackupBatch(DBConst.APWD0300, DBConst.APWD0300);

            dba.ReInit();
            dba.AddTable(DBConst.AUDC0100);
            dba.AddWhere(DBConst.AUDC0102, userModel.Code);
            dba.AddDeleteBatch();

            dba.ReInit();
            dba.AddParam(DBConst.AUDC0101, DBConst.AUDC0101, false);
            dba.AddParam(DBConst.AUDC0102, userModel.Code);
            dba.AddParam(DBConst.AUDC0103, DBConst.AUDC0103, false);
            dba.AddParam(DBConst.AUDC0104, DBConst.AUDC0104, false);
            dba.AddParam(DBConst.AUDC0105, DBConst.AUDC0105, false);
            dba.AddParam(DBConst.AUDC0106, DBConst.AUDC0106, false);
            dba.AddParam(DBConst.AUDC0107, DBConst.AUDC0107, false);
            dba.AddParam(DBConst.AUDC0108, DBConst.AUDC0108, false);
            dba.AddParam(DBConst.AUDC0109, DBConst.AUDC0109, false);
            dba.AddParam(DBConst.AUDC010A, 1);
            dba.AddParam(DBConst.AUDC010B, 1);
            dba.AddWhere(DBConst.AUDC0102, IUser.AMON_CODE);
            dba.AddBackupBatch(DBConst.AUDC0100, DBConst.AUDC0100);

            dba.ExecuteBatch();
            #endregion

            TrRegData1.Visible = false;
            TrRegData2.Visible = false;
            TrRegInfo.Visible = true;

            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Flush();
            writer.Close();

            TBData.Text = buffer.Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"").ToString();
        }
    }
}