/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.m;

import rmp.face.WBaseData;
import cons.prp.aide.P3010000.ConstUI;

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
public class TypeBaseData extends WBaseData
{
    /** 系统标记 */
    private int systemID = 0;
    /** 类别标记 */
    private String typeIndx;
    /** 类别名称 */
    private String typeName;
    /** 类别描述 */
    private String typeDesp;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    @Override
    public boolean wInit()
    {
        typeIndx = ConstUI.DEF_TYPEHASH;
        typeName = "";
        typeDesp = "";

        return true;
    }

    /**
     * @return the systemID
     */
    public int getSystemID()
    {
        return systemID;
    }

    /**
     * @param systemID the systemID to set
     */
    public void setSystemID(int systemID)
    {
        this.systemID = systemID;
    }

    /**
     * @return the typeIndx
     */
    public String getTypeIndx()
    {
        return typeIndx;
    }

    /**
     * @param typeIndx the typeIndx to set
     */
    public void setTypeIndx(String typeIndx)
    {
        this.typeIndx = typeIndx;
    }

    /**
     * @return the typeName
     */
    public String getTypeName()
    {
        return typeName;
    }

    /**
     * @param typeName the typeName to set
     */
    public void setTypeName(String typeName)
    {
        this.typeName = typeName;
    }

    /**
     * @return the typeDesp
     */
    public String getTypeDesp()
    {
        return typeDesp;
    }

    /**
     * @param typeDesp the typeDesp to set
     */
    public void setTypeDesp(String typeDesp)
    {
        this.typeDesp = typeDesp;
    }
}
