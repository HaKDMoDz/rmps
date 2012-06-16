namespace Me.Amon.Sec.V.Wiz
{
    interface ICrypto
    {
        void Init();

        bool IsText { get; set; }

        string Algorithm { get; set; }

        bool DoCrypto(string pass);
    }
}
