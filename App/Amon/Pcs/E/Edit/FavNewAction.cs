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

            string name = IApp.SelectedMeta.GetName();
            while (true)
            {
                name = Main.ShowInput("�������ղ����ƣ�", name);
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
