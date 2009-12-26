/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.amon.code.A1010000.m;

import java.io.File;
import java.io.FileFilter;
import java.util.ArrayList;
import java.util.List;

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
public class Util
{
    /**
     * @param pFile
     * @return
     */
    public static List<File> listFiles(File pFile)
    {
        List<File> fileList = new ArrayList<File>();
        FileFilter f = new FileFilter()
        {
            public boolean accept(File pathname)
            {
                if (pathname.isDirectory())
                {
                    return true;
                }
                return pathname.getName().toLowerCase().endsWith(".java");
            }
        };
        getFileList(pFile, f, fileList);
        return fileList;
    }

    /**
     * @param file
     * @param filter
     * @param list
     */
    private static void getFileList(File file, FileFilter filter, List<File> list)
    {
        // 文件是否存在
        if (file == null || !file.exists())
        {
            return;
        }

        // 文件是否为文档
        if (file.isFile())
        {
            list.add(file);
            return;
        }

        // 获取文件列表
        File files[] = file.listFiles(filter);
        for (int i = 0; i < files.length; i += 1)
        {
            getFileList(files[i], filter, list);
        }
    }
}
