/*
 * FileName:       Util.java
 * CreateDate:     2008-3-1 下午01:51:31
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.P30F0000.t;

import java.sql.ResultSet;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Random;
import java.util.StringTokenizer;
import java.util.Vector;

import javax.swing.ImageIcon;

import rmp.bean.K1SV2S;
import rmp.io.db.DBAccess;
import rmp.prp.aide.P30F0000.P30F0000;
import rmp.prp.aide.P30F0000.b.PropItem;
import rmp.prp.aide.P30F0000.b.TypeItem;
import rmp.prp.aide.P30F0000.m.TypeData;
import rmp.prp.aide.P30F0000.m.UserData;
import rmp.util.CheckUtil;
import rmp.util.HashUtil;
import rmp.util.ImageUtil;
import rmp.util.LogUtil;
import rmp.util.StringUtil;
import cons.EnvCons;
import cons.SqlCons;
import cons.db.ComnCons;
import cons.db.PrpCons;
import cons.prp.aide.P30F0000.ConstUI;
import cons.prp.aide.P30F0000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * TODO: 功能说明
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
 * 日期： 2008-3-1 下午01:51:31
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public final class Util
{
    private static UserData                   userData;
    /** 根节点对象 */
    private static TypeItem                   ti_TypeRoot;
    /** 目录树模型 */
    private static TypeData                   td_TypeList;
    /** 系统图标 */
    private static HashMap<String, ImageIcon> hm_IconList = new HashMap<String, ImageIcon>();

    /**
     * @return
     */
    public static final UserData getUserData()
    {
        if (userData == null)
        {
            userData = new UserData();
            userData.wInit();
        }
        return userData;
    }

    public static String readSetsByID(String setsHash)
    {
        if (ConstUI.SETS_NUMBER.equals(setsHash))
        {
            return "0123456789";
        }
        if (ConstUI.SETS_LOWER.equals(setsHash))
        {
            return "abcdefghijklmnopqrstuvwxyz";
        }
        if (ConstUI.SETS_UPPER.equals(setsHash))
        {
            return "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }
        if (ConstUI.SETS_SPECIAL.equals(setsHash))
        {
            return "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
        }
        if (ConstUI.SETS_LETTER.equals(setsHash))
        {
            return "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        }
        if (ConstUI.SETS_NUMBER_LETTER.equals(setsHash))
        {
            return "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        }
        if (ConstUI.SETS_ASCII_CHARACTER.equals(setsHash))
        {
            return "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
        }
        return "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    }

    /**
     * 指定类别下的所有类别数据列表<br>
     * k:类别数据索引<br>
     * v1:类别数据名称<br>
     * v2:类别数据提示<br>
     * 
     * @param typeHash
     * @return
     */
    public static List<K1SV2S> readTypeList(String typeHash)
    {
        LogUtil.log("类别读取:" + typeHash);
        List<K1SV2S> list = new ArrayList<K1SV2S>();

        DBAccess dba = new DBAccess();
        if (!dba.wInit())
        {
            return list;
        }

        try
        {
            dba.addTable(ComnCons.C2010100);
            dba.addColumn(ComnCons.C2010103);// 类别索引
            dba.addColumn(ComnCons.C2010105);// 类别名称
            dba.addColumn(ComnCons.C2010106);// 类别提示
            dba.addWhere(ComnCons.C2010104, typeHash);
            dba.addSort(ComnCons.C2010101, "DESC");

            ResultSet rest = dba.executeSelect();
            K1SV2S kv;
            while (rest.next())
            {
                kv = new K1SV2S();
                kv.setK(rest.getString(ComnCons.C2010103));
                kv.setV1(rest.getString(ComnCons.C2010105));
                kv.setV2(rest.getString(ComnCons.C2010106));
                list.add(kv);
            }
            rest.close();
        }
        catch(Exception exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.closeConnection();
        }
        return list;
    }

    /**
     * 指定类别下的所有数据名称列表<br>
     * k:用户数据索引<br>
     * v1:用户数据名称<br>
     * v2:用户数据提示<br>
     * 
     * @param typeHash
     * @return
     */
    public static boolean readNameList(String typeHash, List<K1SV2S> dataList)
    {
        LogUtil.log("读取指定类别的密码记录：" + typeHash);

        DBAccess dba = new DBAccess();
        if (!dba.wInit())
        {
            return false;
        }

        try
        {
            dba.addTable(PrpCons.P30F0100);
            dba.addColumn(PrpCons.P30F0103);// 密码索引
            dba.addColumn(PrpCons.P30F0107);// 密码标题
            dba.addWhere(PrpCons.P30F0106, typeHash);// 类别索引
            dba.addWhere(PrpCons.P30F0101, "1");// 使用状态
            dba.addWhere(PrpCons.P30F0102, "0");// 排序依据
            dba.addSort(PrpCons.P30F0107, "ASC");// 升序排列

            ResultSet rest = dba.executeSelect();
            String k;
            String v;
            while (rest.next())
            {
                k = rest.getString(PrpCons.P30F0103);
                v = rest.getString(PrpCons.P30F0107);
                dataList.add(new K1SV2S(k, v, v));
            }
            rest.close();
        }
        catch(Exception exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.closeConnection();
        }
        return true;
    }

    /**
     * 按照显示标题查寻符合条件的数据
     * 
     * @param keysName 用户数据标题
     */
    public static boolean queryUserData(String keysName, List<K1SV2S> dataList)
    {
        LogUtil.log("用户数据查询：查询符合指定条件的数据 － " + keysName);

        DBAccess dba = new DBAccess();
        if (!dba.wInit())
        {
            return true;
        }

        try
        {
            dba.addTable(PrpCons.P30F0100);
            dba.addColumn(PrpCons.P30F0103);// 密码索引
            dba.addColumn(PrpCons.P30F0107);// 密码标题
            keysName = "'%" + keysName.replace(' ', '%') + "%'";
            dba.addWhere(PrpCons.P30F0107 + " LIKE " + keysName + " OR " + PrpCons.P30F0108 + " LIKE " + keysName);// 类别索引
            dba.addWhere(PrpCons.P30F0101, "1");// 使用状态
            dba.addWhere(PrpCons.P30F0102, "0");// 排序依据
            dba.addSort(PrpCons.P30F0107, "ASC");// 升序排列

            ResultSet rest = dba.executeSelect();
            String k;
            String v;
            while (rest.next())
            {
                k = rest.getString(PrpCons.P30F0103);
                v = rest.getString(PrpCons.P30F0107);
                dataList.add(new K1SV2S(k, v, v));
            }
            rest.close();
        }
        catch(Exception exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.closeConnection();
        }
        return true;
    }

    /**
     * 数据加密口令空间
     * 
     * @return
     */
    public static final byte[] generateDataKeys()
    {
        byte[] b = new byte[16];
        new Random().nextBytes(b);
        return b;
    }

    /**
     * 数据加密字符空间
     * 
     * @return
     */
    public static final char[] generateDataChar()
    {
        char[] c = new char[93];
        for (char i = 0; i < 6; i += 1)
        {
            c[i] = (char)(33 + i);
        }
        for (char i = 6; i < 93; i += 1)
        {
            c[i] = (char)(34 + i);
        }

        try
        {
            return HashUtil.nextRandomKey(c, 16, true);
        }
        catch(Exception exp)
        {
            LogUtil.exception(exp);
            return null;
        }
    }

    /**
     * 用户自定义口令类别名称列表
     * 
     * @return
     */
    public static final Vector<K1SV2S> readPropType()
    {
        Vector<K1SV2S> typeList = new Vector<K1SV2S>();

        DBAccess dba = new DBAccess();
        if (!dba.wInit())
        {
            return typeList;
        }

        try
        {
            dba.addTable(PrpCons.P30F0200);
            dba.addColumn(PrpCons.P30F0203);// 属性索引
            dba.addColumn(PrpCons.P30F0205);// 属性名称
            dba.addColumn(PrpCons.P30F0206);// 属性提示
            dba.addWhere(PrpCons.P30F0204, "0");// 类别索引
            dba.addSort(PrpCons.P30F0201, "ASC");// 长序排列

            ResultSet rest = dba.executeSelect();
            String k;
            String v1;
            String v2;
            while (rest.next())
            {
                k = rest.getString(PrpCons.P30F0203);
                v1 = rest.getString(PrpCons.P30F0205);
                v2 = rest.getString(PrpCons.P30F0206);
                typeList.add(new K1SV2S(k, v1, v2));
            }
            rest.close();
        }
        catch(Exception exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.closeConnection();
        }

        return typeList;
    }

    /**
     * 用户自定义口令类别属性列表
     * 
     * @param propHash
     * @param propList
     */
    public static final void readPropData(String propHash, List<PropItem> propList)
    {
        DBAccess dba = new DBAccess();
        if (!dba.wInit())
        {
            return;
        }

        try
        {
            dba.addTable(PrpCons.P30F0200);
            dba.addColumn(PrpCons.P30F0202);// 属性类别
            dba.addColumn(PrpCons.P30F0205);// 属性名称
            dba.addColumn(PrpCons.P30F0206);// 属性提示
            dba.addWhere(PrpCons.P30F0204, propHash);// 类别索引
            dba.addSort(PrpCons.P30F0201, "ASC");// 长序排列

            ResultSet rest = dba.executeSelect();
            int type;
            String name;
            String data;
            while (rest.next())
            {
                type = rest.getInt(PrpCons.P30F0202);
                name = rest.getString(PrpCons.P30F0205);
                data = rest.getString(PrpCons.P30F0206);
                propList.add(new PropItem(type, name, data));
            }
            rest.close();
        }
        catch(Exception exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * @param typeHash 上一级目录索引
     * @param typeName 类别名称
     */
    public static String createType(String typeHash, String typeName)
    {
        DBAccess dba = new DBAccess();
        if (!dba.wInit())
        {
            return null;
        }

        String hash = HashUtil.getCurrTimeHex(false);
        try
        {
            dba.addTable(ComnCons.C2010100);
            dba.addParam(ComnCons.C2010101, "0", false);// 显示排序
            dba.addParam(ComnCons.C2010102, "0", false);// 类别级别
            dba.addParam(ComnCons.C2010103, hash);// 类别索引
            dba.addParam(ComnCons.C2010104, typeHash);// 一级索引
            typeName = StringUtil.toDBText(typeName);
            dba.addParam(ComnCons.C2010105, typeName);// 类别名称
            dba.addParam(ComnCons.C2010106, typeName);// 类别提示
            dba.addParam(ComnCons.C2010107, "");// 类别键值
            dba.addParam(ComnCons.C2010108, "");// 类别描述
            dba.addParam(ComnCons.C2010109, "NOW", false);// 更新时间
            dba.addParam(ComnCons.C201010A, "NOW", false);// 创建时间

            dba.executeInsert();
            return hash;
        }
        catch(Exception exp)
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
     * @param keysHash
     * @param dateHash
     * @return
     */
    public static int deleteBack(String keysHash, String dateHash)
    {
        DBAccess dba = new DBAccess();
        if (!dba.wInit())
        {
            return 0;
        }

        try
        {
            // 更新类别为默认类别
            dba.addTable(PrpCons.P30F0100);
            dba.addWhere(PrpCons.P30F0103, keysHash);
            dba.addWhere(PrpCons.P30F0104, "<", dateHash, true);
            dba.addWhere(PrpCons.P30F0101, "0");
            return dba.executeDelete();
        }
        catch(Exception exp)
        {
            LogUtil.exception(exp);
            return 0;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * 删除指定类别
     * 
     * @param typeHash 要删除的类别索引
     * @return
     */
    public static int deleteType(String typeHash)
    {
        DBAccess dba = new DBAccess();
        if (!dba.wInit())
        {
            return 0;
        }

        try
        {
            // 更新类别为默认类别
            dba.addTable(PrpCons.P30F0100);
            dba.addParam(PrpCons.P30F0106, "0");
            dba.addWhere(PrpCons.P30F0106, typeHash);
            dba.executeUpdate();

            // 删除类别名称
            dba.reset();
            dba.addTable(ComnCons.C2010100);
            dba.addWhere(ComnCons.C2010103, typeHash);// 类别索引

            return dba.executeDelete();
        }
        catch(Exception exp)
        {
            LogUtil.exception(exp);
            return 0;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * 更新类别名称
     * 
     * @param typeHash
     * @param typeName
     * @return
     */
    public static int updateType(String typeHash, String typeName)
    {
        DBAccess dba = new DBAccess();
        if (!dba.wInit())
        {
            return 0;
        }

        try
        {
            // 删除类别名称
            dba.addTable(ComnCons.C2010100);
            typeName = StringUtil.toDBText(typeName);
            dba.addParam(ComnCons.C2010105, typeName);
            dba.addParam(ComnCons.C2010106, typeName);
            dba.addWhere(ComnCons.C2010103, typeHash);// 类别索引

            return dba.executeUpdate();
        }
        catch(Exception exp)
        {
            LogUtil.exception(exp);
            return 0;
        }
        finally
        {
            dba.closeConnection();
        }
    }

    public static void initTypeData()
    {
        if (td_TypeList != null)
        {
            return;
        }

        Thread t = new Thread()
        {
            public void run()
            {
                try
                {
                    // 图标读取
                    String st;
                    st = ConstUI.ICON_P30F0001;
                    hm_IconList.put(st, new ImageIcon(ImageUtil.readJarImage(EnvCons.PATH_P30F0000, st)));
                    st = ConstUI.ICON_P30F0002;
                    hm_IconList.put(st, new ImageIcon(ImageUtil.readJarImage(EnvCons.PATH_P30F0000, st)));
                    st = ConstUI.ICON_P30F0003;
                    hm_IconList.put(st, new ImageIcon(ImageUtil.readJarImage(EnvCons.PATH_P30F0000, st)));
                    st = ConstUI.ICON_P30F0012;
                    hm_IconList.put(st, new ImageIcon(ImageUtil.readJarImage(EnvCons.PATH_P30F0000, st)));
                    st = ConstUI.ICON_P30F0013;
                    hm_IconList.put(st, new ImageIcon(ImageUtil.readJarImage(EnvCons.PATH_P30F0000, st)));
                    st = ConstUI.ICON_P30F0014;
                    hm_IconList.put(st, new ImageIcon(ImageUtil.readJarImage(EnvCons.PATH_P30F0000, st)));
                    st = ConstUI.ICON_P30F0021;
                    hm_IconList.put(st, new ImageIcon(ImageUtil.readJarImage(EnvCons.PATH_P30F0000, st)));
                    st = ConstUI.ICON_P30F0022;
                    hm_IconList.put(st, new ImageIcon(ImageUtil.readJarImage(EnvCons.PATH_P30F0000, st)));
                    st = ConstUI.ICON_P30F0023;
                    hm_IconList.put(st, new ImageIcon(ImageUtil.readJarImage(EnvCons.PATH_P30F0000, st)));
                    st = ConstUI.ICON_P30F0024;
                    hm_IconList.put(st, new ImageIcon(ImageUtil.readJarImage(EnvCons.PATH_P30F0000, st)));
                    st = ConstUI.ICON_P30F0031;
                    hm_IconList.put(st, new ImageIcon(ImageUtil.readJarImage(EnvCons.PATH_P30F0000, st)));
                    st = ConstUI.ICON_P30F0041;
                    hm_IconList.put(st, new ImageIcon(ImageUtil.readJarImage(EnvCons.PATH_P30F0000, st)));

                    // 类别读取
                    ti_TypeRoot = new TypeItem();
                    td_TypeList = new TypeData(ti_TypeRoot);
                    ti_TypeRoot.getChildCount();
                }
                catch(Exception exp)
                {
                    LogUtil.exception(exp);
                }
            }
        };
        t.start();
    }

    /**
     * @return the typeRoot
     */
    public static TypeItem getTypeRoot()
    {
        return ti_TypeRoot;
    }

    /**
     * @return the typeList
     */
    public static TypeData getTypeList()
    {
        return td_TypeList;
    }

    /**
     * @param key
     * @return
     */
    public static ImageIcon getIcon(String key)
    {
        return hm_IconList.get(key);
    }

    /**
     * @param text 数据导入单个记录（以行为单位）
     * @param rrDelimiter 多条属性之间的分隔标记
     * @param tpDelimiter 属性类别与数据之间的分隔标记
     * @param kvDelimiter 属性名称与内容之间的分隔标记
     * @param qualifier 转文标记符，用于去除在此标记之间的分隔标记的特殊意义
     * @return
     */
    public static List<PropItem> importRecordText(String text, String rrDelimiter, String tpDelimiter,
        String kvDelimiter, String qualifier)
    {
        List<PropItem> propList = new ArrayList<PropItem>();

        // 参数为空判断
        if (!CheckUtil.isValidate(text) || !CheckUtil.isValidate(rrDelimiter) || !CheckUtil.isValidate(tpDelimiter)
            || !CheckUtil.isValidate(kvDelimiter))
        {
            return propList;
        }

        // 循环处理每一个属性值对
        StringTokenizer st = new StringTokenizer(text, rrDelimiter);

        boolean q = false;
        int l = qualifier == null ? 0 : qualifier.length();
        StringBuffer b = new StringBuffer();

        String t;
        while (st.hasMoreTokens())
        {
            t = st.nextToken();
            LogUtil.log(t);

            // 没有特殊标记的情况下，直接进行处理
            if (l < 1)
            {
                propList.add(text2Item(t, tpDelimiter, kvDelimiter));
                continue;
            }

            // 存在特殊标记的情况下，处理特殊标记
            if (q)
            {
                // 特殊标记结束处理
                if (t.endsWith(qualifier))
                {
                    b.append(t.substring(0, t.length() - l));
                    propList.add(text2Item(b.toString(), tpDelimiter, kvDelimiter));
                    b.delete(0, b.length());
                    q = false;
                }
                // 特殊标记中存在记录分隔符时的处理
                else
                {
                    b.append(t).append(rrDelimiter);
                }
            }
            else
            {
                // 特殊标记开始处理
                if (t.startsWith(qualifier))
                {
                    b.append(t.substring(l)).append(rrDelimiter);
                    q = true;
                }
                // 不存在特殊标记创建符时的处理
                else
                {
                    propList.add(text2Item(t, tpDelimiter, kvDelimiter));
                }
            }
        }

        return propList;
    }

    /**
     * 由记录文本数据转换为内存数据对象
     * 
     * @param text
     * @param tpDelimiter
     * @param kvDelimiter
     * @return
     */
    private static PropItem text2Item(String text, String tpDelimiter, String kvDelimiter)
    {
        PropItem pi = new PropItem();
        int s = text.indexOf(tpDelimiter);
        if (s < 1)
        {
            pi.setType(ConstUI.RECORD_TYPE_TEXT);
        }
        else
        {
            int t;
            try
            {
                t = Integer.parseInt(text.substring(0, s).trim());
            }
            catch(NumberFormatException exp)
            {
                t = ConstUI.RECORD_TYPE_TEXT;
            }
            pi.setType(t);

            s += 1;
            text = s >= text.length() ? "" : text.substring(s);
        }
        int e = text.lastIndexOf(kvDelimiter);
        if (e < 1)
        {
            pi.setName("<未知>");
            pi.setData(text);
        }
        else
        {
            pi.setName(text.substring(0, e));
            e += 1;
            pi.setData(e >= text.length() ? "" : text.substring(e));
        }
        return pi;
    }

    /**
     * @param list
     * @param rrDelimiter
     * @param tpDelimiter
     * @param kvDelimiter
     * @param qualifier
     * @return
     */
    public static String exportRecordText(List<PropItem> list, String rrDelimiter, String tpDelimiter,
        String kvDelimiter, String qualifier)
    {
        // 数据有效性检测
        if ((list == null || list.size() < 1) || !CheckUtil.isValidate(rrDelimiter)
            || !CheckUtil.isValidate(tpDelimiter) || !CheckUtil.isValidate(kvDelimiter))
        {
            return "";
        }

        StringBuffer b = new StringBuffer();
        StringBuffer t = new StringBuffer();
        for (PropItem pi : list)
        {
            // 内存数据对象转换为记录数据字符串
            t.append(pi.getType()).append(tpDelimiter);
            t.append(pi.getName() != null ? pi.getName() : "").append(kvDelimiter);
            t.append(pi.getData() != null ? pi.getData() : "");

            // 是否需要加注特殊标记符
            if (t.indexOf(rrDelimiter) >= 0)
            {
                b.append(qualifier).append(t.toString()).append(qualifier);
            }
            else
            {
                b.append(t.toString());
            }

            // 记录分隔标记符
            b.append(rrDelimiter);
            t.delete(0, t.length());
        }
        return b.toString();
    }

    public static List<K1SV2S> listHistoryByID(String userKeys)
    {
        List<K1SV2S> list = new ArrayList<K1SV2S>();

        DBAccess dba = new DBAccess();
        if (!dba.wInit())
        {
            return list;
        }

        try
        {
            // 删除类别名称
            dba.addTable(PrpCons.P30F0100);
            dba.addColumn("distinct(" + PrpCons.P30F0104 + ")");
            dba.addWhere(PrpCons.P30F0103, userKeys);// 类别索引
            dba.addSort(PrpCons.P30F0104, SqlCons.DBCS_SORT_DESC);

            ResultSet rest = dba.executeSelect();
            String temp;
            K1SV2S item;
            Date date = new Date();
            SimpleDateFormat sdf = new SimpleDateFormat(P30F0000.getMesg(LangRes.P30FA102));
            while (rest.next())
            {
                item = new K1SV2S();
                temp = rest.getString(1);
                item.setK(temp);
                date.setTime(Long.parseLong(temp, 16));
                temp = sdf.format(date);
                item.setV1(temp);
                item.setV2(temp);
                list.add(item);
            }
            rest.close();
        }
        catch(Exception exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.closeConnection();
        }

        return list;
    }

    public static K1SV2S pickUpHistory(String keysHash, String currHash)
    {
        DBAccess dba = new DBAccess();
        if (!dba.wInit())
        {
            return null;
        }

        try
        {
            K1SV2S kv = new K1SV2S();
            Date date = new Date();
            String hash = StringUtil.lPad(Long.toHexString(date.getTime()), 16, '0');
            kv.setK(hash);
            String text = new SimpleDateFormat(P30F0000.getMesg(LangRes.P30FA102)).format(date);
            kv.setV1(text);
            kv.setV2(text);

            // 更新已有数据状态
            dba.addTable(PrpCons.P30F0100);
            dba.addParam(PrpCons.P30F0101, ConstUI.PWDS_STAT_2);// 使用状态
            dba.addWhere(PrpCons.P30F0103, keysHash);
            dba.executeUpdate();

            // 新增数据
            StringBuffer sql = new StringBuffer();
            sql.append("insert into P30F0100 (P30F0101,");
            sql.append("    P30F0102,");
            sql.append("    P30F0103,");
            sql.append("    P30F0104,");
            sql.append("    P30F0105,");
            sql.append("    P30F0106,");
            sql.append("    P30F0107,");
            sql.append("    P30F0108,");
            sql.append("    P30F0109,");
            sql.append("    P30F010A)");
            sql.append(StringUtil.format(" (select '{0}',", ConstUI.PWDS_STAT_1));
            sql.append("           P30F0102,");
            sql.append("           P30F0103,");
            sql.append(StringUtil.format("'{0}',", kv.getK()));
            sql.append("           P30F0105,");
            sql.append("           P30F0106,");
            sql.append("           P30F0107,");
            sql.append("           P30F0108,");
            sql.append("           P30F0109,");
            sql.append(StringUtil.format("'{0}'", StringUtil.format(P30F0000.getMesg(LangRes.P30FA103), kv.getV1())));
            sql.append("      from P30F0100");
            sql.append(StringUtil.format(" where P30F0103='{0}'", keysHash));
            sql.append(StringUtil.format("   and P30F0104='{0}')", currHash));
            dba.execute(sql.toString());

            return kv;
        }
        catch(Exception exp)
        {
            LogUtil.exception(exp);
            return null;
        }
    }
}
