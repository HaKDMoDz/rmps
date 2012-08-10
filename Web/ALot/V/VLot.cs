using System.Windows.Controls;
using Me.Amon.Lot.M;

namespace Me.Amon.Lot.V
{
    public interface VLot
    {
        void Init(Round round);

        UserControl Control { get; }

        void Value(Item[] values, int length);
    }
}
