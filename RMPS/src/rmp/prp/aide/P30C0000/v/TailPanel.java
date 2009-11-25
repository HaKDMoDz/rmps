/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P30C0000.v;

import java.net.InetAddress;
import java.net.UnknownHostException;
import java.util.EventObject;
import java.util.HashMap;

import rmp.comn.tray.C3010000.C3010000;
import rmp.face.WBackCall;
import rmp.prp.aide.P30C0000.P30C0000;
import rmp.prp.aide.P30C0000.t.Util;
import rmp.util.BeanUtil;
import rmp.util.CheckUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import cons.prp.aide.P30C0000.LangRes;

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
public class TailPanel implements WBackCall
{
    // ////////////////////////////////////////////////////////////////////////
    // 逻辑控制区域
    // ////////////////////////////////////////////////////////////////////////
    // private P30C0000 ms_MainSoft;
    private javax.swing.JPanel tp_TailPanel;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param soft
     * @param tailPanel
     */
    public TailPanel(P30C0000 soft, javax.swing.JPanel tailPanel)
    {
        this.tp_TailPanel = tailPanel;
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        ica();
        ita();

        Util.register("tailPanel", this);

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WBackCall#wAction(java.util.EventObject, java.lang.Object)
     */
    @ Override
    public void wAction(EventObject event, Object object, String property)
    {
        try
        {
            InetAddress inetAddr = InetAddress.getLocalHost();
            tf_INetAddr.setText(inetAddr.getHostAddress());
        }
        catch(UnknownHostException exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(C3010000.queryRef("prp"), "获取本机IP地址出错，请重新尝试！");
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面显示区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 布局管理区域
    // ----------------------------------------------------
    /**
     * 查询界面用户交互区域初始化
     */
    private void ica()
    {
        java.awt.GridBagConstraints gbc = new java.awt.GridBagConstraints();

        tf_INetAddr = new javax.swing.JTextField();
        bt_INetAddr = new javax.swing.JButton();

        tp_TailPanel.setLayout(new java.awt.GridBagLayout());

        tf_INetAddr.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_INetAddr_Handler(evt);
            }
        });
        gbc.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gbc.weightx = 1.0;
        gbc.insets = new java.awt.Insets(5, 5, 5, 5);
        tp_TailPanel.add(tf_INetAddr, gbc);

        bt_INetAddr.setMnemonic('Q');
        bt_INetAddr.setText("查询(Q)");
        bt_INetAddr.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_INetAddr.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_INetAddr_Handler(evt);
            }
        });
        gbc.fill = java.awt.GridBagConstraints.NONE;
        gbc.weightx = 0.0;
        gbc.insets = new java.awt.Insets(5, 0, 5, 5);
        tp_TailPanel.add(bt_INetAddr, gbc);
    }

    // ----------------------------------------------------
    // 语言显示区域
    // ----------------------------------------------------
    /**
     * 界面语言显示
     */
    private void ita()
    {
        BeanUtil.setWText(tf_INetAddr, P30C0000.getMesg(LangRes.FILD_TEXT_INETADDR));
        BeanUtil.setWTips(tf_INetAddr, P30C0000.getMesg(LangRes.FILD_TIPS_INETADDR));
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 文本查询事件处理
     * 
     * @param evt
     */
    private void tf_INetAddr_Handler(java.awt.event.ActionEvent evt)
    {
        queryData();
    }

    /**
     * 按钮查询事件处理
     * 
     * @param evt
     */
    private void bt_INetAddr_Handler(java.awt.event.ActionEvent evt)
    {
        queryData();
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共方法区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 数据查询
     */
    private void queryData()
    {
        String text = this.tf_INetAddr.getText();
        if (!CheckUtil.isValidate(text))
        {
            MesgUtil.showMessageDialog(tp_TailPanel, "查询内容不能为空，请重新输入！");
            this.tf_INetAddr.requestFocus();
            return;
        }

        try
        {
            HashMap<Integer, String> dataList = Util.getCountryCityByIp(text);
            StringBuffer sb = new StringBuffer();
            if (dataList == null || dataList.size() < 1)
            {
                sb.append("无法获得IP数据，请重新查询！");
            }
            else
            {
                sb.append("<html>");
                sb.append("网络地址：").append(dataList.get(0));
                sb.append("<br />");
                sb.append("物理地址：").append(dataList.get(1));
                sb.append("</html>");
            }
            MesgUtil.showMessageDialog(C3010000.queryRef("prp"), sb.toString());
        }
        catch(Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(C3010000.queryRef("prp"), "IP地址查询出错，请重新查询");
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面构件区域
    // ////////////////////////////////////////////////////////////////////////
    /** 查询按钮 */
    private javax.swing.JButton    bt_INetAddr;
    /** 用户输入文本框 */
    private javax.swing.JTextField tf_INetAddr;
}
