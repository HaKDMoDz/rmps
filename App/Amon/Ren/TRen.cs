using System.IO;

namespace Me.Amon.Ren
{
    class TRen
    {
        /// <summary>
        /// 类型：
        /// 0、文件
        /// 1、目录
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 文件全路径
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// 文件父目录
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 初始名称
        /// </summary>
        public string SrcName { get; set; }

        /// <summary>
        /// 临时名称
        /// </summary>
        public string Temp { get; set; }

        /// <summary>
        /// 目标名称
        /// </summary>
        public string DstName { get; set; }

        /// <summary>
        /// 目标属性
        /// </summary>
        public FileAttributes FileAtt { get; set; }
    }
}
