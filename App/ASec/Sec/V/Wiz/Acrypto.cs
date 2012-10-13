using Me.Amon.Sec.M;

namespace Me.Amon.Sec.V.Wiz
{
    class Acrypto : ICrypto<byte, byte>
    {
        public void Init(MSec msec, string pass)
        {
        }

        public int Process(byte[] srcArray, int srcFrom, int length, byte[] dstArray, int dstFrom)
        {
            throw new System.NotImplementedException();
        }

        public int DoFinal(byte[] output, int outOff)
        {
            throw new System.NotImplementedException();
        }
    }
}
