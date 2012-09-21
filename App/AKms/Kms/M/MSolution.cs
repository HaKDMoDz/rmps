using System.Collections.Generic;
using Me.Amon.Kms.Enums;

namespace Me.Amon.Kms.M
{
    public class MSolution
    {
        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// 索引
        /// </summary>
        public string Hash { get; set; }
        /// <summary>
        /// 方案名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 交互语言
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// 交互资源
        /// </summary>
        public List<string> Category { get; set; }
        /// <summary>
        /// 会话目标
        /// </summary>
        public ETarget Target { get; set; }
        /// <summary>
        /// 会话模式
        /// </summary>
        public EMethod Method { get; set; }
        /// <summary>
        /// 会话方式
        /// </summary>
        public EOutput Output { get; set; }
        /// <summary>
        /// 会话间隔
        /// </summary>
        public int Intval { get; set; }
        /// <summary>
        /// 准备输入
        /// </summary>
        public string PostPrepare { get; set; }
        /// <summary>
        /// 输入确认
        /// </summary>
        public string PostConfirm { get; set; }
        /// <summary>
        /// 前置功能
        /// </summary>
        public List<MFunction> PreFunction { get; set; }
        /// <summary>
        /// 后置功能
        /// </summary>
        public List<MFunction> SufFunction { get; set; }
        /// <summary>
        /// 可选文本
        /// </summary>
        public List<MSentence> Sentence { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }

        public string WorkKey { get; set; }

        public string HaltKey { get; set; }

        public string NextKey { get; set; }

        public string StopKey { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is MSolution)
            {
                var sln = obj as MSolution;
                return Hash == sln.Hash;
            }
            if (obj is string)
            {
                return Hash == (string)obj;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Hash.GetHashCode();
        }
    }
}
