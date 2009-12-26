/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.amon.code.A1010000.b;

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
public class WComment
{
    private boolean delLogMultiLine;
    private boolean delLogSingleLine;
    private boolean delLogExceptions;
    private boolean delCmtDocument;
    private boolean delCmtMultiLine;
    private boolean delCmtSingleLine;
    private boolean trimSpaceChar;
    private boolean trimBlankLine;
    private boolean trimReturnTrip;

    /**
     * @return the delLogMultiLine
     */
    public boolean isDelLogMultiLine()
    {
        return delLogMultiLine;
    }

    /**
     * @param delLogMultiLine
     *            the delLogMultiLine to set
     */
    public void setDelLogMultiLine(boolean delLogMultiLine)
    {
        this.delLogMultiLine = delLogMultiLine;
    }

    /**
     * @return the delLogSingleLine
     */
    public boolean isDelLogSingleLine()
    {
        return delLogSingleLine;
    }

    /**
     * @param delLogSingleLine
     *            the delLogSingleLine to set
     */
    public void setDelLogSingleLine(boolean delLogSingleLine)
    {
        this.delLogSingleLine = delLogSingleLine;
    }

    /**
     * @return the delLogExceptions
     */
    public boolean isDelLogExceptions()
    {
        return delLogExceptions;
    }

    /**
     * @param delLogExceptions
     *            the delLogExceptions to set
     */
    public void setDelLogExceptions(boolean delLogExceptions)
    {
        this.delLogExceptions = delLogExceptions;
    }

    /**
     * @return the delCmtDocument
     */
    public boolean isDelCmtDocument()
    {
        return delCmtDocument;
    }

    /**
     * @param delCmtDocument
     *            the delCmtDocument to set
     */
    public void setDelCmtDocument(boolean delCmtDocument)
    {
        this.delCmtDocument = delCmtDocument;
    }

    /**
     * @return the delCmtMultiLine
     */
    public boolean isDelCmtMultiLine()
    {
        return delCmtMultiLine;
    }

    /**
     * @param delCmtMultiLine
     *            the delCmtMultiLine to set
     */
    public void setDelCmtMultiLine(boolean delCmtMultiLine)
    {
        this.delCmtMultiLine = delCmtMultiLine;
    }

    /**
     * @return the delCmtSingleLine
     */
    public boolean isDelCmtSingleLine()
    {
        return delCmtSingleLine;
    }

    /**
     * @param delCmtSingleLine
     *            the delCmtSingleLine to set
     */
    public void setDelCmtSingleLine(boolean delCmtSingleLine)
    {
        this.delCmtSingleLine = delCmtSingleLine;
    }

    /**
     * @return the trimSpaceChar
     */
    public boolean isTrimSpaceChar()
    {
        return trimSpaceChar;
    }

    /**
     * @param trimSpaceChar
     *            the trimSpaceChar to set
     */
    public void setTrimSpaceChar(boolean trimSpaceChar)
    {
        this.trimSpaceChar = trimSpaceChar;
    }

    /**
     * @return the trimBlankLine
     */
    public boolean isTrimBlankLine()
    {
        return trimBlankLine;
    }

    /**
     * @param trimBlankLine
     *            the trimBlankLine to set
     */
    public void setTrimBlankLine(boolean trimBlankLine)
    {
        this.trimBlankLine = trimBlankLine;
    }

    /**
     * @return the trimReturnTrip
     */
    public boolean isTrimReturnTrip()
    {
        return trimReturnTrip;
    }

    /**
     * @param trimReturnTrip
     *            the trimReturnTrip to set
     */
    public void setTrimReturnTrip(boolean trimReturnTrip)
    {
        this.trimReturnTrip = trimReturnTrip;
    }
}
