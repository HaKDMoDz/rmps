/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.amon.rmps.AF010000.v;

import java.awt.GridLayout;

import rmp.amon.rmps.AF010000.AF010000;
import rmp.util.BeanUtil;
import rmp.util.LogUtil;

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
public class TailPanel
{
    // ////////////////////////////////////////////////////////////////////////
    // 控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    private javax.swing.JPanel tp_TailPanel;
    /** MSN机器人 */
    private rmp.irp.Imps ir_ImsRobotA;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param soft
     * @param tailPanel
     */
    public TailPanel(AF010000 soft, javax.swing.JPanel tailPanel)
    {
        this.tp_TailPanel = tailPanel;
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        ica();
        icb();
        ita();
        itb();

        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 对外接口区域
    // ////////////////////////////////////////////////////////////////////////
    // ////////////////////////////////////////////////////////////////////////
    // 布局显示区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 界面布局区域
    // ----------------------------------------------------
    /**
     * 界面布局初始化
     */
    private void ica()
    {
        pl_A = new javax.swing.JPanel();

        java.awt.GridBagConstraints gridBagConstraints;

        lb_A = new javax.swing.JLabel();
        bt_StartA = new javax.swing.JButton();
        bt_StopA = new javax.swing.JButton();

        pl_A.setLayout(new java.awt.GridBagLayout());

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(5, 5, 5, 5);
        pl_A.add(lb_A, gridBagConstraints);

        bt_StartA.setMnemonic('S');
        bt_StartA.setText("S");
        bt_StartA.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_StartA_Handler(evt);
            }
        });
        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.insets = new java.awt.Insets(5, 0, 5, 0);
        pl_A.add(bt_StartA, gridBagConstraints);

        bt_StopA.setMnemonic('E');
        bt_StopA.setText("E");
        bt_StopA.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_StopA_Handler(evt);
            }
        });
        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.insets = new java.awt.Insets(5, 5, 5, 5);
        pl_A.add(bt_StopA, gridBagConstraints);
    }

    /**
     * 
     */
    private void icb()
    {
        tp_TailPanel.setLayout(new GridLayout(1, 0, 5, 5));

        tp_TailPanel.add(pl_A);
    }

    // ----------------------------------------------------
    // 语言显示区域
    // ----------------------------------------------------
    /**
     * 界面语言初始化
     */
    private void ita()
    {
        lb_A.setText("MSN机器人");
        lb_A.setToolTipText("MSN机器人");

        BeanUtil.setWText(bt_StartA, "&S");
        BeanUtil.setWTips(bt_StartA, "启动MSN机器人");

        BeanUtil.setWText(bt_StopA, "&E");
        BeanUtil.setWTips(bt_StopA, "停止MSN机器人");
    }

    /**
     * 
     */
    private void itb()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param evt
     */
    private void bt_StartA_Handler(java.awt.event.ActionEvent evt)
    {
        LogUtil.log("服务启动：启动阿木机器人！");

        // 机器人实例对象是否存在
        if (ir_ImsRobotA == null)
        {
//            ir_ImsRobotA = new ImsRobot();
        }

        // 启动机器人
//        ir_ImsRobotA.start();

        LogUtil.log("服务启动：阿木机器人启动成功！");
    }

    /**
     * @param evt
     */
    private void bt_StopA_Handler(java.awt.event.ActionEvent evt)
    {
        // 机器人实例对象是否存在
        if (ir_ImsRobotA == null)
        {
            LogUtil.log("服务停止：阿木机器人不在服务状态！");
        }

        LogUtil.log("服务停止：停止阿木机器人！");

        // 停止机器人
//        ir_ImsRobotA.stop();

        LogUtil.log("服务停止：阿木机器人停止成功！");
    }
    // ////////////////////////////////////////////////////////////////////////
    // 公共方法区域
    // ////////////////////////////////////////////////////////////////////////
    // ////////////////////////////////////////////////////////////////////////
    // 界面组件区域
    // ////////////////////////////////////////////////////////////////////////
    private javax.swing.JPanel pl_A;
    private javax.swing.JButton bt_StartA;
    private javax.swing.JButton bt_StopA;
    private javax.swing.JLabel lb_A;
}
