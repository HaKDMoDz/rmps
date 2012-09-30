using System.Drawing;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;
using Me.Amon.Kms.Target;

namespace Me.Amon.Kms.Robot
{
    public interface IRobot
    {
        /// <summary>
        /// 总控引用
        /// </summary>
        Main TrayPtn { set; }

        /// <summary>
        /// 输出方式
        /// </summary>
        EMethod Method { get; set; }

        /// <summary>
        /// 是否逐步提示
        /// </summary>
        bool HintByStep { get; set; }

        /// <summary>
        /// 获取是否运行中
        /// </summary>
        bool Running { get; }

        void AppendTarget(ITarget target);

        void RemoveTarget(ITarget target);

        /// <summary>
        /// 会话处理
        /// </summary>
        /// <param name="target"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        bool Deal(ITarget target, MRequest request);

        bool Send(string text);

        bool Send(Image image);

        /// <summary>
        /// 开始工作
        /// </summary>
        /// <returns></returns>
        bool Work();

        /// <summary>
        /// 暂停工作
        /// </summary>
        /// <returns></returns>
        bool Halt();

        /// <summary>
        /// 继续工作
        /// </summary>
        /// <returns></returns>
        bool Next();

        /// <summary>
        /// 停止工作
        /// </summary>
        /// <returns></returns>
        bool Stop();
    }
}
