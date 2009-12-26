/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.bean;

import java.io.File;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 文件名称过滤器，用于显示指定的文件或文件夹。
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public final class FilesFilter extends javax.swing.filechooser.FileFilter implements java.io.FileFilter
{
    public static final int FOLDER_AND_FILE = 0;
    public static final int FOLDER_ONLY = 1;
    public static final int FILE_ONLY = 2;

    /**
     * 文件过滤器构造函数
     */
    public FilesFilter()
    {
        this(new String[0]);
    }

    /**
     * 文件过滤器构造函数
     * 
     * @param incText 过滤文件所包含的字符信息
     */
    public FilesFilter(String[] incText)
    {
        this.strInclude = incText;
        this.fcDespText = incText;
    }

    /**
     * @param includeText
     * @param descriptText
     */
    public FilesFilter(String[] includeText, String[] descriptText)
    {
        this.strInclude = includeText;
        this.fcDespText = descriptText;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.filechooser.FileFilter#accept(java.io.File)
     */
    public boolean accept(File pathname)
    {
        // 文件夹总是要显示
        if (pathname.isDirectory())
        {
            return filesModel != FILE_ONLY;
        }

        // 仅显示文件夹的情况下，直接返回false。
        if (filesModel == FOLDER_ONLY)
        {
            return false;
        }

        // 在不显示隐藏文件并且指定文件为隐藏文件的情况下，返回false
        if (!showHidden && pathname.isHidden())
        {
            return false;
        }

        // 若包含文字为空，则表示显示所有可以显示的文件
        if (strInclude == null || strInclude.length == 0)
        {
            return true;
        }

        // 若包含文字不为空，则表示显示符合包含指定文字的文件
        String name = pathname.getName();
        String temp;
        for (int i = 0, j = strInclude.length; i < j; i += 1)
        {
            temp = strInclude[i];

            // 若不区分大小写的情况下，则进行大小写转换后的比较
            if (!matchCase)
            {
                name = name.toLowerCase();
                temp = temp.toLowerCase();
            }

            // 文件名称包含指定的字符信息
            if (isInclude && name.indexOf(temp) >= 0)
            {
                return true;
            }

            // 文件名称后缀为指定字符信息
            if (name.endsWith(temp))
            {
                return true;
            }
        }

        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.filechooser.FileFilter#getDescription()
     */
    @Override
    public String getDescription()
    {
        if (fcDespText == null || fcDespText.length == 0)
        {
            return "*.*";
        }

        String temp = "";
        for (int i = 0, j = fcDespText.length; i < j; i += 1)
        {
            temp += fcDespText[i] + ";";
        }
        return temp;
    }

    /**
     * 重新设置所有属性信息
     */
    public void reset()
    {
        filesModel = FOLDER_AND_FILE;
        showHidden = false;
        isInclude = false;
        matchCase = false;
        strInclude = new String[]
                {
                    ""
                };
    }

    /**
     * @param fcDespText the fcDespText to set
     */
    public void setDescription(String[] fcDespText)
    {
        this.fcDespText = fcDespText;
    }

    /**
     * @return Returns the strInclude.
     */
    public String[] getTextInclude()
    {
        return strInclude;
    }

    /**
     * @param textInclude The textInclude to set.
     */
    public void setTextInclude(String[] textInclude)
    {
        this.strInclude = textInclude;
    }

    /**
     * @return the filesModel
     */
    public int getFilesModel()
    {
        return filesModel;
    }

    /**
     * @param filesModel the filesModel to set
     */
    public void setFilesModel(int filesModel)
    {
        this.filesModel = filesModel;
    }

    /**
     * 默认值：false
     * 
     * @return Returns the isSuffix.
     */
    public boolean isInclude()
    {
        return isInclude;
    }

    /**
     * @param isInclude The isSuffix to set.
     */
    public void setInclude(boolean isInclude)
    {
        this.isInclude = isInclude;
    }

    /**
     * @return Returns the showHidden.
     */
    public boolean isShowHidden()
    {
        return showHidden;
    }

    /**
     * @param showHidden The showHidden to set.
     */
    public void setShowHidden(boolean showHidden)
    {
        this.showHidden = showHidden;
    }

    /**
     * @return Returns the matchCase.
     */
    public boolean isMatchCase()
    {
        return matchCase;
    }

    /**
     * @param matchCase The matchCase to set.
     */
    public void setMatchCase(boolean matchCase)
    {
        this.matchCase = matchCase;
    }
    /** 是否显示隐藏文件（夹），true：显示隐藏文件（夹），false：不显示隐藏文件夹 */
    private boolean showHidden = false;
    /** 文件过滤方式 */
    private int filesModel = FOLDER_AND_FILE;
    /** 指定文字是否为包含文字，true：文件名称包含文字，false：仅指定文字为文件后缀 */
    private boolean isInclude = false;
    /** 是否文件名称区分大小写，true：区分大小写；false：不区分 */
    private boolean matchCase = false;
    /** 用于JFileChooser时的显示过滤信息 */
    private String[] fcDespText;
    /** 包含文字，若文件名称中包含此字符串则显示，反之不显示 */
    private String[] strInclude;
}
