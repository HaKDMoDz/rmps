/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.util;

import java.awt.Component;
import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.UnsupportedEncodingException;
import java.net.URL;
import java.util.Properties;

import javax.swing.JFileChooser;

import rmp.Rmps;
import rmp.bean.FilesFilter;

import com.amonsoft.util.CharUtil;
import com.amonsoft.util.LogUtil;

import cons.CfgCons;
import cons.EnvCons;
import cons.ui.LangRes;

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
public final class FileUtil
{
    private static JFileChooser fc_FileOpen;
    private static JFileChooser fc_FileSave;

    /** 默认构造函数 */
    private FileUtil()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IRmps#wInit()
     */
    public boolean wInit()
    {
        return true;
    }

    /**
     * @param srcFile
     * @param dstFile
     * @param overWrite
     * @return
     * @throws IOException
     */
    public static String copyFile(File srcFile, File dstFile, boolean overWrite) throws IOException
    {
        return fileMove(srcFile, dstFile, overWrite, false);
    }

    /**
     * @param srcFile
     * @param dstFile
     * @param overWrite
     * @return
     * @throws IOException
     */
    public static String moveFile(File srcFile, File dstFile, boolean overWrite) throws IOException
    {
        return fileMove(srcFile, dstFile, overWrite, true);
    }

    /**
     * @param srcFile
     * @param dstFile
     * @param overWrite
     *            若目标文件存在的情况下，是滞覆盖目标文件：true覆盖目标文件；false不覆盖
     * @param delSrc
     *            文件移动后，是否要删除源文件：true删除；false不删除
     * @return
     * @throws IOException
     */
    private static String fileMove(File srcFile, File dstFile, boolean overWrite, boolean delSrc) throws IOException
    {
        // 源文件不存在
        if (!srcFile.exists())
        {
            return StringUtil.format(LangRes.MESG_FILE_0001, srcFile.getPath());
        }

        // 源文件不是一个文件
        if (!srcFile.isFile())
        {
            return StringUtil.format(LangRes.MESG_FILE_0002, srcFile.getPath());
        }

        // 源文件不可读
        if (!srcFile.canRead())
        {
            return StringUtil.format(LangRes.MESG_FILE_0003, srcFile.getPath());
        }

        // 若目标文件不存在，则创建
        if (!dstFile.exists())
        {
            dstFile.createNewFile();
        }
        // 若目标文件存在，且不覆盖目标文件的情况
        else if (!overWrite)
        {
            return StringUtil.format(LangRes.MESG_FILE_0004, dstFile.getPath());
        }

        // 若目标文件不是一个文件，则直接返回
        if (!dstFile.isFile())
        {
            return StringUtil.format(LangRes.MESG_FILE_0002, dstFile.getPath());
        }

        // 目标文件不可写
        if (!dstFile.canWrite())
        {
            return StringUtil.format(LangRes.MESG_FILE_0005, dstFile.getPath());
        }

        LogUtil.log("文件拷贝：源文件 － " + srcFile.getPath() + "; 汇文件 － " + dstFile.getPath());

        // 文本输入流对象
        FileInputStream fis = new FileInputStream(srcFile);

        // 文本输出流对象
        FileOutputStream fos = new FileOutputStream(dstFile);

        // 临时变量
        int bLen = EnvCons.COMN_BUFF_SIZE;
        byte[] buf = new byte[bLen];

        // 循环读取来源文件的每一个字节，并写入到目标文件中去。
        while (true)
        {
            // 读取一个字节
            bLen = fis.read(buf);

            // 文件读取结束判断
            if (bLen < 0)
            {
                break;
            }

            // 写入当前字节
            fos.write(buf, 0, bLen);
        }

        // 文本输出流关闭
        fos.close();
        fos = null;
        dstFile = null;

        // 文本输入流关闭
        fis.close();
        fis = null;
        // 删除来源文件
        if (delSrc && !srcFile.delete())
        {
            return StringUtil.format(LangRes.MESG_FILE_0006, srcFile.getPath());
        }
        srcFile = null;

        return null;
    }

