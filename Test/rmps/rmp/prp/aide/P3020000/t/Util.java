/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3020000.t;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

import rmp.prp.aide.P3020000.b.FileBean;
import rmp.prp.aide.P3020000.b.VarBean;

import com.amonsoft.util.CharUtil;

import cons.prp.aide.P3020000.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 最终工具类
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public final class Util
{
    /** 用户重命名规则 */
    private static StringBuilder uRule;
    /** 用户变量及取值空间列表 */
    private static List<VarBean> param;

    // ////////////////////////////////////////////////////////////////////////
    // 对外接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 文件重命名<br />
     * 此处不能使用trim()方法，用户输入空格也做为命名字符
     * 
     * @param srcFilePath
     *            重命名原文件夹路径
     * @param dstFilePath
     *            重命名目标文件夹路径
     * @param ruleText
     *            命名规则
     * @param nameList
     *            文件名称列表
     * @param doRename
     *            是否进行文件命名：true文件命名，false仅预览结果
     * @throws Exception
     * @return
     */
    public static boolean reNameFile(String srcFilePath, String dstFilePath, String ruleText, List<FileBean> nameList, boolean doRename) throws Exception
    {
        // 重命名公式检测与校正
        reviseRule(ruleText);

        // 重命名公式解析
        if (specialRule(ruleText, nameList))
        {
            // 分析用户表达式
            parseRule(ruleText.toCharArray());

            // 冲突检测
            int cap = 1;
            for (VarBean bean : param)
            {
                cap *= bean.capacity();
            }
            if (cap < nameList.size())
            {
                throw new Exception("表达式错误：您的表达式取值空间小于文件数量，会产生命名冲突！");
            }

            // 生成预览结果
            buildName(nameList);
        }

        // 确认文件重命名
        if (doRename)
        {
            doRename(srcFilePath, dstFilePath, nameList);
        }

        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 参数检测区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @return
     */
    public static boolean reviseRule(String ruleText) throws Exception
    {
        // 表达式合法性检测
        if (!CharUtil.isValidate(ruleText))
        {
            throw new Exception("命名表达式不能为空！");
        }

        ruleText = ruleText.replace("**", "*");

        uRule = new StringBuilder(ruleText);

        return true;
    }

    /**
     * 特殊表达式处理
     * 
     * @param ruleText
     * @throws Exception
     * @return true:需要进行一般处理，false不需要进行一般处理
     */
    private static boolean specialRule(String ruleText, List<FileBean> nameList) throws Exception
    {
        // 文件名称大写控制
        StringBuilder sb = new StringBuilder();
        // 文件名称全部大写
        if (sb.append(ConstUI.EXPS_CTR_UPP).append(ConstUI.EXPS_MAT_ALL).toString().equals(ruleText))
        {
            for (FileBean bean : nameList)
            {
                bean.toUpper(0);
            }
            return false;
        }
        // 文件名称之名称部分大写
        sb.delete(0, sb.length());
        sb.append(ConstUI.EXPS_CTR_UPP).append(ConstUI.EXPS_CTR_FND).append(ConstUI.EXPS_VAR_UPP);
        if (sb.toString().equals(ruleText))
        {
            for (FileBean bean : nameList)
            {
                bean.toUpper(1);
            }
            return false;
        }
        // 文件名称之扩展部分大写
        sb.delete(0, sb.length());
        sb.append(ConstUI.EXPS_CTR_UPP).append(ConstUI.EXPS_CTR_FND).append(ConstUI.EXPS_VAR_LOW);
        if (sb.toString().equals(ruleText))
        {
            for (FileBean bean : nameList)
            {
                bean.toUpper(2);
            }
            return false;
        }
        // 文件名称全部小写
        sb.delete(0, sb.length());
        sb.append(ConstUI.EXPS_CTR_LOW).append(ConstUI.EXPS_MAT_ALL);
        if (sb.toString().equals(ruleText))
        {
            for (FileBean bean : nameList)
            {
                bean.toLower(0);
            }
            return false;
        }
        // 文件名称之名称部分小写
        sb.delete(0, sb.length());
        sb.append(ConstUI.EXPS_CTR_LOW).append(ConstUI.EXPS_CTR_FND).append(ConstUI.EXPS_VAR_UPP);
        if (sb.toString().equals(ruleText))
        {
            for (FileBean bean : nameList)
            {
                bean.toLower(1);
            }
            return false;
        }
        // 文件名称之扩展部分小写
        sb.delete(0, sb.length());
        sb.append(ConstUI.EXPS_CTR_LOW).append(ConstUI.EXPS_CTR_FND).append(ConstUI.EXPS_VAR_LOW);
        if (sb.toString().equals(ruleText))
        {
            for (FileBean bean : nameList)
            {
                bean.toLower(2);
            }
            return false;
        }
        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 函数解析区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 解析用户重命名公式及变量取值空间信息
     * 
     * @param ruleText
     */
    public static void parseRule(char[] charText) throws Exception
    {
        uRule = new StringBuilder();
        // 用户参数列表
        param = new ArrayList<VarBean>();
        // 用户变量对象
        VarBean pBean = null;
        // 变量取值空间
        StringBuilder pRegn = new StringBuilder();

        boolean isPs = false;// 上一个字符是否为变量标记
        char ch1;// 临时字符变量
        int pIdx = 0;// 用户变量索引标记
        int loop = 0;// 循环标记
        int size = charText.length;// 用户公式总长度
        while (loop < size)
        {
            ch1 = charText[loop++];

            // 用户变量取值区间
            if (ch1 == '"')
            {
                // 非法限制区间
                if (!isPs)
                {
                    throw new Exception("表达式输入错误：取值区间限制应仅跟在变量标记之后！");
                }

                boolean mathed = false;
                // 合法取值区间解析
                while (loop < size)
                {
                    ch1 = charText[loop++];
                    if (ch1 == '"')
                    {
                        mathed = true;
                        break;
                    }
                    pRegn.append(ch1);
                }
                // 引号是否成对出现
                if (!mathed)
                {
                    throw new Exception("表达式输入错误：变量取值区间引号应成对出现！");
                }
                // 变量取值区域是否为空
                if (pRegn.length() < 1)
                {
                    throw new Exception("表达式输入错误：变量取值区间不能为空！");
                }
                pBean.setRegn(pRegn.toString());
                pRegn.delete(0, pRegn.length());

                isPs = false;
                continue;
            }

            // 是否为变量标记
            if (ch1 != '\\' && ch1 != '/' && ch1 != ':')
            {
                uRule.append(ch1);
                continue;
            }

            // 用户变量
            uRule.append('<').append(pIdx++).append('>');
            pBean = new VarBean(ch1);
            param.add(pBean);
            isPs = true;
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 名称构建区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 
     */
    public static void buildName(List<FileBean> nameList)
    {
        StringBuilder sb;
        int t;
        VarBean pb;
        for (FileBean bean : nameList)
        {
            t = param.size() - 1;
            sb = new StringBuilder(uRule);
            boolean b = true;
            while (t >= 0)
            {
                pb = param.get(t);
                replace(sb, "<" + t + ">", pb.nextChar(b) + "");
                b = pb.isEnd();
                t -= 1;
            }
            bean.setDstName(sb.toString());
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 物理命名区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 进行文件重命名
     * 
     * @param srcFilePath
     *            重命名原文件夹路径
     * @param dstFilePath
     *            重命名目标文件夹路径
     * @param nameList
     *            文件名称列表
     */
    public static void doRename(String srcFilePath, String dstFilePath, List<FileBean> nameList)
    {
        tempNamed(srcFilePath, dstFilePath, nameList);
        realNamed(srcFilePath, dstFilePath, nameList);
    }

    /**
     * 临时命名，避免文件命名冲突
     * 
     * @param srcFilePath
     *            重命名原文件夹路径
     * @param dstFilePath
     *            重命名目标文件夹路径
     * @param nameList
     *            文件名称列表
     */
    private static void tempNamed(String srcFilePath, String dstFilePath, List<FileBean> nameList)
    {
        for (FileBean bean : nameList)
        {
            bean.setTmpName(CharUtil.format(ConstUI.FILE_NAME_TEMP, "" + System.nanoTime()));
            new File(srcFilePath, bean.getSrcName()).renameTo(new File(dstFilePath, bean.getTmpName()));
        }
    }

    /**
     * 正式文件命名
     * 
     * @param srcFilePath
     *            重命名原文件夹路径
     * @param dstFilePath
     *            重命名目标文件夹路径
     * @param nameList
     *            文件名称列表
     */
    private static void realNamed(String srcFilePath, String dstFilePath, List<FileBean> nameList)
    {
        for (FileBean bean : nameList)
        {
            new File(dstFilePath, bean.getTmpName()).renameTo(new File(dstFilePath, bean.getDstName()));
            bean.setSrcName(bean.getDstName());
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param sb
     * @param src
     * @param dst
     * @return
     */
    private static StringBuilder replace(StringBuilder sb, String src, String dst)
    {
        int si = sb.indexOf(src);
        return sb.replace(si, si + src.length(), dst);
    }
}
