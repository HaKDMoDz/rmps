/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.prp.aide.P3050000;

import cons.SysCons;
import cons.id.PrpCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 数据安全系统常量
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public interface ConstUI
{
    // ////////////////////////////////////////////////////////////////////////
    // 系统唯一标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件版本 */
    String VER_CODE = "1.2.0.0";
    /** 软件首页 */
    String URL_SOFT = SysCons.HOMEPAGE + "soft/soft0001.aspx?sid=" + PrpCons.P3050000_S;
    /** 电子邮件 */
    String URL_MAIL = SysCons.MAILADDR;
    // ////////////////////////////////////////////////////////////////////////
    // 语言配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件语言资源标记 */
    String RES_NAME = "P3050000";
    /** 软件标题语言资源标记 */
    String RES_TITLE = "P3050000.title";
    /** 软件描述信息语言资源标记 */
    String RES_DESCRIPTION = "P3050000.description";
    String NAME_TEXT_PANEL = "text";
    String NAME_FILE_PANEL = "file";
    /** MessageDigest */
    String CIPHERTP_MD = "0";
    /** CheckSum */
    String CIPHERTP_CS = "1";
    /** Block Cipher */
    String CIPHERTP_BC = "2";
    /** Stream Cipher */
    String CIPHERTP_SC = "3";
    /** KeyGenerator */
    String CIPHERTP_KG = "4";
    /** KeyAgreement */
    String CIPHERTP_KA = "5";
    // ////////////////////////////////////////////////////////////////////////
    // 散列摘要
    // ////////////////////////////////////////////////////////////////////////
    String CIPHERNM_MD_MD2 = "MD2";
    String CIPHERNM_MD_MD4 = "MD4";
    String CIPHERNM_MD_MD5 = "MD5";
    String CIPHERNM_MD_SHA1 = "SHA-1";
    String CIPHERNM_MD_SHA256 = "SHA-256";
    String CIPHERNM_MD_SHA384 = "SHA-384";
    String CIPHERNM_MD_SHA512 = "SHA-512";
    String CIPHERNM_MD_RIPEMD = "RIPEMD";
    String CIPHERNM_MD_RIPEMD128 = "RIPEMD128";
    String CIPHERNM_MD_RIPEMD160 = "RIPEMD160";
    String CIPHERNM_MD_TIGER = "Tiger";
    // ////////////////////////////////////////////////////////////////////////
    // 奇偶校验
    // ////////////////////////////////////////////////////////////////////////
    String CIPHERNM_CRC_CRC32 = "CRC32";
    String CIPHERNM_CRC_CRC64 = "CRC64";
    // ////////////////////////////////////////////////////////////////////////
    // 块加密
    // ////////////////////////////////////////////////////////////////////////
    String CIPHERNM_BC_AES = "AES";
    int KEY_SIZE_BC_AES = 16;
    String CIPHERNM_BC_AESWRAP = "AESWrap";
    int KEY_SIZE_BC_AESWRAP = 16;
    String CIPHERNM_BC_BLOWFISH = "Blowfish";
    int KEY_SIZE_BC_BLOWFISH = 16;
    String CIPHERNM_BC_DES = "DES";
    int KEY_SIZE_BC_DES = 8;
    String CIPHERNM_BC_DESEDE = "DESede";
    int KEY_SIZE_BC_DESEDE = 24;
    String CIPHERNM_BC_DESEDEWRAP = "DESedeWrap";
    int KEY_SIZE_BC_DESEDEWRAP = 16;
    String CIPHERNM_BC_ECIES = "ECIES";
    int KEY_SIZE_BC_ECIES = 16;
    String CIPHERNM_BC_IDEA = "IDEA";
    int KEY_SIZE_BC_IDEA = 16;
    String CIPHERNM_BC_MARS = "MARS";
    int KEY_SIZE_BC_MARS = 16;
    // ////////////////////////////////////////////////////////////////////////
    // 流加密
    // ////////////////////////////////////////////////////////////////////////
    String CIPHERNM_SC_RC2 = "RC2";
    int KEY_SIZE_SC_RC2 = 16;
    String CIPHERNM_SC_RC4 = "RC4";
    int KEY_SIZE_SC_RC4 = 16;
    String CIPHERNM_SC_RC5 = "RC5";
    int KEY_SIZE_SC_RC5 = 16;
    String CIPHERNM_SC_RC6 = "RC6";
    int KEY_SIZE_SC_RC6 = 16;
    // ////////////////////////////////////////////////////////////////////////
    // 加密过程使用常量
    // ////////////////////////////////////////////////////////////////////////
    /** 缓冲区内存大小 */
    int BUF_SIZE = 1024;
    /** 进度条刻度划分 */
    int DEF_STEP = 5;
    /** 密文文件默认附加后缀 */
    String DEF_PLUS = "!";
}
