
using System.Windows.Input;
namespace Me.Amon.Lot.M
{
    /// <summary>
    /// 偏好配置
    /// </summary>
    public class LotFav
    {
        public string BackgroundImage { get; set; }

        public string BackgroundColor { get; set; }

        public string ForegroundColor { get; set; }

        public string FontName { get; set; }

        public Key Run { get; set; }

        public Key AmonMe { get; set; }

        public Key KeepOn { get; set; }

        public Key End { get; set; }
    }
}
