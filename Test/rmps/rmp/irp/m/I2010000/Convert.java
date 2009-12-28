/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.I2010000;

import org.dom4j.Document;
import org.dom4j.DocumentHelper;
import org.dom4j.Element;

public class Convert
{
    public static void main(String[] args)
    {
        Document document = DocumentHelper.createDocument();
        Element ele = DocumentHelper.createElement("");
        document.add(ele);
    }
}
