using System;
using System.IO;
using System.Net;
using Me.Amon.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.M
{
    public sealed class UserModel : AUserModel
    {
        #region 用户配置
        /// <summary>
        /// 剪贴板驻留时间
        /// </summary>
        public int ResidenceDuration { get; set; }
        /// <summary>
        /// 备份文件数量
        /// </summary>
        public int BackFileCount { get; set; }
        /// <summary>
        /// 口令长度
        /// </summary>
        public int PasswordLength { get; set; }
        /// <summary>
        /// 默认字符空间
        /// </summary>
        public string PasswordUdc { get; set; }
        #endregion

        #region 数据初始化
        public override void Init()
        {
            if (File.Exists("Amon.tag"))
            {
                SysHome = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "阿木密码箱");
                if (!Directory.Exists(SysHome))
                {
                    Directory.CreateDirectory(SysHome);
                }
            }
            else
            {
                SysHome = Environment.CurrentDirectory;
            }

            ResHome = SysHome;
            BakHome = Path.Combine(SysHome, CApp.DIR_BACK);

            if (File.Exists(CApp.FILE_VER))
            {
                BeanUtil.UnZip(CApp.FILE_RES, ResHome);
                BeanUtil.UnZip("Amon.lib", "Lib");
                File.Delete(CApp.FILE_VER);
            }
            if (!Directory.Exists(Path.Combine(SysHome, "Skin")))
            {
                BeanUtil.UnZip(CApp.FILE_RES, ResHome);
            }
        }

        public override void Load()
        {
            BackFileCount = 3;
            NoticeInterval = 5;
            PasswordLength = 8;
            PasswordUdc = "AUDC000000000005";
        }
        #endregion

        /// <summary>
        /// 网络访问
        /// </summary>
        /// <param name="data"></param>
        public void Post(string data)
        {
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            //client.UploadStringAsync(new Uri(EnvConst.SERVER_PATH), "POST", "c=" + Code + "&t=" + _Token + data);
        }
    }
}
