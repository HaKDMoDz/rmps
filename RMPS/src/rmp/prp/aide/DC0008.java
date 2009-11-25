/*
 * FileName:       DC0008.java
 * CreateDate:     2007-7-15 下午04:44:45
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.HashMap;

import rmp.bean.K1SV2S;
import rmp.io.db.DBAccess;
import rmp.prp.aide.extparse.m.TypeUserData;
import rmp.util.HashUtil;
import rmp.util.LogUtil;
import rmp.util.StringUtil;
import cons.id.PrpCons;
import cons.prp.aide.extparse.DB0008;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * 系统数据配置数据操作
 * <li>使用说明：</li>
 * <br>
 * TODO: 使用说明
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： Amon
 * </p>
 * <p>
 * 日期： 2007-7-15 下午04:44:45
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public final class DC0008
{
    /**
     * @param dba
     * @param systemId
     * @return
     * @throws SQLException
     */
    public static HashMap<Integer, K1SV2S> selectBaseMeta(DBAccess dba, int systemId) throws SQLException
    {
        LogUtil.log("系统配置查询：- " + systemId);

        HashMap<Integer, K1SV2S> baseHash = new HashMap<Integer, K1SV2S>();

        // 连接初始化
        dba.reset();

        // 查询表格
        dba.addTable(DB0008.TABLE_BASEDATA);

        // 查询字段
        dba.addColumn(DB0008.BASEDATA_APARTKEY);
        dba.addColumn(DB0008.BASEDATA_CFGVALUE);
        dba.addColumn(DB0008.BASEDATA_IDIOMARK);

        // 关联条件
        dba.addWhere(DB0008.BASEDATA_SYSTEMID, systemId + "", false);

        // 排序依据
        dba.addSort(DB0008.BASEDATA_APARTKEY, DB0008.DBCS_SORT_ASC);

        // 查询结果处理
        ResultSet rest = dba.executeSelect();
        String k;
        String v1;
        while (rest.next())
        {
            k = rest.getString(DB0008.BASEDATA_CFGVALUE);
            v1 = rest.getString(DB0008.BASEDATA_IDIOMARK);
            baseHash.put(rest.getInt(DB0008.BASEDATA_APARTKEY), new K1SV2S(k, v1, ""));
        }
        rest.close();

        return baseHash;
    }

    /**
     * 系统配置数据读取
     * 
     * @param dba
     * @param systemId
     * @param apartKey
     * @param column
     * @return
     * @throws SQLException
     */
    public static String selectBaseMeta(DBAccess dba, int systemId, int apartKey, String column) throws SQLException
    {
        LogUtil.log("系统配置查询：（" + systemId + ", " + apartKey + ", " + column + "）");

        // 连接初始化
        dba.reset();

        // 查询表格
        dba.addTable(DB0008.TABLE_BASEDATA);

        // 查询字段
        dba.addColumn(column);

        // 关联条件
        dba.addWhere(DB0008.BASEDATA_SYSTEMID, systemId + "", false);
        dba.addWhere(DB0008.BASEDATA_APARTKEY, apartKey + "", false);

        String cfgValue = null;

        // 查询结果处理
        ResultSet rest = dba.executeSelect();
        if (rest.next())
        {
            cfgValue = rest.getString(column);
        }
        rest.close();

        return cfgValue;
    }

    /**
     * 类别名称数据查询
     * 
     * @param dba
     * @param systemID
     * @param typeIndx
     * @return
     */
    public static String selectTypeName(DBAccess dba, int systemID, String typeIndx)
    {
        LogUtil.log("所属类别信息查询 － " + systemID + "、" + typeIndx);

        // 连接初始化
        dba.reset();

        // 查询表格
        dba.addTable(DB0008.TABLE_TYPEDATA);

        // 查询字段
        dba.addColumn(DB0008.TYPEDATA_TYPENAME);

        // 关联条件
        dba.addWhere(DB0008.TYPEDATA_SYSTEMID, "" + systemID, false);
        dba.addWhere(DB0008.TYPEDATA_TYPEINDX, typeIndx);

        String typeName = "";
        // 数据查询
        try
        {
            ResultSet rest = dba.executeSelect();

            if (rest.next())
            {
                typeName = rest.getString(DB0008.TYPEDATA_TYPENAME);
            }
            rest.close();
        }
        catch(SQLException exp)
        {
            LogUtil.exception(exp);
        }

        return typeName;
    }

    /**
     * 数据配置表格数据更新
     * 
     * @param dba 数据库操作对象
     * @param apartKey
     * @param cfgValue
     * @param idioMark
     * @return
     * @throws SQLException
     */
    public static int updateBaseMeta(DBAccess dba, String apartKey, String cfgValue, String idioMark)
        throws SQLException
    {
        LogUtil.log("数据库基本表格数据配置：（" + apartKey + "、" + cfgValue + "）");
        dba.reset();

        // 更新表格拼接
        dba.addTable(DB0008.TABLE_BASEDATA);

        // 更新内容拼接
        dba.addParam(DB0008.BASEDATA_CFGVALUE, StringUtil.toDBText(cfgValue));
        dba.addParam(DB0008.BASEDATA_IDIOMARK, StringUtil.toDBText(idioMark));

        // 关联条件拼接
        dba.addWhere(DB0008.BASEDATA_SYSTEMID, "" + PrpCons.P3010000_I, false);
        dba.addWhere(DB0008.BASEDATA_APARTKEY, apartKey);

        // 执行数据更新
        return dba.executeUpdate();
    }

    /**
     * @param dba
     * @param userMeta
     * @return
     * @throws SQLException
     */
    public static int updateTypeMeta(DBAccess dba, TypeUserData userMeta) throws SQLException
    {
        LogUtil.log("数据库基本表格数据配置：（" + userMeta.getSystemId() + "、" + userMeta.getTypeName() + "）");
        dba.reset();

        // 字符数据转换
        userMeta.t2db();

        // 更新表格拼接
        dba.addTable(DB0008.TABLE_TYPEDATA);

        // 更新内容拼接
        dba.addParam(DB0008.TYPEDATA_TYPENAME, userMeta.getTypeName());
        dba.addParam(DB0008.TYPEDATA_TYPEDESP, userMeta.getTypeDesp());

        if (userMeta.isUpdate())
        {
            // 关联条件拼接
            dba.addWhere(DB0008.TYPEDATA_SYSTEMID, "" + userMeta.getSystemId(), false);
            dba.addWhere(DB0008.TYPEDATA_TYPEINDX, userMeta.getTypeIndx());

            // 执行数据更新
            return dba.executeUpdate();
        }
        else
        {
            userMeta.setTypeIndx(HashUtil.getCurrTimeHex(false));

            dba.addParam(DB0008.TYPEDATA_DISPORDR, "0");
            dba.addParam(DB0008.TYPEDATA_SYSTEMID, "" + userMeta.getSystemId(), false);
            dba.addParam(DB0008.TYPEDATA_TYPEINDX, userMeta.getTypeIndx());

            // 执行数据更新
            return dba.executeInsert();
        }
    }

    /**
     * 关闭数据库
     * 
     * @param dba
     * @throws SQLException
     */
    public static void closeDataBase(DBAccess dba) throws SQLException
    {
        dba.reset();

        dba.execute("SHUTDOWN");
    }
}
