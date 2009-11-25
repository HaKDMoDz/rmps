/*
 * FileName:       DA0008.java
 * CreateDate:     2007-7-15 下午04:03:48
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.d;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import rmp.bean.K1SV2S;
import rmp.bean.K2SV1S;
import rmp.io.db.DBAccess;
import rmp.prp.aide.extparse.m.AsocBaseData;
import rmp.prp.aide.extparse.m.AsocUserData;
import rmp.prp.aide.extparse.m.BaseData;
import rmp.prp.aide.extparse.m.CorpBaseData;
import rmp.prp.aide.extparse.m.CorpUserData;
import rmp.prp.aide.extparse.m.DespBaseData;
import rmp.prp.aide.extparse.m.DespUserData;
import rmp.prp.aide.extparse.m.ExtsBaseData;
import rmp.prp.aide.extparse.m.ExtsUserData;
import rmp.prp.aide.extparse.m.FileBaseData;
import rmp.prp.aide.extparse.m.FileUserData;
import rmp.prp.aide.extparse.m.IdioBaseData;
import rmp.prp.aide.extparse.m.IdioUserData;
import rmp.prp.aide.extparse.m.MimeBaseData;
import rmp.prp.aide.extparse.m.MimeUserData;
import rmp.prp.aide.extparse.m.NatnBaseData;
import rmp.prp.aide.extparse.m.SoftBaseData;
import rmp.prp.aide.extparse.m.SoftUserData;
import rmp.prp.aide.extparse.m.TypeBaseData;
import rmp.util.CheckUtil;
import rmp.util.HashUtil;
import rmp.util.LogUtil;
import rmp.util.RmpsUtil;
import cons.CfgCons;
import cons.id.PrpCons;
import cons.prp.aide.extparse.ConstUI;
import cons.prp.aide.extparse.DB0008;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * 数据存取类
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
 * 日期： 2007-7-15 下午04:03:48
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public final class DA0008
{
    // ////////////////////////////////////////////////////////////////////////
    // 数据初始化区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 搜索列表初始化
     * 
     * @param dba 数据库操作对象
     * @return
     * @throws SQLException
     */
    public static List<K1SV2S> initOlSearchList(DBAccess dba) throws SQLException
    {
        LogUtil.log("数据库查寻：动态搜索引擎菜单项数据查寻！");

        dba.reset();

        // 数据表格拼接
        dba.addTable(DB0008.TABLE_LINKDATA);

        // 查寻字段拼接
        dba.addColumn(DB0008.LINKDATA_LINKNAME);
        dba.addColumn(DB0008.LINKDATA_LINKURLS);
        dba.addColumn(DB0008.LINKDATA_METADESP);

        // 关联条件拼接
        dba.addWhere(DB0008.LINKDATA_TYPEINDX, DB0008.DBCD_LINK_SRCHTYPE);

        // 排序依据拼接
        dba.addSort(DB0008.LINKDATA_DISPORDR, DB0008.DBCS_SORT_ASC);

        List<K1SV2S> linkList = new ArrayList<K1SV2S>();
        String k;
        String v1;
        String v2;

        // 查询结果数据集处理
        ResultSet rest = dba.executeSelect();
        while (rest.next())
        {
            k = rest.getString(DB0008.LINKDATA_LINKURLS);
            v1 = rest.getString(DB0008.LINKDATA_LINKNAME);
            v2 = rest.getString(DB0008.LINKDATA_METADESP);

            linkList.add(new K1SV2S(k, v1, v2));
        }
        rest.close();

        return linkList;
    }

    /**
     * 语言列表数据初始化查寻
     * 
     * @param dba 数据库操作对象
     * @param langType 语言类型：9表示其它语言；8表示常用语言，其它值表示所有语言
     * @return
     * @throws SQLException
     */
    public static List<K1SV2S> initLanguageList(DBAccess dba, String langType) throws SQLException
    {
        LogUtil.log("数据库查寻：高级模式数据查寻 － 界面语言列表数据查寻！");
        dba.reset();

        // 查寻表格拼接
        dba.addTable(DB0008.TABLE_MESGDATA);

        // 查寻字段拼接
        dba.addColumn(DB0008.MESGDATA_LANGINDX);
        dba.addColumn(DB0008.MESGDATA_MESGTEXT);
        dba.addColumn(DB0008.MESGDATA_MESGDESP);

        // 关联条件拼接
        dba.addWhere(DB0008.MESGDATA_MESGINDX, "<=", langType, true);

        // 排序依据拼接
        dba.addSort(DB0008.MESGDATA_MESGDESP, DB0008.DBCS_SORT_ASC);

        List<K1SV2S> langList = new ArrayList<K1SV2S>();
        String k;
        String v1;
        String v2;

        // 查询结果集处理
        ResultSet rest = dba.executeSelect();
        while (rest.next())
        {
            k = rest.getString(DB0008.MESGDATA_LANGINDX);
            v1 = rest.getString(DB0008.MESGDATA_MESGTEXT);
            v2 = rest.getString(DB0008.MESGDATA_MESGDESP);

            langList.add(new K1SV2S(k, v1, v2));
        }
        rest.close();

        return langList;
    }

    /**
     * 获取指定语言的语言资源信息
     * 
     * @param dba
     * @param langHash
     * @return
     * @throws SQLException
     */
    public static HashMap<String, String> initLangMesg(DBAccess dba, String langHash) throws SQLException
    {
        LogUtil.log("数据查寻：界面语言资源数据查寻！");
        dba.reset();

        // 数据表格拼接
        dba.addTable(DB0008.TABLE_MESGDATA);

        // 查寻字段拼接
        dba.addColumn(DB0008.MESGDATA_MESGINDX);
        dba.addColumn(DB0008.MESGDATA_MESGTEXT);

        // 关联条件拼接
        dba.addWhere(DB0008.MESGDATA_LANGINDX, langHash);

        // 排序依据拼接
        dba.addSort(DB0008.MESGDATA_MESGINDX, DB0008.DBCS_SORT_ASC);

        // 若查寻结果集对象为空，则返回值为NULL；
        ResultSet rest = dba.executeSelect();

        // 读取语言资源到HashMap中去
        HashMap<String, String> hashMap = new HashMap<String, String>();
        while (rest.next())
        {
            hashMap.put(rest.getString(DB0008.MESGDATA_MESGINDX), rest.getString(DB0008.MESGDATA_MESGTEXT));
        }
        rest.close();

        return hashMap;
    }

    /**
     * 公益广告语言资源读取
     * 
     * @param dba
     * @throws SQLException
     */
    public static List<K1SV2S> initPublicAd(DBAccess dba) throws SQLException
    {
        LogUtil.log("数据查询：公益广告语言资源查询！");

        // 连接初始化
        dba.reset();

        // 操作表格
        dba.addTable(DB0008.TABLE_PBADDATA);

        // 查询字段
        dba.addColumn(DB0008.PBADDATA_PBADINDX);
        dba.addColumn(DB0008.PBADDATA_PBADTEXT);
        dba.addColumn(DB0008.PBADDATA_PBADDESP);

        // 返回对象
        List<K1SV2S> pbadList = new ArrayList<K1SV2S>();
        K1SV2S kvItem;

        // 执行数据查询
        ResultSet rest = dba.executeSelect();
        while (rest.next())
        {
            kvItem = new K1SV2S();
            kvItem.setK(rest.getString(DB0008.PBADDATA_PBADINDX));
            kvItem.setV1(rest.getString(DB0008.PBADDATA_PBADTEXT));
            kvItem.setV2(rest.getString(DB0008.PBADDATA_PBADDESP));
            pbadList.add(kvItem);
        }

        return pbadList;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 数据删除区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 备选软件数据删除
     * 
     * @param dba
     * @param asocMeta
     * @return
     * @throws SQLException
     */
    public static int deleteAsocMeta(DBAccess dba, AsocUserData asocMeta) throws SQLException
    {
        LogUtil.log("数据删除：备选软件数据删除 － " + asocMeta.getAsocIndx() + "、" + asocMeta.getSoftIndx());

        // 默认数据不进行任何处理
        if (ConstUI.DEF_ASOCHASH.equals(asocMeta.getAsocIndx()))
        {
            return -1;
        }

        // 初始化
        dba.reset();

        // 操作表格
        dba.addTable(DB0008.TABLE_ASOCDATA);

        // 关联条件
        dba.addWhere(DB0008.ASOCDATA_ASOCINDX, asocMeta.getAsocIndx());
        dba.addWhere(DB0008.ASOCDATA_SOFTINDX, asocMeta.getSoftIndx());

        // 数据删除
        return dba.executeDelete();
    }

    /**
     * 公司信息数据删除
     * 
     * @param dba
     * @param corpMeta
     * @return
     * @throws SQLException
     */
    public static int deleteCorpMeta(DBAccess dba, CorpUserData corpMeta) throws SQLException
    {
        LogUtil.log("数据删除：公司信息指定公司索引数据删除 － " + corpMeta.getCorpIndx());

        // 默认数据不进行任何操作
        if (ConstUI.DEF_CORPHASH.equals(corpMeta.getCorpIndx()))
        {
            return -1;
        }

        // 初始化
        dba.reset();

        // 操作表格
        dba.addTable(DB0008.TABLE_CORPDATA);

        // 关联条件
        dba.addWhere(DB0008.CORPDATA_CORPINDX, corpMeta.getCorpIndx());

        // 数据删除
        return dba.executeDelete();
    }

    /**
     * 描述数据删除
     * 
     * @param dba
     * @param despMeta
     * @return
     * @throws SQLException
     */
    public static int deleteDespMeta(DBAccess dba, DespUserData despMeta) throws SQLException
    {
        LogUtil.log("数据删除：指定语言的特别后缀描述信息删除 － " + despMeta.getDespIndx());

        // 默认数据不进行任何操作
        if (ConstUI.DEF_DESPHASH.equals(despMeta.getDespIndx()))
        {
            return -1;
        }

        // 初始化
        dba.reset();

        // 操作表格
        dba.addTable(DB0008.TABLE_DESPDATA);

        // 关联条件
        dba.addWhere(DB0008.DESPDATA_DESPINDX, despMeta.getDespIndx());
        dba.addWhere(DB0008.DESPDATA_LANGINDX, despMeta.getLangIndx());

        // 数据删除
        return dba.executeDelete();
    }

    /**
     * 后缀数据删除
     * 
     * @param dba
     * @param extsMeta
     * @throws SQLException
     */
    public static int deleteExtsMeta(DBAccess dba, ExtsUserData extsMeta) throws SQLException
    {
        String extsName = extsMeta.getExtsName();
        LogUtil.log("数据删除：指定软件索引的后缀数据删除 － " + extsName + "、" + extsMeta.getSoftIndx());

        // 初始化
        dba.reset();

        // 操作表格
        dba.addTable(DB0008.TABLE_EXTSDATA);

        // 关联条件
        dba.addWhere(DB0008.EXTSDATA_EXTSINDX, HashUtil.digest(extsName.substring(1), false));
        dba.addWhere(DB0008.EXTSDATA_SOFTINDX, extsMeta.getSoftIndx_O());

        // 数据删除
        return dba.executeDelete();
    }

    /**
     * 文件信息数据删除
     * 
     * @param dba
     * @param fileMeta
     * @return
     * @throws SQLException
     */
    public static int deleteFileMeta(DBAccess dba, FileUserData fileMeta) throws SQLException
    {
        LogUtil.log("数据删除：文件信息指定文件索引数据删除 － " + fileMeta.getFileIndx());

        // 默认数据不进行任何操作
        if (ConstUI.DEF_FILEHASH.equals(fileMeta.getFileIndx()))
        {
            return -1;
        }

        // 初始化
        dba.reset();

        // 操作表格
        dba.addTable(DB0008.TABLE_FILEDATA);

        // 关联条件
        dba.addWhere(DB0008.FILEDATA_FILEINDX, fileMeta.getFileIndx());

        // 数据删除
        return dba.executeDelete();
    }

    /**
     * 个人信息数据删除
     * 
     * @param dba
     * @param idioMeta
     * @return
     * @throws SQLException
     */
    public static int deleteIdioMeta(DBAccess dba, IdioUserData idioMeta) throws SQLException
    {
        LogUtil.log("数据删除：个人信息指定个人索引数据删除 － " + idioMeta.getIdioIndx());

        // 默认数据不进行任何操作
        if (ConstUI.DEF_IDIOHASH.equals(idioMeta.getIdioIndx()))
        {
            return -1;
        }

        // 初始化
        dba.reset();

        // 更新表格
        dba.addTable(DB0008.TABLE_IDIODATA);

        // 关联条件
        dba.addWhere(DB0008.IDIODATA_IDIOINDX, idioMeta.getIdioIndx());

        // 数据删除
        return dba.executeDelete();
    }

    /**
     * 主面板数据删除
     * 
     * @param dba
     * @param extsName 形如“.abc”格式的后缀
     * @param softHash
     * @return
     * @throws SQLException
     */
    public static int deleteMainMeta(DBAccess dba, String extsName, String softHash) throws SQLException
    {
        LogUtil.log("数据删除：后缀数据删除 － " + extsName + "、" + softHash);

        // 默认数据不进行任何处理
        if (!CheckUtil.isValidate(extsName))
        {
            return -1;
        }

        // 初始化
        dba.reset();

        // 操作表格
        dba.addTable(DB0008.TABLE_EXTSDATA);

        // 关联条件
        dba.addWhere(DB0008.EXTSDATA_EXTSINDX, HashUtil.digest(extsName.substring(1), false));
        dba.addWhere(DB0008.EXTSDATA_SOFTINDX, softHash);

        // 数据删除
        return dba.executeDelete();
    }

    /**
     * MIME类型数据删除
     * 
     * @param dba
     * @param mimeMeta
     * @return
     * @throws SQLException
     */
    public static int deleteMimeMeta(DBAccess dba, MimeUserData mimeMeta) throws SQLException
    {
        LogUtil.log("数据删除：备选软件数据删除 － " + mimeMeta.getMimeIndx() + "、" + mimeMeta.getMimeType());

        // 默认数据不进行任何处理
        if (ConstUI.DEF_MIMEHASH.equals(mimeMeta.getMimeIndx()))
        {
            return -1;
        }

        // 初始化
        dba.reset();

        // 操作表格
        dba.addTable(DB0008.TABLE_MIMEDATA);

        // 关联条件
        dba.addWhere(DB0008.MIMEDATA_MIMEINDX, mimeMeta.getMimeIndx());
        dba.addWhere(DB0008.MIMEDATA_MIMETYPE, mimeMeta.getMimeType());

        // 数据删除
        return dba.executeDelete();
    }

    /**
     * 软件信息数据删除：删除指定软件索引的数据信息
     * 
     * @param dba
     * @param softMeta
     * @throws SQLException
     */
    public static int deleteSoftMeta(DBAccess dba, SoftUserData softMeta) throws SQLException
    {
        LogUtil.log("数据删除：软件信息指定软件索引数据删除 － " + softMeta.getSoftIndx());

        // 默认数据不进行任何操作
        if (ConstUI.DEF_SOFTHASH.equals(softMeta.getSoftIndx()))
        {
            return -1;
        }

        // 初始化
        dba.reset();

        // 更新表格
        dba.addTable(DB0008.TABLE_SOFTDATA);

        // 关联条件
        dba.addWhere(DB0008.SOFTDATA_SOFTINDX, softMeta.getSoftIndx());

        // 数据删除
        return dba.executeDelete();
    }

    // ////////////////////////////////////////////////////////////////////////
    // 数据查询区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param dba
     * @return
     * @throws SQLException
     */
    public static List<K2SV1S> selectAsocMetaName(DBAccess dba, String asocHash) throws SQLException
    {
        LogUtil.log("数据查询：备选软件名称列表数据查询 － " + asocHash);

        // 连接初始化
        dba.reset();

        // 查询表格
        dba.addTable(DB0008.TABLE_ASOCDATA);
        dba.addTable(DB0008.TABLE_SOFTDATA);

        // 查询字段
        dba.addColumn(DB0008.ASOCDATA_ASOCINDX);
        dba.addColumn(DB0008.ASOCDATA_SOFTINDX);
        dba.addColumn(DB0008.SOFTDATA_SOFTNAME);

        // 关联条件
        if (CheckUtil.isValidate(asocHash) && ConstUI.DEF_ASOCHASH != asocHash)
        {
            dba.addWhere(DB0008.ASOCDATA_ASOCINDX, asocHash);
        }
        dba.addWhere(DB0008.ASOCDATA_SOFTINDX, DB0008.SOFTDATA_SOFTINDX, false);

        List<K2SV1S> asocList = new ArrayList<K2SV1S>();
        K2SV1S kvItem;

        ResultSet rest = dba.executeSelect();
        while (rest.next())
        {
            kvItem = new K2SV1S();
            kvItem.setK1(rest.getString(DB0008.ASOCDATA_ASOCINDX));
            kvItem.setK2(rest.getString(DB0008.ASOCDATA_SOFTINDX));
            kvItem.setV(rest.getString(DB0008.SOFTDATA_SOFTNAME));

            asocList.add(kvItem);
        }
        rest.close();

        return asocList;
    }

    /**
     * 备选软件数据查询
     * 
     * @param dba
     * @param asocHash
     * @return K：软件索引；V1：软件名称；V2：备选软件说明
     * @throws SQLException
     */
    public static AsocBaseData selectAsocMetaInfo(DBAccess dba, String asocHash, String softHash) throws SQLException
    {
        LogUtil.log("数据查询：备选软件软件名称列表数据查询。");

        // 初始化
        dba.reset();

        // 操作表格
        dba.addTable(DB0008.TABLE_ASOCDATA);
        dba.addTable(DB0008.TABLE_SOFTDATA);

        // 查询字段
        dba.addColumn(DB0008.ASOCDATA_SOFTINDX);
        dba.addColumn(DB0008.ASOCDATA_ASOCDESP);
        dba.addColumn(DB0008.SOFTDATA_SOFTNAME);

        // 关联条件
        dba.addWhere(DB0008.ASOCDATA_ASOCINDX, asocHash);
        if (CheckUtil.isValidate(softHash))
        {
            dba.addWhere(DB0008.ASOCDATA_SOFTINDX, softHash);
        }
        dba.addWhere(DB0008.ASOCDATA_SOFTINDX, DB0008.SOFTDATA_SOFTINDX, false);

        // 排序依据
        dba.addSort(DB0008.ASOCDATA_DISPORDR, DB0008.DBCS_SORT_DESC);

        AsocBaseData baseMeta = new AsocBaseData();
        baseMeta.wInit();
        baseMeta.setAsocIndx(asocHash);
        K1SV2S kvItem;

        ResultSet rest = dba.executeSelect();
        while (rest.next())
        {
            kvItem = new K1SV2S();
            kvItem.setK(rest.getString(DB0008.ASOCDATA_SOFTINDX));
            kvItem.setV1(rest.getString(DB0008.SOFTDATA_SOFTNAME));
            kvItem.setV2(rest.getString(DB0008.ASOCDATA_ASOCDESP));
            baseMeta.addAsocSoft(kvItem);
        }
        rest.close();

        return baseMeta;
    }

    /**
     * 公司本语名称列表数据查询
     * 
     * @param dba
     * @param corpMeta
     * @return
     * @throws SQLException
     */
    public static List<K2SV1S> selectCorpMetaName(DBAccess dba, CorpUserData corpMeta) throws SQLException
    {
        return selectCorpMetaName(dba, corpMeta.getNatnIndx(), corpMeta.getCorpLcNm());
    }

    /**
     * 公司本语名称列表数据查询<br>
     * <li>当国别索引为默认值时，返回所有公司名称列表信息；
     * <li>当公司本语名称为空时，返回指定国别索引的所有公司名称列表信息；
     * 
     * @param dba
     * @param natnHash
     * @param corpLcNm
     * @return 公司名值列表：K1公司索引，K2国别索引，V公司本语名称
     * @throws SQLException
     */
    public static List<K2SV1S> selectCorpMetaName(DBAccess dba, String natnHash, String corpLcNm) throws SQLException
    {
        LogUtil.log("数据查询：公司本语名称列表数据查询。");

        // 数据库对象初始化
        dba.reset();

        // 查询表格拼接
        dba.addTable(DB0008.TABLE_CORPDATA);

        // 查询字段拼接
        dba.addColumn(DB0008.CORPDATA_CORPINDX);
        dba.addColumn(DB0008.CORPDATA_NATNINDX);
        dba.addColumn(DB0008.CORPDATA_CORPLCNM);

        // 关联条件
        // 国别索引
        if (CheckUtil.isValidate(natnHash) && !ConstUI.DEF_NATNHASH.equals(natnHash))
        {
            dba.addWhere(DB0008.CORPDATA_NATNINDX, natnHash);
        }
        // 公司本语名称
        if (CheckUtil.isValidate(corpLcNm))
        {
            dba.addWhere("LOWER(" + DB0008.CORPDATA_CORPLCNM + ")", "LIKE", "%" + corpLcNm.toLowerCase() + "%", true);
        }

        // 排序依据
        dba.addSort(DB0008.CORPDATA_DISPORDR, DB0008.DBCS_SORT_DESC);

        List<K2SV1S> corpList = new ArrayList<K2SV1S>();

        // 结果集处理
        ResultSet rest = dba.executeSelect();
        String k1;
        String k2;
        String v;
        while (rest.next())
        {
            k1 = rest.getString(DB0008.CORPDATA_CORPINDX);
            k2 = rest.getString(DB0008.CORPDATA_NATNINDX);
            v = rest.getString(DB0008.CORPDATA_CORPLCNM);
            if (ConstUI.DEF_CORPHASH.equals(k1))
            {
                corpList.add(0, new K2SV1S(k1, k2, v));
            }
            else
            {
                corpList.add(new K2SV1S(k1, k2, v));
            }
        }
        rest.close();

        return corpList;
    }

    /**
     * 公司详细信息查询
     * 
     * @param dba
     * @param corpHash
     * @return
     * @throws SQLException
     */
    public static CorpBaseData selectCorpMetaInfo(DBAccess dba, String corpHash) throws SQLException
    {
        LogUtil.log("数据查询：按公司索引查询公司详细信息 － " + corpHash);

        // 数据库对象初始化
        dba.reset();

        // 查询表格拼接
        dba.addTable(DB0008.TABLE_CORPDATA, DB0008.TABLE_NATNDATA, DB0008.DBCS_JOIN_LEFT, DB0008.CORPDATA_NATNINDX,
            DB0008.NATNDATA_NATNINDX);

        // 查询字段拼接
        dba.addColumn(DB0008.CORPDATA_CORPINDX);
        dba.addColumn(DB0008.CORPDATA_NATNINDX);
        dba.addColumn(DB0008.NATNDATA_NATNSLNM);
        dba.addColumn(DB0008.CORPDATA_CORPLOGO);
        dba.addColumn(DB0008.CORPDATA_CORPLCNM);
        dba.addColumn(DB0008.CORPDATA_CORPENNM);
        dba.addColumn(DB0008.CORPDATA_CORPSITE);
        dba.addColumn(DB0008.CORPDATA_CORPDESP);
        dba.addColumn(DB0008.CORPDATA_UPDTDATE);
        dba.addColumn(DB0008.CORPDATA_MAKEDATE);

        // 查询关联条件
        dba.addWhere(DB0008.CORPDATA_CORPINDX, corpHash);
        dba.addWhere(DB0008.CORPDATA_NATNINDX, DB0008.NATNDATA_NATNINDX, false);
        dba.addWhere(DB0008.NATNDATA_LANGINDX, RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_LANG_ID));

        // 结果数据对象
        CorpBaseData baseMeta = new CorpBaseData();
        baseMeta.wInit();

        // 执行数据查询
        ResultSet rest = dba.executeSelect();

        // 查询结果集处理
        if (rest.next())
        {
            baseMeta.setMetaExist(true);

            baseMeta.setCorpIndx(rest.getString(DB0008.CORPDATA_CORPINDX));
            baseMeta.setNatnIndx(rest.getString(DB0008.CORPDATA_NATNINDX));
            baseMeta.setNatnName(rest.getString(DB0008.NATNDATA_NATNSLNM));
            baseMeta.setCorpLogo(rest.getString(DB0008.CORPDATA_CORPLOGO));
            baseMeta.setCorpLcNm(rest.getString(DB0008.CORPDATA_CORPLCNM));
            baseMeta.setCorpEnNm(rest.getString(DB0008.CORPDATA_CORPENNM));
            baseMeta.setCorpSite(rest.getString(DB0008.CORPDATA_CORPSITE));
            baseMeta.setCorpDesp(rest.getString(DB0008.CORPDATA_CORPDESP));
            baseMeta.setUpdtDate(rest.getDate(DB0008.CORPDATA_UPDTDATE));
            baseMeta.setMakeDate(rest.getDate(DB0008.CORPDATA_MAKEDATE));
        }
        // 数据集关闭
        rest.close();

        // 显示排序更新
        updateDispOrdr(dba, DB0008.TABLE_CORPDATA, DB0008.CORPDATA_DISPORDR, DB0008.CORPDATA_CORPINDX, baseMeta
            .getCorpIndx());

        return baseMeta;
    }

    /**
     * 查询指定语言的特定后缀描述信息
     * 
     * @param dba
     * @param despHash
     * @param langHash
     * @return
     * @throws SQLException
     */
    public static DespBaseData selectDespMetaInfo(DBAccess dba, String despHash, String langHash) throws SQLException
    {
        LogUtil.log("数据查询：特定语言的描述信息查询 － " + despHash);

        // 初始化
        dba.reset();

        // 查询表格
        dba.addTable(DB0008.TABLE_DESPDATA);

        // 查询字段
        dba.addColumn(DB0008.DESPDATA_EXTSDESP);
        dba.addColumn(DB0008.DESPDATA_IDIOMARK);

        // 关联条件
        dba.addWhere(DB0008.DESPDATA_DESPINDX, despHash);
        dba.addWhere(DB0008.DESPDATA_LANGINDX, langHash);

        DespBaseData baseMeta = new DespBaseData();
        baseMeta.wInit();

        // 查询结果集处理
        ResultSet rest = dba.executeSelect();
        if (rest.next())
        {
            baseMeta.setMetaExist(true);

            baseMeta.setExtsDesp(rest.getString(DB0008.DESPDATA_EXTSDESP));
            baseMeta.setIdioMark(rest.getString(DB0008.DESPDATA_IDIOMARK));
        }
        rest.close();

        return baseMeta;
    }

    /**
     * @param dba
     * @param extsName 形如“.abc”格式的后缀名称
     * @return
     * @throws SQLException
     */
    public static List<ExtsBaseData> selectExtsMeta(DBAccess dba, String extsName) throws SQLException
    {
        LogUtil.log("数据查询：后缀详细信息数据查询 － " + extsName);

        // 初始化
        dba.reset();

        // 查询表格
        dba.addTable(DB0008.TABLE_EXTSDATA);

        // 查询字段
        dba.addColumn(DB0008.EXTSDATA_ACSTIMES);
        dba.addColumn(DB0008.EXTSDATA_PLATINDX);
        dba.addColumn(DB0008.EXTSDATA_XCPUBITS);
        dba.addColumn(DB0008.EXTSDATA_EXTSINDX);
        dba.addColumn(DB0008.EXTSDATA_CORPINDX);
        dba.addColumn(DB0008.EXTSDATA_SOFTINDX);
        dba.addColumn(DB0008.EXTSDATA_FILEINDX);
        dba.addColumn(DB0008.EXTSDATA_DESPINDX);
        dba.addColumn(DB0008.EXTSDATA_ASOCINDX);
        dba.addColumn(DB0008.EXTSDATA_MIMEINDX);
        dba.addColumn(DB0008.EXTSDATA_TYPEINDX);
        dba.addColumn(DB0008.EXTSDATA_IDIOINDX);
        dba.addColumn(DB0008.EXTSDATA_UPDTDATE);
        dba.addColumn(DB0008.EXTSDATA_MAKEDATE);
        dba.addColumn(DB0008.EXTSDATA_IDIOMARK);

        // 关联条件
        dba.addWhere(DB0008.EXTSDATA_EXTSINDX, HashUtil.digest(extsName.substring(1), false));

        List<ExtsBaseData> extsList = new ArrayList<ExtsBaseData>();
        ExtsBaseData extsMeta;

        // 结果集处理
        ResultSet rest = dba.executeSelect();

        while (rest.next())
        {
            extsMeta = new ExtsBaseData();
            extsMeta.wInit();

            extsMeta.setExtsName(extsName);
            extsMeta.setAcsTimes(rest.getInt(DB0008.EXTSDATA_ACSTIMES));
            extsMeta.setPlatIndx(rest.getInt(DB0008.EXTSDATA_PLATINDX));
            extsMeta.setArchBits(rest.getInt(DB0008.EXTSDATA_XCPUBITS));
            extsMeta.setExtsIndx(rest.getString(DB0008.EXTSDATA_EXTSINDX));
            extsMeta.setCorpIndx(rest.getString(DB0008.EXTSDATA_CORPINDX));
            extsMeta.setSoftIndx(rest.getString(DB0008.EXTSDATA_SOFTINDX));
            extsMeta.setFileIndx(rest.getString(DB0008.EXTSDATA_FILEINDX));
            extsMeta.setDespIndx(rest.getString(DB0008.EXTSDATA_DESPINDX));
            extsMeta.setAsocIndx(rest.getString(DB0008.EXTSDATA_ASOCINDX));
            extsMeta.setMimeIndx(rest.getString(DB0008.EXTSDATA_MIMEINDX));
            extsMeta.setTypeIndx(rest.getString(DB0008.EXTSDATA_TYPEINDX));
            extsMeta.setIdioIndx(rest.getString(DB0008.EXTSDATA_IDIOINDX));
            extsMeta.setUpdtDate(rest.getDate(DB0008.EXTSDATA_UPDTDATE));
            extsMeta.setMakeDate(rest.getDate(DB0008.EXTSDATA_MAKEDATE));
            extsMeta.setIdioMark(rest.getString(DB0008.EXTSDATA_IDIOMARK));

            extsList.add(extsMeta);
        }
        rest.close();

        return extsList;
    }

    /**
     * 查询对应于某一特定软件的后缀详细信息
     * 
     * @param dba
     * @param baseMeta
     * @return
     * @throws SQLException
     */
    public static ExtsBaseData selectExtsMeta(DBAccess dba, BaseData baseMeta) throws SQLException
    {
        LogUtil.log("数据查询：特定软件的后缀详细信息数据查询 － " + baseMeta.getExtsIndx() + "、" + baseMeta.getSoftIndx());

        // 初始化
        dba.reset();

        // 查询表格
        dba.addTable(DB0008.TABLE_EXTSDATA);

        // 查询字段
        dba.addColumn(DB0008.EXTSDATA_ACSTIMES);
        dba.addColumn(DB0008.EXTSDATA_PLATINDX);
        dba.addColumn(DB0008.EXTSDATA_XCPUBITS);
        dba.addColumn(DB0008.EXTSDATA_EXTSINDX);
        dba.addColumn(DB0008.EXTSDATA_CORPINDX);
        dba.addColumn(DB0008.EXTSDATA_SOFTINDX);
        dba.addColumn(DB0008.EXTSDATA_FILEINDX);
        dba.addColumn(DB0008.EXTSDATA_DESPINDX);
        dba.addColumn(DB0008.EXTSDATA_ASOCINDX);
        dba.addColumn(DB0008.EXTSDATA_MIMEINDX);
        dba.addColumn(DB0008.EXTSDATA_TYPEINDX);
        dba.addColumn(DB0008.EXTSDATA_IDIOINDX);
        dba.addColumn(DB0008.EXTSDATA_UPDTDATE);
        dba.addColumn(DB0008.EXTSDATA_MAKEDATE);
        dba.addColumn(DB0008.EXTSDATA_IDIOMARK);

        // 关联条件
        dba.addWhere(DB0008.EXTSDATA_EXTSINDX, baseMeta.getExtsIndx());
        dba.addWhere(DB0008.EXTSDATA_SOFTINDX, baseMeta.getSoftIndx());

        ExtsBaseData extsMeta = new ExtsBaseData();
        extsMeta.wInit();

        // 结果集处理
        ResultSet rest = dba.executeSelect();

        if (rest.next())
        {
            extsMeta.setExtsName(baseMeta.getExtsName());
            extsMeta.setAcsTimes(rest.getInt(DB0008.EXTSDATA_ACSTIMES));
            extsMeta.setPlatIndx(rest.getInt(DB0008.EXTSDATA_PLATINDX));
            extsMeta.setArchBits(rest.getInt(DB0008.EXTSDATA_XCPUBITS));
            extsMeta.setExtsIndx(rest.getString(DB0008.EXTSDATA_EXTSINDX));
            extsMeta.setCorpIndx(rest.getString(DB0008.EXTSDATA_CORPINDX));
            extsMeta.setSoftIndx(rest.getString(DB0008.EXTSDATA_SOFTINDX));
            extsMeta.setFileIndx(rest.getString(DB0008.EXTSDATA_FILEINDX));
            extsMeta.setDespIndx(rest.getString(DB0008.EXTSDATA_DESPINDX));
            extsMeta.setAsocIndx(rest.getString(DB0008.EXTSDATA_ASOCINDX));
            extsMeta.setMimeIndx(rest.getString(DB0008.EXTSDATA_MIMEINDX));
            extsMeta.setTypeIndx(rest.getString(DB0008.EXTSDATA_TYPEINDX));
            extsMeta.setIdioIndx(rest.getString(DB0008.EXTSDATA_IDIOINDX));
            extsMeta.setUpdtDate(rest.getDate(DB0008.EXTSDATA_UPDTDATE));
            extsMeta.setMakeDate(rest.getDate(DB0008.EXTSDATA_MAKEDATE));
            extsMeta.setIdioMark(rest.getString(DB0008.EXTSDATA_IDIOMARK));
        }
        rest.close();

        return extsMeta;
    }

    /**
     * 同一后缀数据摘要信息查询
     * 
     * @param dba
     * @param extsName
     * @return
     * @throws SQLException
     */
    public static List<BaseData> selectBaseMeta(DBAccess dba, String extsName) throws SQLException
    {
        LogUtil.log("数据查询：同一后缀数据摘要信息查询 － " + extsName);

        // 连接初始化
        dba.reset();

        // 操作表格
        dba.addTable(DB0008.TABLE_EXTSDATA, DB0008.TABLE_SOFTDATA, DB0008.DBCS_JOIN_LEFT, DB0008.EXTSDATA_SOFTINDX,
            DB0008.SOFTDATA_SOFTINDX);

        // 操作字段
        dba.addColumn(DB0008.EXTSDATA_SOFTINDX);
        dba.addColumn(DB0008.SOFTDATA_SOFTNAME);

        // 关联条件
        String extsHash = HashUtil.digest(extsName.substring(1), false);
        dba.addWhere(DB0008.EXTSDATA_EXTSINDX, extsHash);

        List<BaseData> metaList = new ArrayList<BaseData>();

        // 结果处理
        ResultSet rest = dba.executeSelect();
        BaseData baseMeta;
        while (rest.next())
        {
            baseMeta = new BaseData();
            baseMeta.wInit();

            baseMeta.setExtsName(extsName);
            baseMeta.setExtsIndx(extsHash);
            baseMeta.setSoftIndx(rest.getString(DB0008.EXTSDATA_SOFTINDX));
            baseMeta.setSoftName(rest.getString(DB0008.SOFTDATA_SOFTNAME));

            metaList.add(baseMeta);
        }
        rest.close();

        return metaList;
    }

    /**
     * 文件魔术签名列表数据查询<br>
     * <li>软件索引为默认值时，返回所有文件签名列表；
     * <li>文件签名不为空时，返回指定软件索引索引下包含指定签名的文字（不区分大小写）的文件签名列表；
     * 
     * @param dba
     * @param userMeta
     * @return 文件名值列表：K1文件索引，K2直属软件索引，V文件签名
     * @throws SQLException
     */
    public static List<K2SV1S> selectFileMetaName(DBAccess dba, FileUserData userMeta) throws SQLException
    {
        return selectFileMetaName(dba, userMeta.getSoftIndx(), userMeta.getSignChar());
    }

    public static List<K2SV1S> selectFileMetaName(DBAccess dba, String softHash, String fileSign) throws SQLException
    {
        LogUtil.log("数据查询：文件魔术签名列表数据查询。");

        // 数据库对象初始化
        dba.reset();

        // 查询表格拼接
        dba.addTable(DB0008.TABLE_FILEDATA);

        // 查询字段拼接
        dba.addColumn(DB0008.FILEDATA_FILEINDX);
        dba.addColumn(DB0008.FILEDATA_SOFTINDX);
        dba.addColumn(DB0008.FILEDATA_SIGNCHAR);

        // 关联条件
        // 软件索引
        if (CheckUtil.isValidate(softHash) && !ConstUI.DEF_SOFTHASH.equals(softHash))
        {
            dba.addWhere(DB0008.FILEDATA_SOFTINDX, softHash);
        }
        // 文件签名
        if (CheckUtil.isValidate(fileSign))
        {
            dba.addWhere("LOWER(" + DB0008.FILEDATA_SIGNCHAR + ")", "like", "%" + fileSign.toLowerCase() + "%", true);
        }

        // 排序依据
        dba.addSort(DB0008.FILEDATA_DISPORDR, DB0008.DBCS_SORT_DESC);

        List<K2SV1S> fileList = new ArrayList<K2SV1S>();

        // 结果集处理
        ResultSet rest = dba.executeSelect();
        String k1;
        String k2;
        String v;
        while (rest.next())
        {
            k1 = rest.getString(DB0008.FILEDATA_FILEINDX);
            k2 = rest.getString(DB0008.FILEDATA_SOFTINDX);
            v = rest.getString(DB0008.FILEDATA_SIGNCHAR);
            if (ConstUI.DEF_FILEHASH.equals(k1))
            {
                fileList.add(0, new K2SV1S(k1, k2, v));
            }
            else
            {
                fileList.add(new K2SV1S(k1, k2, v));
            }
        }
        rest.close();

        return fileList;
    }

    /**
     * 文件详细信息查询
     * 
     * @param dba
     * @param fileHash
     * @return
     * @throws SQLException
     */
    public static FileBaseData selectFileMetaInfo(DBAccess dba, String fileHash) throws SQLException
    {
        LogUtil.log("数据查询：按文件索引查询文件详细信息 － " + fileHash);

        // 数据库对象初始化
        dba.reset();

        // 查询表格拼接
        dba.addTable(DB0008.TABLE_FILEDATA, DB0008.TABLE_SOFTDATA, DB0008.DBCS_JOIN_LEFT, DB0008.FILEDATA_SOFTINDX,
            DB0008.SOFTDATA_SOFTINDX);

        // 查询字段拼接
        dba.addColumn(DB0008.FILEDATA_FILEINDX);
        dba.addColumn(DB0008.FILEDATA_SOFTINDX);
        dba.addColumn(DB0008.SOFTDATA_SOFTNAME);
        dba.addColumn(DB0008.FILEDATA_FILEICON);
        dba.addColumn(DB0008.FILEDATA_SIGNCHAR);
        dba.addColumn(DB0008.FILEDATA_SIGNCODE);
        dba.addColumn(DB0008.FILEDATA_MSOFFSET);
        dba.addColumn(DB0008.FILEDATA_CIPHERSN);
        dba.addColumn(DB0008.FILEDATA_HEADDATA);
        dba.addColumn(DB0008.FILEDATA_FOOTDATA);
        dba.addColumn(DB0008.FILEDATA_FORMATDT);
        dba.addColumn(DB0008.FILEDATA_FILEDESP);
        dba.addColumn(DB0008.FILEDATA_UPDTDATE);
        dba.addColumn(DB0008.FILEDATA_MAKEDATE);

        // 查询关联条件
        dba.addWhere(DB0008.FILEDATA_FILEINDX, fileHash);
        dba.addWhere(DB0008.FILEDATA_SOFTINDX, DB0008.SOFTDATA_SOFTINDX, false);

        // 结果数据对象
        FileBaseData baseMeta = new FileBaseData();
        baseMeta.wInit();

        // 执行数据查询
        ResultSet rest = dba.executeSelect();

        // 查询结果集处理
        if (rest.next())
        {
            baseMeta.setMetaExist(true);

            baseMeta.setFileIndx(rest.getString(DB0008.FILEDATA_FILEINDX));
            baseMeta.setSoftIndx(rest.getString(DB0008.FILEDATA_SOFTINDX));
            baseMeta.setSoftName(rest.getString(DB0008.SOFTDATA_SOFTNAME));
            baseMeta.setFileIcon(rest.getString(DB0008.FILEDATA_FILEICON));
            baseMeta.setSignChar(rest.getString(DB0008.FILEDATA_SIGNCHAR));
            baseMeta.setSignCode(rest.getString(DB0008.FILEDATA_SIGNCODE));
            baseMeta.setMsOffset(rest.getLong(DB0008.FILEDATA_MSOFFSET));
            baseMeta.setCipherSn(rest.getString(DB0008.FILEDATA_CIPHERSN));
            baseMeta.setHeadData(rest.getString(DB0008.FILEDATA_HEADDATA));
            baseMeta.setFootData(rest.getString(DB0008.FILEDATA_FOOTDATA));
            baseMeta.setFormatDt(rest.getString(DB0008.FILEDATA_FORMATDT));
            baseMeta.setFileDesp(rest.getString(DB0008.FILEDATA_FILEDESP));
            baseMeta.setUpdtDate(rest.getDate(DB0008.FILEDATA_UPDTDATE));
            baseMeta.setMakeDate(rest.getDate(DB0008.FILEDATA_MAKEDATE));
        }
        // 数据集关闭
        rest.close();

        // 显示排序更新
        updateDispOrdr(dba, DB0008.TABLE_FILEDATA, DB0008.FILEDATA_DISPORDR, DB0008.FILEDATA_FILEINDX, baseMeta
            .getFileIndx());

        return baseMeta;
    }

    /**
     * 人员邮件列表数据查询
     * 
     * @param dba
     * @return
     * @throws SQLException
     */
    public static List<K2SV1S> selectIdioMetaName(DBAccess dba, IdioUserData userMeta) throws SQLException
    {
        return selectIdioMetaName(dba, userMeta.getIdioMail());
    }

    /**
     * 人员邮件列表数据查询
     * 
     * @param dba
     * @param idioMail
     * @return 用户名值列表：K1人员索引，K2空余，V用户邮件
     * @throws SQLException
     */
    public static List<K2SV1S> selectIdioMetaName(DBAccess dba, String idioMail) throws SQLException
    {
        LogUtil.log("数据查询：人员邮件列表数据查询。");

        // 数据库对象初始化
        dba.reset();

        // 查询表格拼接
        dba.addTable(DB0008.TABLE_IDIODATA);

        // 查询字段拼接
        dba.addColumn(DB0008.IDIODATA_IDIOINDX);
        dba.addColumn(DB0008.IDIODATA_IDIOMAIL);
        dba.addColumn(DB0008.IDIODATA_NICKNAME);

        // 关联条件：邮件
        if (CheckUtil.isValidate(idioMail))
        {
            dba.addWhere("LOWER(" + DB0008.IDIODATA_IDIOMAIL + ")", "like", "%" + idioMail.toLowerCase() + "%", true);
        }

        // 排序依据
        dba.addSort(DB0008.IDIODATA_DISPORDR, DB0008.DBCS_SORT_DESC);

        List<K2SV1S> idioList = new ArrayList<K2SV1S>();
        String k1;
        String k2;
        String v;

        // 结果集处理
        ResultSet rest = dba.executeSelect();
        while (rest.next())
        {
            k1 = rest.getString(DB0008.IDIODATA_IDIOINDX);
            k2 = rest.getString(DB0008.IDIODATA_IDIOMAIL);
            v = rest.getString(DB0008.IDIODATA_NICKNAME);
            if (ConstUI.DEF_IDIOHASH.equals(k1))
            {
                idioList.add(0, new K2SV1S(k1, k2, v));
            }
            else
            {
                idioList.add(new K2SV1S(k1, k2, v));
            }
        }
        rest.close();

        return idioList;
    }

    /**
     * 人员详细信息查询
     * 
     * @param dba
     * @param userMeta
     * @return
     * @throws SQLException
     */
    public static IdioBaseData selectIdioMetaInfo(DBAccess dba, String idioHash) throws SQLException
    {
        LogUtil.log("数据查询：按索引查询人员详细信息 － " + idioHash);

        // 数据库对象初始化
        dba.reset();

        // 查询表格拼接
        dba.addTable(DB0008.TABLE_IDIODATA);

        // 查询字段拼接
        dba.addColumn(DB0008.IDIODATA_IDIOINDX);
        dba.addColumn(DB0008.IDIODATA_IDIOLOGO);
        dba.addColumn(DB0008.IDIODATA_IDIOMAIL);
        dba.addColumn(DB0008.IDIODATA_NICKNAME);
        dba.addColumn(DB0008.IDIODATA_IDIOSIGN);
        dba.addColumn(DB0008.IDIODATA_HOMEPAGE);
        dba.addColumn(DB0008.IDIODATA_IDIODESP);
        dba.addColumn(DB0008.IDIODATA_UPDTDATE);
        dba.addColumn(DB0008.IDIODATA_MAKEDATE);

        // 查询关联条件
        dba.addWhere(DB0008.IDIODATA_IDIOINDX, idioHash);

        // 结果数据对象
        IdioBaseData baseMeta = new IdioBaseData();
        baseMeta.wInit();

        // 执行数据查询
        ResultSet rest = dba.executeSelect();

        // 查询结果集处理
        if (rest.next())
        {
            baseMeta.setMetaExist(true);

            baseMeta.setIdioIndx(rest.getString(DB0008.IDIODATA_IDIOINDX));
            baseMeta.setIdioLogo(rest.getString(DB0008.IDIODATA_IDIOLOGO));
            baseMeta.setIdioMail(rest.getString(DB0008.IDIODATA_IDIOMAIL));
            baseMeta.setNickName(rest.getString(DB0008.IDIODATA_NICKNAME));
            baseMeta.setIdioSign(rest.getString(DB0008.IDIODATA_IDIOSIGN));
            baseMeta.setHomePage(rest.getString(DB0008.IDIODATA_HOMEPAGE));
            baseMeta.setIdioDesp(rest.getString(DB0008.IDIODATA_IDIODESP));
            baseMeta.setUpdtDate(rest.getDate(DB0008.IDIODATA_UPDTDATE));
            baseMeta.setMakeDate(rest.getDate(DB0008.IDIODATA_MAKEDATE));
        }
        // 数据集关闭
        rest.close();

        // 显示排序更新
        updateDispOrdr(dba, DB0008.TABLE_IDIODATA, DB0008.IDIODATA_DISPORDR, DB0008.IDIODATA_IDIOINDX, baseMeta
            .getIdioIndx());

        return baseMeta;
    }

    /**
     * @param dba
     * @return
     * @throws SQLException
     */
    public static List<K1SV2S> selectMimeMeta(DBAccess dba) throws SQLException
    {
        return null;
    }

    /**
     * MIME类型列表数据查询
     * 
     * @param dba
     * @param mimeHash
     * @return K1：MIME索引 K2：类型索引 V：MIME名称
     * @throws SQLException
     */
    public static List<K2SV1S> selectMimeMetaName(DBAccess dba, String mimeHash, String mimeName) throws SQLException
    {
        LogUtil.log("数据查询：MIME类型列表数据查询。");

        // 数据库对象初始化
        dba.reset();

        // 查询表格拼接
        dba.addTable(DB0008.TABLE_MIMEDATA);

        // 查询字段拼接
        dba.addColumn(DB0008.MIMEDATA_MIMEINDX);
        dba.addColumn(DB0008.MIMEDATA_MIMETYPE);
        dba.addColumn(DB0008.MIMEDATA_MIMENAME);

        // 关联条件拼接
        if (CheckUtil.isValidate(mimeHash) && ConstUI.DEF_MIMEHASH != mimeHash)
        {
            dba.addWhere(DB0008.MIMEDATA_MIMEINDX, mimeHash);
        }
        if (CheckUtil.isValidate(mimeName))
        {
            dba.addWhere("LOWER(" + DB0008.MIMEDATA_MIMENAME + ")", "like", "%" + mimeName.toLowerCase() + "%", true);
        }

        // 排序依据
        dba.addSort(DB0008.MIMEDATA_DISPORDR, DB0008.DBCS_SORT_DESC);
        dba.addSort(DB0008.MIMEDATA_MIMENAME, DB0008.DBCS_SORT_ASC);

        List<K2SV1S> mimeList = new ArrayList<K2SV1S>();
        K2SV1S kvItem;

        // 结果集处理
        ResultSet rest = dba.executeSelect();
        while (rest.next())
        {
            kvItem = new K2SV1S();

            kvItem.setK1(rest.getString(DB0008.MIMEDATA_MIMEINDX));
            kvItem.setK2(rest.getString(DB0008.MIMEDATA_MIMETYPE));
            kvItem.setV(rest.getString(DB0008.MIMEDATA_MIMENAME));

            mimeList.add(kvItem);
        }
        rest.close();

        return mimeList;
    }

    /**
     * @param dba
     * @param mimeHash
     * @return
     * @throws SQLException
     */
    public static MimeBaseData selectMimeMetaInfo(DBAccess dba, String mimeHash, String mimeType) throws SQLException
    {
        LogUtil.log("数据查询：MIME类型名称列表数据查询。");

        // 初始化
        dba.reset();

        // 操作表格
        dba.addTable(DB0008.TABLE_MIMEDATA);

        // 查询字段
        dba.addColumn(DB0008.MIMEDATA_MIMETYPE);
        dba.addColumn(DB0008.MIMEDATA_MIMENAME);
        dba.addColumn(DB0008.MIMEDATA_MIMEDESP);

        // 关联条件
        dba.addWhere(DB0008.MIMEDATA_MIMEINDX, mimeHash);
        if (CheckUtil.isValidate(mimeType))
        {
            dba.addWhere(DB0008.MIMEDATA_MIMETYPE, mimeType);
        }

        // 排序依据
        dba.addSort(DB0008.MIMEDATA_DISPORDR, DB0008.DBCS_SORT_DESC);
        dba.addSort(DB0008.MIMEDATA_MIMENAME, DB0008.DBCS_SORT_ASC);

        MimeBaseData baseMeta = new MimeBaseData();
        baseMeta.wInit();
        baseMeta.setMimeIndx(mimeHash);
        K1SV2S kvItem;

        ResultSet rest = dba.executeSelect();
        while (rest.next())
        {
            kvItem = new K1SV2S();
            kvItem.setK(rest.getString(DB0008.MIMEDATA_MIMETYPE));
            kvItem.setV1(rest.getString(DB0008.MIMEDATA_MIMENAME));
            kvItem.setV2(rest.getString(DB0008.MIMEDATA_MIMEDESP));
            baseMeta.addMimeData(kvItem);
        }
        rest.close();

        return baseMeta;
    }

    /**
     * 国别信息列表数据查询
     * 
     * @param dba
     * @return K1：国别索引；K2：国别全称；V：国别简称
     * @throws SQLException
     */
    public static List<K2SV1S> selectNatnMetaName(DBAccess dba) throws SQLException
    {
        LogUtil.log("数据查询：国别信息列表数据查询。");

        // 数据库对象初始化
        dba.reset();

        // 查询表格拼接
        dba.addTable(DB0008.TABLE_NATNDATA);

        // 查询字段拼接
        dba.addColumn(DB0008.NATNDATA_NATNINDX);
        dba.addColumn(DB0008.NATNDATA_NATNFLNM);
        dba.addColumn(DB0008.NATNDATA_NATNSLNM);

        // 关联条件拼接
        dba.addWhere(DB0008.NATNDATA_LANGINDX, RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_LANG_ID));

        // 排序依据
        dba.addSort(DB0008.NATNDATA_DISPORDR, DB0008.DBCS_SORT_ASC);

        List<K2SV1S> natnList = new ArrayList<K2SV1S>();

        // 结果集处理
        ResultSet rest = dba.executeSelect();
        String k1;
        String k2;
        String v;
        while (rest.next())
        {
            k1 = rest.getString(DB0008.NATNDATA_NATNINDX);
            k2 = rest.getString(DB0008.NATNDATA_NATNFLNM);
            v = rest.getString(DB0008.NATNDATA_NATNSLNM);
            if (ConstUI.DEF_NATNHASH.equals(k1))
            {
                natnList.add(0, new K2SV1S(k1, k2, v));
            }
            else
            {
                natnList.add(new K2SV1S(k1, k2, v));
            }
        }
        rest.close();

        return natnList;
    }

    /**
     * 国别详细信息查询
     * 
     * @param dba
     * @param natnIndx
     * @throws SQLException
     */
    public static NatnBaseData selectNatnMetaInfo(DBAccess dba, String natnIndx) throws SQLException
    {
        LogUtil.log("数据查询：国别详细信息查询 - " + natnIndx);

        // 数据库对象初始化
        dba.reset();

        // 查询表格拼接
        dba.addTable(DB0008.TABLE_NATNDATA);

        // 查询字段拼接
        dba.addColumn(DB0008.NATNDATA_NATNINDX);
        dba.addColumn(DB0008.NATNDATA_NATNFLNM);
        dba.addColumn(DB0008.NATNDATA_NATNSLNM);

        // 关联条件拼接
        dba.addWhere(DB0008.NATNDATA_NATNINDX, natnIndx);
        dba.addWhere(DB0008.NATNDATA_LANGINDX, RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_LANG_ID));

        NatnBaseData baseMeta = new NatnBaseData();
        baseMeta.wInit();

        // 查询结果处理
        ResultSet rest = dba.executeSelect();
        if (rest.next())
        {
            baseMeta.setNatnIndx(rest.getString(DB0008.NATNDATA_NATNINDX));
            baseMeta.setNatnFlNm(rest.getString(DB0008.NATNDATA_NATNFLNM));
            baseMeta.setNatnSlNm(rest.getString(DB0008.NATNDATA_NATNSLNM));
        }
        rest.close();

        return baseMeta;
    }

    /**
     * 软件名称列表查寻
     * 
     * @param dba
     * @param corpHash 查询与此公司索引相关的软件列表信息，当公司索引为默认值时，查询所有软件信息
     * @return
     * @throws SQLException
     */
    public static List<K2SV1S> selectSoftMetaName(DBAccess dba, SoftUserData userMeta) throws SQLException
    {
        return selectSoftMetaName(dba, userMeta.getCorpIndx(), userMeta.getSoftName());
    }

    /**
     * 软件名称列表查寻
     * 
     * @param dba
     * @param corpHash
     * @param softName
     * @return 软件名值列表：K1软件索引，K2直属公司索引，V软件名称
     * @throws SQLException
     */
    public static List<K2SV1S> selectSoftMetaName(DBAccess dba, String corpHash, String softName) throws SQLException
    {
        LogUtil.log("数据查询：软件信息软件名称列表数据查询。");

        // 数据库对象初始化
        dba.reset();

        // 查询表格拼接
        dba.addTable(DB0008.TABLE_SOFTDATA);

        // 查询字段拼接
        dba.addColumn(DB0008.SOFTDATA_SOFTINDX);
        dba.addColumn(DB0008.SOFTDATA_CORPINDX);
        dba.addColumn(DB0008.SOFTDATA_SOFTNAME);

        // 关联条件拼接
        // 公司索引
        if (CheckUtil.isValidate(corpHash) && !ConstUI.DEF_CORPHASH.equals(corpHash))
        {
            dba.addWhere(DB0008.SOFTDATA_CORPINDX, corpHash);
        }
        // 软件名称
        if (CheckUtil.isValidate(softName))
        {
            dba.addWhere("LOWER(" + DB0008.SOFTDATA_SOFTNAME + ")", "like", "%" + softName.toLowerCase() + "%", true);
        }

        // 排序依据
        dba.addSort(DB0008.SOFTDATA_DISPORDR, DB0008.DBCS_SORT_DESC);

        List<K2SV1S> softList = new ArrayList<K2SV1S>();

        // 结果集处理
        ResultSet rest = dba.executeSelect();
        String k1;
        String k2;
        String v;

        while (rest.next())
        {
            k1 = rest.getString(DB0008.SOFTDATA_SOFTINDX);
            k2 = rest.getString(DB0008.SOFTDATA_CORPINDX);
            v = rest.getString(DB0008.SOFTDATA_SOFTNAME);
            if (ConstUI.DEF_SOFTHASH.equals(k1))
            {
                softList.add(0, new K2SV1S(k1, k2, v));
            }
            else
            {
                softList.add(new K2SV1S(k1, k2, v));
            }
        }
        rest.close();

        return softList;
    }

    /**
     * 软件详细信息查询
     * 
     * @param dba
     * @param softHash
     * @return
     * @throws SQLException
     */
    public static SoftBaseData selectSoftMetaInfo(DBAccess dba, String softHash) throws SQLException
    {
        LogUtil.log("数据查询：指定软件索引的软件信息数据查询 － " + softHash);

        // 数据库对象初始化
        dba.reset();

        // 查询表格拼接
        dba.addTable(DB0008.TABLE_SOFTDATA, DB0008.TABLE_CORPDATA, DB0008.DBCS_JOIN_LEFT, DB0008.SOFTDATA_CORPINDX,
            DB0008.CORPDATA_CORPINDX);

        // 查询字段拼接
        dba.addColumn(DB0008.SOFTDATA_SOFTINDX);
        dba.addColumn(DB0008.SOFTDATA_CORPINDX);
        dba.addColumn(DB0008.CORPDATA_CORPLCNM);
        dba.addColumn(DB0008.SOFTDATA_SOFTICON);
        dba.addColumn(DB0008.SOFTDATA_SOFTNAME);
        dba.addColumn(DB0008.SOFTDATA_SOFTMAIL);
        dba.addColumn(DB0008.SOFTDATA_SOFTSITE);
        dba.addColumn(DB0008.SOFTDATA_EXTSLIST);
        dba.addColumn(DB0008.SOFTDATA_SOFTDESP);
        dba.addColumn(DB0008.SOFTDATA_UPDTDATE);
        dba.addColumn(DB0008.SOFTDATA_MAKEDATE);

        // 查询关联条件
        dba.addWhere(DB0008.SOFTDATA_SOFTINDX, softHash);
        dba.addWhere(DB0008.SOFTDATA_CORPINDX, DB0008.CORPDATA_CORPINDX, false);

        // 结果数据对象
        SoftBaseData baseMeta = new SoftBaseData();
        baseMeta.wInit();

        // 执行数据查询
        ResultSet rest = dba.executeSelect();

        // 查询结果集处理
        if (rest.next())
        {
            baseMeta.setMetaExist(true);

            baseMeta.setSoftIndx(rest.getString(DB0008.SOFTDATA_SOFTINDX));
            baseMeta.setCorpIndx(rest.getString(DB0008.SOFTDATA_CORPINDX));
            baseMeta.setCorpName(rest.getString(DB0008.CORPDATA_CORPLCNM));
            baseMeta.setSoftIcon(rest.getString(DB0008.SOFTDATA_SOFTICON));
            baseMeta.setSoftName(rest.getString(DB0008.SOFTDATA_SOFTNAME));
            baseMeta.setSoftMail(rest.getString(DB0008.SOFTDATA_SOFTMAIL));
            baseMeta.setSoftSite(rest.getString(DB0008.SOFTDATA_SOFTSITE));
            baseMeta.setExtsList(rest.getString(DB0008.SOFTDATA_EXTSLIST));
            baseMeta.setSoftDesp(rest.getString(DB0008.SOFTDATA_SOFTDESP));
            baseMeta.setUpdtDate(rest.getDate(DB0008.SOFTDATA_UPDTDATE));
            baseMeta.setMakeDate(rest.getDate(DB0008.SOFTDATA_MAKEDATE));
        }
        // 数据集关闭
        rest.close();

        // 显示排序更新
        updateDispOrdr(dba, DB0008.TABLE_SOFTDATA, DB0008.SOFTDATA_DISPORDR, DB0008.SOFTDATA_SOFTINDX, baseMeta
            .getSoftIndx());

        return baseMeta;
    }

    /**
     * 所属类别数据查询
     * 
     * @param dba
     * @return
     * @throws SQLException
     */
    public static List<K1SV2S> selectTypeMetaName(DBAccess dba) throws SQLException
    {
        LogUtil.log("数据查询：所属类别名称列表查询！");

        // 数据库对象初始化
        dba.reset();

        // 查询表格拼接
        dba.addTable(DB0008.TABLE_TYPEDATA);

        // 查询字段拼接
        dba.addColumn(DB0008.TYPEDATA_TYPEINDX);
        dba.addColumn(DB0008.TYPEDATA_TYPENAME);
        dba.addColumn(DB0008.TYPEDATA_TYPEDESP);

        // 关联条件拼接
        dba.addWhere(DB0008.TYPEDATA_SYSTEMID, "" + PrpCons.P3010000_I, false);

        // 排序依据拼接
        dba.addSort(DB0008.TYPEDATA_DISPORDR, DB0008.DBCS_SORT_DESC);

        List<K1SV2S> typeList = new ArrayList<K1SV2S>();

        // 结果数据集处理
        ResultSet rest = dba.executeSelect();
        String k;
        String v1;
        String v2;

        while (rest.next())
        {
            k = rest.getString(DB0008.TYPEDATA_TYPEINDX);
            v1 = rest.getString(DB0008.TYPEDATA_TYPENAME);
            v2 = rest.getString(DB0008.TYPEDATA_TYPEDESP);

            if (ConstUI.DEF_TYPEHASH.equals(k))
            {
                typeList.add(0, new K1SV2S(k, v1, v2));
            }
            else
            {
                typeList.add(new K1SV2S(k, v1, v2));
            }
        }
        rest.close();

        return typeList;
    }

    /**
     * @param dba
     * @param typeIndx
     * @param systemID
     * @return
     * @throws SQLException
     */
    public static TypeBaseData selectTypeMetaInfo(DBAccess dba, String typeIndx, int systemID) throws SQLException
    {
        LogUtil.log("数据查询：所属类别详细信息查询！");

        // 数据库对象初始化
        dba.reset();

        // 查询表格拼接
        dba.addTable(DB0008.TABLE_TYPEDATA);

        // 查询字段拼接
        dba.addColumn(DB0008.TYPEDATA_TYPENAME);
        dba.addColumn(DB0008.TYPEDATA_TYPEDESP);

        // 关联条件拼接
        dba.addWhere(DB0008.TYPEDATA_SYSTEMID, "" + PrpCons.P3010000_I, false);
        dba.addWhere(DB0008.TYPEDATA_TYPEINDX, typeIndx);

        TypeBaseData typeMeta = new TypeBaseData();
        typeMeta.wInit();
        typeMeta.setSystemID(systemID);
        typeMeta.setTypeIndx(typeIndx);

        // 结果数据集处理
        ResultSet rest = dba.executeSelect();
        if (rest.next())
        {
            typeMeta.setTypeName(rest.getString(DB0008.TYPEDATA_TYPENAME));
            typeMeta.setTypeDesp(rest.getString(DB0008.TYPEDATA_TYPEDESP));
        }
        rest.close();

        return typeMeta;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 数据更新区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 备选软件数据更新
     * 
     * @param dba
     * @param asocMeta
     * @throws SQLException
     */
    public static void updateAsocMeta(DBAccess dba, AsocUserData asocMeta) throws SQLException
    {
        LogUtil.log("数据更新：备选软件数据更新　－　" + asocMeta.getAsocIndx());

        // 字符串转换
        asocMeta.t2db();

        // SQL语句初始化
        dba.reset();

        // 操作表格
        dba.addTable(DB0008.TABLE_ASOCDATA);

        // 公共字段
        dba.addParam(DB0008.ASOCDATA_ASOCDESP, asocMeta.getAsocDesp());
        dba.addParam(DB0008.ASOCDATA_UPDTDATE, DB0008.DBCS_DATE_NOW, false);

        // 数据更新
        if (asocMeta.isUpdate())
        {
            // 默认值
            if (ConstUI.DEF_ASOCHASH.equals(asocMeta.getAsocIndx()))
            {
                return;
            }

            // 更新字段
            dba.addParam(DB0008.ASOCDATA_SOFTINDX, asocMeta.getSoftIndx());

            // 关联条件
            dba.addWhere(DB0008.ASOCDATA_ASOCINDX, asocMeta.getAsocIndx());
            dba.addWhere(DB0008.ASOCDATA_SOFTINDX, asocMeta.getSoftIndx());

            // 数据更新
            dba.executeUpdate();
        }
        // 数据插入
        else
        {
            // 操作字段
            dba.addParam(DB0008.ASOCDATA_DISPORDR, "0", false);
            dba.addParam(DB0008.ASOCDATA_ASOCINDX, asocMeta.getAsocIndx());
            dba.addParam(DB0008.ASOCDATA_SOFTINDX, asocMeta.getSoftIndx());
            dba.addParam(DB0008.ASOCDATA_MAKEDATE, DB0008.DBCS_DATE_NOW, false);

            // 数据插入
            dba.executeInsert();
        }
    }

    /**
     * 公司信息数据更新
     * 
     * @param dba
     * @param corpMeta
     * @throws SQLException
     */
    public static void updateCorpMeta(DBAccess dba, CorpUserData corpMeta) throws SQLException
    {
        LogUtil.log("数据更新：公司信息数据更新　－　" + corpMeta.getCorpIndx());

        // 字符串转换
        corpMeta.t2db();

        // 新增数据时，公司索引总是为默认值，此处不能加判断为默认即返回

        // SQL语句初始化
        dba.reset();

        // 更新表格
        dba.addTable(DB0008.TABLE_CORPDATA);

        // 公共字段设置
        dba.addParam(DB0008.CORPDATA_NATNINDX, corpMeta.getNatnIndx());// 国别索引
        dba.addParam(DB0008.CORPDATA_CORPLOGO, corpMeta.getCorpLogo());// 公司徵标
        dba.addParam(DB0008.CORPDATA_CORPLCNM, corpMeta.getCorpLcNm());// 本语名称
        dba.addParam(DB0008.CORPDATA_CORPENNM, corpMeta.getCorpEnNm());// 英语名称
        dba.addParam(DB0008.CORPDATA_CORPSITE, corpMeta.getCorpSite());// 公司网站
        dba.addParam(DB0008.CORPDATA_CORPDESP, corpMeta.getCorpDesp());// 相关说明
        dba.addParam(DB0008.CORPDATA_UPDTDATE, DB0008.DBCS_DATE_NOW, false);// 更新时间

        // 数据更新
        if (corpMeta.isUpdate())
        {
            // 默认值
            if (ConstUI.DEF_CORPHASH.equals(corpMeta.getCorpIndx()))
            {
                return;
            }

            // 更新条件
            dba.addWhere(DB0008.CORPDATA_CORPINDX, corpMeta.getCorpIndx());// 文件索引

            // 数据更新
            dba.executeUpdate();
        }
        // 数据插入
        else
        {
            // 公司索引
            if (corpMeta.getCorpIndx().length() < 2)
            {
                corpMeta.setCorpIndx(HashUtil.getCurrTimeHex(false));
            }

            // 操作字段
            dba.addParam(DB0008.CORPDATA_DISPORDR, "0");// 显示排序
            dba.addParam(DB0008.CORPDATA_CORPINDX, corpMeta.getCorpIndx());// 文件索引
            dba.addParam(DB0008.CORPDATA_MAKEDATE, DB0008.DBCS_DATE_NOW, false);// 创建时间

            // 数据插入
            dba.executeInsert();
        }
    }

    /**
     * 描述数据更新
     * 
     * @param dba
     * @param despMeta
     * @throws SQLException
     */
    public static void updateDespMeta(DBAccess dba, DespUserData despMeta) throws SQLException
    {
        LogUtil.log("数据更新：描述数据更新 － " + despMeta.getDespIndx());

        // 字符串转换
        despMeta.t2db();

        // 初始化
        dba.reset();

        // 操作表格
        dba.addTable(DB0008.TABLE_DESPDATA);

        // 操作字段
        dba.addParam(DB0008.DESPDATA_EXTSDESP, despMeta.getExtsDesp());
        dba.addParam(DB0008.DESPDATA_IDIOMARK, despMeta.getIdioMark());
        dba.addParam(DB0008.DESPDATA_UPDTDATE, DB0008.DBCS_DATE_NOW, false);

        // 数据更新状态：进行数据的更新操作
        if (despMeta.isUpdate())
        {
            // 默认值
            if (ConstUI.DEF_DESPHASH.equals(despMeta.getDespIndx()))
            {
                return;
            }

            // 关联条件
            dba.addWhere(DB0008.DESPDATA_DESPINDX, despMeta.getDespIndx());
            dba.addWhere(DB0008.DESPDATA_LANGINDX, despMeta.getLangIndx());

            // 执行数据更新
            dba.executeUpdate();
        }
        // 数据新增状态：进行数据的新增操作
        else
        {
            // 操作字段
            dba.addParam(DB0008.DESPDATA_DESPINDX, despMeta.getDespIndx());
            dba.addParam(DB0008.DESPDATA_LANGINDX, despMeta.getLangIndx());
            dba.addParam(DB0008.DESPDATA_MAKEDATE, DB0008.DBCS_DATE_NOW, false);

            // 执行数据插入
            dba.executeInsert();
        }
    }

    /**
     * 后缀信息数据更新
     * 
     * @param dba
     * @param extsMeta
     * @throws SQLException
     */
    public static void updateExtsMeta(DBAccess dba, ExtsUserData extsMeta) throws SQLException
    {
        LogUtil.log("数据更新:后缀信息数据更新 － " + extsMeta.getExtsName());

        // 字符串转换
        extsMeta.t2db();

        String extsName = extsMeta.getExtsName().substring(1);
        String extsIndx = HashUtil.digest(extsName, false);

        // 数据初始化
        dba.reset();

        // 操作表格
        dba.addTable(DB0008.TABLE_EXTSDATA);

        // 操作字段
        dba.addParam(DB0008.EXTSDATA_PLATINDX, "" + extsMeta.getPlatIndx(), false);
        dba.addParam(DB0008.EXTSDATA_XCPUBITS, "" + extsMeta.getArchBits(), false);
        dba.addParam(DB0008.EXTSDATA_CORPINDX, extsMeta.getCorpIndx());
        dba.addParam(DB0008.EXTSDATA_SOFTINDX, extsMeta.getSoftIndx());
        dba.addParam(DB0008.EXTSDATA_FILEINDX, extsMeta.getFileIndx());
        dba.addParam(DB0008.EXTSDATA_TYPEINDX, extsMeta.getTypeIndx());
        dba.addParam(DB0008.EXTSDATA_IDIOINDX, extsMeta.getIdioIndx());
        dba.addParam(DB0008.EXTSDATA_IDIOMARK, extsMeta.getIdioMark());
        dba.addParam(DB0008.EXTSDATA_UPDTDATE, DB0008.DBCS_DATE_NOW, false);

        // 数据更新状态，进行数据的更新操作
        if (extsMeta.isUpdate())
        {
            dba.addWhere(DB0008.EXTSDATA_EXTSINDX, extsIndx);
            dba.addWhere(DB0008.EXTSDATA_SOFTINDX, extsMeta.getSoftIndx_O());

            dba.executeUpdate();
        }
        // 数据新增状态，进行数据的插入操作
        else
        {
            String currTime = HashUtil.getCurrTimeHex(false);

            dba.addParam(DB0008.EXTSDATA_EXTSINDX, extsIndx);
            dba.addParam(DB0008.EXTSDATA_EXTSNAME, extsName);
            dba.addParam(DB0008.EXTSDATA_DESPINDX, currTime);
            dba.addParam(DB0008.EXTSDATA_ASOCINDX, currTime);
            dba.addParam(DB0008.EXTSDATA_MIMEINDX, currTime);
            dba.addParam(DB0008.EXTSDATA_ACSTIMES, "0", false);
            dba.addParam(DB0008.EXTSDATA_MAKEDATE, DB0008.DBCS_DATE_NOW, false);

            dba.executeInsert();
        }
    }

    /**
     * 文件信息数据更新
     * 
     * @param dba
     * @param fileMeta
     * @throws SQLException
     */
    public static void updateFileMeta(DBAccess dba, FileUserData fileMeta) throws SQLException
    {
        LogUtil.log("数据更新：文件信息数据更新　－　" + fileMeta.getFileIndx());

        // 字符串转换
        fileMeta.t2db();

        // SQL语句初始化
        dba.reset();

        // 更新表格
        dba.addTable(DB0008.TABLE_FILEDATA);

        // 公共字段设置
        dba.addParam(DB0008.FILEDATA_SOFTINDX, fileMeta.getSoftIndx());// 直属软件
        dba.addParam(DB0008.FILEDATA_FILEICON, fileMeta.getFileIcon());// 文件图标
        dba.addParam(DB0008.FILEDATA_SIGNCHAR, fileMeta.getSignChar());// 字符签名
        dba.addParam(DB0008.FILEDATA_SIGNCODE, fileMeta.getSignCode());// 数字签名
        dba.addParam(DB0008.FILEDATA_MSOFFSET, "" + fileMeta.getMsOffset(), false);// 偏移位置
        dba.addParam(DB0008.FILEDATA_CIPHERSN, fileMeta.getCipherSn());// 加密算法
        dba.addParam(DB0008.FILEDATA_HEADDATA, fileMeta.getHeadData());// 起始数据
        dba.addParam(DB0008.FILEDATA_FOOTDATA, fileMeta.getFootData());// 结束数据
        dba.addParam(DB0008.FILEDATA_FORMATDT, fileMeta.getFormatDt());// 文档格式
        dba.addParam(DB0008.FILEDATA_FILEDESP, fileMeta.getFileDesp());// 相关说明
        dba.addParam(DB0008.FILEDATA_UPDTDATE, DB0008.DBCS_DATE_NOW, false);// 更新时间

        // 数据更新
        if (fileMeta.isUpdate())
        {
            // 默认值
            if (ConstUI.DEF_FILEHASH.equals(fileMeta.getFileIndx()))
            {
                return;
            }

            // 更新条件
            dba.addWhere(DB0008.FILEDATA_FILEINDX, fileMeta.getFileIndx());// 文件索引

            // 数据更新
            dba.executeUpdate();
        }
        // 数据插入
        else
        {
            // 个人索引
            if (fileMeta.getFileIndx().length() < 2)
            {
                fileMeta.setFileIndx(HashUtil.getCurrTimeHex(false));
            }

            dba.addParam(DB0008.FILEDATA_DISPORDR, "0");// 显示排序
            dba.addParam(DB0008.FILEDATA_FILEINDX, fileMeta.getFileIndx());// 文件索引
            dba.addParam(DB0008.FILEDATA_MAKEDATE, DB0008.DBCS_DATE_NOW, false);// 创建时间

            // 数据插入
            dba.executeInsert();
        }
    }

    /**
     * 人员信息数据更新
     * 
     * @param dba
     * @param idioMeta
     * @throws SQLException
     */
    public static void updateIdioMeta(DBAccess dba, IdioUserData idioMeta) throws SQLException
    {
        LogUtil.log("数据更新：人员信息数据更新　－　" + idioMeta.getIdioIndx());

        // 字符串转换
        idioMeta.t2db();

        // SQL语句初始化
        dba.reset();

        // 更新表格
        dba.addTable(DB0008.TABLE_IDIODATA);

        // 公共字段设置
        dba.addParam(DB0008.IDIODATA_IDIOLOGO, idioMeta.getIdioLogo());// 个性图标
        dba.addParam(DB0008.IDIODATA_IDIOMAIL, idioMeta.getIdioMail());// 邮件
        dba.addParam(DB0008.IDIODATA_NICKNAME, idioMeta.getNickName());// 昵称
        dba.addParam(DB0008.IDIODATA_IDIOSIGN, idioMeta.getIdioSign());// 个性签名
        dba.addParam(DB0008.IDIODATA_HOMEPAGE, idioMeta.getHomePage());// 个人主页
        dba.addParam(DB0008.IDIODATA_IDIODESP, idioMeta.getIdioDesp());// 相关说明
        dba.addParam(DB0008.IDIODATA_UPDTDATE, DB0008.DBCS_DATE_NOW, false);// 更新时间

        // 数据更新
        if (idioMeta.isUpdate())
        {
            // 默认值
            if (ConstUI.DEF_IDIOHASH.equals(idioMeta.getIdioIndx()))
            {
                return;
            }

            // 更新条件
            dba.addWhere(DB0008.IDIODATA_IDIOINDX, idioMeta.getIdioIndx());// 个人索引

            // 数据更新
            dba.executeUpdate();
        }
        // 数据插入
        else
        {
            // 个人索引
            if (idioMeta.getIdioIndx().length() < 2)
            {
                idioMeta.setIdioIndx(HashUtil.getCurrTimeHex(false));
            }

            dba.addParam(DB0008.IDIODATA_DISPORDR, "0");// 显示排序
            dba.addParam(DB0008.IDIODATA_IDIOINDX, idioMeta.getIdioIndx());// 个人索引
            dba.addParam(DB0008.IDIODATA_MAKEDATE, DB0008.DBCS_DATE_NOW, false);// 创建时间

            // 数据插入
            dba.executeInsert();
        }
    }

    /**
     * @param dba
     * @param mimeMeta
     * @throws SQLException
     */
    public static void updateMimeMeta(DBAccess dba, MimeUserData mimeMeta) throws SQLException
    {
        LogUtil.log("数据更新：MIME类型数据更新　－　" + mimeMeta.getMimeIndx());

        // 字符串转换
        mimeMeta.t2db();

        // SQL语句初始化
        dba.reset();

        // 操作表格
        dba.addTable(DB0008.TABLE_MIMEDATA);

        // 公共字段
        dba.addParam(DB0008.MIMEDATA_MIMENAME, mimeMeta.getMimeName());
        dba.addParam(DB0008.MIMEDATA_MIMEDESP, mimeMeta.getMimeDesp());
        dba.addParam(DB0008.MIMEDATA_UPDTDATE, DB0008.DBCS_DATE_NOW, false);

        // 数据更新
        if (mimeMeta.isUpdate())
        {
            // 默认值
            if (ConstUI.DEF_MIMEHASH.equals(mimeMeta.getMimeIndx()))
            {
                return;
            }

            // 关联条件
            dba.addWhere(DB0008.MIMEDATA_MIMEINDX, mimeMeta.getMimeIndx());
            dba.addWhere(DB0008.MIMEDATA_MIMETYPE, mimeMeta.getMimeType());

            // 数据更新
            dba.executeUpdate();
        }
        // 数据插入
        else
        {
            mimeMeta.setMimeType(HashUtil.getCurrTimeHex(false));

            // 操作字段
            dba.addParam(DB0008.MIMEDATA_DISPORDR, "0", false);
            dba.addParam(DB0008.MIMEDATA_MIMEINDX, mimeMeta.getMimeIndx());
            dba.addParam(DB0008.MIMEDATA_MIMETYPE, mimeMeta.getMimeType());
            dba.addParam(DB0008.MIMEDATA_MAKEDATE, DB0008.DBCS_DATE_NOW, false);

            // 数据插入
            dba.executeInsert();
        }
    }

    /**
     * 软件信息数据更新
     * 
     * @param dba
     * @param softMeta
     * @throws SQLException
     */
    public static void updateSoftMeta(DBAccess dba, SoftUserData softMeta) throws SQLException
    {
        LogUtil.log("数据更新：软件信息数据更新　－　" + softMeta.getSoftIndx());

        // 字符串转换
        softMeta.t2db();

        // SQL语句初始化
        dba.reset();

        // 更新表格
        dba.addTable(DB0008.TABLE_SOFTDATA);

        // 公共字段设置
        dba.addParam(DB0008.SOFTDATA_CORPINDX, softMeta.getCorpIndx());// 公司索引
        dba.addParam(DB0008.SOFTDATA_SOFTICON, softMeta.getSoftIcon());// 软件图标
        dba.addParam(DB0008.SOFTDATA_SOFTNAME, softMeta.getSoftName());// 软件名称
        dba.addParam(DB0008.SOFTDATA_SOFTMAIL, softMeta.getSoftMail());// 服务邮件
        dba.addParam(DB0008.SOFTDATA_SOFTSITE, softMeta.getSoftSite());// 链接地址
        dba.addParam(DB0008.SOFTDATA_EXTSLIST, softMeta.getExtsList());// 支持格式
        dba.addParam(DB0008.SOFTDATA_SOFTDESP, softMeta.getSoftDesp());// 相关说明
        dba.addParam(DB0008.SOFTDATA_UPDTDATE, DB0008.DBCS_DATE_NOW, false);// 更新时间

        // 数据更新
        if (softMeta.isUpdate())
        {
            // 默认值
            if (ConstUI.DEF_SOFTHASH.equals(softMeta.getSoftIndx()))
            {
                return;
            }

            // 更新条件
            dba.addWhere(DB0008.SOFTDATA_SOFTINDX, softMeta.getSoftIndx());// 个人索引

            // 数据更新
            dba.executeUpdate();
        }
        // 数据插入
        else
        {
            // 个人索引
            if (softMeta.getSoftIndx().length() < 2)
            {
                softMeta.setSoftIndx(HashUtil.getCurrTimeHex(false));
            }

            dba.addParam(DB0008.SOFTDATA_DISPORDR, "0");// 显示排序
            dba.addParam(DB0008.SOFTDATA_SOFTINDX, softMeta.getSoftIndx());// 个人索引
            dba.addParam(DB0008.SOFTDATA_MAKEDATE, DB0008.DBCS_DATE_NOW, false);// 创建时间

            // 数据插入
            dba.executeInsert();
        }
    }

    /**
     * 更新指定表格中指定索引的记录显示排序值，便其值增１
     * 
     * @param dba
     * @param table 待更新的表格名称
     * @param column 待更新的字段名称
     * @param key 更新关联条件（字段名称）
     * @param value 更新关联条件（字段值）
     * @return 更新影响条件
     * @throws SQLException
     */
    private static int updateDispOrdr(DBAccess dba, String table, String column, String key, String value)
        throws SQLException
    {
        LogUtil.log("数据更新：访问频率统计　－　" + table);

        // 对象初始化
        dba.reset();

        // 更新表格
        dba.addTable(table);

        // 更新频率
        dba.addParam(column, "=", column + " + 1", false);

        // 关联条件
        dba.addWhere(key, value);

        // 频率更新
        return dba.executeUpdate();
    }
}
