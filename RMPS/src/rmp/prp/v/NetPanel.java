/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.v;

import javax.swing.BoxLayout;

import rmp.prp.b.NetPlugin;
import rmp.prp.m.WNetItem;

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
public class NetPanel extends javax.swing.JPanel
{
    // ////////////////////////////////////////////////////////////////////////
    // 逻辑控制区域
    // ////////////////////////////////////////////////////////////////////////
    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 默认构造函数
     */
    public NetPanel()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面显示区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @return
     */
    public boolean wInit()
    {
        this.setLayout(new BoxLayout(this, BoxLayout.Y_AXIS));

        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 对外接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 添加一个独立插件组件
     * 
     * @param soft
     * @return
     */
    public boolean addPlugin(WNetItem item)
    {
        NetPlugin netItem = new NetPlugin();
        netItem.wInit();
        netItem.setItem(item);
        this.add(netItem);

        return true;
    }
    // ////////////////////////////////////////////////////////////////////////
    // 界面组件区域
    // ////////////////////////////////////////////////////////////////////////
    /** serialVersionUID */
    private static final long serialVersionUID = 4825241758939187722L;
}
