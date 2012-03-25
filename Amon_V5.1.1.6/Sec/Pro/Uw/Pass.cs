using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Me.Amon.Sec.Pro.Uw
{
    public partial class Pass : Form, IForm<string>
    {
        private char[] _Array;
        private Point _Point;

        public Pass()
        {
            InitializeComponent();
        }

        public CallBackHandler<string> CallBack { get; set; }

        public void Show(ASec asec, string data)
        {
            _Array = new char[256];

            Random random = new Random();
            for (int i = 0; i < _Array.Length; i += 1)
            {
                _Array[i] = (char)(random.Next(94) + 33);
            }
            base.Show(asec);
        }

        private void Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (!Worker.CancellationPending)
            {
                TbPass.Text += _Array[_Point.X + _Point.Y];

                Thread.Sleep(250);
            }
        }

        private void TbPass_MouseEnter(object sender, System.EventArgs e)
        {
            TbPass.Text = "";

            if (!Worker.IsBusy)
            {
                Worker.RunWorkerAsync();
            }
        }

        private void TbPass_MouseMove(object sender, MouseEventArgs e)
        {
            _Point = e.Location;
        }

        private void TbPass_MouseLeave(object sender, System.EventArgs e)
        {
            if (Worker.IsBusy)
            {
                Worker.CancelAsync();
            }
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            if (CallBack != null)
            {
                CallBack.Invoke(TbPass.Text);
            }

            Close();
        }
    }
}
