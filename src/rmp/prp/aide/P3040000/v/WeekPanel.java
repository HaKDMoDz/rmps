/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3040000.v;

import javax.swing.table.DefaultTableModel;

import rmp.bean.CellRender;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 周视图，用于以列表的方式显示指定周的详细计划、节日等信息<br />
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * @author Amon
 */
public class WeekPanel extends javax.swing.JPanel
{
    /** serialVersionUID */
    private static final long serialVersionUID = -1886817064800620796L;
    private DefaultTableModel tm_WeekTble;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 
     */
    public WeekPanel()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面显示区域
    // ////////////////////////////////////////////////////////////////////////
    /*
     * (non-Javadoc)
     * 
     * @see rmp.ui.frm.FViewPanel#init()
     */
    public boolean wInit()
    {
        ica();
        ita();

        return true;
    }

    /**
     * 界面构件布局显示初始化
     */
    private void ica()
    {
        javax.swing.JScrollPane sp_WeekTble = new javax.swing.JScrollPane();
        tb_WeekTble = new javax.swing.JTable();

        tm_WeekTble = new DefaultTableModel();
        tb_WeekTble.setModel(tm_WeekTble);
        tb_WeekTble.setDefaultRenderer(String.class, new CellRender());
        sp_WeekTble.setViewportView(tb_WeekTble);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(sp_WeekTble,
                javax.swing.GroupLayout.DEFAULT_SIZE, 362, Short.MAX_VALUE).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(sp_WeekTble,
                javax.swing.GroupLayout.DEFAULT_SIZE, 267, Short.MAX_VALUE).addContainerGap()));
    }

    /**
     * 界面语言信息初始化
     */
    private void ita()
    {
    }
    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    // ////////////////////////////////////////////////////////////////////////
    // 公共方法区域
    // ////////////////////////////////////////////////////////////////////////
    // ////////////////////////////////////////////////////////////////////////
    // 界面变量区域
    // ////////////////////////////////////////////////////////////////////////
    private javax.swing.JTable tb_WeekTble;
}
