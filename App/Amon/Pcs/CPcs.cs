namespace Me.Amon.Pcs
{
    public class CPcs
    {
        public const int META_TYPE_UNKNOWN = 0;
        public const int META_TYPE_FOLDER = 1;
        public const int META_TYPE_FILE = 2;

        /// <summary>
        /// Favourites
        /// </summary>
        public const string PATH_FAV = "*fav";
        /// <summary>
        /// Liberates
        /// </summary>
        public const string PATH_LIB = "*lib";
        public const string PATH_LIB_DOCUMENTS = ":documents";
        public const string PATH_LIB_PICTURES = ":pictures";
        public const string PATH_LIB_AUDIOS = ":audios";
        public const string PATH_LIB_VIDEOS = ":videos";
        public const string PATH_ALL = "*all";
        public const string PATH_SNS = "*sns";
        public const string PATH_BIN = "*bin";

        public const string XML_MENU = "WPcs.xml";

        public const string PCS_TYPE_NATIVE = "native";
        public const string PCS_TYPE_KUAIPAN = "kuaipan";
        public const string PCS_TYPE_DROPBOX = "dropbox";
        public const string PCS_TYPE_SKYDRIVE = "skydrive";
    }
}
