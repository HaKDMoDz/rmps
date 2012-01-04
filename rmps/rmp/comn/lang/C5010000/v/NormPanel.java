/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.lang.C5010000.v;

import java.io.File;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;

import javax.swing.DefaultComboBoxModel;
import javax.swing.DefaultListModel;

import rmp.bean.FilesFilter;
import rmp.bean.K1IV2S;
import rmp.comn.lang.C5010000.C5010000;
import rmp.comn.lang.C5010000.t.Util;
import rmp.face.WBean;
import rmp.util.FileUtil;
import rmp.util.MesgUtil;

import com.amonsoft.util.CharUtil;

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
    /** 前置标记，如P,M,E,W等 */
    private String pre;
    /** 当前选择ID变量 */
    private int sid;
    /** 模块标记 */
    private int mid;
    /** 片段标记 */
    private int fid;
    /** 当前片段语言资源数量 */
    private int lis;
    /** 是否为数据更新 */
    private boolean isUpdate;
    /** 语言资源路径 */
    private String langPath;
    /** 当前编辑语言资源 */
    private HashMap<String, String> langProp;
    private List<String> tpltList;
    private DefaultComboBoxModel cm_Module;
    private DefaultComboBoxModel cm_Field;
    private DefaultListModel lm_LangList;

    /**
     * @param soft
     */
    public NormPanel(C5010000 soft)
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
     * 
     */
    private void ica()
    {
        tf_FilePath = new javax.swing.JTextField();
        bt_FilePath = new javax.swing.JButton();
        bt_ReadData = new javax.swing.JButton();
        lb_Module = new javax.swing.JLabel();
        cb_Module = new javax.swing.JComboBox();
        lb_Field = new javax.swing.JLabel();
        cb_Field = new javax.swing.JComboBox();
        lb_LangHash = new javax.swing.JLabel();
        tf_LangHash = new javax.swing.JTextField();
        bt_Create = new javax.swing.JButton();
        bt_Delete = new javax.swing.JButton();
        lb_LangText = new javax.swing.JLabel();
        javax.swing.JScrollPane sp1 = new javax.swing.JScrollPane();
        ta_LangText = new javax.swing.JTextArea();
        javax.swing.JScrollPane sp2 = new javax.swing.JScrollPane();
        ls_LangList = new javax.swing.JList();
        bt_SaveData = new javax.swing.JButton();
        bt_Insert = new javax.swing.JButton();

        tf_FilePath.setText("template/amon/lang/A3010000/comn.wsc");
        tf_FilePath.setToolTipText("模板文档路径");
        tf_FilePath.setEditable(false);

        bt_FilePath.setMnemonic('P');
        bt_FilePath.setText("选择(P)");
        bt_FilePath.setToolTipText("选择模板文件");
        bt_FilePath.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_FilePath_Handler(evt);
            }
        });

        bt_ReadData.setMnemonic('R');
        bt_ReadData.setText("读取(R)");
        bt_ReadData.setToolTipText("读取模板数据");
        bt_ReadData.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ReadData_Handler(evt);
            }
        });

        lb_Module.setDisplayedMnemonic('M');
        lb_Module.setLabelFor(cb_Module);
        lb_Module.setText("语言模块(M)");

        cm_Module = new DefaultComboBoxModel();
        cb_Module.setModel(cm_Module);
        cb_Module.addItemListener(new java.awt.event.ItemListener()
        {
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                cb_Module_Handler(evt);
            }
        });

        lb_Field.setDisplayedMnemonic('F');
        lb_Field.setLabelFor(cb_Field);
        lb_Field.setText("语言区间(F)");

        cm_Field = new DefaultComboBoxModel();
        cb_Field.setModel(cm_Field);
        cb_Field.addItemListener(new java.awt.event.ItemListener()
        {
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                cb_Field_Handler(evt);
            }
        });

        lb_LangHash.setDisplayedMnemonic('I');
        lb_LangHash.setLabelFor(tf_LangHash);
        lb_LangHash.setText("语言标记(I)");

        tf_LangHash.setColumns(10);
        tf_LangHash.setToolTipText("语言标记索引");

        bt_Create.setMnemonic('N');
        bt_Create.setText("N");
        bt_Create.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_Create_Handler(evt);
            }
        });

        bt_Delete.setMnemonic('D');
        bt_Delete.setText("D");
        bt_Delete.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_Delete_Handler(evt);
            }
        });

        lb_LangText.setDisplayedMnemonic('C');
        lb_LangText.setLabelFor(ta_LangText);
        lb_LangText.setText("语言内容(C)");

        ta_LangText.setRows(4);
        ta_LangText.setLineWrap(true);
        sp1.setViewportView(ta_LangText);

        lm_LangList = new DefaultListModel();
        ls_LangList.setModel(lm_LangList);
        ls_LangList.addListSelectionListener(new javax.swing.event.ListSelectionListener()
        {
            public void valueChanged(javax.swing.event.ListSelectionEvent evt)
            {
                ls_LangList_Handler(evt);
            }
        });
        sp2.setViewportView(ls_LangList);

        bt_SaveData.setMnemonic('S');
        bt_SaveData.setText("存储(S)");
        bt_SaveData.setToolTipText("保存语言内容到文件");
        bt_SaveData.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_SaveData_Handler(evt);
            }
        });

        bt_Insert.setMnemonic('O');
        bt_Insert.setText("添加(O)");
        bt_Insert.setToolTipText("添加语言内容");
        bt_Insert.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_Insert_Handler(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                                javax.swing.GroupLayout.Alignment.TRAILING,
                                layout.createSequentialGroup().addComponent(tf_FilePath, javax.swing.GroupLayout.DEFAULT_SIZE, 249, Short.MAX_VALUE).addPreferredGap(
                                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_FilePath).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(
                                        bt_ReadData)).addGroup(
                                layout.createSequentialGroup().addGroup(
                                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                                                layout.createSequentialGroup().addComponent(lb_Module).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(cb_Module,
                                                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addGroup(
                                                layout.createSequentialGroup().addComponent(lb_Field).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(cb_Field,
                                                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addGroup(
                                                layout.createSequentialGroup().addComponent(lb_LangHash).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(tf_LangHash,
                                                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                                                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Create).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                                        .addComponent(bt_Delete)).addComponent(lb_LangText).addComponent(sp1, javax.swing.GroupLayout.DEFAULT_SIZE, 276, Short.MAX_VALUE))
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp2, javax.swing.GroupLayout.PREFERRED_SIZE, 98,
                                                javax.swing.GroupLayout.PREFERRED_SIZE)).addGroup(javax.swing.GroupLayout.Alignment.TRAILING,
                                layout.createSequentialGroup().addComponent(bt_Insert).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_SaveData)))
                        .addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_ReadData).addComponent(bt_FilePath).addComponent(tf_FilePath,
                                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false).addGroup(
                                layout.createSequentialGroup().addGroup(
                                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_Module).addComponent(cb_Module, javax.swing.GroupLayout.PREFERRED_SIZE,
                                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                        .addGroup(
                                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_Field).addComponent(cb_Field,
                                                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_LangHash).addComponent(tf_LangHash,
                                                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(bt_Create)
                                                        .addComponent(bt_Delete)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lb_LangText).addPreferredGap(
                                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                                                javax.swing.GroupLayout.PREFERRED_SIZE)).addComponent(sp2)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED,
                        javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_SaveData).addComponent(bt_Insert)).addContainerGap()));
    }

    /**
     * 
     */
    private void ita()
    {
    }

    /**
     * 新增一个语言资源标记按钮事件处理
     * 
     * @param evt
     */
    private void bt_Create_Handler(java.awt.event.ActionEvent evt)
    {
        tf_LangHash.setText((pre + Integer.toHexString(fid + lis)).toUpperCase());
        ta_LangText.setText("");
        ta_LangText.requestFocus();
        isUpdate = false;
    }

    /**
     * @param evt
     */
    private void bt_Delete_Handler(java.awt.event.ActionEvent evt)
    {
        String key = (String) ls_LangList.getSelectedValue();
        if (key != null)
        {
            if (0 == MesgUtil.showConfirmDialog(this, "确认删除此数据？"))
            {
                langProp.remove(key);
                lm_LangList.removeElement(key);
            }
        }
    }

    /**
     * @param evt
     */
    private void bt_FilePath_Handler(java.awt.event.ActionEvent evt)
    {
        // ------------------------------------------------
        // 显示文件选择对话框
        // ------------------------------------------------
        FilesFilter ff = new FilesFilter();
        ff.setTextInclude(new String[]
        { ".wsc" });
        ff.setInclude(false);
        File tpltFile = FileUtil.showSingleFileOpen(this, false, ff);
        if (tpltFile == null || !tpltFile.exists() || !tpltFile.canRead())
        {
            return;
        }
        tf_FilePath.setText(tpltFile.getAbsolutePath());

        readLangData();
    }

    /**
     * @param evt
     */
    private void bt_ReadData_Handler(java.awt.event.ActionEvent evt)
    {
        readLangData();
    }

    /**
     * 保存当前用户输入语言资源事件处理
     * 
     * @param evt
     */
    private void bt_Insert_Handler(java.awt.event.ActionEvent evt)
    {
        // 用户输入数据完整性检测
        String hash = tf_LangHash.getText();
        if (!CharUtil.isValidate(hash))
        {
            MesgUtil.showMessageDialog(this, "请输入语言资源标记！");
            tf_LangHash.requestFocus();
            return;
        }

        // 更新或添加语言资源
        langProp.put(hash, ta_LangText.getText());

        // 新增语言资源情况处理
        if (!isUpdate)
        {
            // 列表显示更新
            lm_LangList.addElement(hash);
            lis += 1;
            // 语言资源数量更新
            langProp.put((pre + Integer.toHexString(fid)).toUpperCase(), Integer.toHexString(lis));
        }

        // 界面显示更新
        ta_LangText.setText("");
        tf_LangHash.setText((pre + Integer.toHexString(fid + lis)).toUpperCase());
        ta_LangText.requestFocus();
        isUpdate = false;
    }

    /**
     * 保存按钮事件处理
     * 
     * @param evt
     */
    private void bt_SaveData_Handler(java.awt.event.ActionEvent evt)
    {
        Util.saveLangProp(tpltList, langProp, langPath, "LangRes.java");
    }

    /**
     * 语言区间事件处理
     * 
     * @param evt
     */
    private void cb_Field_Handler(java.awt.event.ItemEvent evt)
    {
        initLangList();
    }

    /**
     * 语言模块事件处理
     * 
     * @param evt
     */
    private void cb_Module_Handler(java.awt.event.ItemEvent evt)
    {
        initLangList();
    }

    /**
     * 已有语言列表事件处理
     * 
     * @param evt
     */
    private void ls_LangList_Handler(javax.swing.event.ListSelectionEvent evt)
    {
        String key = (String) ls_LangList.getSelectedValue();
        if (key == null)
        {
            isUpdate = false;
        }
        else
        {
            tf_LangHash.setText(key);
            ta_LangText.setText(langProp.get(key));
            isUpdate = true;
        }
    }

    /**
     * 读取语言资源数据
     */
    private void readLangData()
    {
        // ------------------------------------------------
        // 模板语言资源读取
        // ------------------------------------------------
        // 模板文件读取
        tpltList = Util.readTemplate(tf_FilePath.getText());

        // ------------------------------------------------
        // 已有语言资源读取
        // ------------------------------------------------
        // 语言资源路径
        langPath = "";

        // 语言资源读取
        File langFile = new File(langPath);
        if (!langFile.exists() || !langFile.canWrite())
        {
            MesgUtil.showMessageDialog(this, CharUtil.format("语言资源文件 “{0}” 不存在", langPath));
            return;
        }
        if (langProp == null)
        {
            langProp = new HashMap<String, String>();
        }
        langProp.clear();
        Util.readLangProp(langProp, langPath);

        // ------------------------------------------------
        // 模板数据应用
        // ------------------------------------------------
        String str = tpltList.get(0).trim();
        // 系统标记读取
        pre = str.substring(0, 1);
        sid = Integer.parseInt(str.substring(1), 16);
        // 下拉列表模型初始化
        int i = 1;
        int j = 17;
        while (i < 17)
        {
            cm_Module.addElement(new K1IV2S(i - 1, tpltList.get(i), tpltList.get(i)));
            cm_Field.addElement(new K1IV2S(j - 17, tpltList.get(j), tpltList.get(j)));
            i += 1;
            j += 1;
        }
    }

    /**
     * @param key
     */
    private void initLangList()
    {
        // 模块索引
        mid = sid + (cb_Module.getSelectedIndex() << 12);

        // 区间索引
        fid = mid + (cb_Field.getSelectedIndex() << 8);

        // 语言资源数量读取
        String key = (pre + Integer.toHexString(fid)).toUpperCase();
        String str = langProp.get(key);
        // 语言资源数量不存在时，默认此区段语言资源数量为1，用于新增语言资源
        if (str == null || str.length() < 1)
        {
            str = "1";
        }
        // 语言资源片段值加1
        lis = Integer.parseInt(str.trim(), 16);
        tf_LangHash.setText((pre + Integer.toHexString(fid + lis)).toUpperCase());

        // 列表显示
        str = key.substring(0, 6);
        lm_LangList.removeAllElements();
        String[] keys = new String[langProp.size()];
        langProp.keySet().toArray(keys);
        Arrays.sort(keys);
        for (String s : keys)
        {
            if (key.equals(s))
            {
                continue;
            }
            if (s.startsWith(str))
            {
                lm_LangList.addElement(s);
            }
        }
    }

    /** 新增一条语言资源 */
    private javax.swing.JButton bt_Create;
    /** 删除用户选择的一条语言资源 */
    private javax.swing.JButton bt_Delete;
    /**  */
    private javax.swing.JButton bt_FilePath;
    /**  */
    private javax.swing.JButton bt_ReadData;
    /** 保存用户输入的一条语言资源 */
    private javax.swing.JButton bt_Insert;
    /** 保存所有语言资源到文件 */
    private javax.swing.JButton bt_SaveData;
    /** 模块语言资源 */
    private javax.swing.JComboBox cb_Module;
    /** 片段语言资源 */
    private javax.swing.JComboBox cb_Field;
    private javax.swing.JLabel lb_Field;
    private javax.swing.JLabel lb_LangHash;
    private javax.swing.JLabel lb_LangText;
    private javax.swing.JLabel lb_Module;
    /** 已有语言资源列表 */
    private javax.swing.JList ls_LangList;
    private javax.swing.JTextArea ta_LangText;
    private javax.swing.JTextField tf_FilePath;
    private javax.swing.JTextField tf_LangHash;
    /** serialVersionUID */
    private static final long serialVersionUID = -1947347249379579514L;
}
