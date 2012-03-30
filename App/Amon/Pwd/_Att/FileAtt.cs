namespace Me.Amon.Pwd._Att
{
    public class FileAtt : Att
    {
        public const int SPEC_FILE_NAME = 0;// 附件原文件名
        public const int SPEC_FILE_EXTS = 1;// 附件原扩展名
        public const int SPEC_FILE_ALG = 2;// 加密算法
        public const int SPEC_FILE_KEY = 3;// 加密口令

        public FileAtt()
            : base(TYPE_FILE, "", "")
        {

        }

        public override void SetDefault()
        {
            if (_Spec == null)
            {
                _Spec = new string[4];
            }

            for (int i = 0; i < _Spec.Length; i += 1)
            {
                _Spec[i] = SPEC_VALUE_NONE;
            }
        }
    }
}
