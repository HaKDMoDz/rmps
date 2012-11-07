﻿using Me.Amon.Open;

namespace Me.Amon.Open.V2
{
    public class OAuthTokenV2 : OAuthToken
    {
        //[JsonProperty(PropertyName = "access_token")]
        public string Token { get; internal set; }
        //[JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; internal set; }
        //[JsonProperty(PropertyName = "uid")]
        public string UID { get; internal set; }
        //[JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; internal set; }
    }
}
