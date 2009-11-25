/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.m;

import rmp.face.WUserData;

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
public class TypeUserData extends WUserData
{
    private int systemId;
    private String typeIndx;
    private String typeName;
    private String typeDesp;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    @Override
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
    @Override
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
