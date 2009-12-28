/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3060000.v;

import java.util.List;

import javax.swing.tree.DefaultMutableTreeNode;
import javax.swing.tree.DefaultTreeModel;

import rmp.bean.K1SV2S;
import rmp.face.WBean;
import rmp.prp.aide.P3060000.P3060000;
import rmp.util.BeanUtil;

import com.amonsoft.util.CharUtil;

import cons.prp.aide.P3060000.ConstUI;
import cons.prp.aide.P3060000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class StepPanel extends javax.swing.JPanel implements WBean
{
    /** 树模型 */
    private DefaultTreeModel treeMode;
    /** 树根节点 */
    private DefaultMutableTreeNode rootNode;
    /**  */
    private List<K1SV2S> stepList;
    /**  */
    private int currIndx;

    /**
     * 
     */
    public StepPanel()
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

    /**
     * 显示单步运算过程
     */
    private void ica()
    {
        javax.swing.JScrollPane sp_StepTree = new javax.swing.JScrollPane();
        rootNode = new DefaultMutableTreeNode();
        treeMode = new DefaultTreeModel(rootNode);
        tr_StepTree = new javax.swing.JTree(treeMode);
        bt_NextStep = new javax.swing.JButton();
        bt_LastStep = new javax.swing.JButton();

        sp_StepTree.setViewportView(tr_StepTree);

        bt_NextStep.setText("下一步(N)");
        bt_NextStep.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_NextStep_Handler(evt);
            }
        });

        bt_LastStep.setText("上一步(L)");
        bt_LastStep.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_LastStep_Handler(evt);
            }
        });
        bt_LastStep.setVisible(false);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addComponent(sp_StepTree, javax.swing.GroupLayout.Alignment.LEADING,
                                javax.swing.GroupLayout.DEFAULT_SIZE, 280, Short.MAX_VALUE).addGroup(
                                layout.createSequentialGroup().addComponent(bt_LastStep).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_NextStep)))
                        .addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addContainerGap().addComponent(sp_StepTree, javax.swing.GroupLayout.DEFAULT_SIZE, 150, Short.MAX_VALUE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_NextStep).addComponent(bt_LastStep)).addContainerGap()));
    }

    /**
     * 
     */
    private void ita()
    {
        BeanUtil.setWTips(tr_StepTree, P3060000.getMesg(LangRes.P3069901));

        BeanUtil.setWText(bt_LastStep, P3060000.getMesg(LangRes.P3069501));
        BeanUtil.setWTips(bt_LastStep, P3060000.getMesg(LangRes.P3069502));

        BeanUtil.setWText(bt_NextStep, P3060000.getMesg(LangRes.P3069503));
        BeanUtil.setWTips(bt_NextStep, P3060000.getMesg(LangRes.P3069504));
    }

    /**
     * @param list
     */
    public void setStep(List<K1SV2S> list)
    {
        stepList = list;
        rootNode.removeAllChildren();
        treeMode.nodeStructureChanged(rootNode);
        currIndx = 0;
    }

    /**
     * @param exps
     */
    public void setRoot(String exps)
    {
        if (rootNode != null)
        {
            rootNode.setUserObject(exps);
        }
    }

    /**
     * @param evt
     */
    private void bt_LastStep_Handler(java.awt.event.ActionEvent evt)
    {
    }

    /**
     * @param evt
     */
    private void bt_NextStep_Handler(java.awt.event.ActionEvent evt)
    {
        if (stepList == null || stepList.size() == 0)
        {
            return;
        }

        if (currIndx >= stepList.size())
        {
            // 移除之前显示节点内容
            rootNode.removeAllChildren();
            currIndx = 0;
        }

        // 循环添加每一个处理步骤到树节点并显示
        K1SV2S kvItem = stepList.get(currIndx++);

        // 临时数据持有对象
        String t;

        // 三级节点
        t = CharUtil.format(ConstUI.TAG_FONT, kvItem.getV2());
        DefaultMutableTreeNode node3 = new DefaultMutableTreeNode(CharUtil.format(ConstUI.TAG_HTML, ConstUI.TAG_STEP + t));

        // 二级节点
        t = CharUtil.format(ConstUI.TAG_FONT, kvItem.getV1());
        DefaultMutableTreeNode node2 = new DefaultMutableTreeNode(CharUtil.format(ConstUI.TAG_HTML, t));
        node2.add(node3);

        // 一级节点
        t = kvItem.getK().replace(kvItem.getV1(), t);
        DefaultMutableTreeNode node1 = new DefaultMutableTreeNode(CharUtil.format(ConstUI.TAG_HTML, ConstUI.TAG_STEP + t));
        node1.add(currIndx != stepList.size() ? node2 : node3);

        // 根节点
        rootNode.add(node1);

        // 树结构变更
        treeMode.nodeStructureChanged(rootNode);
    }

    /** 显示上一步计算 */
    private javax.swing.JButton bt_LastStep;
    /** 显示下一步计算 */
    private javax.swing.JButton bt_NextStep;
    /** 计算过程 */
    private javax.swing.JTree tr_StepTree;
    /** serialVersionUID */
    private static final long serialVersionUID = 4179320198058011210L;
}
