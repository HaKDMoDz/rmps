/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3090000.v;

import javax.swing.ButtonGroup;

import rmp.Rmps;
import rmp.prp.aide.P3090000.P3090000;
import rmp.prp.aide.P3090000.t.Util;
import rmp.util.MesgUtil;

import com.amonsoft.util.CharUtil;
import com.amonsoft.util.LogUtil;

import cons.prp.aide.P3090000.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * 
 * @author Amon
 */
public final class SubMenu
{
    /** 主应用程序 */
    private P3090000 ms_MainSoft;
    /** 主级联菜单 */
    private javax.swing.JMenu mm_MainMenu;

    /**
     * @param soft
     * @param menu
     */
    public SubMenu(P3090000 soft, javax.swing.JMenu menu)
    {
        this.ms_MainSoft = soft;
        this.mm_MainMenu = menu;
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        mm_MainMenu.setText(ms_MainSoft.wGetTitle());

        ica();
        icb();
        icc();

        return true;
    }

    /**
     * 日期选择
     */
    private void ica()
    {
        javax.swing.JCheckBoxMenuItem item;
        ButtonGroup bg = new ButtonGroup();

        // 今日
        item = new javax.swing.JCheckBoxMenuItem();
        item.setText("今日");
        item.setSelected(true);
        item.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mm_Days0_Handler(evt);
            }
        });
        bg.add(item);
        mm_MainMenu.add(item);

        // 明日
        item = new javax.swing.JCheckBoxMenuItem();
        item.setText("明日");
        item.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mm_Days1_Handler(evt);
            }
        });
        bg.add(item);
        mm_MainMenu.add(item);

        // 后日
        item = new javax.swing.JCheckBoxMenuItem();
        item.setText("后日");
        item.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mm_Days2_Handler(evt);
            }
        });
        bg.add(item);
        mm_MainMenu.add(item);
    }

    /**
     * 立即更新
     */
    private void icb()
    {
        javax.swing.JMenuItem item;

        mm_MainMenu.addSeparator();

        item = new javax.swing.JMenuItem();
        item.setText("立即更新");
        item.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mm_Updt_Handler(evt);
            }
        });
        mm_MainMenu.add(item);
    }

    /**
     * 城市选择
     */
    private void icc()
    {
        javax.swing.JMenuItem item;

        mm_MainMenu.addSeparator();

        item = new javax.swing.JMenuItem();
        item.setText("选择城市");
        item.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mm_City_Handler(evt);
            }
        });
        mm_MainMenu.add(item);
    }

    /**
     * 显示今日天气事件处理
     * 
     * @param evt
     */
    private void mm_Days0_Handler(java.awt.event.ActionEvent evt)
    {
        Util.setTheDate(0);
        Util.firePropertyChanged("tailPanel");
    }

    /**
     * 显示明日天气事件处理
     * 
     * @param evt
     */
    private void mm_Days1_Handler(java.awt.event.ActionEvent evt)
    {
        Util.setTheDate(1);
        Util.firePropertyChanged("tailPanel");
    }

    /**
     * 显示后日天气事件处理
     * 
     * @param evt
     */
    private void mm_Days2_Handler(java.awt.event.ActionEvent evt)
    {
        Util.setTheDate(2);
        Util.firePropertyChanged("tailPanel");
    }

    /**
     * 立即更新事件处理
     * 
     * @param evt
     */
    private void mm_Updt_Handler(java.awt.event.ActionEvent evt)
    {
        Util.firePropertyChanged("tailPanel");
    }

    /**
     * 城市切换事件处理
     * 
     * @param evt
     */
    private void mm_City_Handler(java.awt.event.ActionEvent evt)
    {
        // 提示用户输入城市信息
        String city = MesgUtil.showInputDialog(null, "请输入您要切换的城市的名称：");
        if (!CharUtil.isValidate(city))
        {
            return;
        }
        city = city.trim();
        Rmps.getUser().setCfg(ConstUI.CFG_CITY, city);
        LogUtil.log("用户切换城市：" + city);

        Util.firePropertyChanged("tailPanel");
    }
}
