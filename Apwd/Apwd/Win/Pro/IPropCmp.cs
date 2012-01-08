using System.Windows.Controls;
using Me.Amon.Apwd.Model;

namespace Me.Amon.Apwd.Win.Pro
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