    /**
     * @param file
     * @return
     */
    public static String getFileExt(String file)
    {
        return getFileExt(new File(file));
    }

    /**
     * 获得指定文件的扩展名信息
     * 
     * @param file
     * @return 返回形如“.abc”格式的扩展名信息
     */
    public static String getFileExt(File file)
    {
        // 不是文件的情况下，返回NULL
        if (!file.isFile())
        {
            return null;
        }

        // 文件名不合法
        String t = file.getName().trim();
        if (!CharUtil.isValidate(t))
        {
            return null;
        }

        // 文件没有扩展名
        int i = t.lastIndexOf('.');
        if (i < 0)
        {
            return "";
        }

        return t.substring(i);
    }

    /**
     * 由指定的文件路径创建缓冲字符数据输入流，并以数据文件默认的编码方案对数据流进行编码
     * 
     * @param filePath
     *            要创建字符数据输入流的文件路径
     * @return 缓冲字符数据输入流
     * @throws FileNotFoundException
     * @throws UnsupportedEncodingException
     */
    public static BufferedReader getReader(String filePath) throws FileNotFoundException, UnsupportedEncodingException
    {
        return getReader(new File(filePath));
    }

    /**
     * 由指定的文件对象创建缓冲字符数据输入流，并以数据文件默认的编码方案对数据流进行编码
     * 
     * @param filePath
     *            要创建字符数据输入流的文件对象
     * @return 缓冲字符数据输入流
     * @throws FileNotFoundException
     * @throws UnsupportedEncodingException
     */
    public static BufferedReader getReader(File filePath) throws FileNotFoundException, UnsupportedEncodingException
    {
        // Stream对象
        FileInputStream fis = new FileInputStream(filePath);
        // Reader对象
        InputStreamReader isr = new InputStreamReader(fis);
        // 缓冲对象
        BufferedReader br = new BufferedReader(isr);

        return br;
    }

    /**
     * 由指定的文件路径创建缓冲字符数据输入流，并以指定的编码方案对数据流进行编码
     * 
     * @param filePath
     *            要创建字符数据输入流的文件路径
     * @param charsetName
     *            字符编码集
     * @return 缓冲字符数据输入流
     * @throws FileNotFoundException
     * @throws UnsupportedEncodingException
     */
    public static BufferedReader getReader(String filePath, String charsetName) throws FileNotFoundException, UnsupportedEncodingException
    {
        return getReader(new File(filePath), charsetName);
    }

    /**
     * 由指定的文件对象创建缓冲字符数据输入流，并以指定的编码方案对数据流进行编码
     * 
     * @param filePath
     *            要创建数据输入流的来源文件
     * @param charsetName
     *            字符编码集
     * @return 缓冲字符数据输入流
     * @throws FileNotFoundException
     * @throws UnsupportedEncodingException
     */
    public static BufferedReader getReader(File filePath, String charsetName) throws FileNotFoundException, UnsupportedEncodingException
    {
        // Stream对象
        FileInputStream fis = new FileInputStream(filePath);
        // Reader对象
        InputStreamReader isr = new InputStreamReader(fis, charsetName);
        // 缓冲对象
        BufferedReader br = new BufferedReader(isr);

        return br;
    }

    /**
     * 由指定的文件路径创建缓冲字符数据输出流，并以系统默认的编码方案对数据流进行编码
     * 
     * @param filePath
     *            要创建缓冲字符输出流的文件路径
     * @return 缓冲字符输出流
     * @throws FileNotFoundException
     * @throws UnsupportedEncodingException
     */
    public static BufferedWriter getWriter(String filePath) throws FileNotFoundException, UnsupportedEncodingException
    {
        return getWriter(new File(filePath));
    }

