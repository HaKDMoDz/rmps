/*
 * FileName:       MiniPanel.java
 * CreateDate:     2007/08/22 14:34:45
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.v;

import java.sql.SQLException;
import java.util.EventObject;
import java.util.List;

import rmp.bean.K1SV2S;
import rmp.bean.K2SV1S;
import rmp.face.WBackCall;
import rmp.io.db.DBAccess;
import rmp.prp.aide.DC0008;
import rmp.prp.aide.extparse.Extparse;
import rmp.prp.aide.extparse.d.DA0008;
import rmp.prp.aide.extparse.m.BaseData;
import rmp.prp.aide.extparse.m.CorpBaseData;
import rmp.prp.aide.extparse.m.DespBaseData;
import rmp.prp.aide.extparse.m.ExtsBaseData;
import rmp.prp.aide.extparse.m.FileBaseData;
import rmp.prp.aide.extparse.m.IdioBaseData;
import rmp.prp.aide.extparse.m.SoftBaseData;
import rmp.prp.aide.extparse.m.UserData;
import rmp.util.BeanUtil;
import rmp.util.CheckUtil;
import rmp.util.EnvUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.RmpsUtil;
import rmp.util.StringUtil;
import cons.CfgCons;
import cons.id.PrpCons;
import cons.prp.aide.extparse.ConstUI;
import cons.prp.aide.extparse.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * 迷你模式交互面板
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
 * 日期： 2007/08/22 14:34:45
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class MiniPanel extends javax.swing.JPanel implements WBackCall, java.awt.event.ActionListener
{
    /**  */
    private static final long      serialVersionUID = 8064936562596525000L;
    /**  */
    private BaseData               bd_BaseMeta;
    /** 界面布局管理器 */
    private java.awt.CardLayout    cl_CardPanl;
    /** 上一次选择的标签 */
    private javax.swing.JLabel     lb_LastLabl;
    /** 多个软件弹出式选择菜单 */
    private javax.swing.JPopupMenu pm_SoftMenu;
    /** 父应用引用 */
    private Extparse               me_MainSoft;

    /**
     * @param soft
     */
    public MiniPanel(Extparse soft)
    {
        me_MainSoft = soft;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.ui.frm.FViewPanel#init()
     */
    public boolean wInit()
    {
        // 迷你模式面板初始化
        ica();

        // 描述信息面板初始化
        icb();

        // MIME类型面板初始化
        icc();

        // 公司信息面板初始化
        icd();

        // 软件信息面板初始化
        ice();

        // 文件信息面板初始化
        icf();

        // 备选软件面板初始化
        icg();

        // 特别致谢面板初始化
        ich();

        // 添加面板
        pl_CardPanl.add(ConstUI.PROP_DESPINFO, pl_DespInfo);
        pl_CardPanl.add(ConstUI.PROP_MIMEINFO, pl_MimeInfo);
        pl_CardPanl.add(ConstUI.PROP_CORPINFO, pl_CorpInfo);
        pl_CardPanl.add(ConstUI.PROP_SOFTINFO, pl_SoftInfo);
        pl_CardPanl.add(ConstUI.PROP_FILEINFO, pl_FileInfo);
        pl_CardPanl.add(ConstUI.PROP_ASOCINFO, pl_AsocInfo);
        pl_CardPanl.add(ConstUI.PROP_IDIOINFO, pl_IdioInfo);

        ita();

        // 当前选择标签状态设置
        java.awt.Color lbc = new java.awt.Color(176, 216, 255);
        lb_DespInfo.setBackground(lbc);
        lb_MimeInfo.setBackground(lbc);
        lb_CorpInfo.setBackground(lbc);
        lb_SoftInfo.setBackground(lbc);
        lb_FileInfo.setBackground(lbc);
        lb_AsocInfo.setBackground(lbc);
        lb_IdioInfo.setBackground(lbc);

        lb_DespInfo.setOpaque(true);
        lb_LastLabl = lb_DespInfo;

        // 快捷菜单
        pm_SoftMenu = new javax.swing.JPopupMenu();
        ib_SoftIcon.setIconPath(EnvUtil.getIconSoftDir());

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WBackCall#wAction(java.awt.Event, java.lang.Object)
     */
    @ Override
    public void wAction(EventObject event, Object object, String property)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.awt.event.ActionListener#actionPerformed(java.awt.event.ActionEvent)
     */
    @ Override
    public void actionPerformed(java.awt.event.ActionEvent evt)
    {
        Object obj = evt.getSource();
        if (obj instanceof javax.swing.JMenuItem)
        {
            javax.swing.JMenuItem menuItem = (javax.swing.JMenuItem)obj;
            String softHash = (String)menuItem.getClientProperty(ConstUI.PROP_SOFTHASH);
            if (CheckUtil.isValidate(softHash))
            {
                bd_BaseMeta.setSoftIndx(softHash);
                this.tf_ExtsName.setText(bd_BaseMeta.getExtsName());

                metaSelect(bd_BaseMeta);
            }
        }
    }

    /**
     * @param extsName
     * @return
     */
    public static List<ExtsBaseData> query(String extsName)
    {
        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return null;
            }

            return query(dba, extsName);
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
    public static List<ExtsBaseData> query(DBAccess dba, String extsName) throws SQLException
    {
        return DA0008.selectExtsMeta(dba, extsName);
    }

    /**
     * @param baseMeta
     * @return
     */
    public static ExtsBaseData query(BaseData baseMeta)
    {
        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return null;
            }

            return query(dba, baseMeta);
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
     * @param baseMeta
     * @return
     * @throws SQLException
     */
    public static ExtsBaseData query(DBAccess dba, BaseData baseMeta) throws SQLException
    {
        return DA0008.selectExtsMeta(dba, baseMeta);
    }

    /**
     * 后缀数据信息查询
     * 
     * @param extsName 形如“.abc”格式的后缀名称
     * @return
     */
    public boolean metaSelect(String extsName)
    {
        LogUtil.log("数据查询：后缀数据查询 － " + extsName);

        // 数据库操作对象
        DBAccess dba = new DBAccess();

        try
        {
            // 建立连接
            if (!dba.wInit())
            {
                return false;
            }

            // 后缀数据查询
            List<BaseData> mainList = DA0008.selectBaseMeta(dba, extsName);

            // 软件列表添加软件对象
            if (!changeMenu(mainList))
            {
                MesgUtil.showMessageDialog(Extparse.getForm(), Extparse.getMesg(LangRes.MESG_SELT_0003));
                return false;
            }

            // 首个结果数据显示
            setBaseData(dba, mainList.get(0));

            return true;
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_SELT_0007, LangRes.TITLE_EXTSFORM, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(Extparse.getForm(), mesg);
            return false;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * @param extsHash 形如“.abc”格式的后缀名称
     * @param softHash
     */
    public boolean metaSelect(BaseData baseMeta)
    {
        LogUtil.log("数据查询：后缀数据查询 － " + baseMeta.getExtsIndx() + "、" + baseMeta.getSoftIndx());

        // 数据库操作对象
        DBAccess dba = new DBAccess();

        try
        {
            // 建立连接
            if (!dba.wInit())
            {
                return false;
            }

            // 首个结果数据显示
            return setBaseData(dba, baseMeta);
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_SELT_0007, LangRes.TITLE_EXTSFORM, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(Extparse.getForm(), mesg);
            return false;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * 获得用户输入数据信息，存在错误的情况下，返回值为NULL。
     * 
     * @param softInc 是否包含软件的相关信息：true包含。
     * @return
     */
    public UserData getUserData(boolean softInc)
    {
        UserData userMeta = new UserData();
        userMeta.wInit();

        // 后缀名称
        if (!userMeta.setExtsName(this.tf_ExtsName.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            return null;
        }
        this.tf_ExtsName.setText(userMeta.getExtsName());

        // 不包含软件信息的情况
        if (!softInc)
        {
            return userMeta;
        }

        // // 用户选择为空
        // K2V1 kvItem = (K2V1)this.cb_SoftName.getSelectedItem();
        // if (kvItem == null)
        // {
        // MesgUtil.showMessageDialog(Extparse.getForm(),
        // LangRes.MAIN_MESG_CHCK_0002, true);
        // return null;
        // }
        //
        // // 软件索引
        // if (!userMeta.setSoftHash(kvItem.getK1()))
        // {
        // MesgUtil.showMessageDialog(Extparse.getForm(),
        // userMeta.getErrMsg(),
        // false);
        // return null;
        // }
        return userMeta;
    }

    // ========================================================================
    // 界面初始化区域
    // ========================================================================
    /**
     * 迷你模式面板初始化
     */
    private void ica()
    {
        ib_SoftIcon = new rmp.prp.aide.extparse.b.WIconBox(me_MainSoft);
        ib_SoftIcon.wInit();
        rl_NoteInfo = new rmp.comn.rmps.C4010000.C4010000();
        rl_NoteInfo.wInit();
        rl_NoteInfo.wShowView(Extparse.VIEW_NORM);

        tf_ExtsName = new javax.swing.JTextField();
        lb_SoftList = new javax.swing.JLabel();
        javax.swing.JSeparator sp1 = new javax.swing.JSeparator();
        pl_CardPanl = new javax.swing.JPanel();
        javax.swing.JSeparator sp2 = new javax.swing.JSeparator();
        bt_SoftList = new javax.swing.JButton();
        lb_IdioInfo = new javax.swing.JLabel();
        lb_AsocInfo = new javax.swing.JLabel();
        lb_FileInfo = new javax.swing.JLabel();
        lb_SoftInfo = new javax.swing.JLabel();
        lb_CorpInfo = new javax.swing.JLabel();
        lb_MimeInfo = new javax.swing.JLabel();
        lb_DespInfo = new javax.swing.JLabel();
        javax.swing.JLabel lb_l0 = new javax.swing.JLabel();
        javax.swing.JLabel lb_l1 = new javax.swing.JLabel();
        javax.swing.JLabel lb_l2 = new javax.swing.JLabel();

        tf_ExtsName.setToolTipText("\u540e\u7f00\u540d\u79f0");
        tf_ExtsName.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_ExtsName_Handler(evt);
            }
        });

        lb_SoftList.setToolTipText("\u76f4\u5c5e\u8f6f\u4ef6");

        pl_CardPanl.setBorder(javax.swing.BorderFactory.createLineBorder(new java.awt.Color(204, 204, 204)));
        pl_CardPanl.setPreferredSize(new java.awt.Dimension(200, 162));
        cl_CardPanl = new java.awt.CardLayout();
        pl_CardPanl.setLayout(cl_CardPanl);

        bt_SoftList.setMnemonic('L');
        bt_SoftList.setText("L");
        bt_SoftList.setToolTipText("\u67e5\u5bfb\u7ed3\u679c");
        bt_SoftList.setMargin(new java.awt.Insets(0, 0, 0, 0));
        bt_SoftList.setMaximumSize(new java.awt.Dimension(20, 20));
        bt_SoftList.setMinimumSize(new java.awt.Dimension(16, 16));
        bt_SoftList.setPreferredSize(new java.awt.Dimension(18, 18));
        bt_SoftList.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_SoftList_Handler(evt);
            }
        });

        lb_IdioInfo.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lb_IdioInfo.setText("I");
        lb_IdioInfo.setToolTipText("\u7279\u522b\u81f4\u8c22");
        lb_IdioInfo.setPreferredSize(new java.awt.Dimension(14, 16));
        lb_IdioInfo.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lb_IdioInfo_Handler(evt);
            }
        });

        lb_AsocInfo.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lb_AsocInfo.setText("A");
        lb_AsocInfo.setToolTipText("\u5907\u9009\u8f6f\u4ef6");
        lb_AsocInfo.setPreferredSize(new java.awt.Dimension(14, 16));
        lb_AsocInfo.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lb_AsocInfo_Handler(evt);
            }
        });

        lb_FileInfo.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lb_FileInfo.setText("F");
        lb_FileInfo.setToolTipText("\u6587\u4ef6\u4fe1\u606f");
        lb_FileInfo.setPreferredSize(new java.awt.Dimension(14, 16));
        lb_FileInfo.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lb_FileInfo_Handler(evt);
            }
        });

        lb_SoftInfo.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lb_SoftInfo.setText("S");
        lb_SoftInfo.setToolTipText("\u8f6f\u4ef6\u4fe1\u606f");
        lb_SoftInfo.setPreferredSize(new java.awt.Dimension(14, 16));
        lb_SoftInfo.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lb_SoftInfo_Handler(evt);
            }
        });

        lb_CorpInfo.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lb_CorpInfo.setText("C");
        lb_CorpInfo.setToolTipText("\u516c\u53f8\u4fe1\u606f");
        lb_CorpInfo.setPreferredSize(new java.awt.Dimension(14, 16));
        lb_CorpInfo.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lb_CorpInfo_Handler(evt);
            }
        });

        lb_MimeInfo.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lb_MimeInfo.setText("M");
        lb_MimeInfo.setToolTipText("MIME\u7c7b\u578b");
        lb_MimeInfo.setPreferredSize(new java.awt.Dimension(14, 16));
        lb_MimeInfo.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lb_MimeInfo_Handler(evt);
            }
        });

        lb_DespInfo.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lb_DespInfo.setText("D");
        lb_DespInfo.setToolTipText("\u540e\u7f00\u63cf\u8ff0");
        lb_DespInfo.setPreferredSize(new java.awt.Dimension(14, 16));
        lb_DespInfo.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lb_DespInfo_Handler(evt);
            }
        });

        lb_l0.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lb_l0.setPreferredSize(new java.awt.Dimension(14, 16));

        lb_l1.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lb_l1.setPreferredSize(new java.awt.Dimension(14, 16));

        lb_l2.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lb_l2.setPreferredSize(new java.awt.Dimension(14, 16));

        // rl_NoteInfo.setText("\u7cfb\u7edf\u63d0\u793a\uff1a");
        // rl_NoteInfo.setToolTipText("\u7cfb\u7edf\u63d0\u793a");

        ib_SoftIcon.setBorder(javax.swing.BorderFactory.createLineBorder(new java.awt.Color(0, 0, 0)));
        ib_SoftIcon.setPreferredSize(new java.awt.Dimension(50, 50));

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(sp1,
                    javax.swing.GroupLayout.DEFAULT_SIZE, 194, Short.MAX_VALUE).addComponent(sp2,
                    javax.swing.GroupLayout.DEFAULT_SIZE, 194, Short.MAX_VALUE).addComponent(pl_CardPanl,
                    javax.swing.GroupLayout.PREFERRED_SIZE, 194, javax.swing.GroupLayout.PREFERRED_SIZE).addGroup(
                    javax.swing.GroupLayout.Alignment.TRAILING,
                    layout.createSequentialGroup().addComponent(lb_l2, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lb_l1,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lb_l0,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lb_DespInfo,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lb_MimeInfo,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lb_CorpInfo,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lb_SoftInfo,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lb_FileInfo,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lb_AsocInfo,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lb_IdioInfo,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE)).addComponent(rl_NoteInfo.getAd(),
                    javax.swing.GroupLayout.DEFAULT_SIZE, 194, Short.MAX_VALUE).addGroup(
                    layout.createSequentialGroup().addComponent(ib_SoftIcon, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                            javax.swing.GroupLayout.Alignment.TRAILING,
                            layout.createSequentialGroup().addComponent(lb_SoftList,
                                javax.swing.GroupLayout.PREFERRED_SIZE, 116, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(
                                    bt_SoftList, javax.swing.GroupLayout.PREFERRED_SIZE,
                                    javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addComponent(tf_ExtsName, javax.swing.GroupLayout.DEFAULT_SIZE, 140, Short.MAX_VALUE))))
                .addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addGroup(
                    layout.createSequentialGroup().addComponent(tf_ExtsName, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(
                            bt_SoftList, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                            javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_SoftList)).addGap(2, 2, 2))
                    .addComponent(ib_SoftIcon, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp1,
                javax.swing.GroupLayout.PREFERRED_SIZE, 1, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(pl_CardPanl,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp2,
                javax.swing.GroupLayout.PREFERRED_SIZE, 1, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_IdioInfo,
                    javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                    javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_AsocInfo,
                    javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                    javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_FileInfo,
                    javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                    javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_SoftInfo,
                    javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                    javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_CorpInfo,
                    javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                    javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_MimeInfo,
                    javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                    javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_DespInfo,
                    javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                    javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_l0, javax.swing.GroupLayout.PREFERRED_SIZE,
                    javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_l1,
                    javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                    javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_l2, javax.swing.GroupLayout.PREFERRED_SIZE,
                    javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE).addComponent(rl_NoteInfo.getAd()).addContainerGap()));
    }

    /**
     * 描述信息面板初始化
     */
    private void icb()
    {
        pl_DespInfo = new javax.swing.JPanel();
        pl_DespInfo.setPreferredSize(new java.awt.Dimension(200, 162));
        pl_DespInfo.setLayout(new java.awt.GridBagLayout());

        java.awt.GridBagConstraints gridBagConstraints;

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.insets = new java.awt.Insets(6, 6, 3, 3);
        lb_ExtsType = new javax.swing.JLabel();
        pl_DespInfo.add(lb_ExtsType, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(6, 3, 3, 6);
        lt_ExtsType = new javax.swing.JLabel();
        pl_DespInfo.add(lt_ExtsType, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_ArchBits = new javax.swing.JLabel();
        pl_DespInfo.add(lb_ArchBits, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_ArchBits = new javax.swing.JLabel();
        pl_DespInfo.add(lt_ArchBits, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_PlatForm = new javax.swing.JLabel();
        pl_DespInfo.add(lb_PlatForm, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_PlatForm = new javax.swing.JLabel();
        pl_DespInfo.add(lt_PlatForm, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 3;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_ExtsDesp = new javax.swing.JLabel();
        pl_DespInfo.add(lb_ExtsDesp, gridBagConstraints);

        javax.swing.JScrollPane sp_ExtsDesp = new javax.swing.JScrollPane();
        lt_ExtsDesp = new javax.swing.JTextArea();
        lt_ExtsDesp.setEditable(false);
        lt_ExtsDesp.setLineWrap(true);
        sp_ExtsDesp.setViewportView(lt_ExtsDesp);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 4;
        gridBagConstraints.gridwidth = 3;
        gridBagConstraints.fill = java.awt.GridBagConstraints.BOTH;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.weighty = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 6, 6);
        pl_DespInfo.add(sp_ExtsDesp, gridBagConstraints);
    }

    /**
     * MIME类型面板初始化
     */
    private void icc()
    {
        pl_MimeInfo = new javax.swing.JPanel();
        lb_MimeType = new javax.swing.JLabel();
        lt_MimeNm00 = new javax.swing.JLabel();
        lt_MimeNm01 = new javax.swing.JLabel();
        lt_MimeNm02 = new javax.swing.JLabel();
        lt_MimeNm03 = new javax.swing.JLabel();
        lt_MimeNm04 = new javax.swing.JLabel();
        lt_MimeNm05 = new javax.swing.JLabel();

        pl_MimeInfo.setPreferredSize(new java.awt.Dimension(200, 162));

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(pl_MimeInfo);
        pl_MimeInfo.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lt_MimeNm00,
                    javax.swing.GroupLayout.PREFERRED_SIZE, 180, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(
                    lb_MimeType).addComponent(lt_MimeNm01, javax.swing.GroupLayout.DEFAULT_SIZE, 180, Short.MAX_VALUE)
                    .addComponent(lt_MimeNm02, javax.swing.GroupLayout.PREFERRED_SIZE, 180,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lt_MimeNm03,
                        javax.swing.GroupLayout.PREFERRED_SIZE, 180, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(lt_MimeNm04, javax.swing.GroupLayout.PREFERRED_SIZE, 180,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lt_MimeNm05,
                        javax.swing.GroupLayout.PREFERRED_SIZE, 180, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addComponent(lb_MimeType).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_MimeNm00).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_MimeNm01).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_MimeNm02).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_MimeNm03).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_MimeNm04).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_MimeNm05).addContainerGap(17,
                Short.MAX_VALUE)));
    }

    /**
     * 公司息面板初始化
     */
    private void icd()
    {
        pl_CorpInfo = new javax.swing.JPanel();
        pl_CorpInfo.setPreferredSize(new java.awt.Dimension(200, 162));
        pl_CorpInfo.setLayout(new java.awt.GridBagLayout());

        java.awt.GridBagConstraints gridBagConstraints;

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.insets = new java.awt.Insets(6, 6, 3, 3);
        lb_CorpLcNm = new javax.swing.JLabel();
        pl_CorpInfo.add(lb_CorpLcNm, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(6, 3, 3, 6);
        lt_CorpLcNm = new javax.swing.JLabel();
        pl_CorpInfo.add(lt_CorpLcNm, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_CorpEnNm = new javax.swing.JLabel();
        pl_CorpInfo.add(lb_CorpEnNm, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_CorpEnNm = new javax.swing.JLabel();
        pl_CorpInfo.add(lt_CorpEnNm, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_CorpSite = new javax.swing.JLabel();
        pl_CorpInfo.add(lb_CorpSite, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_CorpSite = new rmp.ui.link.WLinkLabel();
        lt_CorpSite.setAutoOpenLink(true);
        pl_CorpInfo.add(lt_CorpSite, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 3;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_CorpDesp = new javax.swing.JLabel();
        pl_CorpInfo.add(lb_CorpDesp, gridBagConstraints);

        javax.swing.JScrollPane sp_SoftDesp = new javax.swing.JScrollPane();
        lt_CorpDesp = new javax.swing.JTextArea();
        lt_CorpDesp.setEditable(false);
        lt_CorpDesp.setLineWrap(true);
        sp_SoftDesp.setViewportView(lt_CorpDesp);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 4;
        gridBagConstraints.gridwidth = 3;
        gridBagConstraints.fill = java.awt.GridBagConstraints.BOTH;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.weighty = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 6, 6);
        pl_CorpInfo.add(sp_SoftDesp, gridBagConstraints);
    }

    /**
     * 软件信息面板初始化
     */
    private void ice()
    {
        pl_SoftInfo = new javax.swing.JPanel();
        pl_SoftInfo.setPreferredSize(new java.awt.Dimension(200, 162));
        pl_SoftInfo.setLayout(new java.awt.GridBagLayout());

        java.awt.GridBagConstraints gridBagConstraints;

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.insets = new java.awt.Insets(6, 6, 3, 3);
        lb_SoftName = new javax.swing.JLabel();
        pl_SoftInfo.add(lb_SoftName, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(6, 3, 3, 6);
        lt_SoftName = new javax.swing.JLabel();
        pl_SoftInfo.add(lt_SoftName, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_SoftExts = new javax.swing.JLabel();
        pl_SoftInfo.add(lb_SoftExts, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_SoftExts = new javax.swing.JLabel();
        pl_SoftInfo.add(lt_SoftExts, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_SoftSite = new javax.swing.JLabel();
        pl_SoftInfo.add(lb_SoftSite, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_SoftSite = new rmp.ui.link.WLinkLabel();
        lt_SoftSite.setAutoOpenLink(true);
        pl_SoftInfo.add(lt_SoftSite, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 3;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_SoftDesp = new javax.swing.JLabel();
        pl_SoftInfo.add(lb_SoftDesp, gridBagConstraints);

        javax.swing.JScrollPane sp_SoftDesp = new javax.swing.JScrollPane();
        lt_SoftDesp = new javax.swing.JTextArea();
        lt_SoftDesp.setEditable(false);
        lt_SoftDesp.setLineWrap(true);
        sp_SoftDesp.setViewportView(lt_SoftDesp);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 4;
        gridBagConstraints.gridwidth = 3;
        gridBagConstraints.fill = java.awt.GridBagConstraints.BOTH;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.weighty = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 6, 6);
        pl_SoftInfo.add(sp_SoftDesp, gridBagConstraints);
    }

    /**
     * 文件信息面板初始化
     */
    private void icf()
    {
        pl_FileInfo = new javax.swing.JPanel();
        pl_FileInfo.setPreferredSize(new java.awt.Dimension(200, 162));
        pl_FileInfo.setLayout(new java.awt.GridBagLayout());

        java.awt.GridBagConstraints gridBagConstraints;

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.insets = new java.awt.Insets(6, 6, 3, 3);
        lb_SignChar = new javax.swing.JLabel();
        pl_FileInfo.add(lb_SignChar, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(6, 3, 3, 6);
        lt_SignChar = new javax.swing.JLabel();
        pl_FileInfo.add(lt_SignChar, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_SignCode = new javax.swing.JLabel();
        pl_FileInfo.add(lb_SignCode, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_SignCode = new javax.swing.JLabel();
        pl_FileInfo.add(lt_SignCode, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_CipherSn = new javax.swing.JLabel();
        pl_FileInfo.add(lb_CipherSn, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_CipherSn = new javax.swing.JLabel();
        pl_FileInfo.add(lt_CipherSn, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 3;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_FileDesp = new javax.swing.JLabel();
        pl_FileInfo.add(lb_FileDesp, gridBagConstraints);

        javax.swing.JScrollPane sp_SoftDesp = new javax.swing.JScrollPane();
        lt_FileDesp = new javax.swing.JTextArea();
        lt_FileDesp.setEditable(false);
        lt_FileDesp.setLineWrap(true);
        sp_SoftDesp.setViewportView(lt_FileDesp);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 4;
        gridBagConstraints.gridwidth = 3;
        gridBagConstraints.fill = java.awt.GridBagConstraints.BOTH;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.weighty = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 6, 6);
        pl_FileInfo.add(sp_SoftDesp, gridBagConstraints);
    }

    /**
     * 备选软件面板初始化
     */
    private void icg()
    {
        pl_AsocInfo = new javax.swing.JPanel();
        lb_AsocSoft = new javax.swing.JLabel();
        lt_AsocNm00 = new javax.swing.JLabel();
        lt_AsocNm01 = new javax.swing.JLabel();
        lt_AsocNm02 = new javax.swing.JLabel();
        lt_AsocNm03 = new javax.swing.JLabel();
        lt_AsocNm04 = new javax.swing.JLabel();
        lt_AsocNm05 = new javax.swing.JLabel();

        pl_AsocInfo.setPreferredSize(new java.awt.Dimension(200, 162));

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(pl_AsocInfo);
        pl_AsocInfo.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lt_AsocNm00,
                    javax.swing.GroupLayout.PREFERRED_SIZE, 180, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(
                    lb_AsocSoft).addComponent(lt_AsocNm01, javax.swing.GroupLayout.DEFAULT_SIZE, 180, Short.MAX_VALUE)
                    .addComponent(lt_AsocNm02, javax.swing.GroupLayout.PREFERRED_SIZE, 180,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lt_AsocNm03,
                        javax.swing.GroupLayout.PREFERRED_SIZE, 180, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(lt_AsocNm04, javax.swing.GroupLayout.PREFERRED_SIZE, 180,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lt_AsocNm05,
                        javax.swing.GroupLayout.PREFERRED_SIZE, 180, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addComponent(lb_AsocSoft).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_AsocNm00).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_AsocNm01).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_AsocNm02).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_AsocNm03).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_AsocNm04).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_AsocNm05).addContainerGap(17,
                Short.MAX_VALUE)));
    }

    /**
     * 特别致谢面板初始化
     */
    private void ich()
    {
        pl_IdioInfo = new javax.swing.JPanel();
        pl_IdioInfo.setPreferredSize(new java.awt.Dimension(200, 162));
        pl_IdioInfo.setLayout(new java.awt.GridBagLayout());

        java.awt.GridBagConstraints gridBagConstraints;

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.insets = new java.awt.Insets(6, 6, 3, 3);
        lb_IdioMail = new javax.swing.JLabel();
        pl_IdioInfo.add(lb_IdioMail, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(6, 3, 3, 6);
        lt_IdioMail = new rmp.ui.link.WLinkLabel();
        lt_IdioMail.setAutoOpenLink(true);
        pl_IdioInfo.add(lt_IdioMail, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_NickName = new javax.swing.JLabel();
        pl_IdioInfo.add(lb_NickName, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_NickName = new javax.swing.JLabel();
        pl_IdioInfo.add(lt_NickName, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_HomePage = new javax.swing.JLabel();
        pl_IdioInfo.add(lb_HomePage, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_HomePage = new rmp.ui.link.WLinkLabel();
        lt_HomePage.setAutoOpenLink(true);
        pl_IdioInfo.add(lt_HomePage, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 3;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_IdioDesp = new javax.swing.JLabel();
        pl_IdioInfo.add(lb_IdioDesp, gridBagConstraints);

        javax.swing.JScrollPane sp_SoftDesp = new javax.swing.JScrollPane();
        lt_IdioDesp = new javax.swing.JTextArea();
        lt_IdioDesp.setEditable(false);
        lt_IdioDesp.setLineWrap(true);
        sp_SoftDesp.setViewportView(lt_IdioDesp);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 4;
        gridBagConstraints.gridwidth = 3;
        gridBagConstraints.fill = java.awt.GridBagConstraints.BOTH;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.weighty = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 6, 6);
        pl_IdioInfo.add(sp_SoftDesp, gridBagConstraints);
    }

    /**
     * 
     */
    private void ita()
    {
        // ------------------------------------------------
        // 迷你面板
        // ------------------------------------------------
        // 后缀名称
        BeanUtil.setWText(tf_ExtsName, Extparse.getMesg(LangRes.MAIN_FILD_TEXT_EXTSNAME));
        BeanUtil.setWTips(tf_ExtsName, Extparse.getMesg(LangRes.MAIN_FILD_TIPS_EXTSNAME));

        // 软件名称
        BeanUtil.setWText(lb_SoftList, Extparse.getMesg(LangRes.EXTS_COMB_TEXT_SOFTNAME));
        BeanUtil.setWTips(lb_SoftList, Extparse.getMesg(LangRes.EXTS_COMB_TIPS_SOFTNAME));

        // 结果数量
        BeanUtil.setWText(bt_SoftList, Extparse.getMesg(LangRes.MINI_BUTN_TEXT_SOFTLIST));
        BeanUtil.setWTips(bt_SoftList, Extparse.getMesg(LangRes.MINI_BUTN_TIPS_SOFTLIST));

        // 后缀描述
        BeanUtil.setWText(lb_DespInfo, Extparse.getMesg(LangRes.MINI_LABL_TEXT_DESPINFO));
        BeanUtil.setWTips(lb_DespInfo, Extparse.getMesg(LangRes.TITLE_DESPFORM));

        // MIME类型
        BeanUtil.setWText(lb_MimeInfo, Extparse.getMesg(LangRes.MINI_LABL_TEXT_MIMEINFO));
        BeanUtil.setWTips(lb_MimeInfo, Extparse.getMesg(LangRes.TITLE_MIMEFORM));

        // 公司信息
        BeanUtil.setWText(lb_CorpInfo, Extparse.getMesg(LangRes.MINI_LABL_TEXT_CORPINFO));
        BeanUtil.setWTips(lb_CorpInfo, Extparse.getMesg(LangRes.TITLE_CORPFORM));

        // 软件信息
        BeanUtil.setWText(lb_SoftInfo, Extparse.getMesg(LangRes.MINI_LABL_TEXT_SOFTINFO));
        BeanUtil.setWTips(lb_SoftInfo, Extparse.getMesg(LangRes.TITLE_SOFTFORM));

        // 文件信息
        BeanUtil.setWText(lb_FileInfo, Extparse.getMesg(LangRes.MINI_LABL_TEXT_FILEINFO));
        BeanUtil.setWTips(lb_FileInfo, Extparse.getMesg(LangRes.TITLE_FILEFORM));

        // MIME类型
        BeanUtil.setWText(lb_AsocInfo, Extparse.getMesg(LangRes.MINI_LABL_TEXT_ASOCINFO));
        BeanUtil.setWTips(lb_AsocInfo, Extparse.getMesg(LangRes.TITLE_ASOCFORM));

        // 特别致谢
        BeanUtil.setWText(lb_IdioInfo, Extparse.getMesg(LangRes.MINI_LABL_TEXT_IDIOINFO));
        BeanUtil.setWTips(lb_IdioInfo, Extparse.getMesg(LangRes.TITLE_IDIOFORM));

        // 公益广告
        // BeanUtil.setWTips(rl_NoteInfo,
        // Extparse.getMesg(LangRes.MAIN_ROLL_TIPS_PUBLICAD));

        // ------------------------------------------------
        // 后缀描述
        // ------------------------------------------------
        // 所属类别
        BeanUtil.setWText(lb_ExtsType, Extparse.getMesg(LangRes.MAIN_COMN_TEXT_EXTSTYPE));
        BeanUtil.setWTips(lb_ExtsType, Extparse.getMesg(LangRes.MAIN_COMN_TEXT_EXTSTYPE));

        // CPU 类型
        BeanUtil.setWText(lb_ArchBits, Extparse.getMesg(LangRes.MAIN_COMN_TEXT_ARCHBITS));
        BeanUtil.setWTips(lb_ArchBits, Extparse.getMesg(LangRes.MAIN_COMN_TEXT_ARCHBITS));

        // 运行平台
        BeanUtil.setWText(lb_PlatForm, Extparse.getMesg(LangRes.MAIN_COMN_TEXT_EXTSPLAT));
        BeanUtil.setWTips(lb_PlatForm, Extparse.getMesg(LangRes.MAIN_COMN_TEXT_EXTSPLAT));

        // 后缀说明
        BeanUtil.setWText(lb_ExtsDesp, Extparse.getMesg(LangRes.DESP_COMN_TEXT_EXTSDESP));
        BeanUtil.setWTips(lb_ExtsDesp, Extparse.getMesg(LangRes.DESP_COMN_TEXT_EXTSDESP));

        // 后缀说明
        BeanUtil.setWText(lb_ExtsDesp, Extparse.getMesg(LangRes.DESP_AREA_TEXT_EXTSDESP));
        BeanUtil.setWTips(lb_ExtsDesp, Extparse.getMesg(LangRes.DESP_AREA_TIPS_EXTSDESP));

        // ------------------------------------------------
        // MIME类型
        // ------------------------------------------------
        BeanUtil.setWText(lb_MimeType, Extparse.getMesg(LangRes.MIME_COMN_TEXT_MIMENAME));
        BeanUtil.setWTips(lb_MimeType, Extparse.getMesg(LangRes.MIME_COMN_TEXT_MIMENAME));

        // ------------------------------------------------
        // 公司信息
        // ------------------------------------------------
        BeanUtil.setWText(lb_CorpLcNm, Extparse.getMesg(LangRes.CORP_COMN_TEXT_CORPLCNM));
        BeanUtil.setWTips(lb_CorpLcNm, Extparse.getMesg(LangRes.CORP_COMN_TEXT_CORPLCNM));

        BeanUtil.setWText(lb_CorpEnNm, Extparse.getMesg(LangRes.CORP_COMN_TEXT_CORPENNM));
        BeanUtil.setWTips(lb_CorpEnNm, Extparse.getMesg(LangRes.CORP_COMN_TEXT_CORPENNM));

        BeanUtil.setWText(lb_CorpSite, Extparse.getMesg(LangRes.CORP_COMN_TEXT_CORPSITE));
        BeanUtil.setWTips(lb_CorpSite, Extparse.getMesg(LangRes.CORP_COMN_TEXT_CORPSITE));

        BeanUtil.setWText(lb_CorpDesp, Extparse.getMesg(LangRes.CORP_COMN_TEXT_CORPDESP));
        BeanUtil.setWTips(lb_CorpDesp, Extparse.getMesg(LangRes.CORP_COMN_TEXT_CORPDESP));

        // ------------------------------------------------
        // 软件信息
        // ------------------------------------------------
        BeanUtil.setWText(lb_SoftName, Extparse.getMesg(LangRes.SOFT_COMN_TEXT_SOFTNAME));
        BeanUtil.setWTips(lb_SoftName, Extparse.getMesg(LangRes.SOFT_COMN_TEXT_SOFTNAME));

        BeanUtil.setWText(lb_SoftExts, Extparse.getMesg(LangRes.SOFT_COMN_TEXT_SOFTEXTS));
        BeanUtil.setWTips(lb_SoftExts, Extparse.getMesg(LangRes.SOFT_COMN_TEXT_SOFTEXTS));

        BeanUtil.setWText(lb_SoftSite, Extparse.getMesg(LangRes.SOFT_COMN_TEXT_SOFTSITE));
        BeanUtil.setWTips(lb_SoftSite, Extparse.getMesg(LangRes.SOFT_COMN_TEXT_SOFTSITE));

        BeanUtil.setWText(lb_SoftDesp, Extparse.getMesg(LangRes.SOFT_COMN_TEXT_SOFTDESP));
        BeanUtil.setWTips(lb_SoftDesp, Extparse.getMesg(LangRes.SOFT_COMN_TEXT_SOFTDESP));

        // ------------------------------------------------
        // 文件信息
        // ------------------------------------------------
        BeanUtil.setWText(lb_SignChar, Extparse.getMesg(LangRes.FILE_COMN_TEXT_SIGNCHAR));
        BeanUtil.setWTips(lb_SignChar, Extparse.getMesg(LangRes.FILE_COMN_TEXT_SIGNCHAR));

        BeanUtil.setWText(lb_SignCode, Extparse.getMesg(LangRes.FILE_COMN_TEXT_SIGNCODE));
        BeanUtil.setWTips(lb_SignCode, Extparse.getMesg(LangRes.FILE_COMN_TEXT_SIGNCODE));

        BeanUtil.setWText(lb_CipherSn, Extparse.getMesg(LangRes.FILE_COMN_TEXT_CIPHERSN));
        BeanUtil.setWTips(lb_CipherSn, Extparse.getMesg(LangRes.FILE_COMN_TEXT_CIPHERSN));

        BeanUtil.setWText(lb_FileDesp, Extparse.getMesg(LangRes.FILE_COMN_TEXT_FILEDESP));
        BeanUtil.setWTips(lb_FileDesp, Extparse.getMesg(LangRes.FILE_COMN_TEXT_FILEDESP));

        // ------------------------------------------------
        // 备选软件
        // ------------------------------------------------
        BeanUtil.setWText(lb_AsocSoft, Extparse.getMesg(LangRes.ASOC_COMN_TEXT_ASOCSOFT));
        BeanUtil.setWTips(lb_AsocSoft, Extparse.getMesg(LangRes.ASOC_COMN_TEXT_ASOCSOFT));

        // ------------------------------------------------
        // 特别致谢
        // ------------------------------------------------
        BeanUtil.setWText(lb_IdioMail, Extparse.getMesg(LangRes.IDIO_COMN_TEXT_IDIOMAIL));
        BeanUtil.setWTips(lb_IdioMail, Extparse.getMesg(LangRes.IDIO_COMN_TEXT_IDIOMAIL));

        BeanUtil.setWText(lb_NickName, Extparse.getMesg(LangRes.MINI_LABL_TEXT_NICKNAME));
        BeanUtil.setWTips(lb_NickName, Extparse.getMesg(LangRes.MINI_LABL_TIPS_NICKNAME));

        BeanUtil.setWText(lb_HomePage, Extparse.getMesg(LangRes.IDIO_COMN_TEXT_HOMEPAGE));
        BeanUtil.setWTips(lb_HomePage, Extparse.getMesg(LangRes.IDIO_COMN_TEXT_HOMEPAGE));

        BeanUtil.setWText(lb_IdioDesp, Extparse.getMesg(LangRes.IDIO_COMN_TEXT_IDIODESP));
        BeanUtil.setWTips(lb_IdioDesp, Extparse.getMesg(LangRes.IDIO_COMN_TEXT_IDIODESP));
    }

    // ========================================================================
    // 事件处理区域
    // ========================================================================
    /**
     * @param evt
     */
    private void bt_SoftList_Handler(java.awt.event.ActionEvent evt)
    {
        if (pm_SoftMenu.getComponentCount() > 0)
        {
            pm_SoftMenu.show(bt_SoftList, 0, bt_SoftList.getSize().height);
        }
    }

    /**
     * @param evt
     */
    private void tf_ExtsName_Handler(java.awt.event.ActionEvent evt)
    {
        // 用户输入数据合法性检测
        UserData userMeta = new UserData();
        userMeta.wInit();

        // 数据检测
        if (!userMeta.setExtsName(this.tf_ExtsName.getText()))
        {
            MesgUtil.showMessageDialog(Extparse.getForm(), userMeta.getErrMsg());
            this.tf_ExtsName.requestFocus();
            return;
        }
        this.tf_ExtsName.setText(userMeta.getExtsName());

        // 数据查询
        metaSelect(userMeta.getExtsName());
    }

    /**
     * @param evt
     */
    private void lb_DespInfo_Handler(java.awt.event.MouseEvent evt)
    {
        cl_CardPanl.show(pl_CardPanl, ConstUI.PROP_DESPINFO);
        changeLabel(lb_DespInfo);
    }

    /**
     * @param evt
     */
    private void lb_MimeInfo_Handler(java.awt.event.MouseEvent evt)
    {
        cl_CardPanl.show(pl_CardPanl, ConstUI.PROP_MIMEINFO);
        changeLabel(lb_MimeInfo);
    }

    /**
     * @param evt
     */
    private void lb_CorpInfo_Handler(java.awt.event.MouseEvent evt)
    {
        cl_CardPanl.show(pl_CardPanl, ConstUI.PROP_CORPINFO);
        changeLabel(lb_CorpInfo);
    }

    /**
     * @param evt
     */
    private void lb_SoftInfo_Handler(java.awt.event.MouseEvent evt)
    {
        cl_CardPanl.show(pl_CardPanl, ConstUI.PROP_SOFTINFO);
        changeLabel(lb_SoftInfo);
    }

    /**
     * @param evt
     */
    private void lb_FileInfo_Handler(java.awt.event.MouseEvent evt)
    {
        cl_CardPanl.show(pl_CardPanl, ConstUI.PROP_FILEINFO);
        changeLabel(lb_FileInfo);
    }

    /**
     * @param evt
     */
    private void lb_AsocInfo_Handler(java.awt.event.MouseEvent evt)
    {
        cl_CardPanl.show(pl_CardPanl, ConstUI.PROP_ASOCINFO);
        changeLabel(lb_AsocInfo);
    }

    /**
     * @param evt
     */
    private void lb_IdioInfo_Handler(java.awt.event.MouseEvent evt)
    {
        cl_CardPanl.show(pl_CardPanl, ConstUI.PROP_IDIOINFO);
        changeLabel(lb_IdioInfo);
    }

    // ========================================================================
    // 公共接口区域
    // ========================================================================
    /**
     * 标签背景颜色交替显示
     * 
     * @param currLabl
     */
    private void changeLabel(javax.swing.JLabel currLabl)
    {
        lb_LastLabl.setOpaque(false);
        lb_LastLabl.repaint();

        lb_LastLabl = currLabl;

        lb_LastLabl.setOpaque(true);
        lb_LastLabl.repaint();
    }

    /**
     * @param dataList
     * @return
     */
    private boolean changeMenu(List<BaseData> dataList)
    {
        pm_SoftMenu.removeAll();

        // 数据为空检测
        if (dataList == null || dataList.size() == 0)
        {
            bt_SoftList.setText("0");
            String tips = StringUtil.format(LangRes.MINI_BUTN_NOTE_SOFTLIST, "0");
            bt_SoftList.setToolTipText(tips);
            return false;
        }
        // 一个数据的处理
        if (dataList.size() == 1)
        {
            bt_SoftList.setText("1");
            String tips = StringUtil.format(LangRes.MINI_BUTN_NOTE_SOFTLIST, "1");
            bt_SoftList.setToolTipText(tips);
            return true;
        }

        // 多个数据的处理
        javax.swing.ButtonGroup bgGroup = new javax.swing.ButtonGroup();
        BaseData baseMeta = dataList.get(0);
        javax.swing.JCheckBoxMenuItem menuItem = new javax.swing.JCheckBoxMenuItem(baseMeta.getSoftName());
        menuItem.putClientProperty(ConstUI.PROP_SOFTHASH, baseMeta.getSoftIndx());
        menuItem.setSelected(true);
        menuItem.addActionListener(this);
        bgGroup.add(menuItem);
        pm_SoftMenu.add(menuItem);

        int size = dataList.size();
        for (int i = 1; i < size; i += 1)
        {
            baseMeta = dataList.get(i);
            menuItem = new javax.swing.JCheckBoxMenuItem(baseMeta.getSoftName());
            menuItem.putClientProperty(ConstUI.PROP_SOFTHASH, baseMeta.getSoftIndx());
            menuItem.addActionListener(this);
            bgGroup.add(menuItem);

            pm_SoftMenu.add(menuItem);
        }

        bt_SoftList.setText("" + size);
        String tips = StringUtil.format(LangRes.MINI_BUTN_NOTE_SOFTLIST, "" + size);
        bt_SoftList.setToolTipText(tips);
        return true;
    }

    /**
     * @param dba
     * @param baseMeta
     * @return
     * @throws SQLException
     */
    private boolean setBaseData(DBAccess dba, BaseData baseMeta) throws SQLException
    {
        this.bd_BaseMeta = baseMeta;

        ExtsBaseData extsData = DA0008.selectExtsMeta(dba, baseMeta);
        // 数据保存
        me_MainSoft.setBaseData(extsData);

        // 所属类别
        setWText(lt_ExtsType, DC0008.selectTypeName(dba, PrpCons.P3010000_I, extsData.getTypeIndx()));
        // CPU 构架
        setWText(lt_ArchBits, Extparse.decodeArchBits(extsData.getArchBits()));
        // 运行平台
        setWText(lt_PlatForm, Extparse.decodePlatForm(extsData.getPlatIndx()));
        // 后缀描述
        String langHash = RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_LANG_ID);
        DespBaseData despMeta = DA0008.selectDespMetaInfo(dba, extsData.getDespIndx(), langHash);
        lt_ExtsDesp.setText(despMeta.isMetaExist() ? despMeta.getExtsDesp() : "");

        // MIME类型
        javax.swing.JLabel[] mimeLabl = {lt_MimeNm00, lt_MimeNm01, lt_MimeNm02, lt_MimeNm03, lt_MimeNm04, lt_MimeNm05};
        List<K2SV1S> mimeList = DA0008.selectMimeMetaName(dba, extsData.getMimeIndx(), "");
        int mimeSize = mimeList.size() < mimeLabl.length ? mimeList.size() : mimeLabl.length;
        for (int i = 0; i < mimeSize; i += 1)
        {
            setWText(mimeLabl[i], mimeList.get(i).getV());
        }
        for (int i = mimeSize, j = mimeLabl.length; i < j; i += 1)
        {
            setWText(mimeLabl[i], null);
        }

        // 公司信息
        CorpBaseData corpMeta = DA0008.selectCorpMetaInfo(dba, extsData.getCorpIndx());
        setWText(lt_CorpLcNm, corpMeta.getCorpLcNm());
        setWText(lt_CorpEnNm, corpMeta.getCorpEnNm());
        setWText(lt_CorpSite, corpMeta.getCorpSite());
        lt_CorpSite.setLinkUrl(corpMeta.getCorpSite());
        lt_CorpDesp.setText(corpMeta.getCorpDesp());

        // 软件信息
        SoftBaseData softMeta = DA0008.selectSoftMetaInfo(dba, extsData.getSoftIndx());
        setWText(lt_SoftName, softMeta.getSoftName());
        setWText(lt_SoftExts, softMeta.getExtsList());
        setWText(lt_SoftSite, softMeta.getSoftSite());
        lt_SoftSite.setLinkUrl(softMeta.getSoftSite());
        lt_SoftDesp.setText(softMeta.getSoftDesp());
        // 图像读取
        ib_SoftIcon.setIconHash(softMeta.getSoftIcon());
        // 直属软件
        setWText(lb_SoftList, softMeta.getSoftName());

        // 文件信息
        FileBaseData fileMeta = DA0008.selectFileMetaInfo(dba, extsData.getFileIndx());
        setWText(lt_SignChar, fileMeta.getSignChar());
        setWText(lt_SignCode, fileMeta.getSignCode());
        setWText(lt_CipherSn, fileMeta.getCipherSn());
        lt_FileDesp.setText(fileMeta.getFileDesp());

        // 备选软件
        javax.swing.JLabel[] asocLabl = {lt_AsocNm00, lt_AsocNm01, lt_AsocNm02, lt_AsocNm03, lt_AsocNm04, lt_AsocNm05};
        List<K1SV2S> asocList = DA0008.selectAsocMetaInfo(dba, extsData.getAsocIndx(), "").getAsocList();
        int asocSize = asocList.size() < asocLabl.length ? asocList.size() : asocLabl.length;
        for (int i = 0; i < asocSize; i += 1)
        {
            setWText(asocLabl[i], asocList.get(i).getV1());
        }
        for (int i = asocSize, j = asocLabl.length; i < j; i += 1)
        {
            setWText(asocLabl[i], null);
        }

        // 特别致谢
        IdioBaseData idioMeta = DA0008.selectIdioMetaInfo(dba, extsData.getIdioIndx());
        setWText(lt_IdioMail, idioMeta.getIdioMail());
        lt_IdioMail.setLinkUrl("mailto:" + idioMeta.getIdioMail());
        setWText(lt_NickName, idioMeta.getNickName());
        setWText(lt_HomePage, idioMeta.getHomePage());
        lt_HomePage.setLinkUrl(idioMeta.getHomePage());
        lt_IdioDesp.setText(idioMeta.getIdioDesp());

        return true;
    }

    /**
     * @param label
     * @param wText
     */
    private void setWText(javax.swing.JLabel label, String wText)
    {
        label.setText(wText);
        label.setToolTipText(wText);
    }

    // ========================================================================
    // 界面组件区域
    // ========================================================================
    private javax.swing.JButton              bt_SoftList;
    private javax.swing.JLabel               lb_AsocInfo;
    private javax.swing.JLabel               lb_CorpInfo;
    private javax.swing.JLabel               lb_DespInfo;
    private javax.swing.JLabel               lb_FileInfo;
    private javax.swing.JLabel               lb_IdioInfo;
    private javax.swing.JLabel               lb_MimeInfo;
    private javax.swing.JLabel               lb_SoftInfo;
    private javax.swing.JLabel               lb_SoftList;
    private javax.swing.JPanel               pl_CardPanl;
    private javax.swing.JTextField           tf_ExtsName;
    private rmp.prp.aide.extparse.b.WIconBox ib_SoftIcon;
    private rmp.comn.rmps.C4010000.C4010000  rl_NoteInfo;

    // ----------------------------------------------------
    // 后缀描述组件区域
    // ----------------------------------------------------
    private javax.swing.JPanel               pl_DespInfo;
    private javax.swing.JLabel               lb_ExtsType;
    private javax.swing.JLabel               lb_ArchBits;
    private javax.swing.JLabel               lb_PlatForm;
    private javax.swing.JLabel               lb_ExtsDesp;
    private javax.swing.JLabel               lt_ExtsType;
    private javax.swing.JLabel               lt_ArchBits;
    private javax.swing.JLabel               lt_PlatForm;
    private javax.swing.JTextArea            lt_ExtsDesp;

    // ----------------------------------------------------
    // 公司信息组件区域
    // ----------------------------------------------------
    private javax.swing.JPanel               pl_CorpInfo;
    private javax.swing.JLabel               lb_CorpDesp;
    private javax.swing.JLabel               lb_CorpEnNm;
    private javax.swing.JLabel               lb_CorpLcNm;
    private javax.swing.JLabel               lb_CorpSite;
    private javax.swing.JTextArea            lt_CorpDesp;
    private javax.swing.JLabel               lt_CorpEnNm;
    private javax.swing.JLabel               lt_CorpLcNm;
    private rmp.ui.link.WLinkLabel           lt_CorpSite;

    // ----------------------------------------------------
    // 软件信息组件区域
    // ----------------------------------------------------
    private javax.swing.JPanel               pl_SoftInfo;
    private javax.swing.JLabel               lb_SoftDesp;
    private javax.swing.JLabel               lb_SoftName;
    private javax.swing.JLabel               lb_SoftExts;
    private javax.swing.JLabel               lb_SoftSite;
    private javax.swing.JTextArea            lt_SoftDesp;
    private javax.swing.JLabel               lt_SoftName;
    private javax.swing.JLabel               lt_SoftExts;
    private rmp.ui.link.WLinkLabel           lt_SoftSite;

    // ----------------------------------------------------
    // 文件信息组件区域
    // ----------------------------------------------------
    private javax.swing.JPanel               pl_FileInfo;
    private javax.swing.JLabel               lb_FileDesp;
    private javax.swing.JLabel               lb_SignChar;
    private javax.swing.JLabel               lb_SignCode;
    private javax.swing.JLabel               lb_CipherSn;
    private javax.swing.JTextArea            lt_FileDesp;
    private javax.swing.JLabel               lt_SignChar;
    private javax.swing.JLabel               lt_SignCode;
    private javax.swing.JLabel               lt_CipherSn;

    // ----------------------------------------------------
    // MIME类型组件区域
    // ----------------------------------------------------
    private javax.swing.JPanel               pl_MimeInfo;
    private javax.swing.JLabel               lb_MimeType;
    private javax.swing.JLabel               lt_MimeNm00;
    private javax.swing.JLabel               lt_MimeNm01;
    private javax.swing.JLabel               lt_MimeNm02;
    private javax.swing.JLabel               lt_MimeNm03;
    private javax.swing.JLabel               lt_MimeNm04;
    private javax.swing.JLabel               lt_MimeNm05;

    // ----------------------------------------------------
    // 备选软件组件区域
    // ----------------------------------------------------
    private javax.swing.JPanel               pl_AsocInfo;
    private javax.swing.JLabel               lb_AsocSoft;
    private javax.swing.JLabel               lt_AsocNm00;
    private javax.swing.JLabel               lt_AsocNm01;
    private javax.swing.JLabel               lt_AsocNm02;
    private javax.swing.JLabel               lt_AsocNm03;
    private javax.swing.JLabel               lt_AsocNm04;
    private javax.swing.JLabel               lt_AsocNm05;

    // ----------------------------------------------------
    // 特别致谢组件区域
    // ----------------------------------------------------
    private javax.swing.JPanel               pl_IdioInfo;
    private javax.swing.JLabel               lb_IdioDesp;
    private javax.swing.JLabel               lb_IdioMail;
    private javax.swing.JLabel               lb_NickName;
    private javax.swing.JLabel               lb_HomePage;
    private javax.swing.JTextArea            lt_IdioDesp;
    private rmp.ui.link.WLinkLabel           lt_IdioMail;
    private javax.swing.JLabel               lt_NickName;
    private rmp.ui.link.WLinkLabel           lt_HomePage;
}
