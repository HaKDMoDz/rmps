using System;

namespace rmp.wrp.code
{
    public class UserOpt
    {
        public const String TAG_STYLE_PRE = "pre";
        public const String TAG_STYLE_DIV = "div";
        public const String TAG_STYLE_TBL = "table";

        private bool inLineStyle;
        private bool showLineNbr;
        private bool showLinkUri;
        private int tabCount;
        private String tagStyle;
        private String language;

        public String Language
        {
            get { return language; }
            set { language = value; }
        }

        public UserOpt()
        {
            SetDefault();
        }

        public void SetDefault()
        {
            tabCount = 4;
            tagStyle = TAG_STYLE_DIV;
            inLineStyle = true;
            showLineNbr = true;
            showLinkUri = true;
        }

        public bool InLineStyle
        {
            get { return inLineStyle; }
            set { inLineStyle = value; }
        }

        public bool ShowLineNbr
        {
            get { return showLineNbr; }
            set { showLineNbr = value; }
        }

        public bool ShowLinkUri
        {
            get { return showLinkUri; }
            set { showLinkUri = value; }
        }

        public int TabCount
        {
            get { return tabCount; }
            set { tabCount = value; }
        }

        public String TagStyle
        {
            get { return tagStyle; }
            set { tagStyle = value; }
        }
    }
}
