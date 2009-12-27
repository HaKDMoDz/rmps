/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3020000.v;

import java.io.File;

import javax.swing.JFileChooser;

import rmp.face.WBean;
import rmp.prp.aide.P3020000.P3020000;
import rmp.prp.aide.P3020000.m.DataModel;
import rmp.prp.aide.P3020000.t.Util;
import rmp.util.BeanUtil;
import rmp.util.MesgUtil;
import rmp.util.StringUtil;

import com.amonsoft.util.CharUtil;
import com.amonsoft.util.LogUtil;

import cons.ui.LangRes;

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
public class NormPanel extends javax.swing.JPanel implements WBean
{
    // ////////////////////////////////////////////////////////////////////////
    // 逻辑控制区域
    // ////////////////////////////////////////////////////////////////////////
    /**  */
    private DataModel dm_NameList;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param soft
     */
    public NormPanel(P3020000 soft)
    {
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

    // ////////////////////////////////////////////////////////////////////////
    // 界面显示区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 界面布局初始化
     */
    private void ica()
    {
        lb_FilePath = new javax.swing.JLabel();
        tf_FilePath = new javax.swing.JTextField();
        bt_FilePath = new javax.swing.JButton();
        lb_RuleFild = new javax.swing.JLabel();
        tf_RuleFild = new javax.swing.JTextField();
        lb_NameList = new javax.swing.JLabel();
        javax.swing.JScrollPane sp = new javax.swing.JScrollPane();
        tb_NameList = new javax.swing.JTable();
        bt_RenmButn = new javax.swing.JButton();
        bt_PrevButn = new javax.swing.JButton();

        lb_FilePath.setDisplayedMnemonic('F');
        lb_FilePath.setLabelFor(bt_FilePath);
        lb_FilePath.setText("文件路径(F)");

        tf_FilePath.setEditable(false);

        bt_FilePath.setText(">>");
        bt_FilePath.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_FilePath.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_FilePath_Handler(evt);
            }
        });

        lb_RuleFild.setDisplayedMnemonic('R');
        lb_RuleFild.setLabelFor(tf_RuleFild);
        lb_RuleFild.setText("命名规则(R)");

        tf_RuleFild.setText("ABC_\\/:.jpg");
        tf_RuleFild.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_RuleFild_Handler(evt);
            }
        });

        lb_NameList.setDisplayedMnemonic('L');
        lb_NameList.setText("命名结果(L)");

        dm_NameList = new DataModel();
        tb_NameList.setModel(dm_NameList);
        sp.setViewportView(tb_NameList);

        bt_RenmButn.setMnemonic('O');
        bt_RenmButn.setText("确定(O)");
        bt_RenmButn.setToolTipText("确定进行文件命名");
        bt_RenmButn.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_RenmButn_Handler(evt);
            }
        });

        bt_PrevButn.setMnemonic('P');
        bt_PrevButn.setText("预览(P)");
        bt_PrevButn.setToolTipText("预览文件命名结果");
        bt_PrevButn.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_PrevButn_Handler(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(sp, javax.swing.GroupLayout.DEFAULT_SIZE, 220, Short.MAX_VALUE).addGroup(
                                layout.createSequentialGroup().addComponent(lb_FilePath).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(tf_FilePath,
                                        javax.swing.GroupLayout.DEFAULT_SIZE, 113, Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_FilePath))
                                .addGroup(
                                        layout.createSequentialGroup().addComponent(lb_RuleFild).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(tf_RuleFild,
                                                javax.swing.GroupLayout.DEFAULT_SIZE, 150, Short.MAX_VALUE)).addComponent(lb_NameList).addGroup(javax.swing.GroupLayout.Alignment.TRAILING,
                                        layout.createSequentialGroup().addComponent(bt_PrevButn).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_RenmButn)))
                        .addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_FilePath).addComponent(bt_FilePath).addComponent(tf_FilePath,
                                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_RuleFild).addComponent(tf_RuleFild, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(
                        lb_NameList).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp, javax.swing.GroupLayout.PREFERRED_SIZE, 201,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_RenmButn).addComponent(bt_PrevButn)).addContainerGap()));
    }

    /**
     * 界面语言初始化
     */
    private void ita()
    {
        String t = "<html>命名规则：<br />\\ 代表大写字母；<br />/ 代表小写字母；<br />: 代表数字。</html>";
        BeanUtil.setWTips(tf_RuleFild, t);
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 路径选择按钮事件处理
     * 
     * @param evt
     */
    private void bt_FilePath_Handler(java.awt.event.ActionEvent evt)
    {
        javax.swing.JFileChooser fc = new javax.swing.JFileChooser();
        fc.setFileSelectionMode(javax.swing.JFileChooser.FILES_AND_DIRECTORIES);
        fc.setMultiSelectionEnabled(false);
        String t = tf_FilePath.getText().trim();
        if (t.length() > 0)
        {
            fc.setSelectedFile(new File(t));
        }

        // 对话框状态处理
        int stat = fc.showOpenDialog(this);

        // 用户取消操作
        if (JFileChooser.CANCEL_OPTION == stat)
        {
            LogUtil.log("文件系统操作：用户取消文件打开！！！");
            return;
        }

        // 打开错误处理
        if (JFileChooser.ERROR_OPTION == stat)
        {
            LogUtil.log("文件系统操作：文件打开错误！！！");
            String mesg = StringUtil.format(LangRes.MESG_OTHR_0008, LangRes.MESG_INIT_0007);
            MesgUtil.showMessageDialog(this, mesg);
            return;
        }

        // 选择文件处理
        if (JFileChooser.APPROVE_OPTION != stat)
        {
            return;
        }

        // 获取用户选择文件
        File userFile = fc.getSelectedFile();
        LogUtil.log("文件系统操作：用户选择文件 － " + userFile.getPath());
        tf_FilePath.setText(userFile.getAbsolutePath());

        // 获取文档列表
        dm_NameList.listFiles(userFile.getPath());
        dm_NameList.fireTableDataChanged();
    }

    /**
     * 结果预览按钮事件处理
     * 
     * @param evt
     */
    private void bt_PrevButn_Handler(java.awt.event.ActionEvent evt)
    {
        // 用户输入检测
        if (!checkInput())
        {
            return;
        }

        // 预览事件处理
        File userFile = new File(tf_FilePath.getText());
        String srcFilePath = userFile.getParent();
        try
        {
            Util.reNameFile(srcFilePath, srcFilePath, tf_RuleFild.getText(), dm_NameList.getFileList(), false);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(this, exp.getMessage());
        }
        dm_NameList.fireTableDataChanged();

        // 焦点事件处理
        tf_RuleFild.requestFocus();
    }

    /**
     * 文件命名按钮事件处理
     * 
     * @param evt
     */
    private void bt_RenmButn_Handler(java.awt.event.ActionEvent evt)
    {
        // 用户输入检测
        if (!checkInput())
        {
            return;
        }

        // 命名事件处理
        // 取得父目录
        String srcFilePath = tf_FilePath.getText();
        File userFile = new File(tf_FilePath.getText());
        if (!userFile.isDirectory())
        {
            srcFilePath = userFile.getParent();
        }
        // 文件重命名
        boolean ok = false;
        try
        {
            ok = Util.reNameFile(srcFilePath, srcFilePath, tf_RuleFild.getText(), dm_NameList.getFileList(), true);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(this, exp.getMessage());
        }
        dm_NameList.fireTableDataChanged();

        // 提示信息
        MesgUtil.showMessageDialog(this, ok ? "文件重命名成功！" : "文件重命名失败！");

        // 焦点事件处理
        tf_RuleFild.requestFocus();
    }

    /**
     * 命名规则文本框事件处理
     * 
     * @param evt
     */
    private void tf_RuleFild_Handler(java.awt.event.ActionEvent evt)
    {
        if (!checkInput())
        {
            return;
        }

        dm_NameList.fireTableDataChanged();
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 用户输入合法性检测
     * 
     * @return
     */
    private boolean checkInput()
    {
        // // 命名文件夹选择是否为空
        // if (!CharUtil.isValidate(tf_FilePath.getText()))
        // {
        // MesgUtil.showMessageDialog(this, "请选择重命名目标文件或文件夹！");
        // return false;
        // }
        // 命名规则输入是否为空
        if (!CharUtil.isValidate(tf_RuleFild.getText()))
        {
            MesgUtil.showMessageDialog(this, "重命名表达式不能为空！");
            this.tf_RuleFild.requestFocus();
            return false;
        }

        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面组件区域
    // ////////////////////////////////////////////////////////////////////////
    private javax.swing.JButton bt_FilePath;
    private javax.swing.JButton bt_PrevButn;
    private javax.swing.JButton bt_RenmButn;
    private javax.swing.JLabel lb_FilePath;
    private javax.swing.JLabel lb_NameList;
    private javax.swing.JLabel lb_RuleFild;
    private javax.swing.JTable tb_NameList;
    private javax.swing.JTextField tf_FilePath;
    private javax.swing.JTextField tf_RuleFild;
    /** serialVersionUID */
    private static final long serialVersionUID = 1356601312740442128L;
}
