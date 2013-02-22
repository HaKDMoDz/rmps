namespace Me.Amon.Open
{
    public abstract class OAuthToken
    {
        public string Type { get; set; }

        public abstract string Token { get; set; }

        public abstract string Secret { get; set; }

        public abstract string UserId { get; set; }
    }
}
