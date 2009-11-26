/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.v;

import javax.swing.BoxLayout;

import rmp.prp.b.ExePlug_In;
import rmp.prp.m.WExeItem;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 独立插件承载布局面板
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class ExePanel extends javax.swing.JPanel
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
    public ExePanel()
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
    public boolean addPlugin(WExeItem item)
    {
        ExePlug_In softItem = new ExePlug_In(item);
        softItem.wInit();
        this.add(softItem);

        return true;
    }
    // ////////////////////////////////////////////////////////////////////////
    // 界面组件区域
    // ////////////////////////////////////////////////////////////////////////
    /** serialVersionUID */
    private static final long serialVersionUID = 198021002287443611L;
}