    /**
     * 由指定的文件对象创建缓冲字符数据输出流，并以系统默认的编码方案对数据流进行编码
     * 
     * @param filePath
     *            要创建缓冲字符输出流的文件对象
     * @return 缓冲字符输出流
     * @throws FileNotFoundException
     * @throws UnsupportedEncodingException
     */
    public static BufferedWriter getWriter(File filePath) throws FileNotFoundException, UnsupportedEncodingException
    {
        FileOutputStream fos = new FileOutputStream(filePath);
        OutputStreamWriter osw = new OutputStreamWriter(fos);
        BufferedWriter bw = new BufferedWriter(osw);
        return bw;
    }

    /**
     * 由指定的文件路径创建缓冲字符数据输出流，并以指定的编码方案对数据流进行编码
     * 
     * @param filePath
     *            要创建缓冲字符输出流的文件路径
     * @param charsetName
     *            字符编码集
     * @return 缓冲字符输出流
     * @throws FileNotFoundException
     * @throws UnsupportedEncodingException
     */
    public static BufferedWriter getWriter(String filePath, String charsetName) throws FileNotFoundException, UnsupportedEncodingException
    {
        return getWriter(new File(filePath), charsetName);
    }

    /**
     * 由指定的文件对象创建缓冲字符数据输出流，并以指定的编码方案对数据流进行编码
     * 
     * @param filePath
     *            要创建缓冲字符输出流的文件对象
     * @param charsetName
     *            字符编码集
     * @return 缓冲字符输出流
     * @throws FileNotFoundException
     * @throws UnsupportedEncodingException
     */
    public static BufferedWriter getWriter(File filePath, String charsetName) throws FileNotFoundException, UnsupportedEncodingException
    {
        FileOutputStream fos = new FileOutputStream(filePath);
        OutputStreamWriter osw = new OutputStreamWriter(fos, charsetName);
        BufferedWriter bw = new BufferedWriter(osw);
        return bw;
    }

    /**
     * @param filePath
     * @return
     * @throws FileNotFoundException
     */
    public static BufferedInputStream getInputStream(String filePath) throws FileNotFoundException
    {
        return getInputStream(new File(filePath));
    }

    /**
     * @param filePath
     * @return
     * @throws FileNotFoundException
     */
    public static BufferedInputStream getInputStream(File filePath) throws FileNotFoundException
    {
        FileInputStream fis = new FileInputStream(filePath);
        BufferedInputStream bis = new BufferedInputStream(fis);

        return bis;
    }

    /**
     * @param filePath
     * @return
     * @throws FileNotFoundException
     */
    public static BufferedOutputStream getOutputStream(String filePath) throws FileNotFoundException
    {
        return getOutputStream(new File(filePath));
    }

    /**
     * @param filePath
     * @return
     * @throws FileNotFoundException
     */
    public static BufferedOutputStream getOutputStream(File filePath) throws FileNotFoundException
    {
        FileOutputStream fos = new FileOutputStream(filePath);
        BufferedOutputStream bos = new BufferedOutputStream(fos);

        return bos;
    }

    /**
     * 显示图像文件选择对话框
     */
    public static File showSingleFileSave(Component comp, boolean folderOnly, FilesFilter filter)
    {
        // 文件对话框窗口，文件选择模式为单选
        if (fc_FileSave == null)
        {
            fc_FileSave = new JFileChooser();
            fc_FileSave.setMultiSelectionEnabled(false);
        }

        // 重设文件过滤器
        fc_FileSave.resetChoosableFileFilters();
        if (folderOnly)
        {
            // 文件选择方式
            fc_FileSave.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
        }
        else if (filter != null)
        {
            // 文件过滤器
            fc_FileSave.setFileFilter(filter);
        }

        // 对话框状态处理
        int stat = fc_FileSave.showSaveDialog(comp);

        // 选择文件处理
        if (JFileChooser.APPROVE_OPTION == stat)
        {
            File userFile = fc_FileSave.getSelectedFile();
            LogUtil.log("文件系统操作：用户选择文件 － " + userFile.getPath());
            return userFile;
        }

        // 用户取消操作
        if (JFileChooser.CANCEL_OPTION == stat)
        {
            LogUtil.log("文件系统操作：用户取消文件打开！！！");
            return null;
        }

        // 打开错误处理
        if (JFileChooser.ERROR_OPTION == stat)
        {
            LogUtil.log("文件系统操作：文件打开错误！！！");
            String mesg = StringUtil.format(LangRes.MESG_OTHR_0008, LangRes.MESG_INIT_0007);
            MesgUtil.showMessageDialog(comp, mesg);
            return null;
        }

        // 容错处理
        return null;
    }

