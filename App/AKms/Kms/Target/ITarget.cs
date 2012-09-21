using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Kms.Enums;

namespace Me.Amon.Kms.Target
{
    public interface ITarget
    {
        /// <summary>
        /// 目标类型
        /// </summary>
        ETarget Target { get; }

        //string TargetCode { get; }

        /// <summary>
        /// 目标名称
        /// </summary>
        string TargetName { get; }

        AKms TrayWin { set; }

        /// <summary>
        /// 逐步提示
        /// </summary>
        bool HintByStep { get; set; }

        /// <summary>
        /// 开始会话
        /// </summary>
        bool Start();

        /// <summary>
        /// 消息发送
        /// </summary>
        /// <param name="text"></param>
        void SendMessage(string text);

        void SendMessage(Image image);

        /// <summary>
        /// 显示提示
        /// </summary>
        /// <param name="text"></param>
        void ShowWarning(string text);

        /// <summary>
        /// 显示确认
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        DialogResult ShowConfirm(string text);

        /// <summary>
        /// 结束会话
        /// </summary>
        bool Close();
    }
}
