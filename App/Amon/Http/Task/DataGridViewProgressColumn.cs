using System;
using System.Windows.Forms;

namespace Me.Amon.Http.Task
{
    public class DataGridViewProgressColumn : DataGridViewColumn
    {
        public DataGridViewProgressColumn()
        {
            base.ValueType = typeof(float);
            this.CellTemplate = new DataGridViewProgressCell();
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a ProgressCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(DataGridViewProgressCell)))
                {
                    throw new InvalidCastException("Must be a ProgressCell");
                }
                base.CellTemplate = value;
            }
        }
    }
}
