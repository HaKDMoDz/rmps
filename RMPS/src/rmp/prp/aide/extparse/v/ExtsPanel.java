/*
 * FileName:       ExtsPanel.java
 * CreateDate:     Jul 9, 2007 9:19:46 AM
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.v;

import java.sql.SQLException;
import java.util.EventObject;
import java.util.List;

import javax.swing.DefaultComboBoxModel;

import rmp.bean.K1SV2S;
import rmp.bean.K2SV1S;
import rmp.face.WBackCall;
import rmp.io.db.DBAccess;
import rmp.prp.aide.DC0008;
import rmp.prp.aide.P3010000.b.WListForm;
import rmp.prp.aide.extparse.Extparse;
import rmp.prp.aide.extparse.d.DA0008;
import rmp.prp.aide.extparse.m.BaseData;
import rmp.prp.aide.extparse.m.CorpBaseData;
import rmp.prp.aide.extparse.m.ExtsBaseData;
import rmp.prp.aide.extparse.m.ExtsUserData;
import rmp.prp.aide.extparse.m.FileBaseData;
import rmp.prp.aide.extparse.m.IdioBaseData;
import rmp.prp.aide.extparse.m.NatnBaseData;
import rmp.prp.aide.extparse.m.SoftBaseData;
import rmp.util.BeanUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.StringUtil;
import cons.SysCons;
import cons.id.PrpCons;
import cons.prp.aide.extparse.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * 后缀信息数据管理面板
 * <li>使用说明：</li>
 * <br>
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： Amon
 * </p>
 * <p>
 * 日期： Jul 9, 2007 9:19:46 AM
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class ExtsPanel extends javax.swing.JPanel implements WBackCall
{
    // ////////////////////////////////////////////////////////////////////////
    // 界面控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    /**  */
    private static final long    serialVersionUID = 5626020083712292716L;
    /** 当前状态是否为可编辑状态 */
    private boolean              isEditable;
    /** 当前操作是否为数据更新 */
    private boolean              isUpdate;
    /** 软件索引（更新时使用） */
    private String               softIndx_O;
    /** 公司选择对象 */
    private K2SV1S               kv_CorpLcNm;
    /** 国别选择对象 */
    private K2SV1S               kv_NatnIndx;
    /** 软件选择对象 */
    private K2SV1S               kv_SoftItem;
    /** 公司下拉列表数据模型 */
    private DefaultComboBoxModel cm_CorpLcNm;
    /** 所属类别列表数据模型 */
    private DefaultComboBoxModel cm_ExtsType;
    /** 公司下拉列表数据模型 */
    private DefaultComboBoxModel cm_IdioMail;
    /** 文件下拉列表数据模型 */
    private DefaultComboBoxModel cm_SignChar;
    /** 国别下拉列表数据模型 */
    private DefaultComboBoxModel cm_NatnIndx;
    /** 软件下拉列表数据模型 */
    private DefaultComboBoxModel cm_SoftName;

    /** 父应用引用 */
    private Extparse             me_MainSoft;

    /**
     * @param soft
     */
    public ExtsPanel(Extparse soft)
    {
        me_MainSoft = soft;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        // 界面初始化
        ica();

        // 界面语言显示
        ita();

        cm_NatnIndx = new DefaultComboBoxModel();
        cb_NatnIndx.setModel(cm_NatnIndx);

        cm_CorpLcNm = new DefaultComboBoxModel();
        cb_CorpIndx.setModel(cm_CorpLcNm);

        cm_SoftName = new DefaultComboBoxModel();
        cb_SoftIndx.setModel(cm_SoftName);

        cm_SignChar = new DefaultComboBoxModel();
        cb_FileIndx.setModel(cm_SignChar);

        cm_ExtsType = new DefaultComboBoxModel();
        cb_TypeIndx.setModel(cm_ExtsType);

        cm_IdioMail = new DefaultComboBoxModel();
        cb_IdioIndx.setModel(cm_IdioMail);

        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return false;
            }

            // 国别信息初始化
            initNatnList(dba);

            // 类别信息初始化
            initTypeList(dba);

            // 人员信息初始化
            initIdioList(dba);

            return true;
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
            return false;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WBackCall#wAction(java.awt.Event, java.lang.Object)
     */
    public void wAction(EventObject event, Object object, String property)
    {
        if (object instanceof BaseData)
        {
            BaseData baseMeta = (BaseData)object;

            DBAccess dba = new DBAccess();

            try
            {
                if (!dba.wInit())
                {
                    return;
                }

                setBaseData(dba, baseMeta);
            }
            catch(SQLException exp)
            {
                LogUtil.exception(exp);
            }
            finally
            {
                dba.closeConnection();
            }
        }
    }

    /**
     * @param extsName
     * @return
     */
    public static List<ExtsBaseData> queryByName(String extsName)
    {
        DBAccess dba = new DBAccess();

        try
        {
            List<ExtsBaseData> extsList = null;
            if (dba.wInit())
            {
                extsList = queryByName(dba, extsName);
            }
            return extsList;
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
            return null;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * @param dba
     * @param extsName
     * @return
     * @throws SQLException
     */
    public static List<ExtsBaseData> queryByName(DBAccess dba, String extsName) throws SQLException
    {
        return DA0008.selectExtsMeta(dba, extsName);
    }

    /**
     * 根据后缀名称（形如“.abc”格式）查寻相关信息
     * 
     * @param extsName
     * @return
     */
    public boolean metaSelect(ExtsUserData userMeta)
    {
        DBAccess dba = new DBAccess();

        // 数据查寻
        List<BaseData> extsList;
        try
        {
            if (!dba.wInit())
            {
                return false;
            }

            extsList = DA0008.selectBaseMeta(dba, userMeta.getExtsName());

            // 单个结果
            if (extsList != null && extsList.size() == 1)
            {
                return setBaseData(dba, extsList.get(0));
            }
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
            return false;
        }
        finally
        {
            dba.closeConnection();
        }

        // 错误处理
        if (extsList == null)
        {
            String mesg = StringUtil.format(LangRes.MESG_SELT_0004, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(this, mesg);
            return false;
        }
        // 数据为空
        else if (extsList.size() == 0)
        {
            MesgUtil.showMessageDialog(this, Extparse.getMesg(LangRes.MESG_SELT_0003));
            return false;
        }
        // 多个结果
        else
        {
            String mesg = Extparse.getMesg(LangRes.TITLE_EXTSFORM);
            WListForm.showDialog(null, mesg, extsList, this);
        }
        return true;
    }

    /**
     * @param extsIndx
     * @param softIndx
     * @return
     */
    public static ExtsBaseData queryByHash(String extsIndx, String softIndx)
    {
        return null;
    }

    /**
     * @param dba
     * @param extsIndx
     * @param softIndx
     * @return
     * @throws SQLException
     */
    public static ExtsBaseData queryByHash(DBAccess dba, String extsIndx, String softIndx) throws SQLException
    {
        return null;
    }

    /**
     * 数据更新
     * 
     * @param extsMeta
     * @return
     */
    public boolean metaUpdate(ExtsUserData extsMeta)
    {
        DBAccess dba = new DBAccess();

        try
        {
            // 连接初始化
            if (!dba.wInit())
            {
                return false;
            }

            // 数据更新
            DA0008.updateExtsMeta(dba, extsMeta);

            return true;
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg;
            if (exp.getErrorCode() == -104)
            {
                mesg = Extparse.getMesg(LangRes.MESG_UPDT_0006);
            }
            else
            {
                mesg = StringUtil.format(LangRes.MESG_UPDT_0005, LangRes.TITLE_EXTSFORM, LangRes.MESG_INIT_0010);
            }
            MesgUtil.showMessageDialog(this, mesg);
            return false;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * 后缀数据删除事件处理
     * 
     * @return
     */
    public boolean metaDelete(ExtsUserData extsMeta)
    {
        // 删除确认
        if (0 != MesgUtil.showConfirmDialog(this, Extparse.getMesg(LangRes.EXTS_MESG_DELT_0001)))
        {
            return true;
        }

        LogUtil.log("数据删除：指定软件的后缀信息删除！");

        // 数据库操作对象实例化
        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return false;
            }

            DA0008.deleteExtsMeta(dba, extsMeta);
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.closeConnection();
        }

        return true;
    }

    /**
     * 
     */
    private void ica()
    {
        lb_ExtsName = new javax.swing.JLabel();
        tf_ExtsName = new javax.swing.JTextField();
        lb_NatnIndx = new javax.swing.JLabel();
        cb_NatnIndx = new javax.swing.JComboBox();
        lb_CorpIndx = new javax.swing.JLabel();
        cb_CorpIndx = new javax.swing.JComboBox();
        lb_SoftIndx = new javax.swing.JLabel();
        cb_SoftIndx = new javax.swing.JComboBox();
        lb_FileIndx = new javax.swing.JLabel();
        cb_FileIndx = new javax.swing.JComboBox();
        lb_TypeIndx = new javax.swing.JLabel();
        cb_TypeIndx = new javax.swing.JComboBox();
        lb_IdioIndx = new javax.swing.JLabel();
        cb_IdioIndx = new javax.swing.JComboBox();
        lb_PlatForm = new javax.swing.JLabel();
        ck_PfAll = new javax.swing.JCheckBox();
        ck_PfWin = new javax.swing.JCheckBox();
        ck_PfMac = new javax.swing.JCheckBox();
        ck_PfUnx = new javax.swing.JCheckBox();
        ck_PfLnx = new javax.swing.JCheckBox();
        ck_PfMbl = new javax.swing.JCheckBox();
        ck_PfSpc = new javax.swing.JCheckBox();
        lb_ArchBits = new javax.swing.JLabel();
        ck_Ab64 = new javax.swing.JCheckBox();
        ck_Ab32 = new javax.swing.JCheckBox();
        ck_Ab16 = new javax.swing.JCheckBox();
        ck_Ab00 = new javax.swing.JCheckBox();
        lb_IdioMark = new javax.swing.JLabel();
        javax.swing.JScrollPane sp_TextArea = new javax.swing.JScrollPane();
        ta_IdioMark = new javax.swing.JTextArea();
        bt_Update = new javax.swing.JButton();
        bt_Create = new javax.swing.JButton();

        lb_ExtsName.setText("\u540e\u7f00\u540d\u79f0(E)");
        lb_ExtsName.setToolTipText("\u540e\u7f00\u540d\u79f0");
        lb_ExtsName.setLabelFor(tf_ExtsName);

        tf_ExtsName.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_ExtsName_Handler(evt);
            }
        });

        lb_NatnIndx.setText("\u56fd\u522b\u4fe1\u606f(N)");
        lb_NatnIndx.setToolTipText("\u56fd\u522b\u4fe1\u606f");
        lb_NatnIndx.setLabelFor(cb_NatnIndx);

        cb_NatnIndx.addItemListener(new java.awt.event.ItemListener()
        {
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                cb_NatnIndx_Handler(evt);
            }
        });

        lb_CorpIndx.setText("\u6240\u5c5e\u516c\u53f8(G)");
        lb_CorpIndx.setToolTipText("\u6240\u5c5e\u516c\u53f8");
        lb_CorpIndx.setLabelFor(cb_CorpIndx);

        cb_CorpIndx.addItemListener(new java.awt.event.ItemListener()
        {
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                cb_CorpIndx_Handler(evt);
            }
        });

        lb_SoftIndx.setText("\u76f4\u5c5e\u8f6f\u4ef6(S)");
        lb_SoftIndx.setToolTipText("\u76f4\u5c5e\u8f6f\u4ef6");
        lb_SoftIndx.setLabelFor(cb_SoftIndx);

        cb_SoftIndx.addItemListener(new java.awt.event.ItemListener()
        {
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                cb_SoftIndx_Handler(evt);
            }
        });

        lb_FileIndx.setText("\u6587\u4ef6\u7b7e\u540d(F)");
        lb_FileIndx.setToolTipText("\u6587\u4ef6\u7b7e\u540d");
        lb_FileIndx.setLabelFor(cb_FileIndx);

        lb_TypeIndx.setText("\u6240\u5c5e\u7c7b\u522b(T)");
        lb_TypeIndx.setToolTipText("\u6240\u5c5e\u7c7b\u522b");
        lb_TypeIndx.setLabelFor(cb_TypeIndx);

        lb_IdioIndx.setText("\u7279\u522b\u81f4\u8c22(T)");
        lb_IdioIndx.setToolTipText("\u7279\u522b\u81f4\u8c22");
        lb_IdioIndx.setLabelFor(cb_IdioIndx);

        lb_PlatForm.setText("\u5e94\u7528\u5e73\u53f0");
        lb_PlatForm.setToolTipText("\u5e94\u7528\u5e73\u53f0(P)");

        ck_PfAll.setSelected(true);
        ck_PfAll.setText("\u5e73\u53f0\u901a\u7528(G)");
        ck_PfAll.setToolTipText("\u5e73\u53f0\u901a\u7528");
        ck_PfAll.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfAll.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfAll.addChangeListener(new javax.swing.event.ChangeListener()
        {
            public void stateChanged(javax.swing.event.ChangeEvent evt)
            {
                ck_PfAll_Handler(evt);
            }
        });

        ck_PfWin.setMnemonic('W');
        ck_PfWin.setText("Windows(W)");
        ck_PfWin.setToolTipText("Windows");
        ck_PfWin.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfWin.setDisplayedMnemonicIndex(8);
        ck_PfWin.setEnabled(false);
        ck_PfWin.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfMac.setMnemonic('M');
        ck_PfMac.setText("Macintosh(M)");
        ck_PfMac.setToolTipText("Macintosh");
        ck_PfMac.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfMac.setDisplayedMnemonicIndex(10);
        ck_PfMac.setEnabled(false);
        ck_PfMac.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfUnx.setText("Unix(U)");
        ck_PfUnx.setToolTipText("Unix");
        ck_PfUnx.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfUnx.setDisplayedMnemonicIndex(5);
        ck_PfUnx.setEnabled(false);
        ck_PfUnx.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfLnx.setMnemonic('L');
        ck_PfLnx.setText("Linux(L)");
        ck_PfLnx.setToolTipText("Linux");
        ck_PfLnx.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfLnx.setDisplayedMnemonicIndex(6);
        ck_PfLnx.setEnabled(false);
        ck_PfLnx.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfMbl.setMnemonic('B');
        ck_PfMbl.setText("\u79fb\u52a8\u5e73\u53f0(M)");
        ck_PfMbl.setToolTipText("\u79fb\u52a8\u5e73\u53f0");
        ck_PfMbl.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfMbl.setEnabled(false);
        ck_PfMbl.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfSpc.setMnemonic('O');
        ck_PfSpc.setText("\u5176\u5b83\u5e73\u53f0(O)");
        ck_PfSpc.setToolTipText("\u5176\u5b83\u5e73\u53f0");
        ck_PfSpc.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfSpc.setEnabled(false);
        ck_PfSpc.setMargin(new java.awt.Insets(0, 0, 0, 0));

        lb_ArchBits.setText("CPU \u67b6\u6784");
        lb_ArchBits.setToolTipText("CPU \u67b6\u6784");

        ck_Ab64.setMnemonic('0');
        ck_Ab64.setText("64\u4f4d(0)");
        ck_Ab64.setToolTipText("64\u4f4d");
        ck_Ab64.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Ab64.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_Ab32.setMnemonic('1');
        ck_Ab32.setSelected(true);
        ck_Ab32.setText("32\u4f4d(1)");
        ck_Ab32.setToolTipText("32\u4f4d");
        ck_Ab32.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Ab32.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_Ab16.setMnemonic('2');
        ck_Ab16.setText("16\u4f4d(2)");
        ck_Ab16.setToolTipText("16\u4f4d");
        ck_Ab16.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Ab16.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_Ab00.setMnemonic('3');
        ck_Ab00.setText("\u5176\u5b83(3)");
        ck_Ab00.setToolTipText("\u5176\u5b83");
        ck_Ab00.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Ab00.setMargin(new java.awt.Insets(0, 0, 0, 0));

        lb_IdioMark.setText("\u76f8\u5173\u8bf4\u660e(P)");
        lb_IdioMark.setToolTipText("\u76f8\u5173\u8bf4\u660e");
        lb_IdioMark.setLabelFor(ta_IdioMark);

        ta_IdioMark.setColumns(20);
        ta_IdioMark.setLineWrap(true);
        ta_IdioMark.setRows(4);
        sp_TextArea.setViewportView(ta_IdioMark);

        bt_Update.setMnemonic('D');
        bt_Update.setText("\u5220\u9664(D)");
        bt_Update.setToolTipText("\u5220\u9664");
        bt_Update.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_Update.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_Update_Handler(evt);
            }
        });

        bt_Create.setMnemonic('N');
        bt_Create.setText("\u65b0\u589e(N)");
        bt_Create.setToolTipText("\u65b0\u589e");
        bt_Create.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_Create.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_Create_Handler(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                    javax.swing.GroupLayout.Alignment.TRAILING,
                    layout.createSequentialGroup().addComponent(bt_Create).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Update))
                    .addGroup(
                        layout.createSequentialGroup().addGroup(
                            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(
                                lb_ExtsName).addComponent(lb_NatnIndx).addComponent(lb_CorpIndx).addComponent(
                                lb_SoftIndx).addComponent(lb_FileIndx).addComponent(lb_TypeIndx).addComponent(
                                lb_IdioIndx).addComponent(lb_PlatForm).addComponent(lb_ArchBits).addComponent(
                                lb_IdioMark)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                            .addGroup(
                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(
                                    sp_TextArea, javax.swing.GroupLayout.Alignment.TRAILING,
                                    javax.swing.GroupLayout.DEFAULT_SIZE, 206, Short.MAX_VALUE).addComponent(
                                    cb_IdioIndx, javax.swing.GroupLayout.Alignment.TRAILING, 0, 206, Short.MAX_VALUE)
                                    .addComponent(cb_TypeIndx, javax.swing.GroupLayout.Alignment.TRAILING, 0, 206,
                                        Short.MAX_VALUE).addComponent(cb_FileIndx,
                                        javax.swing.GroupLayout.Alignment.TRAILING, 0, 206, Short.MAX_VALUE)
                                    .addComponent(cb_SoftIndx, javax.swing.GroupLayout.Alignment.TRAILING, 0, 206,
                                        Short.MAX_VALUE).addComponent(cb_CorpIndx,
                                        javax.swing.GroupLayout.Alignment.TRAILING, 0, 206, Short.MAX_VALUE)
                                    .addComponent(cb_NatnIndx, javax.swing.GroupLayout.Alignment.TRAILING, 0, 206,
                                        Short.MAX_VALUE).addGroup(
                                        layout.createSequentialGroup().addGroup(
                                            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                                .addComponent(ck_PfAll).addComponent(ck_PfWin).addComponent(ck_PfUnx)
                                                .addComponent(ck_PfMbl).addComponent(ck_Ab64).addComponent(ck_Ab16))
                                            .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                            .addGroup(
                                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                                    .addComponent(ck_PfMac).addComponent(ck_PfLnx).addComponent(
                                                        ck_PfSpc).addComponent(ck_Ab00).addComponent(ck_Ab32)).addGap(
                                                11, 11, 11)).addComponent(tf_ExtsName,
                                        javax.swing.GroupLayout.DEFAULT_SIZE, 206, Short.MAX_VALUE))))
                .addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_ExtsName)
                    .addComponent(tf_ExtsName, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_NatnIndx)
                    .addComponent(cb_NatnIndx, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_CorpIndx)
                    .addComponent(cb_CorpIndx, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SoftIndx)
                    .addComponent(cb_SoftIndx, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_FileIndx)
                    .addComponent(cb_FileIndx, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_TypeIndx)
                    .addComponent(cb_TypeIndx, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_IdioIndx)
                    .addComponent(cb_IdioIndx, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_PlatForm)
                    .addComponent(ck_PfAll)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(ck_PfWin)
                        .addComponent(ck_PfMac)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(ck_PfUnx)
                        .addComponent(ck_PfLnx)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(ck_PfMbl)
                        .addComponent(ck_PfSpc)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_ArchBits)
                        .addComponent(ck_Ab64).addComponent(ck_Ab32)).addPreferredGap(
                    javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(ck_Ab16)
                        .addComponent(ck_Ab00)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_IdioMark)
                        .addComponent(sp_TextArea, javax.swing.GroupLayout.PREFERRED_SIZE,
                            javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED,
                    javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_Update)
                        .addComponent(bt_Create)).addContainerGap()));
    }

    /**
     * @param isHash
     */
    private void ita()
    {
        // 后缀名称
        BeanUtil.setWText(lb_ExtsName, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_EXTSNAME));
        BeanUtil.setWTips(lb_ExtsName, Extparse.getMesg(LangRes.EXTS_LABL_TIPS_EXTSNAME));

        BeanUtil.setWText(tf_ExtsName, Extparse.getMesg(LangRes.EXTS_FILD_TEXT_EXTSNAME));
        BeanUtil.setWTips(tf_ExtsName, Extparse.getMesg(LangRes.EXTS_FILD_TIPS_EXTSNAME));

        // 国别索引
        BeanUtil.setWText(lb_NatnIndx, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_NATNINDX));
        BeanUtil.setWTips(lb_NatnIndx, Extparse.getMesg(LangRes.EXTS_LABL_TIPS_NATNINDX));

        BeanUtil.setWTips(cb_NatnIndx, Extparse.getMesg(LangRes.EXTS_COMB_TIPS_NATNINDX));

        // 所属公司
        BeanUtil.setWText(lb_CorpIndx, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_CORPLCNM));
        BeanUtil.setWTips(lb_CorpIndx, Extparse.getMesg(LangRes.EXTS_LABL_TIPS_CORPLCNM));

        BeanUtil.setWTips(cb_CorpIndx, Extparse.getMesg(LangRes.EXTS_COMB_TIPS_CORPLCNM));

        // 直属软件
        BeanUtil.setWText(lb_SoftIndx, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_SOFTNAME));
        BeanUtil.setWTips(lb_SoftIndx, Extparse.getMesg(LangRes.EXTS_LABL_TIPS_SOFTNAME));

        BeanUtil.setWTips(cb_SoftIndx, Extparse.getMesg(LangRes.EXTS_COMB_TIPS_SOFTNAME));

        // 文件签名
        BeanUtil.setWText(lb_FileIndx, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_SIGNCHAR));
        BeanUtil.setWTips(lb_FileIndx, Extparse.getMesg(LangRes.EXTS_LABL_TIPS_SIGNCHAR));

        BeanUtil.setWTips(cb_FileIndx, Extparse.getMesg(LangRes.EXTS_COMB_TIPS_SIGNCHAR));

        // 所属类别
        BeanUtil.setWText(lb_TypeIndx, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_EXTSTYPE));
        BeanUtil.setWTips(lb_TypeIndx, Extparse.getMesg(LangRes.EXTS_LABL_TIPS_EXTSTYPE));

        BeanUtil.setWTips(cb_TypeIndx, Extparse.getMesg(LangRes.EXTS_COMB_TIPS_EXTSTYPE));

        // 特别致谢
        BeanUtil.setWText(lb_IdioIndx, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_IDIOMAIL));
        BeanUtil.setWTips(lb_IdioIndx, Extparse.getMesg(LangRes.EXTS_LABL_TIPS_IDIOMAIL));

        BeanUtil.setWTips(cb_IdioIndx, Extparse.getMesg(LangRes.EXTS_COMB_TIPS_IDIOMAIL));

        // 应用平台
        BeanUtil.setWText(lb_PlatForm, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_PLATFORM));
        BeanUtil.setWTips(lb_PlatForm, Extparse.getMesg(LangRes.EXTS_LABL_TIPS_PLATFORM));

        // 平台通用
        BeanUtil.setWText(ck_PfAll, Extparse.getMesg(LangRes.EXTS_CHCK_TEXT_PFALL));
        BeanUtil.setWTips(ck_PfAll, Extparse.getMesg(LangRes.EXTS_CHCK_TIPS_PFALL));

        // Windows
        BeanUtil.setWText(ck_PfWin, Extparse.getMesg(LangRes.EXTS_CHCK_TEXT_PFWIN));
        BeanUtil.setWTips(ck_PfWin, Extparse.getMesg(LangRes.EXTS_CHCK_TIPS_PFWIN));

        // Macintosh
        BeanUtil.setWText(ck_PfMac, Extparse.getMesg(LangRes.EXTS_CHCK_TEXT_PFMAC));
        BeanUtil.setWTips(ck_PfMac, Extparse.getMesg(LangRes.EXTS_CHCK_TIPS_PFMAC));

        // Unix
        BeanUtil.setWText(ck_PfUnx, Extparse.getMesg(LangRes.EXTS_CHCK_TEXT_PFUNX));
        BeanUtil.setWTips(ck_PfUnx, Extparse.getMesg(LangRes.EXTS_CHCK_TIPS_PFUNX));

        // Linux
        BeanUtil.setWText(ck_PfLnx, Extparse.getMesg(LangRes.EXTS_CHCK_TEXT_PFLNX));
        BeanUtil.setWTips(ck_PfLnx, Extparse.getMesg(LangRes.EXTS_CHCK_TIPS_PFLNX));

        // 移动平台
        BeanUtil.setWText(ck_PfMbl, Extparse.getMesg(LangRes.EXTS_CHCK_TEXT_PFMBL));
        BeanUtil.setWTips(ck_PfMbl, Extparse.getMesg(LangRes.EXTS_CHCK_TIPS_PFMBL));

        // 其它平台
        BeanUtil.setWText(ck_PfSpc, Extparse.getMesg(LangRes.EXTS_CHCK_TEXT_PFSPC));
        BeanUtil.setWTips(ck_PfSpc, Extparse.getMesg(LangRes.EXTS_CHCK_TIPS_PFSPC));

        // CPU 架构
        BeanUtil.setWText(lb_ArchBits, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_ARCHBITS));
        BeanUtil.setWTips(lb_ArchBits, Extparse.getMesg(LangRes.EXTS_LABL_TIPS_ARCHBITS));

        // 64位
        BeanUtil.setWText(ck_Ab64, Extparse.getMesg(LangRes.EXTS_CHCK_TEXT_BITS64));
        BeanUtil.setWTips(ck_Ab64, Extparse.getMesg(LangRes.EXTS_CHCK_TIPS_BITS64));

        // 32位
        BeanUtil.setWText(ck_Ab32, Extparse.getMesg(LangRes.EXTS_CHCK_TEXT_BITS32));
        BeanUtil.setWTips(ck_Ab32, Extparse.getMesg(LangRes.EXTS_CHCK_TIPS_BITS32));

        // 16位
        BeanUtil.setWText(ck_Ab16, Extparse.getMesg(LangRes.EXTS_CHCK_TEXT_BITS16));
        BeanUtil.setWTips(ck_Ab16, Extparse.getMesg(LangRes.EXTS_CHCK_TIPS_BITS16));

        // 其它
        BeanUtil.setWText(ck_Ab00, Extparse.getMesg(LangRes.EXTS_CHCK_TEXT_BITS00));
        BeanUtil.setWTips(ck_Ab00, Extparse.getMesg(LangRes.EXTS_CHCK_TIPS_BITS00));

        // 相关说明
        BeanUtil.setWText(lb_IdioMark, Extparse.getMesg(LangRes.EXTS_LABL_TEXT_IDIOMARK));
        BeanUtil.setWTips(lb_IdioMark, Extparse.getMesg(LangRes.EXTS_LABL_TIPS_IDIOMARK));

        BeanUtil.setWText(ta_IdioMark, Extparse.getMesg(LangRes.EXTS_AREA_TEXT_IDIOMARK));
        BeanUtil.setWTips(ta_IdioMark, Extparse.getMesg(LangRes.EXTS_AREA_TIPS_IDIOMARK));

        // 新增按钮
        BeanUtil.setWText(bt_Create, Extparse.getMesg(LangRes.EXTS_BUTN_TEXT_CREATE));
        BeanUtil.setWTips(bt_Create, Extparse.getMesg(LangRes.EXTS_BUTN_TIPS_CREATE));

        // 更新按钮
        BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.EXTS_BUTN_TEXT_UPDATE));
        BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.EXTS_BUTN_TIPS_UPDATE));
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 新增按钮事件处理
     * 
     * @param evt
     */
    private void bt_Create_Handler(java.awt.event.ActionEvent evt)
    {
        // 可编辑状态下进行数据的保存操作
        if (isEditable)
        {
            ExtsUserData userMeta = new ExtsUserData();
            userMeta.wInit();

            if (!getUserData(userMeta, false))
            {
                return;
            }

            // 数据更新
            if (metaUpdate(userMeta))
            {
                setDefault("");

                MesgUtil.showMessageDialog(this, Extparse.getMesg(LangRes.EXTS_MESG_UPDT_0001));
            }
        }
        // 不可编辑状态下显示可编辑界面
        else
        {
            isUpdate = false;

            setDefault("");
            me_MainSoft.getExtsForm().setTitle(Extparse.getMesg(LangRes.TITLE_EXTSFORM) + LangRes.TITLE_INSERT);

            setEditable(true);
        }
    }

    /**
     * 更新按钮事件处理
     * 
     * @param evt
     */
    private void bt_Update_Handler(java.awt.event.ActionEvent evt)
    {
        // 可编辑状态下取消当前操作显示不可编辑界面
        if (isEditable)
        {
            setEditable(false);
            me_MainSoft.getExtsForm().setTitle(Extparse.getMesg(LangRes.TITLE_EXTSFORM));
        }
        // 不可编辑状态下，显示可编辑界面
        else
        {
            isUpdate = true;

            setEditable(true);
            me_MainSoft.getExtsForm().setTitle(Extparse.getMesg(LangRes.TITLE_EXTSFORM) + LangRes.TITLE_UPDATE);
        }
    }

    /**
     * 所属公司事件处理
     * 
     * @param evt
     */
    private void cb_CorpIndx_Handler(java.awt.event.ItemEvent evt)
    {
        K2SV1S kvItem = (K2SV1S)cb_CorpIndx.getSelectedItem();
        if (kvItem == null || kvItem.equals(kv_CorpLcNm))
        {
            return;
        }
        kv_CorpLcNm = kvItem;

        DBAccess dba = new DBAccess();

        try
        {
            // 连接初始化
            if (!dba.wInit())
            {
                return;
            }

            // 数据显示
            initSoftList(dba);
            initFileList(dba);
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * 国别索引事件处理
     * 
     * @param evt
     */
    private void cb_NatnIndx_Handler(java.awt.event.ItemEvent evt)
    {
        K2SV1S kvItem = (K2SV1S)this.cb_NatnIndx.getSelectedItem();
        if (kvItem == null || kvItem.equals(kv_NatnIndx))
        {
            return;
        }
        kv_NatnIndx = kvItem;

        DBAccess dba = new DBAccess();

        try
        {
            // 连接初始化
            if (!dba.wInit())
            {
                return;
            }

            // 数据显示
            initCorpList(dba);
            initSoftList(dba);
            initFileList(dba);
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * 直属软件事件处理
     * 
     * @param evt
     */
    private void cb_SoftIndx_Handler(java.awt.event.ItemEvent evt)
    {
        K2SV1S kvItem = (K2SV1S)this.cb_SoftIndx.getSelectedItem();
        if (kvItem == null || kvItem.equals(kv_SoftItem))
        {
            return;
        }

        kv_SoftItem = kvItem;

        DBAccess dba = new DBAccess();

        try
        {
            // 连接初始化
            if (!dba.wInit())
            {
                return;
            }

            // 数据显示
            initFileList(dba);
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * @param evt
     */
    private void ck_PfAll_Handler(javax.swing.event.ChangeEvent evt)
    {
        boolean b = !this.ck_PfAll.isSelected();

        this.ck_PfWin.setEnabled(b);
        this.ck_PfMac.setEnabled(b);
        this.ck_PfUnx.setEnabled(b);
        this.ck_PfLnx.setEnabled(b);
        this.ck_PfMbl.setEnabled(b);
        this.ck_PfSpc.setEnabled(b);
    }

    /**
     * 后缀名称事件处理
     * 
     * @param evt
     */
    private void tf_ExtsName_Handler(java.awt.event.ActionEvent evt)
    {
        // 用户数据对象实例化
        ExtsUserData userMeta = new ExtsUserData();
        userMeta.wInit();

        if (!getUserData(userMeta))
        {
            return;
        }

        metaSelect(userMeta);
    }

    /**
     * @param dba
     */
    private void initCorpList(DBAccess dba) throws SQLException
    {
        // 清除已有显示数据
        cm_CorpLcNm.removeAllElements();

        // 数据查询
        List<K2SV1S> corpList = DA0008.selectCorpMetaName(dba, kv_NatnIndx.getK1(), "");

        // 事件控制
        if (corpList == null || corpList.size() < 1)
        {
            return;
        }
        kv_CorpLcNm = corpList.get(0);

        // 数据显示
        for (int i = 0, j = corpList.size(); i < j; i += 1)
        {
            cm_CorpLcNm.addElement(corpList.get(i));
        }
    }

    /**
     * @param dba
     */
    private void initFileList(DBAccess dba) throws SQLException
    {
        // 清除已有显示数据
        cm_SignChar.removeAllElements();

        if (kv_SoftItem == null)
        {
            return;
        }

        // 数据查询
        List<K2SV1S> fileList = DA0008.selectFileMetaName(dba, kv_SoftItem.getK1(), "");

        // 事件控制
        if (fileList == null || fileList.size() < 1)
        {
            return;
        }

        // 数据显示
        for (int i = 0, j = fileList.size(); i < j; i += 1)
        {
            cm_SignChar.addElement(fileList.get(i));
        }
    }

    /**
     * @param dba
     * @throws SQLException
     */
    private void initIdioList(DBAccess dba) throws SQLException
    {
        // 清除已有显示数据
        cm_IdioMail.removeAllElements();

        // 数据查询
        List<K2SV1S> idioList = DA0008.selectIdioMetaName(dba, "");

        // 事件控制
        if (idioList == null || idioList.size() < 1)
        {
            return;
        }

        // 数据显示
        for (int i = 0, j = idioList.size(); i < j; i += 1)
        {
            cm_IdioMail.addElement(idioList.get(i));
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param dba
     */
    private void initNatnList(DBAccess dba) throws SQLException
    {
        // 清除已有显示数据
        cm_NatnIndx.removeAllElements();

        // 数据查询
        List<K2SV1S> natnList = DA0008.selectNatnMetaName(dba);

        // 事件控制
        if (natnList == null || natnList.size() < 1)
        {
            return;
        }
        kv_NatnIndx = natnList.get(0);

        // 数据显示
        for (int i = 0, j = natnList.size(); i < j; i += 1)
        {
            cm_NatnIndx.addElement(natnList.get(i));
        }
    }

    /**
     * @param dba
     */
    private void initSoftList(DBAccess dba) throws SQLException
    {
        // 清除已有显示数据
        cm_SoftName.removeAllElements();

        if (kv_CorpLcNm == null)
        {
            return;
        }

        // 数据查询
        List<K2SV1S> softList = DA0008.selectSoftMetaName(dba, kv_CorpLcNm.getK1(), "");

        // 事件控制
        if (softList == null || softList.size() < 1)
        {
            return;
        }
        kv_SoftItem = softList.get(0);

        // 数据显示
        for (int i = 0, j = softList.size(); i < j; i += 1)
        {
            cm_SoftName.addElement(softList.get(i));
        }
    }

    /**
     * @param dba
     * @throws SQLException
     */
    private void initTypeList(DBAccess dba) throws SQLException
    {
        // 清除已有显示数据
        cm_ExtsType.removeAllElements();

        // 数据查询
        List<K1SV2S> typeList = DA0008.selectTypeMetaName(dba);

        // 事件控制
        if (typeList == null || typeList.size() < 1)
        {
            return;
        }

        // 数据显示
        for (int i = 0, j = typeList.size(); i < j; i += 1)
        {
            cm_ExtsType.addElement(typeList.get(i));
        }
    }

    /**
     * @param userMeta
     * @return
     */
    private boolean getUserData(ExtsUserData userMeta)
    {
        return getUserData(userMeta, true);
    }

    /**
     * @param userMeta
     * @param keysOnly
     * @return
     */
    private boolean getUserData(ExtsUserData userMeta, boolean keysOnly)
    {
        // 后缀名称
        if (!userMeta.setExtsName(this.tf_ExtsName.getText()))
        {
            MesgUtil.showMessageDialog(this, userMeta.getErrMsg());
            this.tf_ExtsName.requestFocus();
            return false;
        }
        this.tf_ExtsName.setText(userMeta.getExtsName());

        // 仅关键数据
        if (keysOnly)
        {
            return true;
        }

        userMeta.setUpdate(isUpdate);

        // 软件索引
        K2SV1S k2v1 = (K2SV1S)this.cb_SoftIndx.getSelectedItem();
        userMeta.setSoftIndx(k2v1.getK1());

        // 公司索引
        k2v1 = (K2SV1S)this.cb_CorpIndx.getSelectedItem();
        userMeta.setCorpIndx(k2v1.getK1());

        // 软件索引（更新时使用）
        if (isUpdate && !userMeta.setSoftIndx_O(softIndx_O))
        {
            MesgUtil.showMessageDialog(this, userMeta.getErrMsg());
            this.tf_ExtsName.requestFocus();
            return false;
        }

        // 文件索引
        k2v1 = (K2SV1S)this.cb_FileIndx.getSelectedItem();
        userMeta.setFileIndx(k2v1.getK1());

        // 人员索引
        k2v1 = (K2SV1S)this.cb_IdioIndx.getSelectedItem();
        userMeta.setIdioIndx(k2v1.getK1());

        // 类别索引
        K1SV2S k1v2 = (K1SV2S)this.cb_TypeIndx.getSelectedItem();
        userMeta.setTypeIndx(k1v2.getK());

        // 应用平台
        userMeta.setPlatIndx(encodePlatForm());

        // CPU 架构
        userMeta.setArchBits(encodeArchBits());

        // 相关说明
        if (!userMeta.setIdioMark(this.ta_IdioMark.getText()))
        {
            MesgUtil.showMessageDialog(this, userMeta.getErrMsg());
            this.ta_IdioMark.requestFocus();
            return false;
        }

        return true;
    }

    /**
     * @param baseMeta
     * @return
     */
    private boolean setBaseData(DBAccess dba, BaseData baseMeta) throws SQLException
    {
        if (baseMeta == null)
        {
            return false;
        }

        // 保存等更新记录
        this.softIndx_O = baseMeta.getSoftIndx();

        ExtsBaseData extsData = DA0008.selectExtsMeta(dba, baseMeta);
        dba.executeSelect();

        // 国别索引
        CorpBaseData corpData = DA0008.selectCorpMetaInfo(dba, extsData.getCorpIndx());
        NatnBaseData natnData = DA0008.selectNatnMetaInfo(dba, corpData.getNatnIndx());
        kv_NatnIndx = new K2SV1S(natnData.getNatnIndx(), "", natnData.getNatnSlNm());
        cm_NatnIndx.setSelectedItem(kv_NatnIndx);

        // 所属公司
        kv_CorpLcNm = new K2SV1S(corpData.getCorpIndx(), corpData.getNatnIndx(), corpData.getCorpLcNm());
        cm_CorpLcNm.setSelectedItem(kv_CorpLcNm);

        // 直属软件
        SoftBaseData softData = DA0008.selectSoftMetaInfo(dba, extsData.getSoftIndx());
        kv_SoftItem = new K2SV1S(softData.getSoftIndx(), softData.getCorpIndx(), softData.getSoftName());
        cm_SoftName.setSelectedItem(kv_SoftItem);

        K2SV1S k2v1;

        // 文件信息
        FileBaseData fileData = DA0008.selectFileMetaInfo(dba, extsData.getFileIndx());
        k2v1 = new K2SV1S(fileData.getFileIndx(), fileData.getSoftIndx(), fileData.getSignChar());
        cm_SignChar.setSelectedItem(k2v1);

        // 所属类别
        String typeData = DC0008.selectTypeName(dba, PrpCons.P3010000_I, extsData.getTypeIndx());
        K1SV2S k1v2 = new K1SV2S(extsData.getTypeIndx(), typeData, "");
        cm_ExtsType.setSelectedItem(k1v2);

        // 特别致谢
        IdioBaseData idioData = DA0008.selectIdioMetaInfo(dba, extsData.getIdioIndx());
        k2v1 = new K2SV1S(idioData.getIdioIndx(), idioData.getIdioMail(), idioData.getNickName());
        cm_IdioMail.setSelectedItem(k2v1);

        // 应用平台
        decodePlatForm(extsData.getPlatIndx());

        // CPU 架构
        decodeArchBits(extsData.getArchBits());

        // 相关说明
        ta_IdioMark.setText(extsData.getIdioMark());

        return true;
    }

    /**
     * 应用平台信息显示
     * 
     * @param platForm
     */
    private void decodePlatForm(int platForm)
    {
        // 平台通用
        boolean b = SysCons.OS_IDX_ALL == platForm;
        this.ck_PfAll.setSelected(b);

        // Windows平台
        this.ck_PfWin.setSelected((SysCons.OS_IDX_WINDOWS & platForm) != 0);
        // Macintosh平台
        this.ck_PfMac.setSelected((SysCons.OS_IDX_MACINTOSH & platForm) != 0);
        // Unix平台
        this.ck_PfUnx.setSelected((SysCons.OS_IDX_UNIX & platForm) != 0);
        // Linux平台
        this.ck_PfLnx.setSelected((SysCons.OS_IDX_LINUX & platForm) != 0);
        // 移动平台
        this.ck_PfMbl.setSelected((SysCons.OS_IDX_MOBILE & platForm) != 0);
        // 其它平台
        this.ck_PfSpc.setSelected((SysCons.OS_IDX_UNKNOWN & platForm) != 0);

        setPlatFormEnabled(!b);
    }

    /**
     * 应用平台
     * 
     * @return
     */
    private int encodePlatForm()
    {
        // 平台通用
        if (this.ck_PfAll.isSelected())
        {
            return SysCons.OS_IDX_ALL;
        }

        int platForm = 0;

        // Windows
        if (this.ck_PfWin.isSelected())
        {
            platForm |= SysCons.OS_IDX_WINDOWS;
        }

        // Macintosh
        if (this.ck_PfMac.isSelected())
        {
            platForm |= SysCons.OS_IDX_MACINTOSH;
        }

        // Unix
        if (this.ck_PfUnx.isSelected())
        {
            platForm |= SysCons.OS_IDX_UNIX;
        }

        // Linux
        if (this.ck_PfLnx.isSelected())
        {
            platForm |= SysCons.OS_IDX_LINUX;
        }

        // 移动平台
        if (this.ck_PfMbl.isSelected())
        {
            platForm |= SysCons.OS_IDX_MOBILE;
        }

        // 其它平台
        if (this.ck_PfSpc.isSelected())
        {
            platForm |= SysCons.OS_IDX_UNKNOWN;
        }

        return platForm;
    }

    /**
     * CPU架构信息显示
     * 
     * @param archBits
     */
    private void decodeArchBits(int archBits)
    {
        // 64位
        this.ck_Ab64.setSelected((SysCons.BITS_IDX_64 & archBits) != 0);
        // 32位
        this.ck_Ab32.setSelected((SysCons.BITS_IDX_32 & archBits) != 0);
        // 16位
        this.ck_Ab16.setSelected((SysCons.BITS_IDX_16 & archBits) != 0);
        // 其它
        this.ck_Ab00.setSelected((SysCons.BITS_IDX_00 & archBits) != 0);
    }

    /**
     * 系统架构
     */
    private int encodeArchBits()
    {
        int archBits = 0;

        // 64位
        if (this.ck_Ab64.isSelected())
        {
            archBits |= SysCons.BITS_IDX_64;
        }

        // 32位
        if (this.ck_Ab32.isSelected())
        {
            archBits |= SysCons.BITS_IDX_32;
        }

        // 16位
        if (this.ck_Ab16.isSelected())
        {
            archBits |= SysCons.BITS_IDX_16;
        }

        // 其它
        if (this.ck_Ab00.isSelected())
        {
            archBits |= SysCons.BITS_IDX_00;
        }

        return archBits;
    }

    /**
     * @param enabled
     */
    private void setPlatFormEnabled(boolean enabled)
    {
        this.ck_PfWin.setEnabled(enabled);
        this.ck_PfMac.setEnabled(enabled);
        this.ck_PfUnx.setEnabled(enabled);
        this.ck_PfLnx.setEnabled(enabled);
        this.ck_PfMbl.setEnabled(enabled);
        this.ck_PfSpc.setEnabled(enabled);
    }

    /**
     * 设置初始状态
     */
    private void setDefault(String value)
    {
        if (cm_CorpLcNm.getSize() > 0)
        {
            this.cb_CorpIndx.setSelectedIndex(0);
        }
        this.ta_IdioMark.setText(value);

        this.ck_Ab64.setSelected(false);
        this.ck_Ab32.setSelected(true);
        this.ck_Ab16.setSelected(false);
        this.ck_Ab00.setSelected(false);
        this.ck_PfAll.setSelected(true);
    }

    /**
     * @param editable
     */
    public void setEditable(boolean editable)
    {
        isEditable = editable;

        if (isEditable)
        {
            BeanUtil.setWText(bt_Create, Extparse.getMesg(LangRes.EXTS_BUTN_TEXT_INSERT));
            BeanUtil.setWTips(bt_Create, Extparse.getMesg(LangRes.EXTS_BUTN_TIPS_INSERT));

            BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.EXTS_BUTN_TEXT_CANCEL));
            BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.EXTS_BUTN_TIPS_CANCEL));
        }
        else
        {
            BeanUtil.setWText(bt_Create, Extparse.getMesg(LangRes.EXTS_BUTN_TEXT_CREATE));
            BeanUtil.setWTips(bt_Create, Extparse.getMesg(LangRes.EXTS_BUTN_TIPS_CREATE));

            BeanUtil.setWText(bt_Update, Extparse.getMesg(LangRes.EXTS_BUTN_TEXT_UPDATE));
            BeanUtil.setWTips(bt_Update, Extparse.getMesg(LangRes.EXTS_BUTN_TIPS_UPDATE));
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面组件变量区域
    // ////////////////////////////////////////////////////////////////////////
    /** 新增按钮 */
    private javax.swing.JButton    bt_Create;
    /** 更新按钮 */
    private javax.swing.JButton    bt_Update;
    /** 所属公司 */
    private javax.swing.JComboBox  cb_CorpIndx;
    /** 个人邮件 */
    private javax.swing.JComboBox  cb_IdioIndx;
    /** 国别索引 */
    private javax.swing.JComboBox  cb_NatnIndx;
    /** 文件签名 */
    private javax.swing.JComboBox  cb_FileIndx;
    /** 直属软件 */
    private javax.swing.JComboBox  cb_SoftIndx;
    /** 所属类别 */
    private javax.swing.JComboBox  cb_TypeIndx;
    /** 其它 */
    private javax.swing.JCheckBox  ck_Ab00;
    /** 16位 */
    private javax.swing.JCheckBox  ck_Ab16;
    /** 32位 */
    private javax.swing.JCheckBox  ck_Ab32;
    /** 64位 */
    private javax.swing.JCheckBox  ck_Ab64;
    /** 平台通用 */
    private javax.swing.JCheckBox  ck_PfAll;
    /** Linux平台 */
    private javax.swing.JCheckBox  ck_PfLnx;
    /** Macintosh平台 */
    private javax.swing.JCheckBox  ck_PfMac;
    /** 移动平台 */
    private javax.swing.JCheckBox  ck_PfMbl;
    /** 其它平台 */
    private javax.swing.JCheckBox  ck_PfSpc;
    /** Unix平台 */
    private javax.swing.JCheckBox  ck_PfUnx;
    /** Windows平台 */
    private javax.swing.JCheckBox  ck_PfWin;
    /** 附注信息 */
    private javax.swing.JTextArea  ta_IdioMark;
    /** 后缀名称 */
    private javax.swing.JTextField tf_ExtsName;

    private javax.swing.JLabel     lb_CorpIndx;
    private javax.swing.JLabel     lb_ExtsName;
    private javax.swing.JLabel     lb_IdioIndx;
    private javax.swing.JLabel     lb_IdioMark;
    private javax.swing.JLabel     lb_NatnIndx;
    private javax.swing.JLabel     lb_PlatForm;
    private javax.swing.JLabel     lb_FileIndx;
    private javax.swing.JLabel     lb_SoftIndx;
    private javax.swing.JLabel     lb_TypeIndx;
    private javax.swing.JLabel     lb_ArchBits;
}
