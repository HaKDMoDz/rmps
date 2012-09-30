using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Me.Amon.Apwd.Effect
{
    public class ViewProjection
    {
        private Storyboard _Story;
        private Control _Control;
        private int _ViewTime = 20;
        private double _ViewStep = -0.1;

        public double ViewStep
        {
            get
            {
                return _ViewStep;
            }
            set
            {
                _ViewStep = (value <= 0) ? 0.1 : ((value >= 1.0) ? 1.0 : value);
            }
        }

        public void Hide(Control control)
        {
            _Control = control;
            if (_ViewStep > 0)
            {
                _ViewStep = -_ViewStep;
            }

            InitViewData();
        }

        public void Show(Control control)
        {
            _Control = control;
            if (_ViewStep < 0)
            {
                _ViewStep = -_ViewStep;
            }

            InitViewData();
        }

        public void Begin()
        {
            _Story.Begin();
        }

        private void InitViewData()
        {
            _Story = new Storyboard();
            _Story.Duration = new Duration(TimeSpan.FromMilliseconds(_ViewTime));
            _Story.Completed += new EventHandler(Story_Completed);
        }

        private void Story_Completed(object sender, EventArgs e)
        {
            var o = _Control.Opacity * (1 + _ViewStep);
            //var o = _Control.Opacity + _ViewStep;
            if (o > 0.1 && o < 1.0)
            {
                _Control.Opacity = o;
                _Story.Begin();
            }
        }
    }
}
