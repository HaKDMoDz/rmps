namespace Me.Amon.Ico.E
{
    public class RemoveImgAction : WIcoAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.RemoveImg();
            }
        }
    }
}
