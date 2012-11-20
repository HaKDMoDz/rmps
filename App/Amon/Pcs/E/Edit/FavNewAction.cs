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

            string name = IApp.SelectedMeta.GetMetaName();
            while (true)
            {
                name = Main.ShowInput("«Î ‰»Î ’≤ÿ√˚≥∆£∫", name);
                if (name == null)
                {
                    return;
                }
                if (!string.IsNullOrWhiteSpace(name))
                {
                    break;
                }
            }
            IApp.AddFav(name);
        }
    }
}
