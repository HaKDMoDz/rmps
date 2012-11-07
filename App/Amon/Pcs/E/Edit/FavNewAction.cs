using System;

namespace Me.Amon.Pcs.E.Edit
{
    public class FavNewAction : APcsAction
    {
        public override void EventHandler(object sender, EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }

            string name = Main.ShowInput("", IApp.SelectedMeta.Name);
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }
            IApp.AddFav(name);
        }
    }
}
