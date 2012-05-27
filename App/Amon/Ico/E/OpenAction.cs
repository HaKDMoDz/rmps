using System.Windows.Forms;

namespace Me.Amon.Ico.E
{
    public class OpenAction : AIcoAction
    {
        private OpenFileDialog _FdOpen;

        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }

            if (_FdOpen == null)
            {
                _FdOpen = new OpenFileDialog();
            }
            if (DialogResult.OK != _FdOpen.ShowDialog(IApp.Form))
            {
                return;
            }
            IApp.Open(_FdOpen.FileName);
        }
    }
}
