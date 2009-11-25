/*
 * FileName:       UserData.java
 * CreateDate:     2008-2-29 下午11:19:28
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.P30F0000.m;

import java.io.Serializable;
import java.sql.Date;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;
import java.util.StringTokenizer;

import javax.crypto.Cipher;
import javax.swing.table.DefaultTableModel;

import rmp.io.db.DBAccess;
import rmp.prp.aide.P30F0000.P30F0000;
import rmp.prp.aide.P30F0000.b.PropItem;
import rmp.prp.aide.P30F0000.t.Util;
import rmp.util.HashUtil;
import rmp.util.LogUtil;
import rmp.util.RmpsUtil;
import rmp.util.StringUtil;

import com.sun.xml.internal.messaging.saaj.util.ByteOutputStream;

import cons.SysCons;
import cons.db.PrpCons;
import cons.prp.aide.P30F0000.ConstUI;
import cons.prp.aide.P30F0000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * 用户数据列表显示数据模型
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
 * 日期： 2008-2-29 下午11:19:28
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class UserData extends DefaultTableModel implements Serializable
{
    /** 文件是否被修改过 */
    private boolean        modified;
    /** 类别索引(P30F0105) */
    private String         typeHash;
    /** 口令索引(P30F0103) */
    private String         keysHash;
    /** 当前记录索引(P30F0104) */
    private String         currHash;
    /** 口令标题(P30F0107) */
    private String         keysName;
    /** 关键搜索(P30F0108) */
    private String         keysMeta;
    /** 创建日期 */
    private Date           dateTime;
    /** 共用属性列表 */
    private List<PropItem> ls_ItemList;
    /** 用户登录信息 */
    private UserKeys       uk_UserKeys;

    /**
     * 
     */
    public UserData()
    {
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        ls_ItemList = new ArrayList<PropItem>();

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.AbstractTableModel#getColumnClass(int)
     */
    public Class< ? > getColumnClass(int columnIndex)
    {
        return columnIndex == 0 ? Integer.class : PropItem.class;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.DefaultTableModel#getRowCount()
     */
    public int getRowCount()
    {
        return ls_ItemList != null ? ls_ItemList.size() : 0;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.DefaultTableModel#getColumnCount()
     */
    public int getColumnCount()
    {
        return 2;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.DefaultTableModel#getColumnName(int)
     */
    public String getColumnName(int column)
    {
        return column == 1 ? P30F0000.getMesg(LangRes.P30F6B02) : P30F0000.getMesg(LangRes.P30F6B01);
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.DefaultTableModel#isCellEditable(int, int)
     */
    public boolean isCellEditable(int row, int column)
    {
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.DefaultTableModel#getValueAt(int, int)
     */
    public Object getValueAt(int row, int column)
    {
        // 索引列
        if (column == 0)
        {
            return row + 1;
        }

        // 公共属性
        if (ls_ItemList == null)
        {
            return null;
        }
        return ls_ItemList.get(row);
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.AbstractTableModel#setValueAt(java.lang.Object,
     *      int, int)
     */
    public void setValueAt(Object aValue, int row, int column)
    {
        // if (column != 1)
        // {
        // return;
        // }
        //
        // if (!(aValue instanceof PropItem))
        // {
        // return;
        // }
        //
        // PropItem item = (PropItem)aValue;
        // int size = hm_PubProps != null ? hm_PubProps.size() : 0;
        // if (row < size)
        // {
        // hm_PubProps.put("", item);
        // return;
        // }
        // row -= size;
        // size = hm_PrvProps != null ? hm_PrvProps.size() : 0;
        // if (row < size)
        // {
        // hm_PrvProps.put("", item);
        // }
        // fireTableCellUpdated(row, column);
    }

    /**
     * @param userName
     * @param userPwds
     * @param userSalt
     * @throws Exception
     */
    public boolean signIn(String userName, String userPwds) throws Exception
    {
        if (uk_UserKeys == null)
        {
            uk_UserKeys = new UserKeys(userName, userPwds, userPwds);
            uk_UserKeys.wInit();
        }
        uk_UserKeys.setPwds(userPwds);
        return uk_UserKeys.signIn();
    }

    /**
     * @param userName
     * @param userPwds
     * @throws Exception
     */
    public boolean signUp(String userName, String userPwds) throws Exception
    {
        if (uk_UserKeys == null)
        {
            uk_UserKeys = new UserKeys(userName, userPwds, userPwds);
            uk_UserKeys.wInit();
        }
        return uk_UserKeys.signUp();
    }

    /**
     * @param oldPwds
     * @param userPwds
     * @throws Exception
     */
    public boolean signPwd(String oldPwds, String newPwds) throws Exception
    {
        if (uk_UserKeys == null)
        {
            return false;
        }
        return uk_UserKeys.signPwd(oldPwds, newPwds);
    }

    /**
     * 数据是否被修改过
     * 
     * @return
     */
    public boolean isModified()
    {
        return modified;
    }

    /**
     * @param modified
     */
    public void setModified(boolean modified)
    {
        this.modified = modified;
    }

    /**
     * 读取指定索引的密码数据
     * 
     * @param keysHash
     */
    public void readData(String keysHash) throws Exception
    {
        this.keysHash = keysHash;
        // 清除已有数据
        ls_ItemList.clear();

        // 数据库连接初始化
        DBAccess dba = new DBAccess();
        if (!dba.wInit())
        {
            return;
        }

        // 数据解密处理
        try
        {
            deCrypt(dba);
        }
        finally
        {
            dba.closeConnection();
            modified = false;
        }
        fireTableDataChanged();
    }

    /**
     * 是否要更新原有数据
     * 
     * @param isUpdate
     */
    public boolean saveData(boolean isUpdate)
    {
        // 数据库连接初始化
        DBAccess dba = new DBAccess();
        if (!dba.wInit())
        {
            return false;
        }

        try
        {
            // 数据更新时，首先删除已有数据，再添加数据
            if (isUpdate)
            {
                delete(dba);
            }
            else
            {
                update(dba);
            }
            currHash = StringUtil.lPad(Long.toHexString(System.currentTimeMillis()), 16, '0');
            enCrypt(dba);
            keysHash = null;
            keysName = null;
            return true;
        }
        catch(Exception exp)
        {
            LogUtil.exception(exp);
            return false;
        }
        finally
        {
            dba.closeConnection();
            modified = false;
        }
    }

    /**
     * 删除数据
     */
    public void deleteData()
    {
        DBAccess dba = new DBAccess();
        if (!dba.wInit())
        {
            return;
        }

        try
        {
            delete(dba);
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
     * 
     */
    public void clear()
    {
        ls_ItemList.clear();
    }

    /**
     * 
     */
    public void remove(PropItem pi)
    {
        ls_ItemList.remove(pi);
    }

    /**
     * 添加指定类别的数据
     * 
     * @param type
     */
    public PropItem append(int type)
    {
        PropItem pi = new PropItem(type);
        ls_ItemList.add(pi);
        return pi;
    }

    /**
     * @param pi
     */
    public void append(PropItem pi)
    {
        ls_ItemList.add(pi);
    }

    /**
     * @param row
     * @param to
     */
    public void moveRow(int row, int to)
    {
        LogUtil.log("数据行位置调整：" + row + " -> " + to);
        if (row == to)
        {
            return;
        }

        PropItem p = ls_ItemList.remove(row);
        ls_ItemList.add(to, p);
    }

    /**
     * 重新初始化数据模型，用于新增一个数据，并从选择数据类型开始
     */
    public PropItem reInit()
    {
        ls_ItemList.clear();
        typeHash = null;
        keysHash = null;
        keysName = null;
        keysMeta = null;

        dateTime = new Date(System.currentTimeMillis());

        PropItem pi = new PropItem(ConstUI.RECORD_TYPE_DATE, P30F0000.getMesg(LangRes.P30F6101), "");
        ls_ItemList.add(pi);
        return pi;
    }

    /**
     * 初始化指定类型的数据
     */
    public void reInit(String typeHash)
    {
        if (ls_ItemList.size() < 2)
        {
            ls_ItemList.add(new PropItem(ConstUI.RECORD_TYPE_META, P30F0000.getMesg(LangRes.P30F6102), ""));
        }
        Util.readPropData(typeHash, ls_ItemList);
    }

    /**
     * 删除已有数据
     * 
     * @param dba
     */
    private void delete(DBAccess dba) throws Exception
    {
        if (keysHash == null)
        {
            return;
        }

        dba.addTable(PrpCons.P30F0100);
        dba.addParam(PrpCons.P30F0101, ConstUI.PWDS_STAT_3);
        dba.addWhere(PrpCons.P30F0103, keysHash);
        dba.addWhere(PrpCons.P30F0104, currHash);

        dba.executeUpdate();
        dba.reset();
    }

    /**
     * @param dba
     * @throws Exception
     */
    private void update(DBAccess dba) throws Exception
    {
        if (keysHash == null)
        {
            keysHash = HashUtil.getCurrTimeHex(false);
            return;
        }

        dba.addTable(PrpCons.P30F0100);
        dba.addParam(PrpCons.P30F0101, ConstUI.PWDS_STAT_2);// 使用状态
        dba.addWhere(PrpCons.P30F0103, keysHash);

        dba.executeUpdate();
        dba.reset();
    }

    /**
     * 数据解密处理
     * 
     * @param dba
     */
    private void deCrypt(DBAccess dba) throws Exception
    {
        // 字符串初始化
        ByteOutputStream bo = new ByteOutputStream();

        // 解密算法初始化
        Cipher aes = Cipher.getInstance(ConstUI.NAME_CIPHER);
        aes.init(Cipher.DECRYPT_MODE, uk_UserKeys);

        // 查询语句拼接
        dba.addTable(PrpCons.P30F0100);
        dba.addColumn(PrpCons.P30F0104);// 更新标记
        dba.addColumn(PrpCons.P30F0106);// 所属类别
        dba.addColumn(PrpCons.P30F0107);// 口令标题
        dba.addColumn(PrpCons.P30F0108);// 关键搜索
        dba.addColumn(PrpCons.P30F0109);// 口令内容
        dba.addWhere(PrpCons.P30F0103, keysHash);// 口令索引
        dba.addWhere(PrpCons.P30F0101, ConstUI.PWDS_STAT_1);// 使用状态
        dba.addSort(PrpCons.P30F0102);// 排序依据

        // 数据查询
        ResultSet rest = dba.executeSelect();
        byte[] src;
        if (rest.next())
        {
            currHash = rest.getString(PrpCons.P30F0104);
            typeHash = rest.getString(PrpCons.P30F0106);
            keysName = rest.getString(PrpCons.P30F0107);
            keysMeta = rest.getString(PrpCons.P30F0108);
            src = StringUtil.stringToBytes(rest.getString(PrpCons.P30F0109), uk_UserKeys.getCharacter());
            bo.write(aes.update(src));
        }
        while (rest.next())
        {
            src = StringUtil.stringToBytes(rest.getString(PrpCons.P30F0109), uk_UserKeys.getCharacter());
            bo.write(aes.update(src));
        }
        bo.write(aes.doFinal());
        bo.flush();
        bo.close();
        rest.close();

        // 查询数据是否为空
        String text = new String(bo.getBytes(), SysCons.FILE_ENCODING);
        if (text.length() < 1)
        {
            return;
        }

        // 处理每一个数据
        StringTokenizer st = new StringTokenizer(text, ConstUI.SP_EE);
        int type;
        String name;
        String data;
        int s;
        int e;
        String t;
        while (st.hasMoreTokens())
        {
            t = st.nextToken();
            s = t.indexOf(ConstUI.SP_KV);
            e = t.lastIndexOf(ConstUI.SP_KV);
            if (s < 0 || s >= e)
            {
                continue;
            }

            type = Integer.parseInt(t.substring(0, s));
            name = t.substring(s + 1, e);
            data = t.substring(e + 1);
            ls_ItemList.add(new PropItem(type, name, data));
        }
    }

    public String deCrypt(String keysHash, String currHash)
    {
        StringBuffer keys = new StringBuffer(1024);

        DBAccess dba = new DBAccess();

        try
        {
            if (!dba.wInit())
            {
                return keys.toString();
            }

            // 字符串初始化
            ByteOutputStream bo = new ByteOutputStream();

            // 解密算法初始化
            Cipher aes = Cipher.getInstance(ConstUI.NAME_CIPHER);
            aes.init(Cipher.DECRYPT_MODE, uk_UserKeys);

            // 查询语句拼接
            dba.addTable(PrpCons.P30F0100);
            dba.addColumn(PrpCons.P30F0104);// 更新标记
            dba.addColumn(PrpCons.P30F0106);// 所属类别
            dba.addColumn(PrpCons.P30F0107);// 口令标题
            dba.addColumn(PrpCons.P30F0108);// 关键搜索
            dba.addColumn(PrpCons.P30F0109);// 口令内容
            dba.addWhere(PrpCons.P30F0103, keysHash);// 口令索引
            dba.addWhere(PrpCons.P30F0104, currHash);// 更新标记

            // 数据查询
            ResultSet rest = dba.executeSelect();
            byte[] src;
            if (rest.next())
            {
                currHash = rest.getString(PrpCons.P30F0104);
                typeHash = rest.getString(PrpCons.P30F0106);
                keysName = rest.getString(PrpCons.P30F0107);
                keysMeta = rest.getString(PrpCons.P30F0108);
                src = StringUtil.stringToBytes(rest.getString(PrpCons.P30F0109), uk_UserKeys.getCharacter());
                bo.write(aes.update(src));
            }
            while (rest.next())
            {
                src = StringUtil.stringToBytes(rest.getString(PrpCons.P30F0109), uk_UserKeys.getCharacter());
                bo.write(aes.update(src));
            }
            bo.write(aes.doFinal());
            bo.flush();
            bo.close();
            rest.close();

            // 查询数据是否为空
            String text = new String(bo.getBytes(), SysCons.FILE_ENCODING);
            if (text.length() < 1)
            {
                return keys.toString();
            }

            // 处理每一个数据
            StringTokenizer st = new StringTokenizer(text, ConstUI.SP_EE);
            if (st.hasMoreTokens())
            {
                st.nextToken();
            }
            int s;
            int e;
            String t;
            while (st.hasMoreTokens())
            {
                t = st.nextToken();
                s = t.indexOf(ConstUI.SP_KV);
                e = t.lastIndexOf(ConstUI.SP_KV);
                if (s < 0 || s >= e)
                {
                    continue;
                }

                keys.append(t.substring(s + 1, e));
                keys.append(P30F0000.getMesg(LangRes.P30FA101));
                keys.append(t.substring(e + 1));
                keys.append("\n");
            }

            return keys.toString();
        }
        catch(Exception exp)
        {
            LogUtil.exception(exp);
            return keys.toString();
        }
        finally
        {
            dba.closeConnection();
        }
    }

    /**
     * 数据加密处理
     * 
     * @param dba
     */
    private void enCrypt(DBAccess dba) throws Exception
    {
        // 字符串拼接
        StringBuffer sb = new StringBuffer();
        // 其它信息
        for (PropItem item : ls_ItemList)
        {
            sb.append(item.getType());
            sb.append(ConstUI.SP_KV);
            sb.append(item.getName());
            sb.append(ConstUI.SP_KV);
            sb.append(item.getData());
            sb.append(ConstUI.SP_EE);
        }

        // 加密算法初始化
        Cipher aes = Cipher.getInstance(ConstUI.NAME_CIPHER);
        aes.init(Cipher.ENCRYPT_MODE, uk_UserKeys);

        byte[] dst;
        int idx = 0;
        byte[] src = sb.toString().getBytes(SysCons.FILE_ENCODING);
        String userHash = "" + RmpsUtil.getUserInfo().getUserID();
        // 循环处理每一块数据
        for (int i = 0, j = ConstUI.RECORD_DATA_SIZE; i < src.length;)
        {
            // 以2048字节为一块进行处理
            if (j > src.length)
            {
                j = src.length;
            }
            dst = aes.update(src, i, j);
            i = j;
            j += ConstUI.RECORD_DATA_SIZE;

            // 记录数据到数据库
            dba.addTable(PrpCons.P30F0100);
            dba.addParam(PrpCons.P30F0101, ConstUI.PWDS_STAT_1);// 是否使用中
            dba.addParam(PrpCons.P30F0102, Integer.toString(idx++), false);// 数据块区分
            dba.addParam(PrpCons.P30F0103, keysHash);// 口令索引
            dba.addParam(PrpCons.P30F0104, currHash); // 更新标记
            dba.addParam(PrpCons.P30F0105, userHash);// 用户索引
            dba.addParam(PrpCons.P30F0106, typeHash);// 类别索引
            dba.addParam(PrpCons.P30F0107, StringUtil.toDBText(keysName));// 口令标题
            dba.addParam(PrpCons.P30F0108, StringUtil.toDBText(keysMeta));// 关键搜索
            dba.addParam(PrpCons.P30F0109, StringUtil.bytesToString(uk_UserKeys.getCharacter(), dst));// 密文
            dba.addParam(PrpCons.P30F010A, "");// 相关说明
            dba.executeInsert();
            dba.reset();
        }

        dst = aes.doFinal();

        dba.addTable(PrpCons.P30F0100);
        dba.addParam(PrpCons.P30F0101, ConstUI.PWDS_STAT_1);// 是否使用中
        dba.addParam(PrpCons.P30F0102, Integer.toString(idx++), false);// 数据块区分
        dba.addParam(PrpCons.P30F0103, keysHash);// 索引
        dba.addParam(PrpCons.P30F0104, currHash); // 更新标记
        dba.addParam(PrpCons.P30F0105, userHash);// 用户索引
        dba.addParam(PrpCons.P30F0106, typeHash);// 类别索引
        dba.addParam(PrpCons.P30F0107, StringUtil.toDBText(keysName));// 口令标题
        dba.addParam(PrpCons.P30F0108, StringUtil.toDBText(keysMeta));// 关键搜索
        dba.addParam(PrpCons.P30F0109, StringUtil.bytesToString(uk_UserKeys.getCharacter(), dst));// 密文
        dba.addParam(PrpCons.P30F010A, "");// 相关说明
        dba.executeInsert();
    }

    /** serialVersionUID */
    private static final long serialVersionUID = -7751147050913819559L;

    /**
     * @return the typeHash
     */
    public String getTypeHash()
    {
        return typeHash;
    }

    /**
     * @param typeHash the typeHash to set
     */
    public void setTypeHash(String typeHash)
    {
        this.typeHash = typeHash;
    }

    /**
     * @return the keysHash
     */
    public String getKeysHash()
    {
        return keysHash;
    }

    /**
     * @param keysHash the keysHash to set
     */
    public void setKeysHash(String keysHash)
    {
        this.keysHash = keysHash;
    }

    /**
     * @return the keysName
     */
    public String getKeysName()
    {
        return keysName;
    }

    /**
     * @param keysName the keysName to set
     */
    public void setKeysName(String keysName)
    {
        this.keysName = keysName;
    }

    /**
     * @return the dateTime
     */
    public Date getDateTime()
    {
        if (dateTime == null)
        {
            dateTime = new Date(System.currentTimeMillis());
        }
        return dateTime;
    }

    /**
     * @return the keysMeta
     */
    public String getKeysMeta()
    {
        return keysMeta;
    }

    /**
     * @param keysMeta the keysMeta to set
     */
    public void setKeysMeta(String keysMeta)
    {
        this.keysMeta = keysMeta;
    }
}
