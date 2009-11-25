/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.b;

import java.awt.Dimension;
import java.awt.Window;
import java.util.List;

import javax.swing.DefaultListModel;
import javax.swing.JDialog;
import javax.swing.JList;

import rmp.bean.CellRender;
import rmp.face.WBackCall;
import rmp.util.BeanUtil;
import rmp.util.EnvUtil;

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
public class WListForm extends JDialog
{
    /**  */
    private static final long serialVersionUID = -2520067680781258069L;
    /** 回调对象 */
    private WBackCall bc_BackCall;

    /**
     * 默认构造函数
     */
    public WListForm(Window owner)
    {
        super(owner);
        ica();
    }

    /**
     * @param action
     * @param list
     * @param title
     * @param wTips
     */
    public static void showDialog(Window owner, String title, List<?> list, WBackCall action)
    {
        // 窗口对象为空判断
        WListForm lp = new WListForm(owner);
        lp.setIconImage(BeanUtil.getLogoImage());
        lp.setTitle(title);
        lp.setListModel(list);
        lp.setBackCall(action);
        lp.pack();
        Dimension size = EnvUtil.getScreenSize();
        int x = (size.width - lp.getWidth()) >> 1;
        int y = (size.height - lp.getHeight()) >> 1;
        lp.setLocation(x, y);
        lp.setDefaultCloseOperation(JDialog.DISPOSE_ON_CLOSE);
        lp.setVisible(true);
    }

    /**
     * @param list
     */
    public void setListModel(List<?> list)
    {
        // 列表数据模型变更
        DefaultListModel lm_NameList = new DefaultListModel();
        for (int i = 0, j = list.size(); i < j; i += 1)
        {
            lm_NameList.addElement(list.get(i));
        }
        ls_NameList.setModel(lm_NameList);
        ls_NameList.setCellRenderer(new CellRender());
    }

    /**
     * @param backCall the backCall to set
     */
    public void setBackCall(WBackCall backCall)
    {
        this.bc_BackCall = backCall;
    }

    /**
     * 
     */
    private void ica()
    {
        java.awt.GridBagConstraints gridBagConstraints;

        javax.swing.JScrollPane sp_NameList = new javax.swing.JScrollPane();
        ls_NameList = new javax.swing.JList();

        setLayout(new java.awt.GridBagLayout());

        ls_NameList.setSelectionMode(javax.swing.ListSelectionModel.SINGLE_SELECTION);
        ls_NameList.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                ls_NameList_Handle(evt);
            }
        });
        sp_NameList.setViewportView(ls_NameList);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.fill = java.awt.GridBagConstraints.BOTH;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.weighty = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(10, 10, 10, 10);
        add(sp_NameList, gridBagConstraints);
    }

    /**
     * @param evt
     */
    private void ls_NameList_Handle(java.awt.event.MouseEvent evt)
    {
        if (evt.getClickCount() > 1)
        {
            // 窗口不可见
            this.setVisible(false);

            // 用户选择对象
            bc_BackCall.wAction(null, ls_NameList.getSelectedValue(), null);
        }
    }
    /** 列表对象 */
    private JList ls_NameList;
}
