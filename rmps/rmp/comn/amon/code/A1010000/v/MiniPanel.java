/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.amon.code.A1010000.v;

import java.awt.FlowLayout;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileFilter;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.UnsupportedEncodingException;
import java.util.ArrayList;
import java.util.List;

import javax.swing.JOptionPane;

import rmp.comn.amon.code.A1010000.A1010000;
import rmp.face.WBean;

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
public class MiniPanel extends javax.swing.JPanel implements WBean
{
    /**  */
    private static final long serialVersionUID = 1L;
    private static final String TXT_SRC = "jeuropa\\rmps";
    private static final String TXT_DST = "javanet\\rmps\\src";

    /**
     * @param soft
     */
    public MiniPanel(A1010000 soft)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    public boolean wInit()
    {
        ica();

        return true;
    }

    private void ica()
    {
        this.setLayout(new FlowLayout());
        b = new javax.swing.JButton("清除代码注释");
        b.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                b_Handler(evt);
            }
        });
    }

    private void b_Handler(java.awt.event.ActionEvent evt)
    {
        int option = JOptionPane.showConfirmDialog(this, "此代码清除操作将直接在代码源文件上进行，所有改变无法恢复。系统无法保证所有操作都是正常的，请先备份您的源程序代码！\n确定要进行下一步么？");
        if (option != JOptionPane.YES_OPTION)
        {
            return;
        }

        deleteComment("rmp");
        deleteComment("cons");
        JOptionPane.showMessageDialog(this, "注释处理完毕！");
    }

    private boolean deleteComment(String folder)
    {
        List<File> list = new ArrayList<File>();
        if (!getFileList(new File(folder), list))
        {
            return false;
        }

        File srcFile;
        File dstFile;
        for (int i = 0; i < list.size(); i += 1)
        {
            srcFile = list.get(i);
            dstFile = makeFile(srcFile.getAbsolutePath());
            System.out.println("start------------------------");
            System.out.println(srcFile.getPath());
            System.out.println(dstFile.getPath());
            fileProc(srcFile, dstFile);
            System.out.println("end--------------------------\n");
        }

        return true;
    }

    private boolean fileProc(File srcFile, File dstFile)
    {
        try
        {
            BufferedReader srcReader = getReader(srcFile);
            BufferedWriter dstWriter = getWriter(dstFile);

            String readLine;
            String trimLine;
            boolean sComn = false;
            while (true)
            {
                readLine = srcReader.readLine();
                if (readLine == null)
                {
                    break;
                }

                trimLine = readLine.trim();
                if (trimLine.startsWith("//"))
                {
                    continue;
                }

                if (sComn)
                {
                    if (trimLine.endsWith("*/"))
                    {
                        sComn = false;
                    }
                    continue;
                }
                else if (trimLine.startsWith("/**"))
                {
                    if (!trimLine.endsWith("*/"))
                    {
                        sComn = true;
                    }
                    continue;
                }

                dstWriter.write(readLine);
                dstWriter.newLine();
            }

            dstWriter.close();
            srcReader.close();
        }
        catch (Exception exp)
        {
            exp.printStackTrace();
        }
        return true;
    }

    private boolean getFileList(File dir, List<File> list)
    {
        if (dir == null || !dir.exists())
        {
            return false;
        }

        if (dir.isFile())
        {
            list.add(dir);
            return true;
        }

        File files[] = dir.listFiles(new FileFilter()
        {
            public boolean accept(File pathname)
            {
                if (pathname.isDirectory())
                {
                    return true;
                }
                return pathname.getName().toLowerCase().endsWith(".java");
            }
        });

        File tmpFile;
        for (int i = 0; i < files.length; i += 1)
        {
            tmpFile = files[i];
            getFileList(tmpFile, list);
        }

        return true;
    }

    private File makeFile(String srcPath)
    {
        File dstFile = new File(srcPath.replace(TXT_SRC, TXT_DST));
        if (!dstFile.exists())
        {
            File parent = dstFile.getParentFile();
            if (!parent.exists())
            {
                parent.mkdirs();
            }

            try
            {
                dstFile.createNewFile();
            }
            catch (IOException ioe)
            {
                ioe.printStackTrace();
            }
        }

        return dstFile;
    }

    public BufferedReader getReader(File filePath) throws FileNotFoundException, UnsupportedEncodingException
    {
        // Stream对象
        FileInputStream fis = new FileInputStream(filePath);
        // Reader对象
        InputStreamReader isr = new InputStreamReader(fis, "UTF-8");
        // 缓冲对象
        BufferedReader br = new BufferedReader(isr);

        return br;
    }

    public BufferedWriter getWriter(File filePath) throws FileNotFoundException, UnsupportedEncodingException
    {
        FileOutputStream fos = new FileOutputStream(filePath);
        OutputStreamWriter osw = new OutputStreamWriter(fos, "UTF-8");
        BufferedWriter bw = new BufferedWriter(osw);
        return bw;
    }

    private javax.swing.JButton b;
}
