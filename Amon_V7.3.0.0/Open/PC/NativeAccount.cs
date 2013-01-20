using System;

namespace Me.Amon.Open.PC
{
    public class NativeAccount : OAuthPcsAccount
    {
        public override string Name
        {
            get { return Environment.UserName; }
        }

        public override int Limit
        {
            get { return int.MaxValue; }
        }

        public override long Size
        {
            get { return int.MaxValue; }
        }

        public override long Used
        {
            get { return 0; }
        }

        public override long Recycled
        {
            get { return 0; }
        }
    }
}
