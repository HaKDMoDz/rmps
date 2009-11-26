/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.lang.A3010000.t;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.IOException;
import java.io.StringReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;

import rmp.util.FileUtil;
import rmp.util.LogUtil;
import rmp.util.StringUtil;
import cons.SysCons;
import cons.amon.lang.A3010000.ConstUI;

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
public final class Util
{
    /**
     * @param filePath
     * @return
     */
    public static List<String> readTemplate(String filePath)
    {
        List<String> tpltList = new ArrayList<String>(33);
        tpltList.add("F0000000");
        for (int t = 1; t < 17; t += 1)
        {
            tpltList.add("未知模块语言资源");
        }
        for (int t = 17; t < 33; t += 1)
        {
            tpltList.add("未知片段语言资源");
        }

        File tpltFile = new File(filePath);
        if (!tpltFile.exists() || !tpltFile.canRead())
        {
            return tpltList;
        }

        try
        {
            BufferedReader br = FileUtil.getReader(filePath, "UTF-8");
            String str = br.readLine();
            if (str == null)
            {
                return tpltList;
            }
            str = str.trim();
            if (str.startsWith("sid="))
            {
                tpltList.set(0, str.substring(4));
            }

            char t1;
            char t2;
            str = br.readLine();
            while (str != null)
            {
                str = str.trim();
                if (str.length() > 3)
                {
                    t1 = str.charAt(0);
                    if (t1 == 'm' || t1 == 'M')
                    {
                        t2 = str.charAt(1);
                        if (t2 >= '0' && t2 <= '9')
                        {
                            tpltList.set(t2 - 47, str.substring(3));
                        }
                        else if (t2 >= 'A' && t2 <= 'F')
                        {
                            tpltList.set(t2 - 54, str.substring(3));
                        }
                    }
                    else if (t1 == 'f' || t1 == 'F')
                    {
                        t2 = str.charAt(1);
                        if (t2 >= '0' && t2 <= '9')
                        {
                            tpltList.set(t2 - 31, str.substring(3));
                        }
                        else if (t2 >= 'A' && t2 <= 'F')
                        {
                            tpltList.set(t2 - 38, str.substring(3));
                        }
                    }
                }

                str = br.readLine();
            }

            br.close();
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }

        return tpltList;
    }

    /**
     * @param uniStr
     * @return
     * @throws IOException
     */
    public static String unicode2UnicodeEscWithoutComment(String uniStr) throws IOException
    {
        StringBuilder buf = new StringBuilder();
        BufferedReader reader = new BufferedReader(new StringReader(uniStr));
        boolean continueFlg = false;
        for (String line = null; (line = reader.readLine()) != null;)
        {
            if ((line.trim().startsWith("#") || line.trim().startsWith("!")) && !continueFlg)
            {
                buf.append(line);
            }
            else
            {
                if (line.endsWith("\\"))
                {
                    continueFlg = true;
                }
                else
                {
                    continueFlg = false;
                }
                buf.append(StringUtil.unicode2UnicodeEsc(line));
            }
            buf.append("\n");
        }

        if (!uniStr.endsWith("\n"))
        {
            buf.deleteCharAt(buf.length() - 1);
        }
        return buf.toString();
    }

