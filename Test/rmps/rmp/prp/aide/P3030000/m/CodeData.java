/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3030000.m;

import javax.swing.table.AbstractTableModel;

import rmp.bean.K1SV1S;
import rmp.prp.aide.P3030000.P3030000;
import rmp.util.MesgUtil;

import com.amonsoft.util.CharUtil;

import cons.prp.aide.P3030000.ConstUI;
import cons.prp.aide.P3030000.LangRes;

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
public class CodeData extends AbstractTableModel
{
    /**  */
    private static final long serialVersionUID = -8968164321699499181L;
    /** 当前查询模式：字符模式 */
    private boolean charModel = true;
    /** 字符列显示标记 */
    private boolean showColCh = true;
    /** 16进制列显示标记 */
    private boolean showCol16 = true;
    /** 10进制列显示标记 */
    private boolean showCol10 = true;
    /** 8进制列显示标记 */
    private boolean showCol08 = false;
    /** 2进制列显示标记 */
    private boolean showCol02 = false;
    /** 定长显示 */
    private boolean fixLength = false;
    /** 当前显示列数 */
    private int colCount = 3;
    /** 当前列索引 */
    private int nameIndx = 0;
    /** 当前列索引 */
    private int cellIndx = 0;
    /** 用户输入字符 */
    private char[] usrChar = {};
    /** 起始字符 */
    private char sttChar = 1;
    /** 结束字符 */
    private char endChar = 0;

