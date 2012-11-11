namespace Me.Amon.Open
{
    public interface OAuthClient
    {
        bool RequestToken();

        string AuthorizeUrl { get; }

        bool AccessToken();

        bool Verify();
    }
}
