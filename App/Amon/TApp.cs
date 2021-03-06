﻿using System.Xml;
using Me.Amon.M;

namespace Me.Amon
{
    public class TApp
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public string Logo { get; set; }

        public string Uri { get; set; }

        public string Text { get; set; }

        public string Tips { get; set; }

        public bool IsDefault { get; set; }

        public bool NeedAuth { get; set; }

        public IApp App { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public void FromXml(XmlNode node)
        {
            if (node.Name != "App")
            {
                return;
            }
            Id = Vcs.Attribute(node, "Id", "");
            Type = Vcs.Attribute(node, "Type", "");
            Logo = Vcs.Attribute(node, "Logo", "");
            Uri = Vcs.Attribute(node, "Uri", "");
            Text = Vcs.Attribute(node, "Text", "");
            Tips = Vcs.Attribute(node, "Tips", "");
            IsDefault = "true" == Vcs.Attribute(node, "Default", "").ToLower();
        }

        public IApp CreateApp(AUserModel userModel)
        {
            Main.LogInfo("创建新实例：" + Id);

            switch ((Id ?? "").ToLower())
            {
                case CApp.IAPP_WBAR:
                    App = new Bar.WBar(userModel);
                    break;
                case CApp.IAPP_WICO:
                    App = new Ico.WIco(userModel);
                    break;
                case CApp.IAPP_WIMG:
                    App = new Img.WImg(userModel);
                    break;
                case CApp.IAPP_WSPY:
                    //App = new Spy.ASpy(userModel);
                    break;
                default:
                    break;
            }

            return App;
        }
    }
}
