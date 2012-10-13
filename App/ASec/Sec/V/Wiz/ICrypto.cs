using Me.Amon.Sec.M;
namespace Me.Amon.Sec.V.Wiz
{
    interface ICrypto<T1, T2>
    {
        void Init(MSec msec, string pass);

        //int Process(T1[] srcArray, int srcFrom, int length, T2[] dstArray, int dstFrom);

        int DoFinal(T2[] output, int outOff);
    }
}
