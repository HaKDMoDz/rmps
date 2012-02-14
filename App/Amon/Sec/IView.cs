using System.Xml;

namespace Me.Amon.Sec
{
    public interface IView
    {
        void Init();

        void InitOpt(string opt);

        void InitDir(string dir);

        void InitAlg(string alg);

        void FocusIn();

        bool Check();

        XmlElement SaveXml(XmlDocument doc);

        void LoadXml(XmlDocument doc);
    }
}
