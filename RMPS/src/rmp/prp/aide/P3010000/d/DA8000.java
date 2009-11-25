/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.d;

import java.sql.SQLException;
import java.util.List;

import rmp.io.db.DBAccess;
import rmp.prp.aide.P3010000.b.K2SV2S;
import rmp.prp.aide.P3010000.m.AsocBaseData;
import rmp.prp.aide.P3010000.m.AsocUserData;
import rmp.prp.aide.P3010000.m.CorpBaseData;
import rmp.prp.aide.P3010000.m.CorpUserData;
import rmp.prp.aide.P3010000.m.DespBaseData;
import rmp.prp.aide.P3010000.m.DespUserData;
import rmp.prp.aide.P3010000.m.DocsBaseData;
import rmp.prp.aide.P3010000.m.DocsUserData;
import rmp.prp.aide.P3010000.m.ExtsBaseData;
import rmp.prp.aide.P3010000.m.ExtsUserData;
import rmp.prp.aide.P3010000.m.FileBaseData;
import rmp.prp.aide.P3010000.m.FileUserData;
import rmp.prp.aide.P3010000.m.IdioBaseData;
import rmp.prp.aide.P3010000.m.IdioUserData;
import rmp.prp.aide.P3010000.m.MimeBaseData;
import rmp.prp.aide.P3010000.m.MimeUserData;
import rmp.prp.aide.P3010000.m.SoftBaseData;
import rmp.prp.aide.P3010000.m.SoftUserData;
import rmp.prp.aide.P3010000.m.TypeUserData;
import rmp.prp.aide.P3010000.m.UserData;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 后缀解析数据库存取类
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class DA8000
{
    /**
     * @param extsName
     * @return
     * @throws SQLException
     */
    public static List<UserData> selectMeta(DBAccess dba, String extsName) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param extsName
     * @param softHash
     * @return
     * @throws SQLException
     */
    public static UserData selectMeta(DBAccess dba, String extsName, String softHash) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param extsName
     * @return
     * @throws SQLException
     */
    public static int deleteMeta(DBAccess dba, String extsName) throws SQLException
    {
        return 0;
    }

    /**
     * @return
     * @throws SQLException
     */
    public static int deleteMeta(DBAccess dba, String extsName, String softHash) throws SQLException
    {
        return 0;
    }

    /**
     * @param dba
     * @param asocHash
     * @param t
     * @return
     * @throws SQLException
     */
    public static AsocBaseData selectAsocMetaInfo(DBAccess dba, String asocHash, String t) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param asocHash
     * @param t
     * @return
     * @throws SQLException
     */
    public static List<K2SV2S> selectAsocMetaList(DBAccess dba, String asocHash, String t) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param corpHash
     * @return
     * @throws SQLException
     */
    public static CorpBaseData selectCorpMetaInfo(DBAccess dba, String corpHash) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param corpHash
     * @return
     * @throws SQLException
     */
    public static List<K2SV2S> selectCorpMetaList(DBAccess dba, String natnHash, String t) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param destHash
     * @param langHash
     * @return
     * @throws SQLException
     */
    public static DespBaseData selectDespMetaInfo(DBAccess dba, String destHash, String langHash) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param destHash
     * @param langHash
     * @return
     * @throws SQLException
     */
    public static DespBaseData selectDespMetaList(DBAccess dba, String destHash, String langHash) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param docsHash
     * @return
     * @throws SQLException
     */
    public static DocsBaseData selectDocsMetaInfo(DBAccess dba, String docsHash) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param docsHash
     * @return
     * @throws SQLException
     */
    public static DocsBaseData selectDocsMetaList(DBAccess dba, String docsHash) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param destHash
     * @param langHash
     * @return
     * @throws SQLException
     */
    public static ExtsBaseData selectExtsMetaInfo(DBAccess dba, String destHash, String langHash) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param destHash
     * @param langHash
     * @return
     * @throws SQLException
     */
    public static ExtsBaseData selectExtsMetaList(DBAccess dba, String destHash, String langHash) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param fileHash
     * @return
     * @throws SQLException
     */
    public static FileBaseData selectFileMetaInfo(DBAccess dba, String fileHash) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param fileHash
     * @return
     * @throws SQLException
     */
    public static List<K2SV2S> selectFileMetaList(DBAccess dba, String softHash, String t) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param idioHash
     * @return
     * @throws SQLException
     */
    public static IdioBaseData selectIdioMetaInfo(DBAccess dba, String idioHash) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param idioHash
     * @return
     * @throws SQLException
     */
    public static List<K2SV2S> selectIdioMetaList(DBAccess dba, String idioHash) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param mimeHash
     * @return
     * @throws SQLException
     */
    public static MimeBaseData selectMimeMetaInfo(DBAccess dba, String mimeHash) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param mimeHash
     * @return
     * @throws SQLException
     */
    public static List<K2SV2S> selectMimeMetaList(DBAccess dba, String mimeHash) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @return
     * @throws SQLException
     */
    public static List<K2SV2S> selectNatnMetaList(DBAccess dba) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param softHash
     * @return
     * @throws SQLException
     */
    public static SoftBaseData selectSoftMetaInfo(DBAccess dba, String softHash) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param softHash
     * @return
     * @throws SQLException
     */
    public static List<K2SV2S> selectSoftMetaList(DBAccess dba, String corpHash, String t) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @return
     * @throws SQLException
     */
    public static List<K2SV2S> selectTypeMetaList(DBAccess dba) throws SQLException
    {
        return null;
    }

    /**
     * @param dba
     * @param meta
     * @return
     * @throws SQLException
     */
    public static int updateAsocMeta(DBAccess dba, AsocUserData meta) throws SQLException
    {
        return 1;
    }

    /**
     * @param dba
     * @param meta
     * @return
     * @throws SQLException
     */
    public static int updateCorpMeta(DBAccess dba, CorpUserData meta) throws SQLException
    {
        return 1;
    }

    /**
     * @param dba
     * @param meta
     * @return
     * @throws SQLException
     */
    public static int updateDespMeta(DBAccess dba, DespUserData meta) throws SQLException
    {
        return 1;
    }

    /**
     * @param dba
     * @param meta
     * @return
     * @throws SQLException
     */
    public static int updateDocsMeta(DBAccess dba, DocsUserData meta) throws SQLException
    {
        return 1;
    }

    /**
     * @param dba
     * @param meta
     * @return
     * @throws SQLException
     */
    public static int updateExtsMeta(DBAccess dba, ExtsUserData meta) throws SQLException
    {
        return 1;
    }

    /**
     * @param dba
     * @param meta
     * @return
     * @throws SQLException
     */
    public static int updateFileMeta(DBAccess dba, FileUserData meta) throws SQLException
    {
        return 1;
    }

    /**
     * @param dba
     * @param meta
     * @return
     * @throws SQLException
     */
    public static int updateIdioMeta(DBAccess dba, IdioUserData meta) throws SQLException
    {
        return 1;
    }

    /**
     * @param dba
     * @param meta
     * @return
     * @throws SQLException
     */
    public static int updateMimeMeta(DBAccess dba, MimeUserData meta) throws SQLException
    {
        return 1;
    }

    /**
     * @param dba
     * @param meta
     * @return
     * @throws SQLException
     */
    public static int updateSoftMeta(DBAccess dba, SoftUserData meta) throws SQLException
    {
        return 1;
    }

    /**
     * @param dba
     * @param meta
     * @return
     * @throws SQLException
     */
    public static int updateTypeMeta(DBAccess dba, TypeUserData meta) throws SQLException
    {
        return 1;
    }
}
