using System;
using System.Windows.Forms;
using Me.Amon.Pcs.V;

namespace Me.Amon.Pcs.E.Edit
{
    public class FavNewAction : APcsAction
    {
        private FavNew _FavNew;

        public override void EventHandler(object sender, EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }

            if (_FavNew == null)
            {
                _FavNew = new FavNew();
            }

            if (DialogResult.OK != _FavNew.ShowDialog(IApp.Form))
            {
                return;
            }
            IApp.AddFav();
        }
    }
}
