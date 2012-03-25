using System.Drawing;

namespace App
{
    public class Demo
    {
        public string A { get; set; }

        private bool _b;
        public bool B { get { return _b; } }

        public int C { get; set; }

        public Image Icon { get; set; }

        private string D;

        public string GetName()
        {
            return D;
        }
    }
}
