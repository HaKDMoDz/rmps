using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Pro
{
    public interface IProEdit
    {
        bool ShowData(AAtt att);

        void InitView();

        void Copy();

        void Save();

        void Drop();
    }
}
