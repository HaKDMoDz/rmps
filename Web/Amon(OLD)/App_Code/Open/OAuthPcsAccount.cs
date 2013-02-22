namespace Me.Amon.Open
{
    public abstract class OAuthPcsAccount : OAuthAccount
    {
        public abstract int Limit { get; }

        public abstract long Size { get; }

        public abstract long Used { get; }

        public abstract long Recycled { get; }
    }
}
