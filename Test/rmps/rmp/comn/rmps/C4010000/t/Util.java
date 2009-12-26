/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.rmps.C4010000.t;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.util.Properties;

import rmp.Rmps;
import rmp.util.CheckUtil;

import com.amonsoft.util.LogUtil;

import cons.CfgCons;
import cons.EnvCons;

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
public final class Util
{
    /** 公益广告语言资源文件路径 */
    private static File adFilePath;
    /** 公益广告内容 */
    private static Properties adInfoProp;
    /**  */
    private static Object[] adInfoKeys;

    /**
     * 下一条公益广告内容
     * 
     * @return
     */
    public static String nextAd()
    {
        if (adInfoProp == null)
        {
            loadAdInfo();
        }

        int i = (int) (Math.random() * adInfoKeys.length);
        String t = adInfoProp.getProperty(adInfoKeys[i].toString());
        if (!CheckUtil.isValidate(t))
        {
            t = "为了您和他人，请支持公益广告！";
        }
        return t;
    }

    public static String nextAd(String adId)
    {
        if (adInfoProp == null)
        {
            loadAdInfo();
        }
        return adInfoProp.getProperty(adId);
    }

    /**
     * @return the adFilePath
     */
    public static File getAdFilePath()
    {
        return adFilePath;
    }

    /**
     * @param adFilePath
     *            the adFilePath to set
     */
    public static void setAdFilePath(File adFilePath)
    {
        Util.adFilePath = adFilePath;
        loadAdInfo();
    }

    /**
     * 加载公益广告语言资源
     */
    public static void loadAdInfo()
    {
        adInfoProp = new Properties();

        // 公益广告资源文件可访问性判断
        if (adFilePath == null || !adFilePath.exists() || !adFilePath.canRead())
        {
            // 使用默认资源文件
            StringBuffer defAdFilePath = new StringBuffer(EnvCons.FOLDER0_LANG);
            defAdFilePath.append("").append(EnvCons.COMN_SP_FILE);
            defAdFilePath.append("pbad_").append(Rmps.getUser().getCfg(CfgCons.CFG_LANG_ID)).append(".wad");
            adFilePath = new File(defAdFilePath.toString());

            // 默认资源文件也不存在的情况下，直接返回
            if (!adFilePath.exists() || !adFilePath.canRead())
            {
                adInfoProp.put("Ad000000", "为了您和他人，请支持公益广告！");
                adInfoKeys = adInfoProp.keySet().toArray();
                return;
            }
        }

        // 读取语言资源
        try
        {
            LogUtil.log("公益广告文档路径：" + adFilePath.getPath());
            FileInputStream is = new FileInputStream(adFilePath);
            adInfoProp.load(is);
            is.close();
        }
        catch (IOException exp)
        {
            LogUtil.exception(exp);
            adInfoProp.put("Ad000000", "为了您和他人，请支持公益广告！");
        }
        adInfoKeys = adInfoProp.keySet().toArray();
    }
}
