using Me.Amon.Kms.Enums;

namespace Me.Amon.Kms.M
{
    public class MFunction
    {
        /// <summary>
        /// 执行顺序
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// 方案索引
        /// </summary>
        public string SolId { get; set; }
        /// <summary>
        /// 执行动作
        /// </summary>
        public EAction Action { get; set; }
        /// <summary>
        /// 执行参数
        /// </summary>
        public string Param { get; set; }

        public override string ToString()
        {
            switch (Action)
            {
                case EAction.ThreadWait:
                    return "执行等待";
                case EAction.ExecuteApp:
                    return "执行程序";
                case EAction.ShowWindow:
                    return "激活窗口";
                case EAction.HideWindow:
                    return "隐藏窗口";
                case EAction.GetControl:
                    return "查找组件";
                case EAction.KeybdInput:
                    return "键盘输入";
                case EAction.MouseInput:
                    return "鼠标输入";
                default:
                    return "<未知>";
            }
        }
    }
}
