/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3090000.v;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.FontMetrics;
import java.awt.GradientPaint;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.event.ActionEvent;
import java.awt.image.BufferedImage;
import java.util.EventObject;

import rmp.Rmps;
import rmp.face.WBackCall;
import rmp.prp.aide.P3090000.P3090000;
import rmp.prp.aide.P3090000.t.Util;
import rmp.util.ImageUtil;
import rmp.util.LogUtil;

import com.amonsoft.util.CharUtil;

import cons.EnvCons;
import cons.prp.aide.P3090000.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 天气预报
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class TailPanel extends javax.swing.JPanel implements WBackCall
{
    // ////////////////////////////////////////////////////////////////////////
    // 逻辑控制区域
    // ////////////////////////////////////////////////////////////////////////
    /** 主应用程序 */
    private P3090000 ms_MainSoft;
    /** 内嵌面板 */
    private javax.swing.JPanel tp_TailPanel;
    /** 天气数据信息 */
    private java.util.HashMap<Integer, String> hm_DataList;
    /** 白天背景 */
    private BufferedImage bi_WeatherL;
    /** 分晓背景 */
    // private BufferedImage bi_WeatherD;
    /** 夜间背景 */
    // private BufferedImage bi_WeatherN;
    /** 高亮背景 */
    private BufferedImage bi_WeatherH;
    /** 天气趋势开始图片名称 */
    private BufferedImage bi_WeatherS;
    /** 天气趋势结束图片名称 */
    private BufferedImage bi_WeatherE;
    /** 定时器 */
    private javax.swing.Timer tm_Timer;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param soft
     * @param tailPanel
     */
    public TailPanel(P3090000 soft, javax.swing.JPanel tailPanel)
    {
        // this.ms_MainSoft = soft;
        this.tp_TailPanel = tailPanel;
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        LogUtil.log("天气预报初始化，开始...");

        // 读取天气信息
        Thread t = new Thread()
        {
            public void run()
            {
                readWeatherInfo();
            }
        };
        t.start();

        LogUtil.log("天气预报初始化，读取背景图片...");
        // 读取背景图片
        bi_WeatherL = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + ConstUI.BG_DAYLIGHT);
        bi_WeatherH = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + ConstUI.BG_HIGHLIGHT);

        // 界面初始化
        ica();

        // 语言初始化
        ita();

        // 每半小时读取一次天气信息
        tm_Timer = new javax.swing.Timer(1800000, new java.awt.event.ActionListener()
        {
            public void actionPerformed(ActionEvent e)
            {
                readWeatherInfo();
            }
        });
        tm_Timer.start();

        LogUtil.log("天气预报初始化，结束！！！");

        // 回馈注册
        Util.register("tailPanel", this);

        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 接口实现区域
    // ////////////////////////////////////////////////////////////////////////
    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WBackCall#wAction(java.util.EventObject, java.lang.Object)
     */
    @Override
    public void wAction(EventObject event, Object object, String property)
    {
        readWeatherInfo();
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JComponent#paintComponent(java.awt.Graphics)
     */
    protected void paintComponent(Graphics g)
    {
        super.paintComponent(g);

        Graphics2D g2d = (Graphics2D) g;

        // 绘制背景
        BufferedImage bi = bi_WeatherL;
        g2d.drawImage(bi, 0, 0, 130, 67, this);

        FontMetrics fm = g2d.getFontMetrics();
        int fntH = fm.getHeight();
        int sttX;
        int sttY;
        String strT = "天气信息读取中...";

        // 天气读取过程中
        if (hm_DataList == null || hm_DataList.size() < 1)
        {
            sttX = (ConstUI.VIEW_WIDH - fm.stringWidth(strT)) >> 1;
            sttY = (ConstUI.VIEW_HIGH + fm.getHeight()) >> 1;

            g2d.setPaint(new GradientPaint(0, 0, Color.RED, ConstUI.VIEW_WIDH, 0, Color.LIGHT_GRAY));
            g2d.drawString(strT, sttX, sttY);
            return;
        }

        // 调整绘制区域坐标
        int tmpH = fntH << 1;
        tmpH += fntH > 20 ? fntH : 20;
        sttX = 10;
        sttY = (ConstUI.VIEW_HIGH - tmpH) >> 1;
        int tmpX = sttX;
        int tmpY = sttY;

        // ////////////////////////////////////////////////////////////////////
        // 当日天气
        // ////////////////////////////////////////////////////////////////////
        // 日期
        strT = hm_DataList.get(Util.getTheDate() + 1);
        int i = strT.indexOf(' ');
        strT = strT.substring(0, i);
        g2d.drawString(strT, tmpX, tmpY + fntH);
        tmpX += fm.stringWidth(strT) + 8;

        // 开始天气
        g2d.drawImage(bi_WeatherS, tmpX, tmpY, this);
        tmpX += bi_WeatherS.getWidth() + 5;

        // 结束天气
        g2d.drawImage(bi_WeatherE, tmpX, tmpY, this);

        // 天气
        tmpX = sttX;
        tmpY += fntH;
        strT = hm_DataList.get(Util.getTheDate() + 1);
        i = strT.indexOf(' ');
        strT = strT.substring(i + 1);
        g2d.drawString(strT, tmpX, tmpY + fntH);
        tmpX += fm.stringWidth(strT) + 8;

        // 气温
        g2d.drawString(hm_DataList.get(Util.getTheDate() + 0), tmpX, tmpY + fntH);

        // 风力
        tmpX = sttX;
        tmpY += fntH;
        g2d.drawString(hm_DataList.get(Util.getTheDate() + 2), tmpX, tmpY + fntH);

        // 高亮
        g2d.drawImage(bi_WeatherH, 4, 4, 123, 60, this);
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面显示区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 界面布局初始化
     */
    private void ica()
    {
        this.addMouseListener(new java.awt.event.MouseListener()
        {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
            }

            @Override
            public void mouseEntered(java.awt.event.MouseEvent evt)
            {
                showTips();
            }

            @Override
            public void mouseExited(java.awt.event.MouseEvent evt)
            {
            }

            @Override
            public void mousePressed(java.awt.event.MouseEvent evt)
            {
            }

            @Override
            public void mouseReleased(java.awt.event.MouseEvent evt)
            {
            }
        });
        tp_TailPanel.add(this);
        setPreferredSize(new Dimension(ConstUI.VIEW_WIDH, ConstUI.VIEW_HIGH));
    }

    /**
     * 界面语言初始化
     */
    private void ita()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 读取天气信息
     */
    private void readWeatherInfo()
    {
        try
        {
            // 读取天气信息数据
            hm_DataList = Util.getWeatherByCity(Rmps.getUser().getCfg(ConstUI.CFG_CITY, ""));

            // 读取天气状况图标
            bi_WeatherS = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + CharUtil.format(ConstUI.BG_ICON, hm_DataList.get(Util.getTheDate() + 3)));
            bi_WeatherE = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + CharUtil.format(ConstUI.BG_ICON, hm_DataList.get(Util.getTheDate() + 4)));
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }

        // 强制重新绘制
        repaint();
    }

    /**
     * 显示提示
     */
    private void showTips()
    {
        if (hm_DataList == null)
        {
            return;
        }

        // 提示信息拼接
        StringBuffer sb = new StringBuffer();
        sb.append("<html>");
        sb.append("<div align=\"center\"><Strong>").append(hm_DataList.get(1)).append("</Strong></div>");
        sb.append("<hr height=\"1\" />");
        sb.append(hm_DataList.get(10).replace("；", "；<br />"));
        sb.append("</html>");

        // 信息显示
        setToolTipText(sb.toString());
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面组件区域
    // ////////////////////////////////////////////////////////////////////////
}
