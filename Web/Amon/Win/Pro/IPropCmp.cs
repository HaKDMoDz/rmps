using System.Windows.Controls;
using Me.Amon.Model;

namespace Me.Amon.Win.Pro
{
    /// <summary>
    /// 属性展示控件
    /// </summary>
    public interface IPropCmp
    {
        bool ShowData(Att att);

        void InitView(Border border);

        void Copy();

        void Save();

        void Drop();
    }
}
