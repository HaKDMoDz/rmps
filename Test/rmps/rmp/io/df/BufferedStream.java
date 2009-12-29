/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.io.df;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.RandomAccessFile;

import rmp.util.LogUtil;


import cons.EnvCons;

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
public class BufferedStream
{
    // -----------------------------------------------------
    // 缓冲区特征控制变量
    // -----------------------------------------------------
    /**
     * 当前文档数据是否被修改过，true：是；false：未被修改
     */
    private boolean modified;
    /**
     * 当前文档数据是否使用加密，true：是；false：未使用加密
     */
    private boolean ciphered;
    // -----------------------------------------------------
    // 文件流及缓冲区控制变量
    // -----------------------------------------------------
    /**
     * 当前缓冲大小，以字节为单位
     */
    private int buffSize = EnvCons.COMN_BUFF_SIZE;
    /**
     * 当前缓冲区中实际有效字节个数，其数值介于0～buffSize之间
     */
    private int byteSize;
    /**
     * 当前读取位置相对于缓冲区起始位置的偏移量
     */
    private int buffPint;
    /**
     * 当前操作的文件的长度
     */
    private long fileLeng;
    /**
     * 当前缓冲数据相对于文档起始位置的偏移量
     */
    private long filePint;
    /**
     * 当前使用的字节缓冲区
     */
    private byte[] buffByte;
    // -----------------------------------------------------
    // 物理文件存取对象及控制信息
    // -----------------------------------------------------
    /**
     * 文件存取权限，其参数说明见java.io.RandomAccessFile类中的说明
     */
    private String acesMode = "rw";
    /**
     * 数据交互目标文件
     */
    private File destFile;
    /**
     * 系统随机文件流，用于随机读取或写入数据
     */
    private RandomAccessFile randStream;

    // /////////////////////////////////////////////////////////////////////////
    // 系统构造函数
    // /////////////////////////////////////////////////////////////////////////
    /**
     * 默认构造函数，此函数中并不实现任何操作
     */
    public BufferedStream()
    {
    }

    /**
     * 构造函数
     * 
     * @param filePath
     *            进行数据存取的目标文件路径
     * @param acesMode
     *            标记目标文件的读取写权限，其参数说明见RandomAccessFile构造函数中的说明
     */
    public BufferedStream(String filePath, String acesMode)
    {
        this(filePath, acesMode, EnvCons.COMN_BUFF_SIZE);
    }

    /**
     * 构造函数，创建一个指定缓冲区大小的文档流
     * 
     * @param filePath
     *            进行数据存取的目标文件路径
     * @param buffSize
     *            缓冲区的大小
     */
    public BufferedStream(String filePath, String acesMode, int buffSize)
    {
        this.destFile = new File(filePath);
        this.acesMode = acesMode;
        this.buffSize = buffSize;
    }

    /**
     * 创建一个使用默认大小缓冲区的文档流
     * 
     * @param destFile
     *            要进行读写操作的目标文件
     * @param acesMode
     *            标记目标文件的读取写权限，其参数说明见RandomAccessFile构造函数中的说明
     */
    public BufferedStream(File destFile, String acesMode)
    {
        this(destFile, acesMode, EnvCons.COMN_BUFF_SIZE);
    }

