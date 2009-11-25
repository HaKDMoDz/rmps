/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.ui.form;

import javax.swing.JPopupMenu;

import rmp.face.WBean;

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
class FMenu extends JPopupMenu implements WBean
{
    private FForm ff;

    /**
     * 
     */
    public FMenu(FForm form)
    {
        this.ff = form;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    public boolean wInit()
    {
        ica();
        ita();

        return true;
    }

    /**
     * 
     */
    private void ica()
    {
        // 使用帮助
        mi_HelpItem = new javax.swing.JMenuItem();
        mi_HelpItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
            }
        });
        add(mi_HelpItem);

        // 关于软件
        mi_InfoItem = new javax.swing.JMenuItem();
        mi_InfoItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
            }
        });
        add(mi_InfoItem);

        // 系统退出
        mi_ExitItem = new javax.swing.JMenuItem();
        mi_ExitItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                ff.wExit();
            }
        });
        add(mi_ExitItem);
    }

    /**
     * 
     */
    private void ita()
    {
        mi_HelpItem.setText("使用帮助");

        mi_InfoItem.setText("关于软件");

        mi_ExitItem.setText("系统退出");
    }
    private javax.swing.JMenuItem mi_HelpItem;
    private javax.swing.JMenuItem mi_InfoItem;
    private javax.swing.JMenuItem mi_ExitItem;
    private javax.swing.JMenuItem mi_SkinItem;
}
