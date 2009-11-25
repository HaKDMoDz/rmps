/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.b;

import java.awt.Component;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

import javax.swing.JCheckBox;
import javax.swing.JList;
import javax.swing.ListCellRenderer;
import javax.swing.ListSelectionModel;
import javax.swing.UIManager;
import javax.swing.border.Border;
import javax.swing.border.EmptyBorder;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * @author Amon
 */
public class WCheckList extends JList
{
    /**
     * 
     */
    public WCheckList()
    {
        setCellRenderer(new ListCellRender());

        addMouseListener(new MouseAdapter()
        {
            @Override
            public void mousePressed(MouseEvent e)
            {
                int index = locationToIndex(e.getPoint());

                if (index != -1)
                {
                    JCheckBox checkbox = (JCheckBox) (getModel().getElementAt(index));
                    checkbox.setSelected(!checkbox.isSelected());
                    repaint();
                }
            }
        });

        setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
    }
    /**  */
    private static final long serialVersionUID = -5701520856030146470L;
}

/**
 * @author Amon
 */
class ListCellRender implements ListCellRenderer
{
    private static Border noFocusBorder = new EmptyBorder(1, 1, 1, 1);

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.ListCellRenderer#getListCellRendererComponent(javax.swing.JList,
     *      java.lang.Object, int, boolean, boolean)
     */
    @Override
    public Component getListCellRendererComponent(JList list, Object value, int index, boolean isSelected,
            boolean cellHasFocus)
    {
        JCheckBox checkbox = new JCheckBox((String) value);
        checkbox.setBackground(isSelected ? list.getSelectionBackground() : list.getBackground());
        checkbox.setForeground(isSelected ? list.getSelectionForeground() : list.getForeground());
        checkbox.setEnabled(list.isEnabled());
        checkbox.setFont(list.getFont());
        checkbox.setFocusPainted(false);
        checkbox.setBorderPainted(true);
        checkbox.setBorder(isSelected ? UIManager.getBorder("List.focusCellHighlightBorder") : noFocusBorder);
        return checkbox;
    }
}
