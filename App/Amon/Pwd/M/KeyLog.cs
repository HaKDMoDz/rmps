using Me.Amon.M;

namespace Me.Amon.Pwd.M
{
    public class KeyLog : Log
    {
        /// <summary>
        /// 显示排序
        /// </summary>
        public int Order;
        /// <summary>
        /// 使用状态
        /// </summary>
        public int Label;
        /// <summary>
        /// 紧要程度
        /// </summary>
        public int Major;
        /// <summary>
        /// 所属类别
        /// </summary>
        public string CatId;
        /// <summary>
        /// 注册日期
        /// </summary>
        public string RegTime;
        /// <summary>
        /// 模板索引
        /// </summary>
        public string LibId;
        /// <summary>
        /// 口令标题
        /// </summary>
        public string Title;
        /// <summary>
        /// 关键搜索
        /// </summary>
        public string MetaKey;
        /// <summary>
        /// 口令图标
        /// </summary>
        public string IcoName;
        /// <summary>
        /// 图标路径
        /// </summary>
        public string IcoPath;
        /// <summary>
        /// 图标说明
        /// </summary>
        public string IcoMemo;
        /// <summary>
        /// 提醒索引
        /// </summary>
        public string GtdId;
        /// <summary>
        /// 提醒备注
        /// </summary>
        public string GtdMemo;
        /// <summary>
        /// 窗口对象
        /// </summary>
        public string Window;
        /// <summary>
        /// 执行脚本
        /// </summary>
        public string Script;
        /// <summary>
        /// 相关说明
        /// </summary>
        public string Memo;
        /// <summary>
        /// 访问日期
        /// </summary>
        public string AccessTime;
        /// <summary>
        /// 是否备份
        /// </summary>
        public bool Backup;
        /// <summary>
        /// 加密版本
        /// </summary>
        public int CipherVer;
        /// <summary>
        /// 索性索引
        /// </summary>
        public int AttIndex;
        /// <summary>
        /// 用户数据
        /// </summary>
        public string Password;
    }
}
