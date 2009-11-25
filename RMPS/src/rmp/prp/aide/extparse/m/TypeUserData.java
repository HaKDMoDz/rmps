/*
 * FileName:       TypeUserData.java
 * CreateDate:     2007/09/04 10:19:00
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.m;

import rmp.face.WUserData;

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
 * 日期： 2007/09/04 10:19:00
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class TypeUserData extends WUserData
{
    private int    systemId;
    private String typeIndx;
    private String typeName;
    private String typeDesp;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    @ Override
    public boolean wInit()
    {
        // TODO Auto-generated method stub
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WUserData#t2db()
     */
    @ Override
    public boolean t2db()
    {
        // TODO Auto-generated method stub
        return false;
    }

    /**
     * @return the systemId
     */
    public int getSystemId()
    {
        return systemId;
    }

    /**
     * @param systemId the systemId to set
     */
    public void setSystemId(int systemId)
    {
        this.systemId = systemId;
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
    public boolean setTypeName(String typeName)
    {
        this.typeName = typeName;
        return true;
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
    public boolean setTypeDesp(String typeDesp)
    {
        this.typeDesp = typeDesp;
        return true;
    }
}
