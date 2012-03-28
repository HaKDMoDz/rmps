namespace Me.Amon.Bean
{
    public class KeyLog : Log
    {
        /// <summary>
        /// 显示排序
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// 使用状态
        /// </summary>
        public int Label { get; set; }
        /// <summary>
        /// 紧要程度
        /// </summary>
        public int Major { get; set; }
        /// <summary>
        /// 所属类别
        /// </summary>
        public string CatId { get; set; }
        /// <summary>
        /// 注册日期
        /// </summary>
        public string RegTime { get; set; }
        /// <summary>
        /// 模板索引
        /// </summary>
        public string LibId { get; set; }
        /// <summary>
        /// 口令标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 关键搜索
        /// </summary>
        public string MetaKey { get; set; }
        /// <summary>
        /// 口令图标
        /// </summary>
        public string IcoName { get; set; }
        /// <summary>
        /// 图标路径
        /// </summary>
        public string IcoPath { get; set; }
        /// <summary>
        /// 图标说明
        /// </summary>
        public string IcoMemo { get; set; }
        /// <summary>
        /// 提醒索引
        /// </summary>
        public string GtdId { get; set; }
        /// <summary>
        /// 提醒备注
        /// </summary>
        public string GtdMemo { get; set; }
        /// <summary>
        /// 相关说明
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 访问日期
        /// </summary>
        public string AccessTime { get; set; }
        /// <summary>
        /// 是否备份
        /// </summary>
        public bool Backup { get; set; }
        /// <summary>
        /// 加密版本
        /// </summary>
        public int CipherVer { get; set; }
        /// <summary>
        /// 索性索引
        /// </summary>
        public int AttIndex { get; set; }
        /// <summary>
        /// 用户数据
        /// </summary>
        public string Password { get; set; }
    }
}
