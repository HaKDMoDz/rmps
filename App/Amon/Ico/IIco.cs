using System.Collections.Generic;
using System.Drawing;
using System.Drawing.IconLib;

namespace Me.Amon.Ico
{
    public interface IIco
    {
        void InitOnce();

        SingleIcon SingleIcon { get; set; }

        void AppendImg();

        void RemoveImg();

        void Import(string file);

        void Export(string file);

        void ToImages(List<Image> images);
    }
}