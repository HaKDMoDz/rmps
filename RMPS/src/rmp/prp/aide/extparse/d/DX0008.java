/*
 * FileName:       DX0008.java
 * CreateDate:     Jul 4, 2007 12:48:23 PM
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.d;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.File;
import java.io.IOException;
import java.sql.SQLException;
import java.util.List;

import rmp.bean.K1SV2S;
import rmp.io.db.DBAccess;
import rmp.prp.aide.extparse.Extparse;
import rmp.prp.aide.extparse.m.AsocBaseData;
import rmp.prp.aide.extparse.m.BaseData;
import rmp.prp.aide.extparse.m.CorpBaseData;
import rmp.prp.aide.extparse.m.DespBaseData;
import rmp.prp.aide.extparse.m.ExtsBaseData;
import rmp.prp.aide.extparse.m.FileBaseData;
import rmp.prp.aide.extparse.m.IdioBaseData;
import rmp.prp.aide.extparse.m.SoftBaseData;
import rmp.prp.aide.extparse.m.TypeBaseData;
import rmp.util.CheckUtil;
import rmp.util.EnvUtil;
import rmp.util.FileUtil;
import rmp.util.LogUtil;
import rmp.util.StringUtil;
import cons.SysCons;
import cons.id.PrpCons;
import cons.prp.aide.extparse.ConstUI;
import cons.prp.aide.extparse.DB0008;
import cons.prp.aide.extparse.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * 数据导出类，对外仅提供一个数据导出接口，用于导出不同格式的数据。
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
 * 日期： Jul 4, 2007 12:48:23 PM
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public final class DX0008
{
    private static String errMsg;
    private static String corpIcon;
    private static String softIcon;
    private static String fileIcon;
    private static String idioIcon;

    /**
     * 执行数据导出
     * 
     * @param exptFile 导出目标文件路径，此文件会自动创建。
     * @param tpltFile 导出模板文件路径
     * @param baseMeta 等导出的后缀信息
     * @param langHash 界面语言索引
     * @param exptIcon 是否同时导出图标：true表示导出图标
     * @return
     * @throws IOException
     */
    public static boolean export(File exptFile, File tpltFile, BaseData baseMeta, String langHash, boolean exptIcon)
        throws IOException
    {
        // 模板文件存在性判断
        if (!tpltFile.exists())
        {
            errMsg = StringUtil.format(LangRes.MESG_EXPT_0003, tpltFile.getPath());
            return false;
        }
        // 模板文件是否为文件判断
        if (!tpltFile.isFile())
        {
            errMsg = StringUtil.format(LangRes.MESG_EXPT_0004, tpltFile.getPath());
            return false;
        }
        // 模板文件可读性判断
        if (!tpltFile.canRead())
        {
            errMsg = StringUtil.format(LangRes.MESG_EXPT_0005, tpltFile.getPath());
            return false;
        }

        // 导出文件的存在性判断
        if (!exptFile.exists())
        {
            // 父目录存在性判断
            if (!exptFile.getParentFile().exists())
            {
                exptFile.getParentFile().mkdirs();
            }

            // 创建文件
            exptFile.createNewFile();
        }

        // 目标文件不是有效的文件。
        if (!exptFile.isFile())
        {
            errMsg = StringUtil.format(LangRes.MESG_EXPT_0006, exptFile.getPath());
            return false;
        }

        // 目标文件不可写入
        if (!exptFile.canWrite())
        {
            errMsg = StringUtil.format(LangRes.MESG_EXPT_0007, exptFile.getPath());
            return false;
        }

        // 模板文件内容数据读取
        String fileText = readData(tpltFile);
        // 字符替换
        fileText = replace(fileText, baseMeta, langHash);
        // 数据写出
        saveData(exptFile, fileText);

        // 图标拷贝
        if (exptIcon)
        {
            exptFile = new File(exptFile.getParentFile(), ConstUI.EXPT_ICONPATH);
            if (!exptFile.exists())
            {
                exptFile.mkdir();
            }
            // 公司图标
            File srcFile = new File(EnvUtil.getIconCorpDir(), corpIcon + SysCons.ICON_SIZE_0048 + SysCons.EXTS_ICON);
            File dstFile = new File(exptFile, ConstUI.EXPT_CORPICON);
            FileUtil.copyFile(srcFile, dstFile, true);
            // 软件图标
            srcFile = new File(EnvUtil.getIconSoftDir(), softIcon + SysCons.ICON_SIZE_0048 + SysCons.EXTS_ICON);
            dstFile = new File(exptFile, ConstUI.EXPT_SOFTICON);
            FileUtil.copyFile(srcFile, dstFile, true);
            // 文件图标
            srcFile = new File(EnvUtil.getIconFileDir(), fileIcon + SysCons.ICON_SIZE_0048 + SysCons.EXTS_ICON);
            dstFile = new File(exptFile, ConstUI.EXPT_FILEICON);
            FileUtil.copyFile(srcFile, dstFile, true);
            // 特别致谢
            srcFile = new File(EnvUtil.getIconIdioDir(), idioIcon + SysCons.ICON_SIZE_0048 + SysCons.EXTS_ICON);
            dstFile = new File(exptFile, ConstUI.EXPT_IDIOICON);
            FileUtil.copyFile(srcFile, dstFile, true);
        }

        return true;
    }

    /**
     * @return the errMsg
     */
    public static String getErrMsg()
    {
        return errMsg;
    }

    /**
     * 模板文件内容数据读取
     * 
     * @return
     * @throws IOException
     */
    private static String readData(File tpltFile) throws IOException
    {
        // 文件字节数组
        int fileLeng = (int)tpltFile.length();
        byte[] b = new byte[fileLeng];

        // 读取文件内容
        BufferedInputStream bis = null;
        try
        {
            bis = FileUtil.getInputStream(tpltFile);
            fileLeng = bis.read(b);
        }
        finally
        {
            if (bis != null)
            {
                bis.close();
            }
        }

        // 构建合适字符串
        if (fileLeng < 0)
        {
            return "";
        }
        return new String(b, 0, fileLeng, SysCons.FILE_ENCODING);
    }

    /**
     * 保存数据到目标文件。
     * 
     * @param exptFile
     * @param fileText
     * @throws IOException
     */
    private static void saveData(File exptFile, String fileText) throws IOException
    {
        byte[] b = fileText.getBytes(SysCons.FILE_ENCODING);

        BufferedOutputStream bos = null;
        try
        {
            bos = FileUtil.getOutputStream(exptFile);
            bos.write(b);
            bos.flush();
        }
        finally
        {
            if (bos != null)
            {
                bos.close();
            }
        }
    }

    /**
     * @param baseMeta
     * @param langHash 语言索引
     */
    private static String replace(String fileText, BaseData baseMeta, String langHash)
    {
        ExtsBaseData extsData = null;
        CorpBaseData corpData = null;
        SoftBaseData softData = null;
        FileBaseData fileData = null;
        IdioBaseData idioData = null;
        DespBaseData despData = null;
        AsocBaseData asocData = null;
        TypeBaseData typeData = null;

        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return fileText;
            }

            // 后缀信息查寻
            extsData = DA0008.selectExtsMeta(dba, baseMeta);
            fileData = DA0008.selectFileMetaInfo(dba, extsData.getFileIndx());
            softData = DA0008.selectSoftMetaInfo(dba, extsData.getSoftIndx());
            corpData = DA0008.selectCorpMetaInfo(dba, softData.getCorpIndx());
            idioData = DA0008.selectIdioMetaInfo(dba, extsData.getIdioIndx());
            despData = DA0008.selectDespMetaInfo(dba, extsData.getDespIndx(), langHash);
            asocData = DA0008.selectAsocMetaInfo(dba, extsData.getAsocIndx(), "");
            typeData = DA0008.selectTypeMetaInfo(dba, extsData.getTypeIndx(), PrpCons.P3010000_I);
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
            return fileText;
        }
        finally
        {
            dba.closeConnection();
        }

        // 字符替换
        fileText = replaceExtsData(fileText, extsData);
        fileText = replaceFileData(fileText, fileData);
        fileText = replaceSoftData(fileText, softData);
        fileText = replaceCorpData(fileText, corpData);
        fileText = replaceIdioData(fileText, idioData);
        fileText = replaceDespData(fileText, despData);
        fileText = replaceAsocData(fileText, asocData);
        fileText = replaceTypeData(fileText, typeData);

        return fileText;
    }

    /**
     * 后缀信息数据替换
     * 
     * @param fileText 等替换原字符串
     * @param extsData 数据库查寻结果
     */
    private static String replaceExtsData(String fileText, ExtsBaseData extsData)
    {
        if (!CheckUtil.isValidate(fileText) || extsData == null)
        {
            return fileText;
        }

        String temp;

        // 应用平台
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.EXTSDATA_PLATINDX);
        fileText = fileText.replace(temp, Extparse.decodePlatForm(extsData.getPlatIndx()));

        // 处理字长
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.EXTSDATA_XCPUBITS);
        fileText = fileText.replace(temp, Extparse.decodeArchBits(extsData.getArchBits()));

        // 后缀索引
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.EXTSDATA_EXTSINDX);
        fileText = fileText.replace(temp, extsData.getExtsIndx());

        // 公司索引
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.EXTSDATA_CORPINDX);
        fileText = fileText.replace(temp, extsData.getCorpIndx());

        // 软件索引
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.EXTSDATA_SOFTINDX);
        fileText = fileText.replace(temp, extsData.getSoftIndx());

        // 文件索引
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.EXTSDATA_FILEINDX);
        fileText = fileText.replace(temp, extsData.getFileIndx());

        // 描述索引
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.EXTSDATA_DESPINDX);
        fileText = fileText.replace(temp, extsData.getDespIndx());

        // 备选软件
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.EXTSDATA_ASOCINDX);
        fileText = fileText.replace(temp, extsData.getAsocIndx());

        // 所属类别
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.EXTSDATA_TYPEINDX);
        fileText = fileText.replace(temp, extsData.getTypeIndx());

        // 贡献人员
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.EXTSDATA_IDIOINDX);
        fileText = fileText.replace(temp, extsData.getIdioIndx());

        // 后缀名称
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.EXTSDATA_EXTSNAME);
        fileText = fileText.replace(temp, extsData.getExtsName());

        return fileText;
    }

    /**
     * 文件信息数据替换
     * 
     * @param fileText 等替换原字符串
     * @param fileData 数据库查寻结果
     */
    private static String replaceFileData(String fileText, FileBaseData fileData)
    {
        if (!CheckUtil.isValidate(fileText) || fileData == null)
        {
            return fileText;
        }

        String temp;

        // 文件索引
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.FILEDATA_FILEINDX);
        fileText = fileText.replace(temp, fileData.getFileIndx());

        // 直属软件
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.FILEDATA_SOFTINDX);
        fileText = fileText.replace(temp, fileData.getSoftIndx());

        // 文件图标
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.FILEDATA_FILEICON);
        fileText = fileText.replace(temp, ConstUI.EXPT_ICONPATH + "/" + ConstUI.EXPT_FILEICON);

        // 字符签名
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.FILEDATA_SIGNCHAR);
        fileText = fileText.replace(temp, fileData.getSignChar());

        // 数字签名
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.FILEDATA_SIGNCODE);
        fileText = fileText.replace(temp, fileData.getSignCode());

        // 偏移位置
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.FILEDATA_MSOFFSET);
        fileText = fileText.replace(temp, "" + fileData.getMsOffset());

        // 加密算法
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.FILEDATA_CIPHERSN);
        fileText = fileText.replace(temp, fileData.getCipherSn());

        // 起始数据
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.FILEDATA_HEADDATA);
        fileText = fileText.replace(temp, fileData.getHeadData());

        // 结束数据
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.FILEDATA_FOOTDATA);
        fileText = fileText.replace(temp, fileData.getFootData());

        // 文档格式
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.FILEDATA_FORMATDT);
        fileText = fileText.replace(temp, fileData.getFormatDt());

        // 附注信息
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.FILEDATA_FILEDESP);
        fileText = fileText.replace(temp, fileData.getFileDesp());

        fileIcon = fileData.getFileIcon();

        return fileText;
    }

    /**
     * 软件信息数据替换
     * 
     * @param fileText 等替换原字符串
     * @param softData 数据库查寻结果
     */
    private static String replaceSoftData(String fileText, SoftBaseData softData)
    {
        if (!CheckUtil.isValidate(fileText) || softData == null)
        {
            return fileText;
        }

        String temp;

        // 软件索引
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.SOFTDATA_SOFTINDX);
        fileText = fileText.replace(temp, softData.getSoftIndx());

        // 公司索引
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.SOFTDATA_CORPINDX);
        fileText = fileText.replace(temp, softData.getCorpIndx());

        // 软件图标
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.SOFTDATA_SOFTICON);
        fileText = fileText.replace(temp, ConstUI.EXPT_ICONPATH + "/" + ConstUI.EXPT_SOFTICON);

        // 软件名称
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.SOFTDATA_SOFTNAME);
        fileText = fileText.replace(temp, softData.getSoftName());

        // 电子邮件
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.SOFTDATA_SOFTMAIL);
        fileText = fileText.replace(temp, softData.getSoftMail());

        // 链接地址
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.SOFTDATA_SOFTSITE);
        fileText = fileText.replace(temp, softData.getSoftSite());

        // 兼容后缀
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.SOFTDATA_EXTSLIST);
        fileText = fileText.replace(temp, softData.getExtsList());

        // 软件描述
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.SOFTDATA_SOFTDESP);
        fileText = fileText.replace(temp, softData.getSoftDesp());

        softIcon = softData.getSoftIcon();

        return fileText;
    }

    /**
     * 公司信息数据替换
     * 
     * @param fileText 等替换原字符串
     * @param corpData 数据库查寻结果
     */
    private static String replaceCorpData(String fileText, CorpBaseData corpData)
    {
        if (!CheckUtil.isValidate(fileText) || corpData == null)
        {
            return fileText;
        }

        String temp;

        // 公司索引
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.CORPDATA_CORPINDX);
        fileText = fileText.replace(temp, corpData.getCorpIndx());

        // 国别索引
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.CORPDATA_NATNINDX);
        fileText = fileText.replace(temp, corpData.getNatnIndx());

        // 公司徽标
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.CORPDATA_CORPLOGO);
        fileText = fileText.replace(temp, ConstUI.EXPT_ICONPATH + "/" + ConstUI.EXPT_CORPICON);

        // 本语名称
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.CORPDATA_CORPLCNM);
        fileText = fileText.replace(temp, corpData.getCorpLcNm());

        // 英语名称
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.CORPDATA_CORPENNM);
        fileText = fileText.replace(temp, corpData.getCorpEnNm());

        // 公司网址
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.CORPDATA_CORPSITE);
        fileText = fileText.replace(temp, corpData.getCorpSite());

        // 公司描述
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.CORPDATA_CORPDESP);
        fileText = fileText.replace(temp, corpData.getCorpDesp());

        corpIcon = corpData.getCorpLogo();

        return fileText;
    }

    /**
     * 个人信息数据替换
     * 
     * @param fileText 等替换原字符串
     * @param idioData 数据库查寻结果
     */
    private static String replaceIdioData(String fileText, IdioBaseData idioData)
    {
        if (!CheckUtil.isValidate(fileText) || idioData == null)
        {
            return fileText;
        }

        String temp;

        // 人员索引
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.IDIODATA_IDIOINDX);
        fileText = fileText.replace(temp, idioData.getIdioIndx());

        // 个性图标
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.IDIODATA_IDIOLOGO);
        fileText = fileText.replace(temp, ConstUI.EXPT_ICONPATH + "/" + ConstUI.EXPT_IDIOICON);

        // 电子邮件
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.IDIODATA_IDIOMAIL);
        fileText = fileText.replace(temp, idioData.getIdioMail());

        // 昵称
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.IDIODATA_NICKNAME);
        fileText = fileText.replace(temp, idioData.getNickName());

        // 个性签名
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.IDIODATA_IDIOSIGN);
        fileText = fileText.replace(temp, idioData.getIdioSign());

        // 个人主页
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.IDIODATA_HOMEPAGE);
        fileText = fileText.replace(temp, idioData.getHomePage());

        // 相关说明
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.IDIODATA_IDIODESP);
        fileText = fileText.replace(temp, idioData.getIdioDesp());

        idioIcon = idioData.getIdioLogo();

        return fileText;
    }

    /**
     * 描述信息数据替换
     * 
     * @param fileText 等替换原字符串
     * @param despData 数据库查寻结果
     */
    private static String replaceDespData(String fileText, DespBaseData despData)
    {
        if (!CheckUtil.isValidate(fileText) || despData == null)
        {
            return fileText;
        }

        String temp;

        // 描述索引
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.DESPDATA_DESPINDX);
        fileText = fileText.replace(temp, despData.getDespIndx());

        // 语言索引
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.DESPDATA_LANGINDX);
        fileText = fileText.replace(temp, despData.getLangIndx());

        // 后缀描述
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.DESPDATA_EXTSDESP);
        fileText = fileText.replace(temp, despData.getExtsDesp());

        // 相关说明
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.DESPDATA_IDIOMARK);
        fileText = fileText.replace(temp, despData.getIdioMark());

        return fileText;
    }

    /**
     * @param fileText
     * @param asocData
     * @return
     */
    private static String replaceAsocData(String fileText, AsocBaseData asocData)
    {
        if (!CheckUtil.isValidate(fileText) || asocData == null)
        {
            return fileText;
        }

        String temp;

        // 备选软件
        List<K1SV2S> asocList = asocData.getAsocList();
        if (asocList != null)
        {
            String asocName = "";
            for (int i = 0, j = asocList.size(); i < j; i += 1)
            {
                asocName += Extparse.getMesg(LangRes.TEXT_CTRLSPVV) + asocList.get(i).getV1();
            }

            if (asocName.length() > 0)
            {
                asocName = asocName.substring(Extparse.getMesg(LangRes.TEXT_CTRLSPVV).length());
            }

            // ASOCDATA替换
            temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.ASOCDATA_SOFTINDX);
            fileText = fileText.replace(temp, asocName);

            // EXTSDATA替换
            temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.EXTSDATA_ASOCINDX);
            fileText = fileText.replace(temp, asocName);
        }

        return fileText;
    }

    /**
     * @param fileText
     * @param typeData
     * @return
     */
    private static String replaceTypeData(String fileText, TypeBaseData typeData)
    {
        if (!CheckUtil.isValidate(fileText) || typeData == null)
        {
            return fileText;
        }

        String temp;

        // 系统标记
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.TYPEDATA_SYSTEMID);
        fileText = fileText.replace(temp, "" + typeData.getSystemID());

        // 类别索引
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.TYPEDATA_TYPEINDX);
        fileText = fileText.replace(temp, typeData.getTypeIndx());

        // 类别名称
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.TYPEDATA_TYPENAME);
        fileText = fileText.replace(temp, typeData.getTypeName());

        // 类别描述
        temp = StringUtil.format(ConstUI.EXPT_FORMTEXT, DB0008.TYPEDATA_TYPEDESP);
        fileText = fileText.replace(temp, typeData.getTypeDesp());

        return fileText;
    }
}
