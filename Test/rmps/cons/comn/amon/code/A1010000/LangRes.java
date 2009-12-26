/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.comn.amon.code.A1010000;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 代码安全语言资源常量
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public interface LangRes
{
    /** 窗口标题 */
    String TITLE_FRAME = "81010000";
    // ========================================================================
    // 高级窗口语言资源区域
    // ========================================================================
    // ----------------------------------------------------
    // 0 预留语言资源
    // ----------------------------------------------------
    /** 高级窗口标题 */
    String TITLE_FRAME_MAIN = "81016000";
    // ----------------------------------------------------
    // 1 共用语言资源
    // ----------------------------------------------------
    // ----------------------------------------------------
    // 2 标题语言资源
    // ----------------------------------------------------
    // ----------------------------------------------------
    // 3 标签语言资源
    // ----------------------------------------------------
    /** 来源文件 */
    String LABL_TEXT_SRCFILE = "81016301";
    String LABL_TIPS_SRCFILE = "81016302";
    /** 输出文件 */
    String LABL_TEXT_DSTFILE = "81016303";
    String LABL_TIPS_DSTFILE = "81016304";
    /** 日志 */
    String LABL_TEXT_LOG = "81016305";
    String LABL_TIPS_LOG = "81016306";
    /** 注释 */
    String LABL_TEXT_CMT = "81016307";
    String LABL_TIPS_CMT = "81016308";
    /** 格式 */
    String LABL_TEXT_FMT = "81016309";
    String LABL_TIPS_FMT = "8101630A";
    /** 转换方式 */
    String LABL_TEXT_CIPHERTP = "8101630B";
    String LABL_TIPS_CIPHERTP = "8101630C";
    /** 密码算法 */
    String LABL_TEXT_CIPHERNM = "8101630D";
    String LABL_TIPS_CIPHERNM = "8101630E";
    /** 用户口令 */
    String LABL_TEXT_USERPWDS = "8101630F";
    String LABL_TIPS_USERPWDS = "81016310";
    // ----------------------------------------------------
    // 4 文本语言资源
    // ----------------------------------------------------
    /** 来源文件 */
    String FILD_TEXT_CSRCFILE = "81016401";
    String FILD_TIPS_CSRCFILE = "81016402";
    // 来源文件路径，可以是文档或目录";
    /** 输出文件 */
    String FILD_TEXT_DSTFILE = "81016403";
    String FILD_TIPS_DSTFILE = "81016404";
    // 输出文件路径，可以是文档或目录";
    /** 处理结果 */
    String AREA_TEXT_INFOAREA = "81016405";
    String AREA_TIPS_INFOAREA = "81016406";
    /** 分块大小 */
    String FILD_TEXT_CHARSIZE = "81016407";
    String FILD_TIPS_CHARSIZE = "81016408";
    /** 用户口令 */
    String FILD_TEXT_USERPWDS = "81016409";
    String FILD_TIPS_USERPWDS = "8101640A";
    /** 来源文件 */
    String FILD_TEXT_SSRCFILE = "8101640B";
    String FILD_TIPS_SSRCFILE = "8101640C";
    // ----------------------------------------------------
    // 5 按钮语言资源
    // ----------------------------------------------------
    /** 来源文件 */
    String BUTN_TEXT_SRCFILE = "81016501";
    // 选择(&S)";
    String BUTN_TIPS_SRCFILE = "81016502";
    // 选择来源文件";
    /** 输出文件 */
    String BUTN_TEXT_DSTFILE = "81016503";
    // 选择(&D)";
    String BUTN_TIPS_DSTFILE = "81016504";
    // 选择输出文件";
    /** 清除注释 */
    String BUTN_TEXT_COMMENT = "81016505";
    // 清除(&C)";
    String BUTN_TIPS_COMMENT = "81016506";
    // 执行代码注释清除操作";
    /** 运算 */
    String BUTN_TEXT_CODESEC = "81016507";
    // 运算(&O)";
    String BUTN_TIPS_CODESEC = "81016508";
    // 执行数据的加密操作";
    // ----------------------------------------------------
    // 6 菜单语言资源
    // ----------------------------------------------------
    // ----------------------------------------------------
    // 7 单选框语言资源
    // ----------------------------------------------------
    /** 清除注释 */
    String RBTN_TEXT_COMMENT = "81016701";
    // 代码清理";
    String RBTN_TIPS_COMMENT = "81016702";
    // 清除代码中的注释及日志等";
    /** 代码安全 */
    String RBTN_TEXT_CODESEC = "81016703";
    // 代码安全";
    String RBTN_TIPS_CODESEC = "81016704";
    // 对代码进行加密或解密处理";
    // ----------------------------------------------------
    // 8 复选框语言资源
    // ----------------------------------------------------
    /** 调试日志 */
    String CHCK_TEXT_LOG1 = "81016801";
    String CHCK_TIPS_LOG1 = "81016802";
    /** 消息日志 */
    String CHCK_TEXT_LOG2 = "81016803";
    String CHCK_TIPS_LOG2 = "81016804";
    /** 异常日志 */
    String CHCK_TEXT_LOG3 = "81016805";
    String CHCK_TIPS_LOG3 = "81016806";
    /** 文档注释 */
    String CHCK_TEXT_CMT1 = "81016807";
    String CHCK_TIPS_CMT1 = "81016808";
    /** 多行注释 */
    String CHCK_TEXT_CMT2 = "81016809";
    String CHCK_TIPS_CMT2 = "8101680A";
    /** 单行注释 */
    String CHCK_TEXT_CMT3 = "8101680B";
    String CHCK_TIPS_CMT3 = "8101680C";
    /** 空格 */
    String CHCK_TEXT_FMT1 = "8101680D";
    String CHCK_TIPS_FMT1 = "8101680E";
    /** 空行 */
    String CHCK_TEXT_FMT2 = "8101680F";
    String CHCK_TIPS_FMT2 = "81016810";
    /** 回行 */
    String CHCK_TEXT_FMT3 = "81016811";
    String CHCK_TIPS_FMT3 = "81016812";
    /** 随机口令 */
    String CHCK_TEXT_RANDOMKEY = "81016813";
    String CHCK_TIPS_RANDOMKEY = "81016814";
    // ----------------------------------------------------
    // 9 其它组件语言资源
    // ----------------------------------------------------
    /** 解密 */
    String COMB_TEXT_DECIPHER = "81016903";
    // 解密";
    String COMB_TIPS_DECIPHER = "81016904";
    // 解密";
    /** 加密 */
    String COMB_TEXT_ENCIPHER = "81016905";
    // 加密";
    String COMB_TIPS_ENCIPHER = "81016906";
    // 加密";
    // ----------------------------------------------------
    // A 消息提示语言资源
    // ----------------------------------------------------
    /** 来源文件不能为空 */
    String MESG_0001 = "81016A01";
    /** 来源文件不存在 */
    String MESG_0002 = "81016A02";
    /** 输出文件不能为空 */
    String MESG_0003 = "81016A03";
    /** 输出文件不存在 */
    String MESG_0004 = "81016A04";
    /** 选择注释清除选项 */
    String MESG_0005 = "81016A05";
    /** 文件列表为空 */
    String MESG_0006 = "81016A06";
    /** 未知错误 */
    String MESG_0007 = "81016A07";
    /** 文件打开出现未知错误 */
    String MESG_0008 = "81016A08";
    /** 注释清理完毕 */
    String MESG_0009 = "81016A09";
    /** 文档加密处理成功 */
    String MESG_0010 = "81016A0A";
    /** 文档解密处理成功 */
    String MESG_0011 = "81016A0B";
    // ----------------------------------------------------
    // F 日志输出语言资源
    // ----------------------------------------------------
}
