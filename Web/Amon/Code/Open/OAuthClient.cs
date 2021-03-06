﻿using System;

namespace Me.Amon.Open
{
    public abstract class OAuthClient
    {
        public const string KUAIPAN = "kuaipan";

        public abstract bool RequestToken();

        public abstract string GetAuthorizeUrl();

        public abstract bool AccessToken(string verifier);

        public static string GetOAuthNonce()
        {
            return new Random().Next(123400, 9999999).ToString();
        }

        public static string GetOAuthTimestamp()
        {
            TimeSpan span = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
            return Math.Ceiling(span.TotalSeconds).ToString();
        }
    }
}
