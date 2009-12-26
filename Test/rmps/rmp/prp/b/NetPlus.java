/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.b;

import java.awt.Color;
import java.awt.Cursor;
import java.util.logging.Level;
import java.util.logging.Logger;

import rmp.prp.m.NetItem;
import rmp.util.BeanUtil;

import com.amonsoft.util.DeskUtil;
import com.amonsoft.util.LogUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 网络插件对象
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * 
 * @author Amon
 */
public class NetPlus extends javax.swing.JPanel
{
    // ////////////////////////////////////////////////////////////////////////
    // 逻辑控制区域
    // ////////////////////////////////////////////////////////////////////////
    /** 用户添加对象 */
    private NetItem item;
    /** 内嵌面板边框 */
    private javax.swing.border.Border border;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 默认构造函数
     */
    public NetPlus()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面初始化区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @return
     */
    public boolean wInit()
    {
        border = javax.swing.BorderFactory.createLineBorder(new java.awt.Color(153, 153, 153));

        ica();

        ita();

        return true;
    }

    /**
     * 界面布局初始化
     */
    private void ica()
    {
        lb_ItemLabl = new rmp.ui.link.WLinkLabel();
        lb_ItemLabl.setForeground(Color.BLUE);
        lb_ItemLabl.setCursor(Cursor.getPredefinedCursor(Cursor.HAND_CURSOR));
        lb_ItemLabl.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lb_ItemLabl_Handler(evt);
            }

            public void mouseEntered(java.awt.event.MouseEvent evt)
            {
                lb_ItemLabl.setBorder(border);
            }

            public void mouseExited(java.awt.event.MouseEvent evt)
            {
                lb_ItemLabl.setBorder(null);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_ItemLabl, javax.swing.GroupLayout.DEFAULT_SIZE, 110, Short.MAX_VALUE));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(lb_ItemLabl).addGap(1)));
    }

    /**
     * 界面语言初始化
     */
    private void ita()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 鼠标点击事件处理
     * 
     * @param evt
     */
    private void lb_ItemLabl_Handler(java.awt.event.MouseEvent evt)
    {
        LogUtil.log("网络程序启动：" + item.getHref());
        try
        {
            DeskUtil.browse(item.getHref());
        }
        catch (Exception ex)
        {
            Logger.getLogger(NetPlus.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 设置程序对象
     * 
     * @return
     */
    public boolean setItem(NetItem item)
    {
        this.item = item;
        this.lb_ItemLabl.setIcon(item.getIcon());
        BeanUtil.setWText(lb_ItemLabl, item.getTitle());
        BeanUtil.setWTips(lb_ItemLabl, item.getDescription());
        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面组件区域
    // ////////////////////////////////////////////////////////////////////////
    private javax.swing.JLabel lb_ItemLabl;
    /** serialVersionUID */
    private static final long serialVersionUID = -5735877669516238196L;
}
