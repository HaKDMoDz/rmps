namespace Me.Amon.Sec.V.Wiz
{
    interface ICrypto
    {
        bool Encrypt(string src, string dst);

        bool Decrypt(string src, string dst);
    }
}