    /**
     * @param langProp
     */
    public static void saveLangProp(List<String> tpltList, HashMap<String, String> langProp, String propFilePath,
            String javaFilePath)
    {
        String[] keys = new String[langProp.size()];
        langProp.keySet().toArray(keys);
        Arrays.sort(keys);

        try
        {
            // Java语言文件
            BufferedWriter bwj = FileUtil.getWriter(javaFilePath, "UTF-8");
            bwj.write("public interface LangRes");
            bwj.newLine();
            bwj.write("{");
            bwj.newLine();

            // 语言资源文件
            BufferedWriter bwp = FileUtil.getWriter(propFilePath);
            String mid = "";
            String fid = "";
            String tmp;
            for (String key : keys)
            {
                // 模块标题
                tmp = key.substring(4, 5);
                if (!tmp.equals(mid))
                {
                    mid = tmp;

                    // Java语言文件
                    bwj.write(ConstUI.LANGRES_M_SIGN);
                    bwj.newLine();
                    tmp = StringUtil.format(ConstUI.LANGRES_M_DESP, mid, tpltList.get(1 + Integer.parseInt(mid, 16)));
                    bwj.write(tmp);
                    bwj.newLine();
                    bwj.write(ConstUI.LANGRES_M_SIGN);
                    bwj.newLine();

                    // 语言资源文件
                    bwp.write(ConstUI.COMMENT_M_SIGN);
                    bwp.newLine();
                    tmp = StringUtil.format(ConstUI.COMMENT_M_DESP, mid, tpltList.get(1 + Integer.parseInt(mid, 16)));
                    bwp.write(StringUtil.unicode2UnicodeEsc(tmp));
                    bwp.newLine();
                    bwp.write(ConstUI.COMMENT_M_SIGN);
                    bwp.newLine();
                }
                // 片段标题
                tmp = key.substring(5, 6);
                if (!tmp.equals(fid))
                {
                    fid = tmp;

                    // Java语言文件
                    bwj.write(ConstUI.LANGRES_F_SIGN);
                    bwj.newLine();
                    tmp = StringUtil.format(ConstUI.LANGRES_F_DESP, fid, tpltList.get(17 + Integer.parseInt(fid, 16)));
                    bwj.write(tmp);
                    bwj.newLine();
                    bwj.write(ConstUI.LANGRES_F_SIGN);
                    bwj.newLine();

                    // 语言资源文件
                    bwp.write(ConstUI.COMMENT_F_SIGN);
                    bwp.newLine();
                    tmp = StringUtil.format(ConstUI.COMMENT_F_DESP, fid, tpltList.get(17 + Integer.parseInt(fid, 16)));
                    bwp.write(StringUtil.unicode2UnicodeEsc(tmp));
                    bwp.newLine();
                    bwp.write(ConstUI.COMMENT_F_SIGN);
                    bwp.newLine();
                }

                // Java语言文件
                bwj.write(StringUtil.format(ConstUI.LANGRES_L_SIGN, key));
                bwj.write(langProp.get(key));
                bwj.newLine();

                // 语言资源文件
                bwp.write(key);
                bwp.write(ConstUI.COMMENT_L_SIGN);
                bwp.write(StringUtil.unicode2UnicodeEsc(langProp.get(key)));
                bwp.newLine();
            }

            bwp.flush();
            bwp.close();

            bwj.write("}");
            bwj.newLine();
            bwj.flush();
            bwj.close();
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    /**
     * 保存语言资源到文件
     * 
     * @param langProp
     * @param filePath
     */
    public static void readLangProp(HashMap<String, String> langProp, String filePath)
    {
        try
        {
            BufferedReader bw = FileUtil.getReader(filePath, SysCons.FILE_ENCODING);
            String line = bw.readLine();
            char chr;
            int idot;
            String key = "";
            while (line != null)
            {
                if (line.length() > 0)
                {
                    chr = line.charAt(0);
                    if (chr != '#' && chr != '!')
                    {
                        line = StringUtil.unicodeEsc2Unicode(line);
                        idot = line.indexOf(ConstUI.COMMENT_L_SIGN);
                        if (idot >= 0)
                        {
                            key = line.substring(0, idot);
                        }
                        langProp.put(key, line.substring(idot + 1));
                    }
                }
                line = bw.readLine();
            }
            bw.close();
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    /**
     * @param sid 软件ID前四位，例如C0FF
     * @param mid 模块ID，仅1位数字
     * @param fid 片段ID，仅1位数字
     */
    public static String getLangID(String sid, int mid, int fid, int idx)
    {
        return (sid + mid + fid + idx).toUpperCase();
    }
}
