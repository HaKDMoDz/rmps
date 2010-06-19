using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Services;

using cons;
using cons.io.db.prp;
using cons.wrp.exts;

using rmp.comn;
using rmp.io.db;
using rmp.util;

namespace rmp.wrp.exts
{
    /// <summary>
    /// Exts0001 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://amonsoft.cn/exts/", Description = "")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Exts0001 : WebService
    {
        /// <summary>
        /// 后缀解析专用
        /// </summary>
        /// <param name="user">用户名称</param>
        /// <param name="pwds">身份认证</param>
        /// <param name="exts">后缀名称</param>
        /// <param name="mime">MIME类型</param>
        /// <param name="desp">后缀说明</param>
        /// <param name="file">文件图标</param>
        /// <returns>是否添加成功</returns>
        [WebMethod]
        public bool exts(String user, String pwds, String exts, String mime, String desp, byte[][] file)
        {
            // 身份认证
            if (pwds == null || pwds != "5p39mfkCZQ6oKtK9fQfHtIaxydVdz7JU")
            {
                return false;
            }

            // 后缀检测
            if (!StringUtil.isValidate(exts))
            {
                return false;
            }

            exts = exts.Trim(' ', '.');
            if (exts == "" || exts == ".")
            {
                return false;
            }
            if (exts[0] == '.')
            {
                exts = exts.Substring(1);
            }

            // 贡献用户
            if (!StringUtil.isValidate(user))
            {
                user = "User";
            }

            // 数据是否存在
            String extsHash = HashUtil.digest(exts, false);
            DBAccess dba = new DBAccess();
            dba.addTable(PrpCons.P3010000);
            dba.addColumn(PrpCons.P3010001);
            dba.addWhere(PrpCons.P3010003, extsHash);

            DataTable dataList = dba.executeSelect();
            if (dataList != null && dataList.Rows.Count > 0)
            {
                return false;
            }

            // 添加基本信息
            String fileHash = HashUtil.getCurrTimeHex(false);
            Bean extsBase = new Bean();
            extsBase.P3010002 = SysCons.BITS_IDX_32;
            extsBase.P3010003 = extsHash;
            extsBase.P3010013 = '.' + exts;
            extsBase.P3010004 = "0";
            extsBase.P3010005 = "0";
            extsBase.P3010006 = "0";
            extsBase.P3010007 = fileHash;
            extsBase.P3010008 = "0";
            extsBase.P3010009 = "0";
            extsBase.P301000A = "0";
            extsBase.P301000C = "0";
            extsBase.P301000F = "sctvzvsyvrcfzvrt";
            String mimeHash = Exts.SaveBase(extsBase);

            // 添加文件信息
            dba.reset();
            String fileIcon = HashUtil.getCurrTimeHex(true);
            dba.addTable(PrpCons.P3010300);
            dba.addParam(PrpCons.P3010301, 0);
            dba.addParam(PrpCons.P3010302, fileHash);
            dba.addParam(PrpCons.P3010303, "0");
            dba.addParam(PrpCons.P3010304, fileIcon);
            dba.addParam(PrpCons.P3010305, "");
            dba.addParam(PrpCons.P3010306, '(' + exts + ')');
            dba.addParam(PrpCons.P3010307, 0);
            dba.addParam(PrpCons.P3010308, "");
            dba.addParam(PrpCons.P3010309, "");
            dba.addParam(PrpCons.P301030A, "");
            dba.addParam(PrpCons.P301030B, "");
            dba.addParam(PrpCons.P301030C, "");
            dba.addParam(PrpCons.P301030D, EnvCons.SQL_NOW, false);
            dba.addParam(PrpCons.P301030E, EnvCons.SQL_NOW, false);
            dba.executeInsert();

            // 添加后缀描述
            dba.reset();
            dba.addTable(PrpCons.P3010500);
            dba.addParam(PrpCons.P3010501, mimeHash);
            dba.addParam(PrpCons.P3010502, SysCons.UI_LANGHASH);
            dba.addParam(PrpCons.P3010503, WrpUtil.text2Db(desp));
            dba.addParam(PrpCons.P3010504, "");
            dba.addParam(PrpCons.P3010505, EnvCons.SQL_NOW, false);
            dba.addParam(PrpCons.P3010506, EnvCons.SQL_NOW, false);
            dba.executeInsert();

            // 保存文件图标
            if (file != null)
            {
                String path = HttpContext.Current.Server.MapPath("~/exts/file/");
                foreach (byte[] b in file)
                {
                    if (b == null || b.Length < 1)
                    {
                        continue;
                    }
                    MemoryStream ms = new MemoryStream(b.Length);
                    ms.Write(b, 0, b.Length);
                    Image img = Image.FromStream(ms);
                    img.Save(path + fileIcon + Convert.ToString(img.Width, 16).PadLeft(4, '0') + ".png", ImageFormat.Png);
                    ms.Close();
                }
            }

            // 添加MIME信息
            if (!StringUtil.isValidate(mime))
            {
                return true;
            }

            dba.reset();
            dba.addTable(PrpCons.P301F100);
            dba.addColumn(PrpCons.P301F102);
            dba.addWhere(PrpCons.P301F104, mime);
            dataList = dba.executeSelect();

            String mimeType;
            if (dataList == null || dataList.Rows.Count < 1)
            {
                // 添加MIME数据
                mimeType = HashUtil.getCurrTimeHex(false);

                dba.reset();
                dba.addTable(PrpCons.P301F100);
                dba.addParam(PrpCons.P301F101, 0);
                dba.addParam(PrpCons.P301F102, mimeType);
                dba.addParam(PrpCons.P301F103, SysCons.UI_LANGHASH);
                dba.addParam(PrpCons.P301F104, mime);
                dba.addParam(PrpCons.P301F105, "");
                dba.addParam(PrpCons.P301F106, "");
                dba.addParam(PrpCons.P301F107, EnvCons.SQL_NOW, false);
                dba.addParam(PrpCons.P301F108, EnvCons.SQL_NOW, false);
                dba.executeInsert();
            }
            else
            {
                mimeType = dataList.Rows[0][PrpCons.P301F102].ToString();
            }

            // 添加MIME类型数据
            dba.reset();
            dba.addTable(PrpCons.P3010600);
            dba.addParam(PrpCons.P3010601, 0);
            dba.addParam(PrpCons.P3010602, mimeHash);
            dba.addParam(PrpCons.P3010603, mimeType);
            dba.addParam(PrpCons.P3010604, "");
            dba.addParam(PrpCons.P3010605, EnvCons.SQL_NOW, false);
            dba.addParam(PrpCons.P3010606, EnvCons.SQL_NOW, false);
            dba.executeInsert();
            return true;
        }
    }
}