    /**
     * 
     */
    public CodeData()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.AbstractTableModel#getColumnName(int)
     */
    @Override
    public String getColumnName(int column)
    {
        if (column == 0)
        {
            nameIndx = 0;
        }

        switch (nameIndx)
        {
            case 0:
                nameIndx += 1;
                if (showColCh)
                {
                    return P3030000.getMesg(LangRes.COMN_TEXT_MODECH, "字符");
                }
            case 1:
                nameIndx += 1;
                if (showCol16)
                {
                    return P3030000.getMesg(LangRes.COMN_TEXT_MODE16, "十六进制");
                }
            case 2:
                nameIndx += 1;
                if (showCol10)
                {
                    return P3030000.getMesg(LangRes.COMN_TEXT_MODE10, "十进制");
                }
            case 3:
                nameIndx += 1;
                if (showCol08)
                {
                    return P3030000.getMesg(LangRes.COMN_TEXT_MODE08, "八进制");
                }
            case 4:
                nameIndx += 1;
                if (showCol02)
                {
                    return P3030000.getMesg(LangRes.COMN_TEXT_MODE02, "二进制");
                }
            default:
                nameIndx = 0;
                return "";
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.AbstractTableModel#getColumnClass(int)
     */
    public Class<?> getColumnClass(int columnIndex)
    {
        return String.class;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.AbstractTableModel#isCellEditable(int, int)
     */
    public boolean isCellEditable(int rowIndex, int columnIndex)
    {
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.TableModel#getColumnCount()
     */
    @Override
    public int getColumnCount()
    {
        return colCount;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.TableModel#getRowCount()
     */
    @Override
    public int getRowCount()
    {
        if (charModel)
        {
            return usrChar.length;
        }

        int count = endChar - sttChar + 1;
        return count >= 0 ? count : 0;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.TableModel#getValueAt(int, int)
     */
    @Override
    public Object getValueAt(int rowIndex, int columnIndex)
    {
        if (columnIndex == 0)
        {
            cellIndx = 0;
        }

        switch (cellIndx)
        {
            case 0:
                cellIndx += 1;
                if (showColCh)
                {
                    return getColumnCh(rowIndex);
                }
            case 1:
                cellIndx += 1;
                if (showCol16)
                {
                    return getColumn16(rowIndex);
                }
            case 2:
                cellIndx += 1;
                if (showCol10)
                {
                    return getColumn10(rowIndex);
                }
            case 3:
                cellIndx += 1;
                if (showCol08)
                {
                    return getColumn08(rowIndex);
                }
            case 4:
                cellIndx += 1;
                if (showCol02)
                {
                    return getColumn02(rowIndex);
                }
            default:
                cellIndx = 0;
                return "";
        }
    }

    /**
     * @param charModel
     *            the charModel to set
     */
    public void setCharModel(boolean charModel)
    {
        this.charModel = charModel;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 用户接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param showColCh
     *            the showColCh to set
     */
    public void setShowColCh(boolean showColCh)
    {
        if (this.showColCh != showColCh)
        {
            this.showColCh = showColCh;
            colCount += showColCh ? 1 : -1;
        }
    }

    /**
     * @param showCol16
     *            the showCol16 to set
     */
    public void setShowCol16(boolean showCol16)
    {
        if (this.showCol16 != showCol16)
        {
            this.showCol16 = showCol16;
            colCount += showCol16 ? 1 : -1;
        }
    }

    /**
     * @param showCol10
     *            the showCol10 to set
     */
    public void setShowCol10(boolean showCol10)
    {
        if (this.showCol10 != showCol10)
        {
            this.showCol10 = showCol10;
            colCount += showCol10 ? 1 : -1;
        }
    }

    /**
     * @param showCol08
     *            the showCol08 to set
     */
    public void setShowCol08(boolean showCol08)
    {
        if (this.showCol08 != showCol08)
        {
            this.showCol08 = showCol08;
            colCount += showCol08 ? 1 : -1;
        }
    }

    /**
     * @param showCol02
     *            the showCol02 to set
     */
    public void setShowCol02(boolean showCol02)
    {
        if (this.showCol02 != showCol02)
        {
            this.showCol02 = showCol02;
            colCount += showCol02 ? 1 : -1;
        }
    }

    /**
     * @param fixLength
     *            the fixLength to set
     */
    public void setFixLength(boolean fixLength)
    {
        this.fixLength = fixLength;
    }

    /**
     * @param usrChar
     *            the usrChar to set
     */
    public void setUsrChar(String userText)
    {
        this.usrChar = userText.toCharArray();
    }

    /**
     * @param sttChar
     *            the sttChar to set
     */
    public void setSttChar(String sttChar)
    {
        if (sttChar.startsWith(P3030000.getMesg(LangRes.COMN_PFIX_MODE16)))
        {
            this.sttChar = (char) Integer.parseInt(sttChar.substring(2), 16);
        }
        else if (sttChar.startsWith(P3030000.getMesg(LangRes.COMN_PFIX_MODE10)))
        {
            this.sttChar = (char) Integer.parseInt(sttChar.substring(2), 10);
        }
        else if (sttChar.startsWith(P3030000.getMesg(LangRes.COMN_PFIX_MODE08)))
        {
            this.sttChar = (char) Integer.parseInt(sttChar.substring(2), 8);
        }
        else if (sttChar.startsWith(P3030000.getMesg(LangRes.COMN_PFIX_MODE02)))
        {
            this.sttChar = (char) Integer.parseInt(sttChar.substring(2), 2);
        }
        else
        {
            this.sttChar = (char) Integer.parseInt(sttChar, 10);
        }
    }

    /**
     * @param endChar
     *            the endChar to set
     */
    public void setEndChar(String endChar)
    {
        if (endChar.startsWith(P3030000.getMesg(LangRes.COMN_PFIX_MODE16)))
        {
            this.endChar = (char) Integer.parseInt(endChar.substring(2), 16);
        }
        else if (endChar.startsWith(P3030000.getMesg(LangRes.COMN_PFIX_MODE10)))
        {
            this.endChar = (char) Integer.parseInt(endChar.substring(2), 10);
        }
        else if (endChar.startsWith(P3030000.getMesg(LangRes.COMN_PFIX_MODE08)))
        {
            this.endChar = (char) Integer.parseInt(endChar.substring(2), 8);
        }
        else if (endChar.startsWith(P3030000.getMesg(LangRes.COMN_PFIX_MODE02)))
        {
            this.endChar = (char) Integer.parseInt(endChar.substring(2), 2);
        }
        else
        {
            this.endChar = (char) Integer.parseInt(endChar, 10);
        }

        if (this.endChar < this.sttChar)
        {
            MesgUtil.showMessageDialog(null, P3030000.getMesg(LangRes.MESG_0005));
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 数值计算区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param rowIndex
     * @return
     */
    private K1SV1S getColumnCh(int rowIndex)
    {
        K1SV1S kv = new K1SV1S();

        char tmp = charModel ? usrChar[rowIndex] : (char) (rowIndex + sttChar);

        if (tmp == 127)
        {
            kv.setK("DEL");
            kv.setV1("DEL");
        }
        else if (tmp <= 32)
        {
            String[] CTRL =
            { "NUL", "SOH", "STX", "ETX", "EOT", "ENQ", "ACK", "BEL", "BS", "TAB", "LF", "VT", "FF", "CR", "SO", "SI", "DLE", "DC1", "DC2", "DC3", "DC4", "NAK", "SYN", "ETB", "CAN", "EM", "SUB",
                    "ESC", "FS", "GS", "RS", "US", " " };
            String[] TIPS =
            { "null", "start of heading", "start of text", "end of text", "end of transmission", "enquiry", "acknowledge", "bell", "backspace", "horizontal tab", "line feed, NL new line",
                    "vertical tab", "form feed, NP new page", "carriage return", "shift out", "shift in", "data link escape", "device control 1", "device control 2", "device control 3",
                    "device control 4", "negative acknowledge", "synchronous idle", "end of trans. block", "cancel", "end of medium", "substitute", "escape", "file separator", "group separator",
                    "record separator", "unit separator", "space" };

            kv.setK(TIPS[tmp]);
            kv.setV1(CTRL[tmp]);
        }
        else
        {
            kv.setK(Character.toString(tmp));
            kv.setV1(kv.getK());
        }
        return kv;
    }

    /**
     * @param rowIndex
     * @return
     */
    private K1SV1S getColumn16(int rowIndex)
    {
        String v = "";
        // 字符查询模式
        if (charModel)
        {
            v += Integer.toHexString(usrChar[rowIndex]);
        }
        // 数值查询模式
        else
        {
            v += Integer.toHexString(sttChar + rowIndex);
        }

        if (fixLength)
        {
            v = CharUtil.lPad(v, ConstUI.COMN_SIZE_MODE16, '0');
        }

        v = P3030000.getMesg(LangRes.COMN_PFIX_MODE16) + v;
        return new K1SV1S(v, v);
    }

    /**
     * @param rowIndex
     * @return
     */
    private K1SV1S getColumn10(int rowIndex)
    {
        String v = "";
        // 字符查询模式
        if (charModel)
        {
            v += Integer.toString(usrChar[rowIndex]);
        }
        // 数值查询模式
        else
        {
            v += Integer.toString(sttChar + rowIndex);
        }

        if (fixLength)
        {
            v = CharUtil.lPad(v, ConstUI.COMN_SIZE_MODE10, '0');
        }

        v = P3030000.getMesg(LangRes.COMN_PFIX_MODE10) + v;
        return new K1SV1S(v, v);
    }

    /**
     * @param rowIndex
     * @return
     */
    private K1SV1S getColumn08(int rowIndex)
    {
        String v = "";
        // 字符查询模式
        if (charModel)
        {
            v += Integer.toOctalString(usrChar[rowIndex]);
        }
        // 数值查询模式
        else
        {
            v += Integer.toOctalString(sttChar + rowIndex);
        }

        if (fixLength)
        {
            v = CharUtil.lPad(v, ConstUI.COMN_SIZE_MODE08, '0');
        }

        v = P3030000.getMesg(LangRes.COMN_PFIX_MODE08) + v;
        return new K1SV1S(v, v);
    }

    /**
     * @param rowIndex
     * @return
     */
    private K1SV1S getColumn02(int rowIndex)
    {
        String v = "";
        // 字符查询模式
        if (charModel)
        {
            v += Integer.toBinaryString(usrChar[rowIndex]);
        }
        // 数值查询模式
        else
        {
            v += Integer.toBinaryString(sttChar + rowIndex);
        }

        if (fixLength)
        {
            v = CharUtil.lPad(v, ConstUI.COMN_SIZE_MODE02, '0');
        }

        v = P3030000.getMesg(LangRes.COMN_PFIX_MODE02) + v;
        return new K1SV1S(v, v);
    }
}