    /**
     * @param folderOnly
     * @param filter
     * @return
     */
    public static File showSingleFileOpen(Component comp, boolean folderOnly, FilesFilter filter)
    {
        // 文件对话框窗口，文件选择模式为单选
        if (fc_FileOpen == null)
        {
            fc_FileOpen = new JFileChooser();
            fc_FileOpen.setMultiSelectionEnabled(false);
        }

        // 重设文件过滤器
        fc_FileOpen.resetChoosableFileFilters();
        if (folderOnly)
        {
            // 文件选择方式
            fc_FileOpen.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
        }
        else if (filter != null)
        {
            // 文件过滤器
            fc_FileOpen.setFileFilter(filter);
        }

        // 对话框状态处理
        int stat = fc_FileOpen.showOpenDialog(comp);

        // 选择文件处理
        if (JFileChooser.APPROVE_OPTION == stat)
        {
            File userFile = fc_FileOpen.getSelectedFile();
            LogUtil.log("文件系统操作：用户选择文件 － " + userFile.getPath());
            return userFile;
        }

        // 用户取消操作
        if (JFileChooser.CANCEL_OPTION == stat)
        {
            LogUtil.log("文件系统操作：用户取消文件打开！！！");
            return null;
        }

        // 打开错误处理
        if (JFileChooser.ERROR_OPTION == stat)
        {
            LogUtil.log("文件系统操作：文件打开错误！！！");
            String mesg = StringUtil.format(LangRes.MESG_OTHR_0008, LangRes.MESG_INIT_0007);
            MesgUtil.showMessageDialog(comp, mesg);
            return null;
        }

        // 容错处理
        return null;
    }

    /**
     * @param path
     * @param name
     * @return
     */
    public static URL getResource(String path, String name)
    {
        StringBuffer sb = new StringBuffer();
        sb.append(EnvCons.FOLDER0_SKIN).append(path).append(EnvCons.COMN_SP_FILE);
        sb.append(StringUtil.format(name, Rmps.getUser().getCfg(CfgCons.CFG_LANG_ID)));
        return FileUtil.class.getResource(sb.toString());
    }

    /**
     * @param path
     * @param name
     * @return
     */
    public static InputStream getResourceAsStream(String path, String name)
    {
        StringBuffer sb = new StringBuffer();
        sb.append(EnvCons.FOLDER0_SKIN).append(path).append(EnvCons.COMN_SP_FILE);
        sb.append(StringUtil.format(name, Rmps.getUser().getCfg(CfgCons.CFG_LANG_ID)));
        LogUtil.log("系统语言资源加载：" + sb.toString());
        return FileUtil.class.getResourceAsStream(sb.toString());
    }

    /**
     * @param langRes
     * @param resPath
     * @param resName
     */
    public static void readLangRes(Properties langRes, String resPath) throws Exception
    {
        String resName = "";
        // 读取语言资源
        InputStream inStream = null;
        try
        {
            // 首先读取Jar内部语言资源
            inStream = getResourceAsStream(resPath, resName);
            if (inStream != null)
            {
                langRes.load(inStream);
            }
        }
        finally
        {
            if (inStream != null)
            {
                inStream.close();
            }
        }
    }
}
