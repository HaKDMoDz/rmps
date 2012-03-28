using Me.Amon.Bean;

namespace Me.Amon.Ren.M
{
    public class MRen : Vcs
    {
        public string Name { get; set; }

        public string Command { get; set; }

        public string Remark { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
