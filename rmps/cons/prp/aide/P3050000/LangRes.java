/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.prp.aide.P3050000;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * 
 * @author Amon
 */
public interface LangRes
{
    String TITLE_FRAME = "13050101";
    // 数据安全";
    // ////////////////////////////////////////////////////////////////////////
    // 密码类别
    // ////////////////////////////////////////////////////////////////////////
    /** 散列摘要 */
    String CIPHERTP_MD = "13050111";
    // 散列摘要";
    /** 奇偶校验 */
    String CIPHERTP_CS = "13050112";
    // 奇偶校验";
    /** 块加密 */
    String CIPHERTP_BC = "13050113";
    // 块加密";
    /** 流加密 */
    String CIPHERTP_SC = "13050114";
    // 流加密";
    /** Signature Algorithms */
    String CIPHERTP_SA = "13050115";
    /** KeyGenerator */
    String CIPHERTP_KG = "13050116";
    /** KeyAgreement */
    String CIPHERTP_KA = "13050117";
    // ////////////////////////////////////////////////////////////////////////
    // 散列摘要
    // ////////////////////////////////////////////////////////////////////////
    /** MD2 */
    String CIPHERNM_MD_TEXT_MD2 = "13050121";
    // MD2";
    String CIPHERNM_MD_TIPS_MD2 = "13050122";
    // MD2";
    /** MD4 */
    String CIPHERNM_MD_TEXT_MD4 = "13050123";
    // MD4";
    String CIPHERNM_MD_TIPS_MD4 = "13050124";
    // MD4";
    /** MD5 */
    String CIPHERNM_MD_TEXT_MD5 = "13050125";
    // MD5";
    String CIPHERNM_MD_TIPS_MD5 = "13050126";
    // MD5";
    /** SHA-1 */
    String CIPHERNM_MD_TEXT_SHA1 = "13050127";
    // SHA-1";
    String CIPHERNM_MD_TIPS_SHA1 = "13050128";
    // SHA-1";
    /** SHA-256 */
    String CIPHERNM_MD_TEXT_SHA256 = "13050129";
    // SHA-256";
    String CIPHERNM_MD_TIPS_SHA256 = "1305012A";
    // 256-bit hash function";
    /** SHA-384 */
    String CIPHERNM_MD_TEXT_SHA384 = "1305012B";
    // SHA-384";
    String CIPHERNM_MD_TIPS_SHA384 = "1305012C";
    // 384-bit hash function";
    /** SHA-512 */
    String CIPHERNM_MD_TEXT_SHA512 = "1305012D";
    // SHA-512";
    String CIPHERNM_MD_TIPS_SHA512 = "1305012E";
    // 512-bit hash function";
    /** RIPEMD */
    String CIPHERNM_MD_TEXT_RIPEMD = "1305012F";
    String CIPHERNM_MD_TIPS_RIPEMD = "13050130";
    /** RIPEMD128 */
    String CIPHERNM_MD_TEXT_RIPEMD128 = "13050131";
    String CIPHERNM_MD_TIPS_RIPEMD128 = "13050132";
    /** RIPEMD160 */
    String CIPHERNM_MD_TEXT_RIPEMD160 = "13050133";
    String CIPHERNM_MD_TIPS_RIPEMD160 = "13050134";
    /** Tiger */
    String CIPHERNM_MD_TEXT_TIGER = "13050135";
    // Tiger";
    String CIPHERNM_MD_TIPS_TIGER = "13050136";
    // Tiger";
    // RC6";
    // ////////////////////////////////////////////////////////////////////////
    // 奇偶校验
    // ////////////////////////////////////////////////////////////////////////
    /** CRC32 */
    String CIPHERNM_CS_TEXT_CRC32 = "13050141";
    // CRC32";
    String CIPHERNM_CS_TIPS_CRC32 = "13050142";
    // CRC32";
    /** CRC64 */
    String CIPHERNM_CS_TEXT_CRC64 = "13050143";
    // CRC64";
    String CIPHERNM_CS_TIPS_CRC64 = "13050144";
    // ////////////////////////////////////////////////////////////////////////
    // 块加密
    // ////////////////////////////////////////////////////////////////////////
    /** AES */
    String CIPHERNM_BC_TEXT_AES = "13050151";
    // AES";
    String CIPHERNM_BC_TIPS_AES = "13050152";
    // Advanced Encryption Standard";
    /** AESWrap */
    String CIPHERNM_BC_TEXT_AESWRAP = "13050153";
    // AESWrap";
    String CIPHERNM_BC_TIPS_AESWRAP = "13050154";
    // AES key wrapping";
    /** Blowfish */
    String CIPHERNM_BC_TEXT_BLOWFISH = "13050155";
    // Blowfish";
    String CIPHERNM_BC_TIPS_BLOWFISH = "13050156";
    // Blowfish";
    /** DES */
    String CIPHERNM_BC_TEXT_DES = "13050157";
    // DES";
    String CIPHERNM_BC_TIPS_DES = "13050158";
    // Digital Encryption Standard";
    /** DESede */
    String CIPHERNM_BC_TEXT_DESEDE = "13050159";
    // DESede";
    String CIPHERNM_BC_TIPS_DESEDE = "1305015A";
    // Triple DES";
    /** DESedeWrap */
    String CIPHERNM_BC_TEXT_DESEDEWRAP = "1305015B";
    // DESedeWrap";
    String CIPHERNM_BC_TIPS_DESEDEWRAP = "1305015C";
    // DESede key wrapping";
    /** ECIES */
    String CIPHERNM_BC_TEXT_ECIES = "1305015D";
    // ECIES";
    String CIPHERNM_BC_TIPS_ECIES = "1305015E";
    // Elliptic Curve Integrated Encryption Scheme";
    /** IDEA */
    String CIPHERNM_BC_TEXT_IDEA = "1305015F";
    // IDEA";
    String CIPHERNM_BC_TIPS_IDEA = "13050160";
    // IDEA";
    /** MARS */
    String CIPHERNM_BC_TEXT_MARS = "13050161";
    // MARS";
    String CIPHERNM_BC_TIPS_MARS = "13050162";
    // MARS";
    // ////////////////////////////////////////////////////////////////////////
    // 流加密
    // ////////////////////////////////////////////////////////////////////////
    /** RC2 */
    String CIPHERNM_SC_TEXT_RC2 = "13050171";
    // RC2";
    String CIPHERNM_SC_TIPS_RC2 = "13050172";
    // RC2";
    /** RC4 */
    String CIPHERNM_SC_TEXT_RC4 = "13050173";
    // RC4";
    String CIPHERNM_SC_TIPS_RC4 = "13050174";
    // RC4";
    /** RC5 */
    String CIPHERNM_SC_TEXT_RC5 = "13050175";
    // RC5";
    String CIPHERNM_SC_TIPS_RC5 = "13050176";
    // RC5";
    /** RC6 */
    String CIPHERNM_SC_TEXT_RC6 = "13050177";
    // RC6";
    String CIPHERNM_SC_TIPS_RC6 = "13050178";
    // CRC64";
    // ////////////////////////////////////////////////////////////////////////
    // 数字签名
    // ////////////////////////////////////////////////////////////////////////
    /** DH */
    String CIPHERNM_TEXT_PK_DH = "DH";
    String CIPHERNM_TIPS_PK_DH = "Diffie-Hellman";
    /** DSA */
    String CIPHERNM_TEXT_DSA = "DSA";
    String CIPHERNM_TIPS_DSA = "Digital Signature Algorithm";
    /** RSA */
    String CIPHERNM_TEXT_RSA = "RSA";
    String CIPHERNM_TIPS_RSA = "RSA";
    /** EC */
    String CIPHERNM_TEXT_EC = "EC";
    String CIPHERNM_TIPS_EC = "Elliptic Curve algorithm";
    // ////////////////////////////////////////////////////////////////////////
    // 标签语言资源
    // ////////////////////////////////////////////////////////////////////////
    /** 用户口令 */
    String LABL_TEXT_USERPWDS = "13050801";
    // 口令(&P)";
    String LABL_TIPS_USERPWDS = "13050802";
    /** 明文 */
    String LABL_TEXT_SRCTAREA = "13050803";
    // 明文(&S)";
    String LABL_TIPS_SRCTAREA = "13050804";
    /** 密文 */
    String LABL_TEXT_DSTTAREA = "13050805";
    // 密文(&S)";
    String LABL_TIPS_DSTTAREA = "13050806";
    /** 明文 */
    String LABL_TEXT_SRCFLIST = "13050807";
    // 明文(&S)";
    String LABL_TIPS_SRCFLIST = "13050808";
    /** 密文 */
    String LABL_TEXT_DSTTLIST = "13050809";
    // 密文(&D)";
    String LABL_TIPS_DSTTLIST = "1305080A";
    // ////////////////////////////////////////////////////////////////////////
    // 文本语言资源
    // ////////////////////////////////////////////////////////////////////////
    /** 口令 */
    String FILD_TEXT_USERPWDS = "13050901";
    String FILD_TIPS_USERPWDS = "13050902";
    // 用户口令";
    /** 明文 */
    String AREA_TEXT_SRCTAREA = "13050903";
    String AREA_TIPS_SRCTAREA = "13050904";
    /** 密文 */
    String AREA_TEXT_DSTTAREA = "13050905";
    String AREA_TIPS_DSTTAREA = "13050906";
    // ////////////////////////////////////////////////////////////////////////
    // 按钮语言资源
    // ////////////////////////////////////////////////////////////////////////
    /** 加密 */
    String BUTN_TEXT_ENCIPHER = "13050A01";
    // 加密(&E)";
    String BUTN_TIPS_ENCIPHER = "13050A02";
    /** 解密 */
    String BUTN_TEXT_DECIPHER = "13050A03";
    // 解密(&D)";
    String BUTN_TIPS_DECIPHER = "13050A04";
    /** 运算 */
    String BUTN_TEXT_DODIGEST = "13050A05";
    // 运算(&O)";
    String BUTN_TIPS_DODIGEST = "13050A06";
    // ////////////////////////////////////////////////////////////////////////
    // 组合框语言资源
    // ////////////////////////////////////////////////////////////////////////
    /** 密码名称 */
    String COMB_TIPS_CIPHERTP = "13050B02";
    /** 密码类别 */
    String COMB_TIPS_CIPHERNM = "13050B04";
    // ////////////////////////////////////////////////////////////////////////
    // 单选按钮语言资源
    // ////////////////////////////////////////////////////////////////////////
    /** 文件模式 */
    String RBTN_TEXT_FILEMODE = "13050D01";
    // 文件模式(&F)";
    String RBTN_TIPS_FILEMODE = "13050D02";
    /** 文本模式 */
    String RBTN_TEXT_TEXTMODE = "13050D03";
    // 文本模式(&C)";
    String RBTN_TIPS_TEXTMODE = "13050D04";
    /** 明文 */
    String LIST_TIPS_SRCFLIST = "13050F01";
    /** 密文 */
    String LIST_TIPS_DSTFLIST = "13050F02";
    // ////////////////////////////////////////////////////////////////////////
    // 消息提示
    // ////////////////////////////////////////////////////////////////////////
    /** 文件不存在 */
    String MESG_CHCK_0101 = "13050301";
    // 来源数据文件 “{0}” 不存在!";
    String MESG_CHCK_0102 = "13050302";
    // 无法创建加密数据文件 “{0}”，请确认您对此文件的访问权限。";
    String MESG_CHCK_0103 = "13050303";
    // 无法创建解密数据文件 “{0}”，请确认您对此文件的访问权限。";
    String MESG_CHCK_0104 = "13050304";
    // 用户口令不能空！";
    String MESG_CHCK_0105 = "13050305";
    // 请选择您要进行密码运算的单个或多个文件！";
    String MESG_CHCK_0106 = "13050306";
    // 请输入您要进行密码运算的字符信息！";
    String MESG_UPDT_0101 = "13050501";
    // 算法初始化错误：数据散列算法{0}不存在，请确认算法名称是否正确。";
    String MESG_UPDT_0102 = "13050502";
    // 数据散列处理错误。";
    String MESG_UPDT_0202 = "13050503";
    // 文件校验处理错误";
    String MESG_UPDT_0302 = "13050504";
    // 算法初始化错误：数据加密算法{0}不存在，请确认算法名称是否正确。";
    String MESG_UPDT_0303 = "13050505";
    // 算法初始化错误：数据加密算法{0}允许最大密钥长度为{1}字节，请修正您的口令长度。";
    String MESG_UPDT_0304 = "13050506";
    // 算法初始化错误：密钥长度与密码算法需求长度不符！";
    String MESG_UPDT_0305 = "13050507";
    // 数据加密出现未知错误。";
    String MESG_UPDT_0306 = "13050508";
    // 数据解密出现未知错误。";
    String MESG_UPDT_0307 = "13050509";
    // {0}，文件加密中....";
}