    /**
     * 创建一个使用指定大小缓冲区的文档流
     * 
     * @param destFile
     *            要进行读写操作的目标文件
     * @param acesMode
     *            标记目标文件的读取写权限，其参数说明见RandomAccessFile构造函数中的说明
     * @param buffSize
     *            使用的缓冲区的大小，建议大于2048字节，当缓冲区过小时会造成频繁的磁盘读写操作影响性能，
     *            当缓冲区过大时会造成不必要的空间浪费。
     */
    public BufferedStream(File destFile, String acesMode, int buffSize)
    {
        this.destFile = destFile;
        this.acesMode = acesMode;
        this.buffSize = buffSize;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.InitShow#wInit()
     */
    public boolean init()
    {
        // 目标文件持有对象是否为空判断
        if (destFile == null)
        {
            return false;
        }
        try
        {
            // 目标文件是否存在判断
            if (!destFile.exists())
            {
                destFile.createNewFile();
            }
            // 目标文件的真实性及读写性判断
            if (!destFile.isFile() || !destFile.canWrite())
            {
                return false;
            }
            // 随机文件流创建
            if (randStream != null)
            {
                randStream.close();
            }
            randStream = new RandomAccessFile(destFile, acesMode);
        }
        catch (FileNotFoundException fnfe)
        {
            LogUtil.exception(fnfe);
            return false;
        }
        catch (IOException ioe)
        {
            LogUtil.exception(ioe);
            return false;
        }

        // 当前缓冲区初始化
        if (buffByte == null || buffByte.length != buffSize)
        {
            buffByte = new byte[buffSize];
        }
        // 文件长度信息读取
        fileLeng = destFile.length();

        // 文档流控制信息初始化
        modified = false;
        filePint = 0;
        buffPint = 0;
        return true;
    }

    // /////////////////////////////////////////////////////////////////////////
    // 公共字节数据存取
    // /////////////////////////////////////////////////////////////////////////
    // -----------------------------------------------------
    // 字节数据读取方法
    // -----------------------------------------------------
    /**
     * 读取一个Boolean值
     * 
     * @return boolean 返回一个boolean值
     * @throws IOException
     *             文件存取异常
     */
    public boolean readBoolean() throws IOException
    {
        // 判断是否需要重新从文件中读取数据到缓冲区
        if (buffPint + 1 > byteSize)
        {
            if (!readFlush())
            {
                throw new IOException("End OF File -- Amon");
            }
        }

        // 合成用户需要的数据
        return buffByte[buffPint++] != 0;
    }

    /**
     * 读取一个字节数据，并以有符号Byte格式数据返回
     * 
     * @return byte 返回一个字节
     * @throw IOException 处理过程中抛出
     */
    public byte readSByte() throws IOException
    {
        // 判断是否需要重新从文件中读取数据到缓冲区
        if (buffPint + 1 > byteSize)
        {
            if (!readFlush())
            {
                throw new IOException("End OF File -- Amon");
            }
        }
        return buffByte[buffPint++];
    }

    /**
     * 读取一个字节数据，并以无符号Int格式数据返回
     * 
     * @return int 返回读取的值
     * @throws IOException
     *             读取文件时抛出
     */
    public int readUByte() throws IOException
    {
        return readSByte() & 0xFF;
    }

    /**
     * 读取指定的字节到目标字节数组中去
     * 
     * @param v
     *            目标数组
     * @return
     * @throws IOException
     */
    public int readBytes(byte[] v) throws IOException
    {
        return readBytes(v, 0, v.length);
    }

    /**
     * 读取指定长度的字节数据到指定偏移量的字节数组中去
     * 
     * @param v
     *            读取数据的存放数组
     * @param off
     *            指定数组的偏移量信息
     * @param len
     *            待读取的字节长度
     * @return 实际读取的字节长度
     * @throws IOException
     */
    public int readBytes(byte[] v, int off, int len) throws IOException
    {
        // 用户参数的合法性判断
        if (v == null)
        {
            return -1;
        }
        int vLen = v.length;
        if (vLen < 1 || off < 0 || len < 1 || off + len > vLen)
        {
            return -1;
        }

        // 判断要读取的字节长度是否超出剩余数据的长度
        vLen = (int) (fileLeng - filePint - buffPint);
        // 已经读取到文件结尾处的处理
        if (vLen < 1)
        {
            return -1;
        }

        // 若文件剩余数据长度不小于待读取字节长度，以读取指定长度的字节数据
        if (vLen >= len)
        {
            vLen = len;
        }
        // 否则仅读取剩余长度的字节数据
        else
        {
            len = vLen;
        }

        // 判断是否需要进行重新读取
        if (buffPint == byteSize)
        {
            readFlush();
        }

        // 缓冲区剩余有效字节数量
        int buffLeft = byteSize - buffPint;
        // 读取字节长度大于缓冲区中剩余字节长度时的处理
        while (vLen > buffLeft)
        {
            // 缓冲区数据拷贝到目标数组中
            System.arraycopy(buffByte, buffPint, v, off, buffLeft);
            // 目标数组偏移量更新
            off += buffLeft;
            // 剩余数组字节长度更新
            vLen -= buffLeft;
            // 流指针修正
            buffPint += buffLeft;
            // 从文件读取数据到缓冲区
            readFlush();
            // 缓冲区中剩余字节更新
            buffLeft = byteSize - buffPint;
        }
        // 读取字节长度小于缓冲区中剩余字节长度时的处理
        if (vLen > 0)
        {
            // 缓冲区数据拷贝到目标数组中
            System.arraycopy(buffByte, buffPint, v, off, vLen);
            // 缓冲区中当前文档流指针更新
            buffPint += vLen;
            // 修正剩余长度
            vLen = 0;
        }
        return len - vLen;
    }

    /**
     * 读取一个单字节字符
     * 
     * @return
     * @throws IOException
     */
    public char readChar1() throws IOException
    {
        return (char) (readSByte() & 0xFF);
    }

    /**
     * 读取单字节数据到指定的大小的字符数组中去
     */
    public int readChars1(char[] v) throws IOException
    {
        return readChars1(v, 0, v.length);
    }

    /**
     * 读取指定长度的单字节数据到指定的字符数组中去，并从指定位置起存放
     * 
     * @param v
     * @param off
     * @param len
     * @return
     * @throws IOException
     */
    public int readChars1(char[] v, int off, int len) throws IOException
    {
        // 用户参数的合法性判断
        if (v == null)
        {
            return -1;
        }
        int vLen = v.length;
        if (vLen < 1 || off < 0 || len < 1 || off + len > vLen)
        {
            return -1;
        }

        // 判断要读取的字节长度是否超出剩余数据的长度
        vLen = (int) (fileLeng - filePint - buffPint);
        // 已经读取到文件结尾处的处理
        if (vLen < 1)
        {
            return -1;
        }

        // 若文件剩余数据长度不小于待读取字节长度，以读取指定长度的字节数据
        if (vLen >= len)
        {
            vLen = len;
        }
        // 否则仅读取剩余长度的字节数据
        else
        {
            len = vLen;
        }

        // 判断是否需要进行重新读取
        if (buffPint == byteSize)
        {
            readFlush();
        }

        // 缓冲区剩余有效字节数量
        int buffLeft = byteSize - buffPint;
        // 读取字节长度大于缓冲区中剩余字节长度时的处理
        while (vLen > buffLeft)
        {
            // 缓冲区数据拷贝到目标数组中
            while (buffPint < byteSize)
            {
                v[off++] = (char) buffByte[buffPint++];
            }
            // 剩余数组字节长度更新
            vLen -= buffLeft;
            // 从文件读取数据到缓冲区
            readFlush();
            // 缓冲区中剩余字节更新
            buffLeft = byteSize - buffPint;
        }
        // 读取字节长度小于缓冲区中剩余字节长度时的处理
        // 缓冲区数据拷贝到目标数组中
        while (vLen-- > 0)
        {
            v[off++] = (char) buffByte[buffPint++];
        }
        return len - vLen;
    }

    /**
     * 读取一个单字节字符串数据
     * 
     * @param len
     *            读取的字符串的长度
     * @return 实际读取的字符串数据
     * @throws IOException
     *             文件存取异常
     */
    public String readString1(int len) throws IOException
    {
        // 读取长度合法性检查
        if (len < 1)
        {
            return null;
        }

        // 字节数据读取
        char v[] = new char[len];
        readChars1(v, 0, len);

        return new String(v);
    }

    // -----------------------------------------------------
    // 字节数据写入方法
    // -----------------------------------------------------
    /**
     * 写入一个boolean数值，true:则写入1 false：写入0
     * 
     * @param b
     *            写入数据的标识值
     * @throws IOException
     *             处理过程中抛出
     */
    public void writeBoolean(boolean v) throws IOException
    {
        // 判断是否需要进行缓冲区数据写出到文件
        if (buffPint + 1 > buffSize)
        {
            writeFlush();
        }

        // 写入单字节数据
        buffByte[buffPint++] = (byte) (v ? 1 : 0);

        // 修正当前数据缓冲区中存储字节数量
        byteSize = buffPint;
        modified = true;
    }

    /**
     * 写入一个字节数据，此处的S、U仅是相对于读取一个字节时的标记，后台写入数据并无区别
     * 
     * @param b
     *            待写入的字节数据
     * @throws IOException
     *             文件存取异常
     */
    public void writeSByte(byte v) throws IOException
    {
        // 判断是否需要进行缓冲区数据写出到文件
        if (buffPint + 1 > buffSize)
        {
            writeFlush();
        }

        // 写入单字节数据
        buffByte[buffPint++] = v;

        // 修正当前数据缓冲区中存储字节数量
        byteSize = buffPint;
        modified = true;
    }

    /**
     * 写入一个字节数据，此处的S、U仅是相对于读取一个字节时的标记，后台写入数据并无区别
     * 
     * @param i
     *            待写入的整形数据
     * @throws IOException
     *             文件存取异常
     */
    public void writeUByte(int v) throws IOException
    {
        writeSByte((byte) v);
    }

    /**
     * 写入指定的字节级数，并返回实际写入的字节数量
     * 
     * @param v
     *            待写入的字节数组
     * @return 实际写入的字节数量
     * @throws IOException
     *             文件存取异常
     */
    public void writeBytes(byte[] v) throws IOException
    {
        writeBytes(v, 0, v.length);
    }

    /**
     * 从当前文件流位置开始，写入指定的字节数组中从指定偏移地址开始指定长度的字节数组，并返回实际 写入的字节数量
     * 
     * @param v
     *            待写入的字节数组
     * @param off
     *            待写入字节数组的偏移量
     * @param len
     *            待写入字节数组的字节数量
     * @return 实际写入的字节个数
     * @throws IOException
     *             文件存取异常
     */
    public int writeBytes(byte[] v, int off, int len) throws IOException
    {
        // 用户参数合法性判断
        if (v == null)
        {
            return -1;
        }
        int vLen = v.length;
        if (vLen < 1 || off < 0 || len < 1 || off + len > vLen)
        {
            return -1;
        }
        vLen = len;

        // 判断是否需要将当前缓冲区中数据写出到文件
        if (buffPint == buffSize)
        {
            writeFlush();
        }

        // 写入字节数组数据
        int buffLeft = buffSize - buffPint;
        // 整缓冲区数据写入
        while (vLen > buffLeft)
        {
            // 将部分数据写入缓冲区
            System.arraycopy(v, off, buffByte, buffPint, buffLeft);
            // 调整有待写入缓冲区的剩余数据长度
            vLen -= buffLeft;
            // 调整源字节数组剩余数据的起点
            off += buffLeft;
            // 调整缓冲区中已有字节数据个数
            byteSize = buffSize;
            // 将缓冲区数据写入文件
            writeFlush();
            // 计算缓冲区中剩余有效容量；
            buffLeft = buffSize - buffPint;
        }
        // 剩余数据写入
        if (vLen > 0)
        {
            // 将部分数据写入缓冲区
            System.arraycopy(v, off, buffByte, buffPint, vLen);
            // 调整buf用到的pointer，maxPos；
            buffPint += vLen;
            // 修正当前数据缓冲区中存储字节数量
            byteSize = buffPint;
            // 剩余字节个数修正
            vLen = 0;
        }

        modified = true;
        return len - vLen;
    }

    /**
     * 写入一个单字节字符数据
     * 
     * @param v
     * @throws IOException
     */
    public void writeChar1(char v) throws IOException
    {
        writeSByte((byte) v);
    }

    /**
     * 写入一个单字节字符数组数据
     * 
     * @param v
     *            待写入的字符单字节数组
     * @throws IOException
     */
    public int writeChars1(char[] v) throws IOException
    {
        return writeChars1(v, 0, v.length);
    }

    /**
     * 写入一个单字节字符数组数据
     * 
     * @param v
     *            待写入的字符单字节数组
     * @param off
     *            数组的起始偏移地址
     * @param len
     *            写入字符的个数
     * @throws IOException
     */
    public int writeChars1(char[] v, int off, int len) throws IOException
    {
        // 用户参数合法性判断
        if (v == null)
        {
            return -1;
        }
        int vLen = v.length;
        if (vLen < 1 || off < 0 || len < 1 || off + len > vLen)
        {
            return -1;
        }
        vLen = len;

        // 判断是否需要将当前缓冲区中数据写出到文件
        if (buffPint == buffSize)
        {
            writeFlush();
        }

        // 写入字节数组数据
        int buffLeft = buffSize - buffPint;
        // 整缓冲区数据写入
        while (vLen > buffLeft)
        {
            // 将部分数据写入缓冲区
            while (buffPint < buffSize)
            {
                buffByte[buffPint++] = (byte) v[off++];
            }
            // 调整有待写入缓冲区的剩余数据长度
            vLen -= buffLeft;
            // 调整缓冲区中已有字节数据个数
            byteSize = buffSize;
            // 将缓冲区数据写入文件
            writeFlush();
            // 计算缓冲区中剩余有效容量；
            buffLeft = buffSize - buffPint;
        }
        // 剩余数据写入
        if (vLen > 0)
        {
            // 将部分数据写入缓冲区
            while (vLen-- > 0)
            {
                buffByte[buffPint++] = (byte) v[off++];
            }
            // 修正当前数据缓冲区中存储字节数量
            byteSize = buffPint;
        }

        modified = true;
        return len - vLen;
    }

    /**
     * 写入单字节字符串数据
     * 
     * @param v
     *            待写入的字符串数据
     * @throws IOException
     *             文件存取异常
     */
    public int writeString1(String v) throws IOException
    {
        return writeChars1(v.toCharArray(), 0, v.length());
    }

    // -----------------------------------------------------
    // 字节数据修改方法
    // -----------------------------------------------------
    /**
     * 修改指定位置的处的布尔数据值为指定的状态
     * 
     * @param p
     *            待修改数据相对于文档起始位置的偏移量
     * @param v
     *            目标布尔数据
     * @throws IOException
     */
    public void modifyBoolean(long p, boolean v) throws IOException
    {
        // 若数值非法或者修改位置在当前写出点之后，则不进行任何操作
        if (p < 0 || p > filePint + buffPint)
        {
            return;
        }
        // 若修改位置在当前缓冲区之内，则直接进行替换操作
        else if (p >= filePint)
        {
            buffByte[(int) (p - filePint)] = (byte) (v ? 1 : 0);
        }
        // 若修改位置在当前缓冲区之前，则使用随机流进行定位写操作
        else
        {
            randStream.seek(p);
            randStream.writeByte(v ? 1 : 0);
        }
        modified = true;
    }

    /**
     * 修改指定位置的无符号字节数据为指定的数值
     * 
     * @param p
     *            待修改数据相对于文档起始位置的偏移量
     * @param v
     *            目标无符号数据值
     * @throws IOException
     */
    public void modifySByte(long p, byte v) throws IOException
    {
        modifyUByte(p, v);
    }

    /**
     * 修改指定位置的有符号字节数据为指定的数值
     * 
     * @param p
     *            待修改数据相对于文档起始位置的偏移量
     * @param v
     *            目标有符号数据值
     * @throws IOException
     */
    public void modifyUByte(long p, int v) throws IOException
    {
        // 若数值非法或者修改位置在当前写出点之后，则不进行任何操作
        if (p < 0 || p > filePint + buffPint)
        {
            return;
        }
        // 若修改位置在当前缓冲区之内，则直接进行替换操作
        else if (p >= filePint)
        {
            buffByte[(int) (p - filePint)] = (byte) v;
        }
        // 若修改位置在当前缓冲区之前，则使用随机流进行定位写操作
        else
        {
            randStream.seek(p);
            randStream.writeByte(v);
        }
        modified = true;
    }

    /**
     * 从指定位置起始替换指定长度的字节数据
     * 
     * @param p
     *            修改起始位置
     * @param v
     *            待替换的字节数组
     * @return 实际修改的字节个数
     * @throws IOException
     */
    public int modifyBytes(long p, byte[] v) throws IOException
    {
        return modifyBytes(p, v, 0, v.length);
    }

    /**
     * 从指定位置起始替换指定长度的字节数据
     * 
     * @param p
     *            修改起始位置
     * @param v
     *            待替换的字节数组
     * @param off
     * @param len
     * @return
     * @throws IOException
     */
    public int modifyBytes(long p, byte[] v, int off, int len) throws IOException
    {
        if (p < 0 || p > filePint + buffPint)
        {
            return -1;
        }
        else
        {
            writeFlush();
            randStream.seek(p);
            randStream.write(v, off, len);
        }
        modified = true;
        return len;
    }

    // /////////////////////////////////////////////////////////////////////////
    // 通用数据存取方法
    // /////////////////////////////////////////////////////////////////////////
    // -----------------------------------------------------
    // 通用数据读取方法
    // -----------------------------------------------------
    /**
     * @return
     * @throws IOException
     */
    public char readChar() throws IOException
    {
        return readIChar();
    }

    /**
     * @return
     * @throws IOException
     */
    public short readSShort() throws IOException
    {
        return readISShort();
    }

    /**
     * @return
     * @throws IOException
     */
    public int readUShort() throws IOException
    {
        return readIUShort();
    }

    /**
     * @return
     * @throws IOException
     */
    public int readInt() throws IOException
    {
        return readIInt();
    }

    /**
     * @return
     * @throws IOException
     */
    public long readLong() throws IOException
    {
        return readILong();
    }

    /**
     * @return
     * @throws IOException
     */
    public float readFloat() throws IOException
    {
        return readIFloat();
    }

    /**
     * @return
     * @throws IOException
     */
    public double readDouble() throws IOException
    {
        return readIDouble();
    }

    /**
     * @param l
     * @return
     */
    public char[] readChars(int l) throws IOException
    {
        return readIChars(l);
    }

    /**
     * @param v
     * @return
     * @throws IOException
     */
    public int readChars(char[] v) throws IOException
    {
        return readIChars(v);
    }

    /**
     * @param v
     * @param off
     * @param len
     * @return
     * @throws IOException
     */
    public int readChars(char[] v, int off, int len) throws IOException
    {
        return readIChars(v, off, len);
    }

    /**
     * @param l
     * @return
     */
    public int[] readInts(int l) throws IOException
    {
        return readIInts(l);
    }

    /**
     * @param v
     * @return
     * @throws IOException
     */
    public int readInts(int[] v) throws IOException
    {
        return readIInts(v);
    }

    /**
     * @param v
     * @param off
     * @param len
     * @return
     * @throws IOException
     */
    public int readInts(int[] v, int off, int len) throws IOException
    {
        return readIInts(v, off, len);
    }

    /**
     * @param l
     * @return
     * @throws IOException
     */
    public long[] readLongs(int l) throws IOException
    {
        return readILongs(l);
    }

    /**
     * @param v
     * @return
     * @throws IOException
     */
    public int readLongs(long[] v) throws IOException
    {
        return readILongs(v);
    }

    /**
     * @param v
     * @param off
     * @param len
     * @return
     * @throws IOException
     */
    public int readLongs(long[] v, int off, int len) throws IOException
    {
        return readILongs(v, off, len);
    }

    /**
     * @param l
     * @return
     * @throws IOException
     */
    public String readString(int l) throws IOException
    {
        return readIString(l);
    }

    // -----------------------------------------------------
    // 通用数据写入方法
    // -----------------------------------------------------
    /**
     * @param v
     * @throws IOException
     */
    public void writeChar(char v) throws IOException
    {
        writeIChar(v);
    }

    /**
     * @param v
     * @throws IOException
     */
    public void writeSShort(short v) throws IOException
    {
        writeISShort(v);
    }

    /**
     * @param v
     * @throws IOException
     */
    public void writeUShort(int v) throws IOException
    {
        writeIUShort(v);
    }

    /**
     * @param v
     */
    public void writeInt(int v) throws IOException
    {
        writeIInt(v);
    }

    /**
     * @param v
     */
    public void writeLong(long v) throws IOException
    {
        writeILong(v);
    }

    /**
     * @param v
     */
    public void writeFloat(float v) throws IOException
    {
        writeIFloat(v);
    }

    /**
     * @param v
     */
    public void writeDouble(double v) throws IOException
    {
        writeIDouble(v);
    }

    /**
     * @param v
     * @return
     * @throws IOException
     */
    public int writeChars(char[] v) throws IOException
    {
        return writeIChars(v);
    }

    /**
     * @param v
     * @param off
     * @param len
     * @return
     * @throws IOException
     */
    public int writeChars(char[] v, int off, int len) throws IOException
    {
        return writeIChars(v, off, len);
    }

    /**
     * @param v
     * @return
     * @throws IOException
     */
    public int writeInts(int[] v) throws IOException
    {
        return writeIInts(v);
    }

    /**
     * @param v
     * @param s
     * @param e
     * @throws IOException
     */
    public int writeInts(int[] v, int s, int e) throws IOException
    {
        return writeIInts(v, s, e);
    }

    /**
     * @param v
     * @return
     * @throws IOException
     */
    public int writeLongs(long[] v) throws IOException
    {
        return writeILongs(v);
    }

    /**
     * @param v
     * @param off
     * @param len
     * @return
     * @throws IOException
     */
    public int writeLongs(long[] v, int off, int len) throws IOException
    {
        return writeILongs(v, off, len);
    }

    /**
     * @param v
     * @return
     * @throws IOException
     */
    public int writeString(String v) throws IOException
    {
        return writeIString(v);
    }

    /**
     * @param v
     * @param s
     * @param e
     * @return
     * @throws IOException
     */
    public int writeString(String v, int s, int e) throws IOException
    {
        return writeIString(v, s, e);
    }

    // -----------------------------------------------------
    // 通用数据修改方法
    // -----------------------------------------------------
    /**
     * @param p
     * @param v
     */
    public void modifyChar(long p, char v) throws IOException
    {
        modified = true;
    }

    /**
     * @param p
     * @param v
     */
    public void modifySShort(long p, short v) throws IOException
    {
        modified = true;
    }

    /**
     * @param p
     * @param v
     */
    public void modifyUShort(long p, int v) throws IOException
    {
        modified = true;
    }

    /**
     * @param p
     * @param v
     */
    public void modifyInt(long p, int v) throws IOException
    {
        modified = true;
    }

    /**
     * @param p
     * @param v
     */
    public void modifyLong(long p, int v) throws IOException
    {
        modified = true;
    }

    /**
     * @param p
     * @param v
     */
    public void modifyFloat(long p, float v) throws IOException
    {
        modified = true;
    }

    /**
     * @param p
     * @param v
     */
    public void modifyDouble(long p, double v) throws IOException
    {
        modified = true;
    }

    /**
     * @param p
     * @param v
     * @param off
     * @param len
     * @throws IOException
     */
    public void modifyInts(long p, int[] v, int off, int len) throws IOException
    {
        ;
    }

    // /////////////////////////////////////////////////////////////////////////
    // Intel格式数据存取方法
    // /////////////////////////////////////////////////////////////////////////
    // -----------------------------------------------------
    // Intel格式数据读取方法
    // -----------------------------------------------------
    /**
     * 读取一个双字节的字符
     * 
     * @return 实际读取的字符数据
     * @throws IOException
     *             文件存取异常
     */
    public char readIChar() throws IOException
    {
        return (char) readIUShort();
    }

    /**
     * 读取有符号Short数据
     * 
     * @return 实际读取的有符号Short数据
     * @throws IOException
     *             文件存取异常
     */
    public short readISShort() throws IOException
    {
        return (short) readIUShort();
    }

    /**
     * 读取无符号Short数据
     * 
     * @return 实际读取的无符号Short数据
     * @throws IOException
     *             文件存取异常
     */
    public int readIUShort() throws IOException
    {
        // 判断是否需要重新从文件中读取数据到缓冲区
        if (buffPint + 2 > byteSize)
        {
            if (!readFlush())
            {
                throw new IOException("End Of File --Amon");
            }
        }

        // 指定格式数据合成
        int v = (buffByte[buffPint++] & 0xFF) << 0;
        v |= (buffByte[buffPint++] & 0xFF) << 8;

        return v;
    }

    /**
     * 读取长度为四字节的整形数据
     * 
     * @return 实际读取的整形数值
     * @throws IOException
     *             文件存取异常
     */
    public int readIInt() throws IOException
    {
        // 判断是否需要重新从文件中读取数据到缓冲区
        if (buffPint + 4 > byteSize)
        {
            if (!readFlush())
            {
                throw new IOException("End Of File --Amon");
            }
        }

        // 指定格式数据合成
        int v = (buffByte[buffPint++] & 0xFF) << 0;
        v |= (buffByte[buffPint++] & 0xFF) << 8;
        v |= (buffByte[buffPint++] & 0xFF) << 16;
        v |= (buffByte[buffPint++] & 0xFF) << 24;

        return v;
    }

    /**
     * 读取长度为8字节的长整形数据
     * 
     * @return 实际读取的长整形数值
     * @throws IOException
     *             文件存取异常
     */
    public long readILong() throws IOException
    {
        // 判断是否需要重新从文件中读取数据到缓冲区
        if (buffPint + 8 > buffSize)
        {
            if (!readFlush())
            {
                throw new IOException("End Of File --Amon");
            }
        }

        // 指定格式数据合成
        long v = (buffByte[buffPint++] & 0xFF) << 0;
        v |= (buffByte[buffPint++] & 0xFF) << 8;
        v |= (buffByte[buffPint++] & 0xFF) << 16;
        v |= (buffByte[buffPint++] & 0xFF) << 24;
        v |= (buffByte[buffPint++] & 0xFF) << 32;
        v |= (buffByte[buffPint++] & 0xFF) << 40;
        v |= (buffByte[buffPint++] & 0xFF) << 56;
        v |= (buffByte[buffPint++] & 0xFF) << 64;

        return v;
    }

    /**
     * 读取一个Float数据
     * 
     * @return
     * @throws IOException
     */
    public float readIFloat() throws IOException
    {
        return Float.intBitsToFloat(readIInt());
    }

    /**
     * 读取一个double数据
     * 
     * @return
     * @throws IOException
     */
    public double readIDouble() throws IOException
    {
        return Double.longBitsToDouble(readILong());
    }

    /**
     * 读取指定长度个字符数据，并以字符数组的形式返回
     * 
     * @param l
     *            待读取的字符个数
     * @return
     */
    public char[] readIChars(int l) throws IOException
    {
        if (l < 1)
        {
            return null;
        }
        char[] v = new char[l];
        readIChars(v, 0, l);
        return v;
    }

    /**
     * 读取双字节数据到指定的大小的字符数组中去
     * 
     * @param v
     *            目标字符数组
     * @return 实际读取的字符长度
     * @throws IOException
     *             文件存取异常
     */
    public int readIChars(char[] v) throws IOException
    {
        return readIChars(v, 0, v.length);
    }

    /**
     * 读取指定长度的双字节数据到指定的字符数组中去，并从指定位置起存放
     * 
     * @param v
     *            目标字符数组
     * @param off
     *            目标字符数组偏移量
     * @param len
     *            待读取字符长度
     * @return 实际读取的字符长度
     * @throws IOException
     *             文件存取异常
     */
    public int readIChars(char[] v, int off, int len) throws IOException
    {
        // 用户参数的合法性判断
        if (v == null)
        {
            return -1;
        }
        int vLen = v.length;
        if (vLen < 1 || off < 0 || len < 1 || off + len > vLen)
        {
            return -1;
        }

        // 判断要读取的字节长度是否超出剩余数据的长度
        vLen = (int) (fileLeng - filePint - buffPint);
        if (vLen < 2)
        {
            return -1;
        }

        // 若文件剩余数据长度不小于待读取字节长度，以读取指定长度的字节数据
        vLen >>= 1;
        if (vLen >= len)
        {
            vLen = len;
        }
        // 否则仅读取剩余长度的字节数据
        else
        {
            len = vLen;
        }

        // 是否需要进行数据读取
        if (buffPint == buffSize)
        {
            readFlush();
        }

        int temp;
        // 缓冲区剩余空间大小
        int buffLeft = (buffSize - buffPint) >> 1;
        // 读取字节长度大于缓冲区中剩余字节长度时的处理
        while (vLen > buffLeft)
        {
            // 缓冲区数据拷贝到目标数组中
            while (buffPint < buffSize)
            {
                temp = (buffByte[buffPint++] & 0xFF) << 0;
                temp |= (buffByte[buffPint++] & 0xFF) << 8;
                v[off++] = (char) temp;
            }
            // 剩余数组字节长度更新
            vLen -= buffLeft;
            // 从文件读取数据到缓冲区
            readFlush();
            // 缓冲区中剩余字节更新
            buffLeft = (buffSize - buffPint) >> 1;
        }
        // 读取字节长度小于缓冲区中剩余字节长度时的处理
        // 缓冲区数据拷贝到目标数组中
        while (vLen-- > 0)
        {
            temp = (buffByte[buffPint++] & 0xFF) << 0;
            temp |= (buffByte[buffPint++] & 0xFF) << 8;
            v[off++] = (char) temp;
        }
        return len - vLen - 1;
    }

    /**
     * @param l
     * @return
     */
    public int[] readIInts(int l) throws IOException
    {
        if (l < 1)
        {
            return null;
        }
        int[] v = new int[l];
        readInts(v, 0, l);
        return v;
    }

    /**
     * @param v
     * @return
     * @throws IOException
     */
    public int readIInts(int[] v) throws IOException
    {
        return readIInts(v, 0, v.length);
    }

    /**
     * @param v
     * @param off
     * @param len
     * @return
     * @throws IOException
     */
    public int readIInts(int[] v, int off, int len) throws IOException
    {
        // 用户参数的合法性判断
        if (v == null)
        {
            return -1;
        }
        int vLen = v.length;
        if (vLen < 1 || off < 0 || len < 0 || off + len > vLen)
        {
            return -1;
        }

        // 判断要读取的字节长度是否超出剩余数据的长度
        vLen = (int) (fileLeng - filePint - buffPint);
        if (vLen < 4)
        {
            return -1;
        }

        // 若文件剩余数据长度不小于待读取字节长度，以读取指定长度的字节数据
        vLen >>= 2;
        if (vLen >= len)
        {
            vLen = len;
        }
        // 否则仅读取剩余长度的字节数据
        else
        {
            len = vLen;
        }

        if (buffPint == buffSize)
        {
            readFlush();
        }

        int temp;
        // 缓冲区剩余空间大小
        int buffLeft = (buffSize - buffPint) >> 2;
        // 读取字节长度大于缓冲区中剩余字节长度时的处理
        while (vLen > buffLeft)
        {
            // 缓冲区数据拷贝到目标数组中
            while (buffPint < buffSize)
            {
                temp = (buffByte[buffPint++] & 0xFF) << 0;
                temp |= (buffByte[buffPint++] & 0xFF) << 8;
                temp |= (buffByte[buffPint++] & 0xFF) << 16;
                temp |= (buffByte[buffPint++] & 0xFF) << 24;
                v[off++] = temp;
            }
            // 剩余数组字节长度更新
            vLen -= buffLeft;
            // 从文件读取数据到缓冲区
            readFlush();
            // 缓冲区中剩余字节更新
            buffLeft = (buffSize - buffPint) >> 2;
        }
        // 读取字节长度小于缓冲区中剩余字节长度时的处理
        // 缓冲区数据拷贝到目标数组中
        while (vLen-- > 0)
        {
            temp = (buffByte[buffPint++] & 0xFF) << 0;
            temp |= (buffByte[buffPint++] & 0xFF) << 8;
            temp |= (buffByte[buffPint++] & 0xFF) << 16;
            temp |= (buffByte[buffPint++] & 0xFF) << 24;
            v[off++] = temp;
        }
        return len - vLen;
    }

    /**
     * @param l
     * @return
     * @throws IOException
     */
    public long[] readILongs(int l) throws IOException
    {
        if (l < 1)
        {
            return null;
        }
        long[] v = new long[l];
        readILongs(v, 0, l);
        return v;
    }

    /**
     * @param v
     * @return
     * @throws IOException
     */
    public int readILongs(long[] v) throws IOException
    {
        return readILongs(v, 0, v.length);
    }

    /**
     * @param v
     * @param off
     * @param len
     * @return
     * @throws IOException
     */
    public int readILongs(long[] v, int off, int len) throws IOException
    {
        // 用户参数的合法性判断
        if (v == null)
        {
            return -1;
        }
        int vLen = v.length;
        if (vLen < 1 || off < 0 || len < 0 || off + len > vLen)
        {
            return -1;
        }

        // 判断要读取的字节长度是否超出剩余数据的长度
        vLen = (int) (fileLeng - filePint - buffPint);
        if (vLen < 8)
        {
            return -1;
        }
        // 若文件剩余数据长度不小于待读取字节长度，以读取指定长度的字节数据
        vLen >>= 3;
        if (vLen >= len)
        {
            vLen = len;
        }
        // 否则仅读取剩余长度的字节数据
        else
        {
            len = vLen;
        }

        if (buffPint == buffSize)
        {
            readFlush();
        }

        long temp;
        // 缓冲区剩余空间大小
        int buffLeft = (buffSize - buffPint) >> 3;
        // 读取字节长度大于缓冲区中剩余字节长度时的处理
        while (vLen > buffLeft)
        {
            // 缓冲区数据拷贝到目标数组中
            while (buffPint < buffSize)
            {
                temp = (buffByte[buffPint++] & 0xFF) << 0;
                temp |= (buffByte[buffPint++] & 0xFF) << 8;
                temp |= (buffByte[buffPint++] & 0xFF) << 16;
                temp |= (buffByte[buffPint++] & 0xFF) << 24;
                temp |= (buffByte[buffPint++] & 0xFF) << 32;
                temp |= (buffByte[buffPint++] & 0xFF) << 40;
                temp |= (buffByte[buffPint++] & 0xFF) << 48;
                temp |= (buffByte[buffPint++] & 0xFF) << 56;
                v[off++] = temp;
            }
            // 剩余数组字节长度更新
            vLen -= buffLeft;
            // 从文件读取数据到缓冲区
            readFlush();
            // 缓冲区中剩余字节更新
            buffLeft = (buffSize - buffPint) >> 3;
        }
        // 读取字节长度小于缓冲区中剩余字节长度时的处理
        // 缓冲区数据拷贝到目标数组中
        while (vLen-- > 0)
        {
            temp = (buffByte[buffPint++] & 0xFF) << 0;
            temp |= (buffByte[buffPint++] & 0xFF) << 8;
            temp |= (buffByte[buffPint++] & 0xFF) << 16;
            temp |= (buffByte[buffPint++] & 0xFF) << 24;
            temp |= (buffByte[buffPint++] & 0xFF) << 32;
            temp |= (buffByte[buffPint++] & 0xFF) << 40;
            temp |= (buffByte[buffPint++] & 0xFF) << 48;
            temp |= (buffByte[buffPint++] & 0xFF) << 56;
            v[off++] = temp;
        }
        return len - vLen;
    }

    /**
     * 读取指定长度的双字节字符串
     * 
     * @param len
     *            待读取的字符串长度
     * @return 实际读取的字符串
     * @throws IOException
     *             文件存取异常
     */
    public String readIString(int l) throws IOException
    {
        // 读取长度数据合法性检查
        if (l < 1)
        {
            return null;
        }

        // 读取字符数组
        char[] v = new char[l];
        l = readIChars(v, 0, l);
        return new String(v, 0, l);
    }

    // -----------------------------------------------------
    // Intel格式数据写入方法
    // -----------------------------------------------------
    /**
     * @param v
     */
    public void writeIChar(char v) throws IOException
    {
        writeISShort((short) v);
    }

    /**
     * @param v
     */
    public void writeISShort(short v) throws IOException
    {
        // 判断是否需要进行缓冲区数据写出到文件
        if (buffPint + 2 > buffSize)
        {
            writeFlush();
        }

        // 按Intel方式写出数据
        buffByte[buffPint++] = (byte) v;
        buffByte[buffPint++] = (byte) (v >>> 8);

        // 修正当前数据缓冲区中存储字节数量
        byteSize = buffPint;
        modified = true;
    }

    /**
     * @param v
     * @throws IOException
     */
    public void writeIUShort(int v) throws IOException
    {
        writeISShort((short) v);
    }

    /**
     * @param v
     * @throws IOException
     */
    public void writeIInt(int v) throws IOException
    {
        // 判断是否需要进行缓冲区数据写出到文件
        if (buffPint + 4 > buffSize)
        {
            writeFlush();
        }

        // 按Intel方式写出数据
        buffByte[buffPint++] = (byte) v;
        buffByte[buffPint++] = (byte) (v >>> 8);
        buffByte[buffPint++] = (byte) (v >>> 16);
        buffByte[buffPint++] = (byte) (v >>> 24);

        // 修正当前数据缓冲区中存储字节数量
        byteSize = buffPint;
        modified = true;
    }

    /**
     * @param v
     * @throws IOException
     */
    public void writeILong(long v) throws IOException
    {
        // 判断是否需要进行缓冲区数据写出到文件
        if (buffPint + 8 > buffSize)
        {
            writeFlush();
        }

        // 按Intel方式写出数据
        buffByte[buffPint++] = (byte) v;
        buffByte[buffPint++] = (byte) (v >>> 8);
        buffByte[buffPint++] = (byte) (v >>> 16);
        buffByte[buffPint++] = (byte) (v >>> 24);
        buffByte[buffPint++] = (byte) (v >>> 32);
        buffByte[buffPint++] = (byte) (v >>> 40);
        buffByte[buffPint++] = (byte) (v >>> 48);
        buffByte[buffPint++] = (byte) (v >>> 56);

        // 修正当前数据缓冲区中存储字节数量
        byteSize = buffPint;
        modified = true;
    }

    /**
     * @param v
     * @throws IOException
     */
    public void writeIFloat(float v) throws IOException
    {
        writeIInt(Float.floatToIntBits(v));
    }

    /**
     * @param v
     * @throws IOException
     */
    public void writeIDouble(double v) throws IOException
    {
        writeILong(Double.doubleToLongBits(v));
    }

    /**
     * 按Inter方式写入字符串数组，并返回写入字符个数
     * 
     * @param v
     *            待写入的字符数组
     * @return 实际写入字符个数
     * @throws IOException
     *             文件存取异常
     */
    public int writeIChars(char[] v) throws IOException
    {
        return writeIChars(v, 0, v.length);
    }

    /**
     * @param v
     * @param s
     * @param e
     */
    public int writeIChars(char[] v, int off, int len) throws IOException
    {
        // 用户参数数据合法性检查
        if (v == null)
        {
            return -1;
        }
        int vLen = v.length;
        if (vLen < 1 || off < 0 || len < 1 || off + len > vLen)
        {
            return -1;
        }

        vLen = len;
        char temp;
        // 写入字节数组数据
        int buffLeft = (buffSize - buffPint) >> 1;
        // 整缓冲区数据写入
        while (vLen > buffLeft)
        {
            // 将部分数据写入缓冲区
            for (int i = 0; i < buffLeft; ++i)
            {
                temp = v[i];
                buffByte[buffPint++] = (byte) temp;
                buffByte[buffPint++] = (byte) (temp >>> 8);
            }
            // 调整有待写入缓冲区的剩余数据长度
            vLen -= buffLeft;
            // 调整源字节数组剩余数据的起点
            off += buffLeft;
            // 调整缓冲区中已有字节数据个数
            byteSize = buffSize;
            // 将缓冲区数据写入文件
            writeFlush();
            // 计算缓冲区中剩余有效容量；
            buffLeft = (buffSize - buffPint) >> 1;
        }

        // 剩余数据写入
        if (vLen > 0)
        {
            for (int i = 0; i < vLen; ++i)
            {
                temp = v[i];
                buffByte[buffPint++] = (byte) temp;
                buffByte[buffPint++] = (byte) (temp >>> 8);
            }
            // 修正当前数据缓冲区中存储字节数量
            byteSize = buffPint;
        }

        modified = true;
        return len;
    }

    /**
     * @param v
     * @return
     * @throws IOException
     */
    public int writeIInts(int[] v) throws IOException
    {
        return writeIInts(v, 0, v.length);
    }

    /**
     * @param v
     * @param off
     * @param len
     * @throws IOException
     */
    public int writeIInts(int[] v, int off, int len) throws IOException
    {
        // 用户参数数据合法性检查
        if (v == null)
        {
            return -1;
        }
        int vLen = v.length;
        if (vLen < 1 || off < 0 || len < 1 || off + len > vLen)
        {
            return -1;
        }

        vLen = len;
        int temp;
        // 写入字节数组数据
        int buffLeft = (buffSize - buffPint) >> 2;
        // 整缓冲区数据写入
        while (vLen >= buffLeft)
        {
            // 将部分数据写入缓冲区
            for (int i = 0; i < buffLeft; ++i)
            {
                temp = v[i];
                buffByte[buffPint++] = (byte) temp;
                buffByte[buffPint++] = (byte) (temp >>> 8);
                buffByte[buffPint++] = (byte) (temp >>> 16);
                buffByte[buffPint++] = (byte) (temp >>> 24);
            }
            // 调整有待写入缓冲区的剩余数据长度
            vLen -= buffLeft;
            // 调整源字节数组剩余数据的起点
            off += buffLeft;
            // 调整缓冲区中已有字节数据个数
            byteSize = buffSize;
            // 将缓冲区数据写入文件
            writeFlush();
            // 计算缓冲区中剩余有效容量；
            buffLeft = (buffSize - buffPint) >> 2;
        }

        // 剩余数据写入
        if (vLen > 0)
        {
            for (int i = 0; i < vLen; ++i)
            {
                temp = v[i];
                buffByte[buffPint++] = (byte) temp;
                buffByte[buffPint++] = (byte) (temp >>> 8);
                buffByte[buffPint++] = (byte) (temp >>> 16);
                buffByte[buffPint++] = (byte) (temp >>> 24);
            }
            // 修正当前数据缓冲区中存储字节数量
            byteSize = buffPint;
        }

        modified = true;
        return len;
    }

    /**
     * @param v
     * @return
     * @throws IOException
     */
    public int writeILongs(long[] v) throws IOException
    {
        return writeILongs(v, 0, v.length);
    }

    /**
     * @param v
     * @param off
     * @param len
     * @return
     * @throws IOException
     */
    public int writeILongs(long[] v, int off, int len) throws IOException
    {
        // 用户参数数据合法性检查
        if (v == null)
        {
            return -1;
        }
        int vLen = v.length;
        if (vLen < 1 || off < 0 || len < 1 || off + len > vLen)
        {
            return -1;
        }

        vLen = len;
        long temp;
        // 写入字节数组数据
        int buffLeft = (buffSize - buffPint) >> 3;
        // 整缓冲区数据写入
        while (vLen >= buffLeft)
        {
            // 将部分数据写入缓冲区
            for (int i = 0; i < buffLeft; ++i)
            {
                temp = v[i];
                buffByte[buffPint++] = (byte) temp;
                buffByte[buffPint++] = (byte) (temp >>> 8);
                buffByte[buffPint++] = (byte) (temp >>> 16);
                buffByte[buffPint++] = (byte) (temp >>> 24);
                buffByte[buffPint++] = (byte) (temp >>> 32);
                buffByte[buffPint++] = (byte) (temp >>> 40);
                buffByte[buffPint++] = (byte) (temp >>> 48);
                buffByte[buffPint++] = (byte) (temp >>> 56);
            }
            // 调整有待写入缓冲区的剩余数据长度
            vLen -= buffLeft;
            // 调整源字节数组剩余数据的起点
            off += buffLeft;
            // 调整缓冲区中已有字节数据个数
            byteSize = buffSize;
            // 将缓冲区数据写入文件
            writeFlush();
            // 计算缓冲区中剩余有效容量；
            buffLeft = (buffSize - buffPint) >> 3;
        }

        // 剩余数据写入
        if (vLen > 0)
        {
            for (int i = 0; i < vLen; ++i)
            {
                temp = v[i];
                buffByte[buffPint++] = (byte) temp;
                buffByte[buffPint++] = (byte) (temp >>> 8);
                buffByte[buffPint++] = (byte) (temp >>> 16);
                buffByte[buffPint++] = (byte) (temp >>> 24);
                buffByte[buffPint++] = (byte) (temp >>> 32);
                buffByte[buffPint++] = (byte) (temp >>> 40);
                buffByte[buffPint++] = (byte) (temp >>> 48);
                buffByte[buffPint++] = (byte) (temp >>> 56);
            }
            // 修正当前数据缓冲区中存储字节数量
            byteSize = buffPint;
        }

        modified = true;
        return len;
    }

    /**
     * @param v
     * @throws IOException
     */
    public int writeIString(String v) throws IOException
    {
        return writeIString(v, 0, v.length());
    }

    /**
     * @param v
     * @param off
     * @param len
     * @return
     * @throws IOException
     */
    public int writeIString(String v, int off, int len) throws IOException
    {
        if (v == null || v.length() < 1)
        {
            return -1;
        }
        return writeIChars(v.toCharArray(), off, len);
    }

    // -----------------------------------------------------
    // Intel格式数据修改方法
    // -----------------------------------------------------
    /**
     * @param p
     * @param v
     */
    public void modifyIChar(long p, char v) throws IOException
    {
        if (p < 0 || p > filePint + buffPint)
        {
            return;
        }
        else if (p >= filePint)
        {
            int off = (int) (p - filePint);
            buffByte[off] = (byte) v;
            buffByte[off + 1] = (byte) (v >> 8);
        }
        else
        {
            randStream.seek(p);
            randStream.writeChar(v);
        }
        modified = true;
    }

    /**
     * @param p
     * @param v
     */
    public void modifyISShort(long p, short v)
    {
        modified = true;
    }

    /**
     * @param p
     * @param v
     */
    public void modifyIUShort(long p, int v)
    {
        modified = true;
    }

    /**
     * @param p
     * @param v
     */
    public void modifyIInt(long p, int v)
    {
        modified = true;
    }

    /**
     * @param p
     * @param v
     */
    public void modifyILong(long p, int v)
    {
        modified = true;
    }

    /**
     * @param p
     * @param v
     */
    public void modifyIFloat(long p, float v)
    {
        modified = true;
    }

    /**
     * @param p
     * @param v
     */
    public void modifyIDouble(long p, double v)
    {
        modified = true;
    }

    // /////////////////////////////////////////////////////////////////////////
    // Motorola格式数据存取方法
    // /////////////////////////////////////////////////////////////////////////
    // -----------------------------------------------------
    // Motorola格式数据读取方法
    // -----------------------------------------------------
    /**
     * @return
     */
    public char readMChar()
    {
        char v = 0;
        return v;
    }

    /**
     * @return
     */
    public short readMSShort()
    {
        short v = 0;
        return v;
    }

    /**
     * @return
     */
    public int readMUShort()
    {
        int v = 0;
        return v;
    }

    /**
     * @return
     */
    public int readMInt()
    {
        int v = 0;
        return v;
    }

    /**
     * @return
     */
    public long readMLong()
    {
        long v = 0;
        return v;
    }

    /**
     * @return
     */
    public float readMFloat()
    {
        float v = 0;
        return v;
    }

    /**
     * @return
     */
    public double readMDouble()
    {
        double v = 0;
        return v;
    }

    /**
     * @param l
     * @return
     */
    public char[] readMChars(int l)
    {
        return null;
    }

    /**
     * @param v
     * @return
     * @throws IOException
     */
    public int readMChars(char[] v) throws IOException
    {
        return 0;
    }

    /**
     * @param v
     * @param off
     * @param len
     * @return
     * @throws IOException
     */
    public int readMChars(char[] v, int off, int len) throws IOException
    {
        return 0;
    }

    /**
     * @param l
     * @return
     */
    public int[] readMInts(int l)
    {
        return null;
    }

    /**
     * @param v
     * @return
     * @throws IOException
     */
    public int readMInts(int[] v) throws IOException
    {
        return 0;
    }

    /**
     * @param v
     * @param off
     * @param len
     * @return
     * @throws IOException
     */
    public int readMInts(int[] v, int off, int len) throws IOException
    {
        return 0;
    }

    /**
     * @param l
     * @return
     */
    public long[] readMLongs(int l)
    {
        return null;
    }

    /**
     * @param v
     * @return
     * @throws IOException
     */
    public int readMLongs(long[] v) throws IOException
    {
        return 0;
    }

    /**
     * @param v
     * @param off
     * @param len
     * @return
     * @throws IOException
     */
    public int readMLongs(long[] v, int off, int len) throws IOException
    {
        return 0;
    }

    /**
     * @param l
     * @return
     */
    public String readMString(int l)
    {
        return null;
    }

    // -----------------------------------------------------
    // Motorola格式数据写入方法
    // -----------------------------------------------------
    /**
     * @param v
     */
    public void writeMChar(char v) throws IOException
    {
        writeMSShort((short) v);
    }

    /**
     * @param v
     * @throws IOException
     */
    public void writeMSShort(short v) throws IOException
    {
        // 判断是否需要进行缓冲区数据写出到文件
        if (buffPint + 2 > buffSize)
        {
            writeFlush();
        }

        // 按Motorola方式写出数据
        buffByte[buffPint++] = (byte) (v >>> 8);
        buffByte[buffPint++] = (byte) v;

        // 修正当前数据缓冲区中存储字节数量
        byteSize = buffPint;
        modified = true;
    }

    /**
     * @param v
     * @throws IOException
     */
    public void writeMUShort(int v) throws IOException
    {
        writeMSShort((short) v);
    }

    /**
     * @param v
     * @throws IOException
     */
    public void writeMInt(int v) throws IOException
    {
        // 判断是否需要进行缓冲区数据写出到文件
        if (buffPint + 4 > buffSize)
        {
            writeFlush();
        }

        // 按Motorola方式写出数据
        buffByte[buffPint++] = (byte) (v >>> 24);
        buffByte[buffPint++] = (byte) (v >>> 16);
        buffByte[buffPint++] = (byte) (v >>> 8);
        buffByte[buffPint++] = (byte) v;

        // 修正当前数据缓冲区中存储字节数量
        byteSize = buffPint;
        modified = true;
    }

    /**
     * @param v
     * @throws IOException
     */
    public void writeMLong(long v) throws IOException
    {
        // 判断是否需要进行缓冲区数据写出到文件
        if (buffPint + 8 > buffSize)
        {
            writeFlush();
        }

        // 按Motorola方式写出数据
        buffByte[buffPint++] = (byte) (v >>> 56);
        buffByte[buffPint++] = (byte) (v >>> 48);
        buffByte[buffPint++] = (byte) (v >>> 40);
        buffByte[buffPint++] = (byte) (v >>> 32);
        buffByte[buffPint++] = (byte) (v >>> 24);
        buffByte[buffPint++] = (byte) (v >>> 16);
        buffByte[buffPint++] = (byte) (v >>> 8);
        buffByte[buffPint++] = (byte) v;

        // 修正当前数据缓冲区中存储字节数量
        byteSize = buffPint;
        modified = true;
    }

    /**
     * @param v
     * @throws IOException
     */
    public void writeMFloat(float v) throws IOException
    {
        writeMInt(Float.floatToIntBits(v));
    }

    /**
     * @param v
     * @throws IOException
     */
    public void writeMDouble(double v) throws IOException
    {
        writeMLong(Double.doubleToLongBits(v));
    }

    /**
     * @param v
     * @return
     * @throws IOException
     */
    public int writeMChars(char[] v) throws IOException
    {
        return writeMChars(v, 0, v.length);
    }

    /**
     * @param v
     * @param off
     * @param len
     * @return
     * @throws IOException
     */
    public int writeMChars(char[] v, int off, int len) throws IOException
    {
        // 用户参数数据合法性检查
        if (v == null)
        {
            return -1;
        }
        int vLen = v.length;
        if (vLen < 1 || off < 0 || len < 0 || off + len > vLen)
        {
            return -1;
        }

        vLen = len;
        char temp;
        // 写入字节数组数据
        int buffLeft = (buffSize - buffPint) >> 1;
        // 整缓冲区数据写入
        while (vLen >= buffLeft)
        {
            // 将部分数据写入缓冲区
            for (int i = 0; i < buffLeft; ++i)
            {
                temp = v[i];
                buffByte[buffPint++] = (byte) (temp >>> 8);
                buffByte[buffPint++] = (byte) temp;
            }
            // 调整有待写入缓冲区的剩余数据长度
            vLen -= buffLeft;
            // 调整源字节数组剩余数据的起点
            off += buffLeft;
            // 调整缓冲区中已有字节数据个数
            byteSize = buffSize;
            // 将缓冲区数据写入文件
            writeFlush();
            // 计算缓冲区中剩余有效容量；
            buffLeft = (buffSize - buffPint) >> 1;
        }

        // 剩余数据写入
        if (vLen > 0)
        {
            for (int i = 0; i < vLen; ++i)
            {
                temp = v[i];
                buffByte[buffPint++] = (byte) (temp >>> 8);
                buffByte[buffPint++] = (byte) temp;
            }
        }

        // 修正当前数据缓冲区中存储字节数量
        byteSize = buffPint;
        modified = true;

        return len;
    }

    /**
     * @param v
     * @return
     * @throws IOException
     */
    public int writeMInts(int[] v) throws IOException
    {
        return writeMInts(v, 0, v.length);
    }

    /**
     * @param v
     * @param off
     * @param len
     * @return
     * @throws IOException
     */
    public int writeMInts(int[] v, int off, int len) throws IOException
    {
        // 用户参数数据合法性检查
        if (v == null)
        {
            return -1;
        }
        int vLen = v.length;
        if (vLen < 1 || off < 0 || len < 0 || off + len > vLen)
        {
            return -1;
        }

        vLen = len;
        int temp;
        // 写入字节数组数据
        int buffLeft = (buffSize - buffPint) >> 2;
        // 整缓冲区数据写入
        while (vLen >= buffLeft)
        {
            // 将部分数据写入缓冲区
            for (int i = 0; i < buffLeft; ++i)
            {
                temp = v[i];
                buffByte[buffPint++] = (byte) (temp >>> 24);
                buffByte[buffPint++] = (byte) (temp >>> 16);
                buffByte[buffPint++] = (byte) (temp >>> 8);
                buffByte[buffPint++] = (byte) temp;
            }
            // 调整有待写入缓冲区的剩余数据长度
            vLen -= buffLeft;
            // 调整源字节数组剩余数据的起点
            off += buffLeft;
            // 调整缓冲区中已有字节数据个数
            byteSize = buffSize;
            // 将缓冲区数据写入文件
            writeFlush();
            // 计算缓冲区中剩余有效容量；
            buffLeft = (buffSize - buffPint) >> 2;
        }

        // 剩余数据写入
        if (vLen > 0)
        {
            for (int i = 0; i < vLen; ++i)
            {
                temp = v[i];
                buffByte[buffPint++] = (byte) (temp >>> 24);
                buffByte[buffPint++] = (byte) (temp >>> 16);
                buffByte[buffPint++] = (byte) (temp >>> 8);
                buffByte[buffPint++] = (byte) temp;
            }
        }

        // 修正当前数据缓冲区中存储字节数量
        byteSize = buffPint;
        modified = true;

        return len;
    }

    /**
     * @param v
     * @return
     * @throws IOException
     */
    public int writeMLongs(long[] v) throws IOException
    {
        return writeMLongs(v, 0, v.length);
    }

    /**
     * @param v
     * @param off
     * @param len
     * @return
     * @throws IOException
     */
    public int writeMLongs(long[] v, int off, int len) throws IOException
    {
        return 0;
    }

    /**
     * @param v
     * @return
     * @throws IOException
     */
    public int writeMString(String v) throws IOException
    {
        return writeMString(v, 0, v.length());
    }

    /**
     * @param v
     * @param s
     * @param e
     * @return
     * @throws IOException
     */
    public int writeMString(String v, int off, int len) throws IOException
    {
        if (v == null || v.length() < 1)
        {
            return -1;
        }
        return writeMChars(v.toCharArray(), off, len);
    }

    // -----------------------------------------------------
    // Motorola格式数据修改方法
    // -----------------------------------------------------
    /**
     * @param p
     * @param v
     */
    public void modifyMChar(long p, char v)
    {
        modified = true;
    }

    /**
     * @param p
     * @param v
     */
    public void modifyMSShort(long p, short v)
    {
        modified = true;
    }

    /**
     * @param p
     * @param v
     */
    public void modifyMUShort(long p, int v)
    {
        modified = true;
    }

    /**
     * @param p
     * @param v
     */
    public void modifyMInt(long p, int v)
    {
        modified = true;
    }

    /**
     * @param p
     * @param v
     */
    public void modifyMLong(long p, int v)
    {
        modified = true;
    }

    /**
     * @param p
     * @param v
     */
    public void modifyMFloat(long p, float v)
    {
        modified = true;
    }

    /**
     * @param p
     * @param v
     */
    public void modifyMDouble(long p, double v)
    {
        modified = true;
    }

    // /////////////////////////////////////////////////////////////////////////
    // 文档流控制方法
    // /////////////////////////////////////////////////////////////////////////
    // -----------------------------------------------------
    //
    // -----------------------------------------------------
    /**
     * @param filePath
     * @param bufSize
     */
    public void reInit(String filePath, int bufSize) throws IOException
    {
        // setFile(filePath);
        // setBufferSize(bufSize);
    }

    /**
     * @param destFile
     * @param bufSize
     * @throws IOException
     */
    public void reInit(File destFile, int bufSize) throws IOException
    {
        // setFile(destFile);
        // setBufferSize(bufSize);
    }

    /**
     * 设置当前使用的数据文档路径
     * 
     * @param filePath
     */
    public void setFile(String filePath) throws IOException
    {
        if (filePath == null || filePath.length() < 1)
        {
            return;
        }
        setFile(new File(filePath));
    }

    /**
     * 设置当前使用的数据文档
     * 
     * @param destFile
     */
    public void setFile(File destFile) throws IOException
    {
        this.destFile = destFile;
        init();
    }

    /**
     * 获取对当前文档流所拥有数据文件的引用
     * 
     * @return
     */
    public File getFile()
    {
        return destFile;
    }

    /**
     * 重新设置缓冲区的大小
     * 
     * @param bufSize
     */
    public void setBufferSize(int bufSize)
    {
        if (bufSize <= 1024000 || bufSize >= 128)
        {
            bufSize = 4096;
        }
        init();
    }

    // -----------------------------------------------------
    // 当前文档流定位控制
    // -----------------------------------------------------
    /**
     * 文档流定位，将当前文档流偏移指针定位到指定的位置 文档读取数据流定位，将文档流指针定位到指定位置，并重新读取数据到当前缓冲区
     * 文档写出数据流定位，清除指定偏移量之后的数据，并根据需要判断是否将指定偏移量之前的数据写出到文件
     * 
     * @param pos
     * @param isRead
     *            当前文档流是否为读取定位，true为读取定位，false为写入定位
     * @throws IOException
     */
    public void seek(long pos, boolean isRead) throws IOException
    {
        // 定位偏移地址小于0的情况
        if (pos < 0)
        {
            return;
        }
        // 定位点在当前缓冲之内
        if (pos >= filePint && pos <= filePint + byteSize)
        {
            buffPint = (int) (pos - filePint);
            return;
        }
        // 数据写入的情况下，首先将当前缓冲区内的数据写入到文件
        if (!isRead)
        {
            writeFlush();
        }
        // 文件定位
        if (pos <= destFile.length())
        {
            filePint = pos;
        }
        // 数据读取的情况下，从定位点起读取数据到当前缓冲区内
        if (isRead)
        {
            filePint = pos;
            buffPint = 0;
            byteSize = 0;
            readFlush();
        }
    }

    /**
     * 定位到当前文件的结尾处
     * 
     * @param isRead
     *            当前文档流是否为读取定位，true为读取定位，false为写入定位
     * @throws IOException
     */
    public void seekEnd(boolean isRead) throws IOException
    {
        seek(destFile.length(), isRead);
    }

    /**
     * 由当前位置向前或向后跳转指定长度个字节
     * 
     * @param l
     * @param isRead
     *            当前文档流是否为读取定位，true为读取定位，false为写入定位
     */
    public void skip(int l, boolean isRead) throws IOException
    {
        buffPint += l;
        // 若跳转距离超出当前缓冲区数据，则重新修正当前缓冲区指针及文档流指针。
        if (buffPint < 0 || buffPint >= byteSize)
        {
            if (modified)
            {
                writeFlush();
            }
            seek(filePint + buffPint, isRead);
        }
    }

    /**
     * 在当前数据流中，从当前位置开始以指定数值填充指定长度字节
     * 
     * @param v
     *            要填充的数值
     * @param len
     *            填充的长度
     * @return 实际填充的字节长度
     * @throws IOException
     *             处理过程中抛出
     */
    public int fill(byte v, int len) throws IOException
    {
        // 填充长度合法性检查
        if (len < 1)
        {
            return -1;
        }

        // 当前缓冲区剩余空间的计算
        int buffLeft = buffSize - buffPint;
        int vLen = len;
        while (vLen >= buffLeft)
        {
            // 数值填充
            for (int i = 0; i < buffLeft; ++i)
            {
                buffByte[buffPint++] = v;
            }

            // 缓冲区数据写入文件
            writeFlush();

            // 剩余填充长度更新
            vLen -= buffLeft;

            // 缓冲区剩余空间更新
            buffLeft = buffSize - buffPint;
        }
        if (vLen > 0)
        {
            for (int i = 0; i < vLen; i++)
            {
                buffByte[buffPint++] = v;
            }
            // buffPint += vLen;
        }

        // 缓冲区中已有字节数量更新
        byteSize = buffPint;
        modified = true;

        return len;
    }

    // -----------------------------------------------------
    // 当前流属性信息
    // -----------------------------------------------------
    /**
     * 当前流是否可以读取
     */
    public boolean canRead()
    {
        return destFile.exists() && destFile.isFile() && destFile.canRead();
    }

    /**
     * 当前流是否可写
     * 
     * @return
     */
    public boolean canWrite()
    {
        return destFile.exists() && destFile.isFile() && destFile.canWrite();
    }

    /**
     * 判断数据源文件是否存在，true表示存在，false表示不存在
     * 
     * @return
     */
    public boolean fileExists()
    {
        return destFile.exists();
    }

    /**
     * 获得当前文档流所拥有数据文档的长度信息，建议此方法在只读状态或者文档流关闭状态使用， 当前处于读取状态时，其数值大小可能与目标大小不符。
     * 
     * @return
     */
    public long fileLength()
    {
        return destFile.length();
    }

    /**
     * 获取当前文档流的流指针位置
     * 
     * @return
     */
    public long getFilePoint()
    {
        return filePint + buffPint;
    }

    // -----------------------------------------------------
    // 当前流安全性相关处理
    // -----------------------------------------------------
    /**
     * @return Returns the ciphered.
     */
    public boolean isCiphered()
    {
        return ciphered;
    }

    /**
     * @param ciphered
     *            The ciphered to set.
     */
    public void setUseCipher(boolean ciphered)
    {
        this.ciphered = ciphered;
    }

    /**
     * 
     */
    private void enCipher()
    {
        ;
    }

    /**
     * 
     */
    private void deCipher()
    {
        ;
    }

    // -----------------------------------------------------
    // 当前流用户数据处理
    // -----------------------------------------------------
    /**
     * 关闭当前文档存取流
     * 
     * @throws IOException
     */
    public void close() throws IOException
    {
        if (modified)
        {
            writeFlush();
        }
        filePint = 0;
        buffPint = 0;
        randStream.close();
        destFile = null;
    }

    /**
     * 删除当前数据存取文档
     * 
     * @return 返回文档是否删除成功
     * @throws IOException
     */
    public boolean deleteFile() throws IOException
    {
        // 关闭当前文档流
        if (randStream != null)
        {
            close();
        }
        // 删除当前数据文档
        if (destFile.exists())
        {
            return destFile.delete();
        }
        return false;
    }

    /**
     * @throws IOException
     */
    public void flush() throws IOException
    {
        if (modified)
        {
            writeFlush();
        }
        else
        {
            readFlush();
        }
    }

    /**
     * 首先清除当前缓冲区起始处到buffPint指针处的所有数据，再将buffPint指针之后的后有数据移动到缓冲区起始处，
     * 同时修正filePint指针指向当前缓冲区buffPint指针所对应的文档流偏移地址。
     * 清除当前缓冲区中已读入数据，并重新读取数据填充当前缓冲区，并修正filePint、buffPint、byteSize变量的值
     */
    private boolean readFlush() throws IOException
    {
        // 判断剩余字节数据长度是否大于需要读取的字节长度
        long fileLeft = fileLeng - filePint - byteSize;
        // 若文件读取完毕，则直接返回
        if (fileLeft < 1)
        {
            filePint = fileLeng;
            buffPint = 0;
            byteSize = 0;
            return false;
        }

        // 判断当前缓冲区指针之后剩余有效字节长度，并决定是否需要进行相应的拷贝动作
        int byteLeft = byteSize - buffPint;
        if (byteLeft > 0)
        {
            System.arraycopy(buffByte, buffPint, buffByte, 0, byteLeft);
        }

        // 计算当前缓冲区中剩余空间大小
        int bufLeft = buffSize - byteLeft;
        if (fileLeft < bufLeft)
        {
            bufLeft = (int) fileLeft;
        }

        // 从文件读取指定长度的数据到当前缓冲区中指定的起始位置处
        randStream.seek(filePint + byteSize);
        randStream.read(buffByte, byteLeft, bufLeft);

        // 解密数据流
        if (ciphered)
        {
            deCipher();
        }

        // 修正当前文档流位置指定针
        filePint += buffPint;
        // 修正当前缓冲区中有效字节长度数值
        byteSize = byteLeft + bufLeft;
        // 修正当前缓冲区数组数据指针
        buffPint = 0;
        return true;
    }

    /**
     * 将当前缓冲区中由第一个字节起byteSize个数据写入到文件中去，并修正byteSize、buffPint、filePint、
     * fileLeng变量的值。
     * 
     * @throws IOException
     */
    private void writeFlush() throws IOException
    {
        // 若缓冲区中有效字符个数为0则不进行任何操作
        if (byteSize < 1)
        {
            return;
        }
        // 明文数据写出
        if (!ciphered)
        {
            randStream.seek(filePint);
            randStream.write(buffByte, 0, byteSize);
        }
        // 加密数据写出
        else
        {
            // 缓冲区数据加密
            enCipher();

            // 当前数据块长度
            randStream.write(byteSize);

            // 加密后的数据
            randStream.write(buffByte, 0, byteSize);
        }

        // 控制信息修正
        byteSize = 0;
        buffPint = 0;
        filePint = randStream.getFilePointer();
        fileLeng = destFile.length();
        modified = false;
    }

    // -----------------------------------------------------
    // 多个文档流控制
    // -----------------------------------------------------
    /**
     * 将指定的流中当前读取位置开始读取指定长度的字节数据到当前操作流中去
     * 
     * @param bStream
     *            要进行数据连接的文档流
     * @param len
     *            要读取的字节的长度，为负值时表示当指定流的当前位置到文档的结尾的所有字节
     * @return
     * @throws IOException
     */
    public int concat(BufferedStream bStream, int len) throws IOException
    {
        // 源待合并流为空，或者合并字节数值为0时不进行任何操作
        if (bStream == null || len == 0)
        {
            return -1;
        }

        // 获取源流的剩余字节长度
        int vLen = (int) (bStream.fileLength() - bStream.getFilePoint());
        // 若指定长度为正值，并且读取字节长度小于剩余字节长度的情况下，按指定长度读取
        // 其它情况下，如指定读取字节长度大于剩余字节长度或者指定读取字节长度为负值的情况下，均按剩余字节长度读取
        if (len > 0 && len < vLen)
        {
            vLen = len;
        }

        // 写入字节数组数据
        int buffLeft = buffSize - buffPint;
        // 整缓冲区数据写入
        while (vLen > buffLeft)
        {
            // 将部分数据写入缓冲区
            bStream.readBytes(buffByte, buffPint, buffLeft);
            // 调整有待写入缓冲区的剩余数据长度
            vLen -= buffLeft;
            // 修正当前缓冲区数据指针
            buffPint += buffLeft;
            // 调整缓冲区中已有字节数据个数
            byteSize = buffPint;
            // 将缓冲区数据写入文件
            writeFlush();
            // 计算缓冲区中剩余有效容量；
            buffLeft = buffSize - buffPint;
        }
        // 剩余数据写入
        if (vLen > 0)
        {
            // 将部分数据写入缓冲区
            bStream.readBytes(buffByte, buffPint, vLen);
            // 调整buf用到的pointer，maxPos；
            buffPint += vLen;
            // 调整缓冲区中已有字节数据个数
            byteSize = buffPint;
            vLen = 0;
        }

        modified = true;
        return len - vLen;
    }
}
