/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.io.df;

import java.io.File;
import java.io.IOException;

import rmp.util.LogUtil;


import cons.SysCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 文件存取抽象类，提供一些共用的变量及方法。
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public abstract class FileAccess
{
    // -----------------------------------------------------
    // 与文档头有关的一些关键控制信息
    // -----------------------------------------------------
    /**
     * 当前读取文档的文档签名
     */
    protected int fileMagic;
    /**
     * 当前读取文档的应用系统
     */
    protected int fileSystem;
    /**
     * 当前读取文档的版本信息
     */
    protected long fileVersion;
    // -----------------------------------------------------
    // 原有数据文档操作
    // -----------------------------------------------------
    /**
     * 原有数据流数据段起始偏移地址，相对于文档起始处
     */
    protected long dataStart;
    /**
     * 原有数据文档
     */
    protected File dataFile;
    /**
     * 原有数据文档输入输出流
     */
    protected BufferedStream dataStream;
    // -----------------------------------------------------
    // 交换数据文档操作
    // -----------------------------------------------------
    /**
     * 交换数据流数据段起始偏移地址，相对于文档起始处
     */
    protected long swapStart;
    /**
     * 交换数据文档
     */
    protected File swapFile;
    /**
     * 交换数据文档输入输出流
     */
    protected BufferedStream swapStream;

    // -----------------------------------------------------
    // 与存取文档有关的一些方法
    // -----------------------------------------------------
    /**
     * 当前读取文档的合法性及版本信息的判断
     * 
     * @return
     */
    protected abstract boolean checkFile();

    /**
     * 获得当前系统使用的数据文件的路径
     * 
     * @param fileExts
     *            指定的文件后缀名称
     * @return
     */
    protected abstract String getFilePath(String fileExts);

    /**
     * 文件头信息读取，此方法默认仅读取文档签名字段、应用系统字段及文档版本信息字段（默认包含文档是否使用 加密字段）。
     * 
     * @param bStream
     *            文档读取流
     */
    protected boolean readHead(BufferedStream bStream)
    {
        try
        {
            dataStream.seek(0, true);
            // 文档签名读取
            fileMagic = bStream.readInt();
            // 应用系统读取
            fileSystem = bStream.readInt();
            // 文档版本读取
            fileVersion = bStream.readLong();

            return true;
        }
        catch (IOException ioe)
        {
            LogUtil.exception(ioe);
        }
        return false;
    }

    /**
     * 写入文档结尾信息
     * 
     * @param bStream
     */
    protected void writeEOF(BufferedStream bStream)
    {
        try
        {
            bStream.writeInt(SysCons.FILE_TAIL_SIGN);
        }
        catch (IOException ioe)
        {
            LogUtil.exception(ioe);
        }
    }

    /**
     * 使用指定的文档流，写入适用于当前系统的文件头标记信息
     * 
     * @param 要写入的数据文档所使用的文档流
     */
    protected abstract void writeHead(BufferedStream bStream);

    /**
     * 从当前正式数据文档中读取符合要求的元记录数据，并返回读取记录的个数
     * 
     * @return 实际读取的符合读取要求的元记录数据的个数，数值-1表示读取存在错误
     */
    protected abstract int readMeta();

    /**
     * 在当前正式数据文档中写入符合要求的元记录数据，并返回是否写入成功
     * 
     * @return 符合写入要求的元记录数据是否写入成功
     */
    protected abstract boolean writeMeta();
}
