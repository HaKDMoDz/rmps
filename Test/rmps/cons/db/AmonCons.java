/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.db;

import cons.SysCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * Amon系统数据库设计常量
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public interface AmonCons
{
    // ========================================================================
    // 数据管理
    // ========================================================================
    /** 数据管理 */
    String A2010100 = "A2010100";
    /** 数据管理： 表格标记 */
    String A2010101 = "A2010101";
    int A2010101_SIZE = 8;
    /** 数据管理： 中文名称 */
    String A2010102 = "A2010102";
    int A2010102_SIZE = 256;
    /** 数据管理： 数据类型 */
    String A2010103 = "A2010103";
    int A2010103_SIZE = 1;
    /** 数据管理： 数据长度 */
    String A2010104 = "A2010104";
    /** 数据管理： 是否主键 */
    String A2010105 = "A2010105";
    int A2010105_SIZE = 1;
    /** 数据管理： 是否为空 */
    String A2010106 = "A2010106";
    int A2010106_SIZE = 1;
    /** 数据管理： 是否唯一 */
    String A2010107 = "A2010107";
    int A2010107_SIZE = 1;
    /** 数据管理： 默认数据 */
    String A2010108 = "A2010108";
    int A2010108_SIZE = 1024;
    /** 数据管理： 参考外键 */
    String A2010109 = "A2010109";
    int A2010109_SIZE = 8;
    /** 数据管理： 类别标记 */
    String A201010A = "A201010A";
    int A201010A_SIZE = 1;
    /** 数据管理： 所属系统 */
    String A201010B = "A201010B";
    int A201010B_SIZE = 1;
    /** 数据管理： 创建人员 */
    String A201010C = "A201010C";
    int A201010C_SIZE = 256;
    /** 数据管理： 数据版本 */
    String A201010D = "A201010D";
    int A201010D_SIZE = 10;
    /** 数据管理： 表格描述 */
    String A201010E = "A201010E";
    int A201010E_SIZE = SysCons.DBCD_DESP_SIZE;
    /** 数据管理： 更新日期 */
    String A201010F = "A201010F";
    /** 数据管理： 提交日期 */
    String A2010110 = "A2010110";
}
