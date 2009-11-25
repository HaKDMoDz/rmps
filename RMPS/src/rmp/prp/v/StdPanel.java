/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.v;

import javax.swing.BoxLayout;

import com.amonsoft.rmps.prp.ISoft;
import rmp.prp.b.StdPlugin;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 标准插件承载布局面板
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class StdPanel extends javax.swing.JPanel
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
    public StdPanel()
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
    // 对象接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 添加一个标准插件组件
     * 
     * @param soft
     * @return
     */
    public boolean addPlugin(ISoft soft)
    {
        StdPlugin stdPlugin = new StdPlugin();
        stdPlugin.wInit();
        stdPlugin.setSoft(soft);
        this.add(stdPlugin);

        return true;
    }
    // ////////////////////////////////////////////////////////////////////////
    // 界面组件区域
    // ////////////////////////////////////////////////////////////////////////
    /** serialVersionUID */
    private static final long serialVersionUID = 730826188734915473L;
}
