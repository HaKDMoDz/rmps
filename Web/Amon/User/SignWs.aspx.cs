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