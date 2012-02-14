namespace Me.Amon.Model
{
    public class Cat : Vcs
    {
        public int Order { get; set; }
        /// <summary>
        /// 类别索引
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 上级索引
        /// </summary>
        public string Parent { get; set; }
        /// <summary>
        /// 类别图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 类别提示
        /// </summary>
        public string Tips { get; set; }
        /// <summary>
        /// 类别键值
        /// </summary>
        public string Meta { get; set; }
        /// <summary>
        /// 类别说明
        /// </summary>
        public string Memo { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
