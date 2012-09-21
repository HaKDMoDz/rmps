using System.ComponentModel;
using System.Windows.Forms;
using Me.Amon.Properties;

namespace Me.Amon.V.Uc
{
    public class LogoIco : ILogo
    {
        public LogoIco(PictureBox pBox, IContainer container)
        {
            pBox.Image = Resources.Logo25;
        }

        #region 接口实现
        public void DoWork()
        {
        }

        public void MouseMove()
        {
        }

        public void KeyPress()
        {
        }

        public void DoStop()
        {
        }
        #endregion
    }
}
