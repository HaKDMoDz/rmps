/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package com.amonsoft.util;

import rmp.util.*;
import cons.EnvCons;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.HashMap;
import java.util.Properties;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author yihaodian
 */
public final class LangUtil
{
    /**当前使用的语言资源*/
    private Properties currLang;
    /**系统存在的语言资源*/
    private static HashMap<String, LangUtil> langList = new HashMap<String, LangUtil>();

    /**
     * 私有构造函数
     * @param prop
     */
    private LangUtil(Properties prop)
    {
        currLang = prop;
    }

    /**
     * 获取一个语言资源实例
     * @param code
     * @return
     */
    public static LangUtil initLang(String code)
    {
        LangUtil langUtill = langList.get(code);
        if (langUtill == null)
        {
            // 读取语言资源
            Properties langRes = new Properties();
            InputStream inStream = null;
            try
            {
                inStream = new FileInputStream(new File(EnvCons.FOLDER0_LANG, StringUtil.format(code, EnvCons.COMN_SOFT_LANG)));
                langRes.load(inStream);
            }
            catch (IOException ex)
            {
                LogUtil.exception(ex);
            }
            finally
            {
                if (inStream != null)
                {
                    try
                    {
                        inStream.close();
                    }
                    catch (IOException ex)
                    {
                        LogUtil.exception(ex);
                    }
                }
            }
            langUtill = new LangUtil(langRes);
        }

        return langUtill;
    }

    /**
     * 语言资源查询
     *
     * @param mesgId 语言资源索引
     * @return 语言资源内容
     */
    public String getMesg(String msgRes, String msgDef)
    {
        return (currLang != null) ? currLang.getProperty(msgRes, msgDef) : msgRes;
    }

    /**
     * 设置给定按钮的语言信息
     * @param c
     * @param wText
     * @param isHash
     */
    public void setWText(javax.swing.AbstractButton c, String msgRes, String msgDef)
    {
        if (c == null)
        {
            return;
        }
        msgRes = getMesg(msgRes, msgDef);

        // 快捷字符替换
        if (CheckUtil.isValidate(msgRes))
        {
            int si = msgRes.indexOf('&');
            if (si >= 0)
            {
                msgRes = msgRes.replace("&", "");
                if (msgRes.length() > si)
                {
                    c.setMnemonic(msgRes.charAt(si));
                }
            }
        }

        c.setText(msgRes);
    }

    /**
     * @param c
     * @param wText
     * @param isHash
     */
    public void setWText(javax.swing.text.JTextComponent c, String msgRes, String msgDef)
    {
        if (msgRes == null)
        {
            return;
        }

        c.setText(msgRes);
    }

    /**
     * @param c
     * @param wText
     * @param isHash
     */
    public void setWText(javax.swing.JLabel c, String msgRes, String msgDef)
    {
        if (msgRes == null)
        {
            return;
        }

        // 快捷字符替换
        if (CheckUtil.isValidate(msgRes))
        {
            int si = msgRes.indexOf('&');
            if (si >= 0)
            {
                msgRes = msgRes.replace("&", "");
                if (msgRes.length() > si)
                {
                    c.setDisplayedMnemonic(msgRes.charAt(si));
                }
            }
        }

        c.setText(msgRes);
    }

    /**
     * @param c
     * @param wTips
     * @param isHash
     */
    public void setWTips(javax.swing.JComponent c, String msgRes, String msgDef)
    {
        if (msgRes == null)
        {
            return;
        }

        c.setToolTipText(msgRes);
    }
}
