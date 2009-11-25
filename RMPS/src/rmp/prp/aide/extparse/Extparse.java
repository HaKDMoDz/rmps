/*
 * FileName:       Extparse.java
 * CreateDate:     Jul 4, 2007 12:58:12 PM
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse;

import java.awt.Component;
import java.awt.Container;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.util.Properties;

import javax.swing.JMenu;
import javax.swing.JPanel;

import rmp.Rmps;
import rmp.bean.K1SV2S;
import rmp.comn.info.C1010000.C1010000;
import com.amonsoft.rmps.prp.ISoft;
import rmp.prp.Prps;
import rmp.prp.aide.extparse.m.ExtsBaseData;
import rmp.prp.aide.extparse.v.AsocPanel;
import rmp.prp.aide.extparse.v.CorpPanel;
import rmp.prp.aide.extparse.v.DespPanel;
import rmp.prp.aide.extparse.v.ExtsPanel;
import rmp.prp.aide.extparse.v.FilePanel;
import rmp.prp.aide.extparse.v.IdioPanel;
import rmp.prp.aide.extparse.v.MainPanel;
import rmp.prp.aide.extparse.v.MimePanel;
import rmp.prp.aide.extparse.v.MiniPanel;
import rmp.prp.aide.extparse.v.SoftPanel;
import rmp.prp.aide.extparse.v.StepPanel;
import rmp.ui.form.AForm;
import rmp.ui.form.DForm;
import rmp.ui.form.FForm;
import rmp.ui.icon.WIconLabel;
import rmp.user.UserInfo;
import rmp.util.BeanUtil;
import rmp.util.EnvUtil;
import rmp.util.FileUtil;
import rmp.util.ImageUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.RmpsUtil;
import rmp.util.StringUtil;
import cons.CfgCons;
import cons.EnvCons;
import cons.SysCons;
import cons.id.PrpCons;
import cons.prp.aide.extparse.ConstUI;
import cons.prp.aide.extparse.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * 后缀解析
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
 * 日期： Jul 4, 2007 12:58:12 PM
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class Extparse extends AForm implements ISoft
{
    /**  */
    private static final long serialVersionUID = 1L;

    // ////////////////////////////////////////////////////////////////////////
    // 控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 逻辑控制区域
    // ----------------------------------------------------
    /** 当前运行状态标记：参见AppCons.APP_MODE_*** */
    private static int        appMode;

    /** 程序主窗口 */
    private static AForm      softAForm;
    private static FForm      softFForm;

    /** 语言资源 */
    private static Properties langRes;
    /** RMPS系统运行目录 */
    private static String     baseFolder       = "";
    /** 插件程序运行目录 */
    private static String     plusFolder       = "";

    // ----------------------------------------------------
    // 界面显示区域
    // ----------------------------------------------------
    /** 当前显示后台数据 */
    private ExtsBaseData      me_BaseData;

    // ////////////////////////////////////////////////////////////////////////
    // 接口实现区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 默认构造函数
     */
    public Extparse()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    @ Override
    public boolean wInit()
    {
        // 实例化主窗口
        softFForm = new FForm();
        softFForm.wInit();
        softFForm.setResizable(false);
        softFForm.setIconImage(BeanUtil.getLogoImage());

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#dispose()
     */
    @ Override
    public void wDispose()
    {
        Rmps.exit(0, true, true);
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getBaseFolder()
     */
    @ Override
    public String wGetBaseFolder()
    {
        return baseFolder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#setBaseFolder(java.lang.String)
     */
    @ Override
    public void wSetBaseFolder(String folder)
    {
        baseFolder = folder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getSoftDescription()
     */
    @ Override
    public String wGetDescription()
    {
        return Prps.getMesg(ConstUI.RES_DESCRIPTION);
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getHomepage()
     */
    @ Override
    public String wGetHomepage()
    {
        return ConstUI.URL_SOFT;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getSoftLogo()
     */
    @ Override
    public BufferedImage wGetIconImage(int type)
    {
        return BeanUtil.getLogoImage();
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetMode()
     */
    @ Override
    public int wGetMode()
    {
        return 0;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getSystemID()
     */
    @ Override
    public int wCode()
    {
        return PrpCons.P3010000_I;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getSystemName()
     */
    @ Override
    public String wGetName()
    {
        return Prps.getMesg(ConstUI.RES_NAME);
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetPlusFolder()
     */
    @ Override
    public String wGetPlusFolder()
    {
        return plusFolder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wSetPlusFolder(java.lang.String)
     */
    @ Override
    public void wSetPlusFolder(String folder)
    {
        plusFolder = folder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getTitle()
     */
    public String wGetTitle()
    {
        return Prps.getMesg(ConstUI.RES_TITLE);
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#getSystemVersion()
     */
    @ Override
    public String wGetVersion()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#initSoftMenu(javax.swing.JMenu)
     */
    @ Override
    public boolean wInitMenu(JMenu menu)
    {
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#initSoftTail(javax.swing.JPanel)
     */
    @ Override
    public boolean wInitTail(JPanel view)
    {
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wShowHelp()
     */
    @ Override
    public void wShowHelp()
    {
        EnvUtil.open(EnvCons.FOLDER0_HELP + EnvCons.COMN_SP_FILE + "index.html");
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wShowInfo()
     */
    @ Override
    public void wShowInfo()
    {
        C1010000.setInfo(getInfoPath());
        Prps.getSoftInfo().wShowView(VIEW_NORM);
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wShowView(int)
     */
    @ Override
    public javax.swing.JPanel wShowView(int modelIdx)
    {
        switch (modelIdx)
        {
            // 显示内嵌模式
            case VIEW_TAIL:
                return showTail();

                // 显示迷你模式
            case VIEW_MINI:
                return showMini();

                // 显示正常模式
            case VIEW_NORM:
                return showNorm();

                // 显示高级模式
            case VIEW_MAIN:
                return showMain();

                // 显示向导模式
            case VIEW_STEP:
                return showStep();

            default:
                return null;
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wStart()
     */
    @ Override
    public boolean wStart()
    {
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wStop()
     */
    @ Override
    public boolean wStop()
    {
        return true;
    }

    /**
     * 语言资源查询
     * 
     * @param mesgId 语言资源索引
     * @return 语言资源内容
     */
    public static String getMesg(String mesgId)
    {
        if (langRes == null)
        {
            langRes = new Properties();

            // 语言资源信息读取
            try
            {
                FileUtil.readLangRes(langRes, EnvCons.PATH_P3010000, EnvCons.COMN_SOFT_LANG);
            }
            catch(Exception exp)
            {
                LogUtil.exception(exp);
                MesgUtil.showMessageDialog(getForm(), exp.getMessage());
            }
        }
        return langRes.getProperty(mesgId);
    }

    /**
     * 语言资源查询
     * 
     * @param mesgId 语言资源索引
     * @param defMesg 默认语言资源
     * @return 语言资源内容
     */
    public static String getMesg(String mesgId, String defMesg)
    {
        String v = getMesg(mesgId);
        return v != null ? v : defMesg;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 模块接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 程序当前运行方式：Application、Applet、Web Start
     * 
     * @return
     */
    public static int getAppMode()
    {
        return appMode;
    }

    /**
     * 软件主窗口获取
     * 
     * @return 软件主窗口
     */
    public static Container getForm()
    {
        return appMode == MODE_APPLET ? softAForm : softFForm;
    }

    /**
     * CPU架构信息解析
     * 
     * @param bits
     * @return
     */
    public static String decodeArchBits(int bits)
    {
        // 其它
        if (SysCons.BITS_IDX_00 == bits)
        {
            return Extparse.getMesg(LangRes.MAIN_COMN_TEXT_AB00);
        }

        String ab = "";
        String sp = Extparse.getMesg(LangRes.TEXT_CTRLSPVV);

        // 64位
        if ((bits & SysCons.BITS_IDX_64) != 0)
        {
            ab += sp + Extparse.getMesg(LangRes.MAIN_COMN_TEXT_AB64);
        }
        // 32位
        if ((bits & SysCons.BITS_IDX_32) != 0)
        {
            ab += sp + Extparse.getMesg(LangRes.MAIN_COMN_TEXT_AB32);
        }
        // 16位
        if ((bits & SysCons.BITS_IDX_16) != 0)
        {
            ab += sp + Extparse.getMesg(LangRes.MAIN_COMN_TEXT_AB16);
        }

        // 去除分隔符
        if (ab.length() > 1)
        {
            ab = ab.substring(sp.length());
        }
        return ab;
    }

    /**
     * 使用平台数据解析，用于显示存储的平台数据信息
     */
    public static String decodePlatForm(int platForm)
    {
        // 平台通用
        if (SysCons.OS_IDX_ALL == platForm)
        {
            return Extparse.getMesg(LangRes.MAIN_COMN_TEXT_PFALL);
        }

        String pf = "";
        String sp = Extparse.getMesg(LangRes.TEXT_CTRLSPVV);

        // Windows平台
        if ((platForm & SysCons.OS_IDX_WINDOWS) != 0)
        {
            pf += sp + Extparse.getMesg(LangRes.MAIN_COMN_TEXT_PFWIN);
        }
        // Mac OS平台
        if ((platForm & SysCons.OS_IDX_MACINTOSH) != 0)
        {
            pf += sp + Extparse.getMesg(LangRes.MAIN_COMN_TEXT_PFMAC);
        }
        // Linux平台
        if ((platForm & SysCons.OS_IDX_LINUX) != 0)
        {
            pf += sp + Extparse.getMesg(LangRes.MAIN_COMN_TEXT_PFLNX);
        }
        // Unix平台
        if ((platForm & SysCons.OS_IDX_UNIX) != 0)
        {
            pf += sp + Extparse.getMesg(LangRes.MAIN_COMN_TEXT_PFUNX);
        }
        // 移动平台
        if ((platForm & SysCons.OS_IDX_MOBILE) != 0)
        {
            pf += sp + Extparse.getMesg(LangRes.MAIN_COMN_TEXT_PFMBL);
        }
        // 其它平台
        if ((platForm & SysCons.OS_IDX_UNKNOWN) != 0)
        {
            pf += sp + Extparse.getMesg(LangRes.MAIN_COMN_TEXT_PFSPC);
        }

        // 去除分隔符
        if (pf.length() > 1)
        {
            pf = pf.substring(sp.length());
        }
        return pf;
    }

    /**
     * 以纯种方式读取图像文件内容并在指定的图像标签上显示。
     * 
     * @param imgLbl
     * @param folder
     * @param iconName
     */
    public static void readEnvImage(final WIconLabel imgLbl, final String folder, final String iconName,
        final String postfix)
    {
        // 创建线程
        Thread thread = new Thread(new Runnable()
        {
            public void run()
            {
                String filePath = folder + EnvCons.COMN_SP_FILE + iconName + postfix + SysCons.EXTS_ICON;
                // 读取图标文件
                BufferedImage bi = null;
                try
                {
                    bi = ImageUtil.readPngImage(filePath);
                }
                catch(IOException exp)
                {
                    LogUtil.exception(exp);
                    String arg1 = Extparse.getMesg(LangRes.MESG_INIT_0010);
                    String errMsg = StringUtil.format(LangRes.IDIO_MESG_ICON_0001, filePath, arg1);
                    MesgUtil.showMessageDialog(Extparse.getForm(), errMsg);
                    bi = null;
                }

                // 设置图像显示
                imgLbl.setBackgroundImage(bi);
            }
        });

        // 线程启动
        thread.start();
    }

    /**
     * @return the baseData
     */
    public ExtsBaseData getBaseData()
    {
        if (me_BaseData == null)
        {
            me_BaseData = new ExtsBaseData();
            me_BaseData.wInit();
        }
        return me_BaseData;
    }

    /**
     * @param baseData the baseData to set
     */
    public void setBaseData(ExtsBaseData baseData)
    {
        this.me_BaseData = baseData;
    }

    /**
     * @return
     */
    public AsocPanel getAsocPanel()
    {
        if (ap_AsocPanel == null)
        {
            ap_AsocPanel = new AsocPanel(this);
            ap_AsocPanel.wInit();
        }
        return ap_AsocPanel;
    }

    /**
     * @return
     */
    public AsocPanel showAsocForm()
    {
        // 控制信息
        String mesg = Extparse.getMesg(LangRes.TITLE_ASOCFORM);
        K1SV2S kvItem = new K1SV2S(ConstUI.PROP_ASOCINFO, mesg, mesg);
        DForm df = getSoftForm();
        df.setTitle(kvItem.getV2());

        // 面板实例化
        if (ap_AsocPanel == null)
        {
            ap_AsocPanel = new AsocPanel(this);
            ap_AsocPanel.wInit();
        }
        // 初次显示时不可交互
        // if (df.addViewPanel(kvItem, ap_AsocPanel))
        // {
        // ap_AsocPanel.setEditable(false);
        // }
        df.pack();

        // 前端显示
        df.toFront();
        if (!df.isVisible())
        {
            df.center();
            df.setVisible(true);
        }

        return ap_AsocPanel;
    }

    /**
     * @return the CorpPanel
     */
    public CorpPanel getCorpPanel()
    {
        return cp_CorpPanel;
    }

    /**
     * @return
     */
    public CorpPanel hideCorpForm()
    {
        if (dg_ItemForm == null || !dg_ItemForm.isVisible())
        {
            return cp_CorpPanel;
        }

        if (cp_CorpPanel != null)
        {
            String mesg = Extparse.getMesg(LangRes.TITLE_CORPFORM);
            K1SV2S kvItem = new K1SV2S(ConstUI.PROP_CORPINFO, mesg, mesg);
            // dg_ItemForm.addViewPanel(kvItem, cp_CorpPanel);
        }
        return cp_CorpPanel;
    }

    /**
     * @return
     */
    public CorpPanel showCorpForm()
    {
        // 控制信息
        String mesg = Extparse.getMesg(LangRes.TITLE_CORPFORM);
        K1SV2S kvItem = new K1SV2S(ConstUI.PROP_CORPINFO, mesg, mesg);
        DForm df = getSoftForm();
        df.setTitle(kvItem.getV2());

        // 面板实例化
        if (cp_CorpPanel == null)
        {
            cp_CorpPanel = new CorpPanel(this);
            cp_CorpPanel.wInit();
        }
        // 初次显示时不可交互
        // if (df.addViewPanel(kvItem, cp_CorpPanel))
        // {
        // cp_CorpPanel.setEditable(false);
        // }
        df.pack();

        // 前端显示
        df.toFront();
        if (!df.isVisible())
        {
            df.center();
            df.setVisible(true);
        }

        return cp_CorpPanel;
    }

    /**
     * @return the dp_DespPanel
     */
    public DespPanel getDespPanel()
    {
        return dp_DespPanel;
    }

    /**
     * @return
     */
    public DespPanel showDespForm()
    {
        // 控制信息
        String mesg = Extparse.getMesg(LangRes.TITLE_DESPFORM);
        K1SV2S kvItem = new K1SV2S(ConstUI.PROP_DESPINFO, mesg, mesg);
        DForm df = getSoftForm();
        df.setTitle(kvItem.getV2());

        // 面板实例化
        if (dp_DespPanel == null)
        {
            dp_DespPanel = new DespPanel(this);
            dp_DespPanel.wInit();
        }
        // df.addViewPanel(kvItem, dp_DespPanel);
        df.pack();

        // 前端显示
        df.toFront();
        if (!df.isVisible())
        {
            df.center();
            df.setVisible(true);
        }

        return dp_DespPanel;
    }

    /**
     * @return the ExtsPanel
     */
    public ExtsPanel getExtsPanel()
    {
        return ep_ExtsPanel;
    }

    /**
     * @return
     */
    public ExtsPanel showExtsForm()
    {
        // 控制信息
        String mesg = Extparse.getMesg(LangRes.TITLE_EXTSFORM);
        K1SV2S kvItem = new K1SV2S(ConstUI.PROP_EXTSINFO, mesg, mesg);
        DForm df = getExtsForm();
        df.setTitle(kvItem.getV2());

        if (ep_ExtsPanel == null)
        {
            ep_ExtsPanel = new ExtsPanel(this);
            ep_ExtsPanel.wInit();
        }

        // if (df.addViewPanel(kvItem, ep_ExtsPanel))
        // {
        // ep_ExtsPanel.setEditable(false);
        // }
        df.pack();

        // 前端显示
        df.toFront();
        if (!df.isVisible())
        {
            df.center();
            df.setVisible(true);
        }

        return ep_ExtsPanel;
    }

    /**
     * @return the FilePanel
     */
    public FilePanel getFilePanel()
    {
        return fp_FilePanel;
    }

    /**
     * @return
     */
    public FilePanel showFileForm()
    {
        // 控制信息
        String mesg = Extparse.getMesg(LangRes.TITLE_FILEFORM);
        K1SV2S kvItem = new K1SV2S(ConstUI.PROP_FILEINFO, mesg, mesg);
        DForm df = getSoftForm();
        df.setTitle(kvItem.getV2());

        // 面板实例化
        if (fp_FilePanel == null)
        {
            fp_FilePanel = new FilePanel(this);
            fp_FilePanel.wInit();
        }
        // 初次显示时不可交互
        // if (df.addViewPanel(kvItem, fp_FilePanel))
        // {
        // fp_FilePanel.setEditable(false);
        // }
        df.pack();

        // 前端显示
        df.toFront();
        if (!df.isVisible())
        {
            df.center();
            df.setVisible(true);
        }

        return fp_FilePanel;
    }

    /**
     * @return the IdioPanel
     */
    public IdioPanel getIdioPanel()
    {
        return ip_IdioPanel;
    }

    /**
     * @return
     */
    public IdioPanel showIdioForm()
    {
        // 控制信息
        String mesg = Extparse.getMesg(LangRes.TITLE_IDIOFORM);
        K1SV2S kvItem = new K1SV2S(ConstUI.PROP_IDIOINFO, mesg, mesg);
        DForm df = getSoftForm();
        df.setTitle(kvItem.getV2());

        // 面板实例化
        if (ip_IdioPanel == null)
        {
            ip_IdioPanel = new IdioPanel(this);
            ip_IdioPanel.wInit();
        }
        // 初次显示时不可交互
        // if (df.addViewPanel(kvItem, ip_IdioPanel))
        // {
        // ip_IdioPanel.setEditable(false);
        // }
        df.pack();

        // 前端显示
        df.toFront();
        if (!df.isVisible())
        {
            df.center();
            df.setVisible(true);
        }

        return ip_IdioPanel;
    }

    /**
     * @return the mainPanel
     */
    public MainPanel getMainPanel()
    {
        return mp_MainPanel;
    }

    /**
     * @return
     */
    public MimePanel getMimePanel()
    {
        return mp_MimePanel;
    }

    /**
     * @return
     */
    public MimePanel showMimeForm()
    {
        // 控制信息
        String mesg = Extparse.getMesg(LangRes.TITLE_MIMEFORM);
        K1SV2S kvItem = new K1SV2S(ConstUI.PROP_MIMEINFO, mesg, mesg);
        DForm df = getSoftForm();
        df.setTitle(kvItem.getV2());

        // 面板实例化
        if (mp_MimePanel == null)
        {
            mp_MimePanel = new MimePanel(this);
            mp_MimePanel.wInit();
        }
        // 初次显示时不可交互
        // if (df.addViewPanel(kvItem, mp_MimePanel))
        // {
        // mp_MimePanel.setEditable(false);
        // }
        df.pack();

        // 前端显示
        df.toFront();
        if (!df.isVisible())
        {
            df.center();
            df.setVisible(true);
        }

        return mp_MimePanel;
    }

    /**
     * @return the SoftPanel
     */
    public SoftPanel getSoftPanel()
    {
        return sp_SoftPanel;
    }

    /**
     * @return
     */
    public SoftPanel hideSoftForm()
    {
        if (dg_ItemForm == null || !dg_ItemForm.isVisible())
        {
            return sp_SoftPanel;
        }

        if (cp_CorpPanel != null)
        {
            String mesg = Extparse.getMesg(LangRes.TITLE_SOFTFORM);
            K1SV2S kvItem = new K1SV2S(ConstUI.PROP_SOFTINFO, mesg, mesg);
            // dg_ItemForm.addViewPanel(kvItem, sp_SoftPanel);
        }
        return sp_SoftPanel;
    }

    /**
     * @return
     */
    public SoftPanel showSoftForm()
    {
        // 控制信息
        String mesg = Extparse.getMesg(LangRes.TITLE_SOFTFORM);
        K1SV2S kvItem = new K1SV2S(ConstUI.PROP_SOFTINFO, mesg, mesg);
        DForm df = getSoftForm();
        df.setTitle(kvItem.getV2());

        // 面板实例化
        if (sp_SoftPanel == null)
        {
            sp_SoftPanel = new SoftPanel(this);
            sp_SoftPanel.wInit();
        }
        // 初次显示时不可交互
        // if (df.addViewPanel(kvItem, sp_SoftPanel))
        // {
        // sp_SoftPanel.setEditable(false);
        // }
        df.pack();

        // 前端显示
        df.toFront();
        if (!df.isVisible())
        {
            df.center();
            df.setVisible(true);
        }

        return sp_SoftPanel;
    }

    /**
     * @return
     */
    public StepPanel showStepForm()
    {
        // 控制信息
        String mesg = Extparse.getMesg(LangRes.TITLE_EXTSFORM);
        K1SV2S kvItem = new K1SV2S(ConstUI.PROP_EXTSINFO, mesg, mesg);
        DForm df = getExtsForm();
        df.setTitle(kvItem.getV2());

        if (sp_StepPanel == null)
        {
            sp_StepPanel = new StepPanel(this);
            sp_StepPanel.wInit();
        }
        sp_StepPanel.startWizard();

        // df.addViewPanel(kvItem, sp_StepPanel);
        df.pack();

        // 前端显示
        df.toFront();
        if (!df.isVisible())
        {
            df.center();
            df.setVisible(true);
        }

        return sp_StepPanel;
    }

    /**
     * @return
     */
    public MainMenu getMainMenu()
    {
        return mm_MainMenu;
    }

    /**
     * @return
     */
    public MainMenu showMainMenu(Component invoker)
    {
        if (mm_MainMenu == null)
        {
            mm_MainMenu = new MainMenu(this);
            mm_MainMenu.wInit();
            mm_MainMenu.getPopupMenu().show(invoker, 0, 0);
        }

        int h = mm_MainMenu.getPopupMenu().getHeight();
        mm_MainMenu.getPopupMenu().show(invoker, 0, 0 - h);
        return mm_MainMenu;
    }

    /**
     * 获取关于信息语言资源路径
     * 
     * @return
     */
    private static String getInfoPath()
    {
        StringBuffer sb = new StringBuffer(baseFolder).append(EnvCons.FOLDER0_LANG);
        sb.append(EnvCons.PATH_P3010000).append(EnvCons.COMN_SP_FILE);
        sb.append(EnvCons.COMN_SOFT_INFO).append(RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_LANG_ID));
        sb.append(SysCons.EXTS_INFO);
        return sb.toString();
    }

    /**
     * 
     */
    private javax.swing.JPanel showMain()
    {
        if (mp_MainPanel == null)
        {
            mp_MainPanel = new MainPanel(this);
            mp_MainPanel.wInit();
        }
        me_BaseData = null;

        // softForm.setViewPanel(mp_MainPanel);
        // softForm.center();
        // softForm.setTitle(wGetTitle());
        // softForm.setVisible(true);
        return null;
    }

    /**
     * 
     */
    private javax.swing.JPanel showMini()
    {
        if (mp_MiniPanel == null)
        {
            mp_MiniPanel = new MiniPanel(this);
            mp_MiniPanel.wInit();
        }
        me_BaseData = null;

        // softForm.setViewPanel(mp_MiniPanel);
        // softForm.center();
        // softForm.setTitle(wGetTitle());
        // softForm.setVisible(true);
        return null;
    }

    /**
     * 
     */
    private javax.swing.JPanel showNorm()
    {
        return null;
    }

    /**
     * @return
     */
    private javax.swing.JPanel showStep()
    {
        return null;
    }

    /**
     * @return
     */
    private javax.swing.JPanel showTail()
    {
        return null;
    }

    /**
     * 实例化对话框窗口
     * 
     * @param title 窗口标题
     * @param width 窗口宽度
     * @param height 窗口高度
     * @return 对话框窗口对象
     */
    public DForm getSoftForm()
    {
        if (dg_ItemForm == null)
        {
            // dg_ItemForm = new DForm(Extparse.getForm());
            dg_ItemForm.setDefaultCloseOperation(DForm.HIDE_ON_CLOSE);
            dg_ItemForm.setResizable(false);
        }

        return dg_ItemForm;
    }

    /**
     * @param title
     * @return
     */
    public DForm getExtsForm()
    {
        if (dg_ExtsForm == null)
        {
            // dg_ExtsForm = new DForm(Extparse.getForm());
            dg_ExtsForm.setDefaultCloseOperation(DForm.HIDE_ON_CLOSE);
            dg_ExtsForm.setResizable(false);
        }

        return dg_ExtsForm;
    }

    /**
     * @param title
     * @return
     */
    public DForm getStepForm()
    {
        if (dg_ExtsForm == null)
        {
            // dg_ExtsForm = new DForm(Extparse.getForm());
            dg_ExtsForm.setDefaultCloseOperation(DForm.HIDE_ON_CLOSE);
            dg_ExtsForm.setResizable(false);
        }

        return dg_ExtsForm;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 系统全局变量区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 数据面板区域
    // ----------------------------------------------------
    /** 备选软件面板 */
    private AsocPanel ap_AsocPanel;
    /** 公司信息面板 */
    private CorpPanel cp_CorpPanel;
    /** 描述信息面板 */
    private DespPanel dp_DespPanel;
    /** 后缀管理面板 */
    private ExtsPanel ep_ExtsPanel;
    /** 文件信息面板 */
    private FilePanel fp_FilePanel;
    /** 个人信息面板 */
    private IdioPanel ip_IdioPanel;
    /** 用户交互面板 */
    private MainPanel mp_MainPanel;
    /** MIME类型面板 */
    private MimePanel mp_MimePanel;
    /** 迷你交互面板 */
    private MiniPanel mp_MiniPanel;
    /** 软件信息面板 */
    private SoftPanel sp_SoftPanel;
    /** 向导后缀管理面板 */
    private StepPanel sp_StepPanel;

    // ----------------------------------------------------
    // 子窗口对象区域
    // ----------------------------------------------------
    /** 分页信息窗口 */
    private DForm     dg_ItemForm;

    /** 后缀管理窗口 */
    private DForm     dg_ExtsForm;

    /** 系统菜单 */
    private MainMenu  mm_MainMenu;

    public void init()
    {
        // 运算目录标记
        baseFolder = EnvCons.COMN_PATH_JNLP;

        UserInfo ui = new UserInfo("Amon", "amon");
        ui.wInit();
        RmpsUtil.setUserInfo(ui);

        // 1、 运行环境检测
        appMode = MODE_APPLET;

        // 2、 用户配置加载
        if (!ui.loadCfg(baseFolder, appMode))
        {
            System.exit(0);
            return;
        }

        // 3、 应用界面风格
        if (!Rmps.initLnF("", ""))
        {
            System.exit(0);
            return;
        }

        // 承载窗口引用
        softAForm = this;
        // 4、显示主窗口 启动应用程序
        wShowView(VIEW_NORM);
    }

    /**
     * @param args
     */
    public static void main(String[] args)
    {
        // 运算目录标记
        baseFolder = EnvCons.COMN_PATH_HOME;

        UserInfo ui = new UserInfo("Amon", "amon");
        ui.wInit();
        RmpsUtil.setUserInfo(ui);

        // 1、 启动系统日志
        appMode = LogUtil.init() ? MODE_APPLICATION : MODE_WEB_START;

        // 2、 运行环境检测
        if (!Rmps.checkJre())
        {
            System.exit(0);
            return;
        }

        // 3、 用户配置加载
        if (!ui.loadCfg(baseFolder, appMode))
        {
            System.exit(0);
            return;
        }

        // 4、 应用界面风格
        if (!Rmps.initLnF(ui.getCfg(CfgCons.CFG_LNF_TYPE), ui.getCfg(CfgCons.CFG_LNF_NAME)))
        {
            System.exit(0);
            return;
        }

        // 5、引用应用对象
        Extparse soft = new Extparse();
        soft.wInit();

        // 承载窗口引用
        softFForm.setDefaultCloseOperation(FForm.EXIT_ON_CLOSE);
        // 6、显示主窗口 启动应用程序
        soft.wShowView(VIEW_NORM);
    }
}
