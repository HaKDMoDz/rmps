using Me.Amon.Lot.M;
using Me.Amon.Lot.V;

namespace Me.Amon.Lot.C
{
    public interface CLot
    {
        void Init(MLot mlot, VLot vlot);

        void Run();

        void AmonMe();

        void KeepOn();

        void End();
    }
}
