/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.io.df;

import java.io.File;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

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
public class XMLReader
{
    /** XML文本对象 */
    private Document document;

    /**
     * 构造器
     */
    public XMLReader()
    {
    }

    /**
     * 数据预处理
     * 
     * @param xmlPath
     * @throws Exception
     */
    public void init(String xmlPath) throws Exception
    {
        this.init(new File(xmlPath));
    }

    /**
     * @param xmlFile
     * @throws Exception
     */
    public void init(File xmlFile) throws Exception
    {
        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        DocumentBuilder db = dbf.newDocumentBuilder();
        document = db.parse(xmlFile);
    }

    /**
     * 获取元素个数
     * 
     * @param element
     * @return
     */
    public int getElementSize(String element)
    {
        return document.getElementsByTagName(element).getLength();
    }

    /**
     * @param nodeName
     */
    public NodeList getNodeList(String nodeName)
    {
        return document.getElementsByTagName(nodeName);
    }

    /**
     * @param nodeName
     * @return
     */
    public String getNodeValue(String nodeName)
    {
        return getNodeValue(nodeName, null);
    }

    /**
     * @param nodeName
     * @param defValue
     * @return
     */
    public String getNodeValue(String nodeName, String defValue)
    {
        NodeList nodeList = document.getElementsByTagName(nodeName);
        if (nodeList == null || nodeList.getLength() < 1)
        {
            return defValue;
        }
        return nodeList.item(0).getFirstChild().getNodeValue();
    }

    // 该方法负责把XML文件的内容显示出来
    void viewXML(String xmlFile) throws Exception
    {
        this.init(xmlFile);
        // 在xml文件里,只有一个根元素,先把根元素拿出来看看
        Element element = document.getDocumentElement();
        System.out.println("根元素为:" + element.getTagName());

        NodeList nodeList = document.getElementsByTagName("plugin");
        System.out.println("plugin节点个数:" + nodeList.getLength());

        Node node = nodeList.item(0);
        System.out.println("父节点为:" + node.getParentNode().getNodeName());

        // 把父节点的属性拿出来
        NamedNodeMap attributes = node.getAttributes();

        for (int i = 0; i < attributes.getLength(); i++)
        {
            Node attribute = attributes.item(i);
            System.out.println("plugin的属性名为:" + attribute.getNodeName());
            System.out.println("相对应的属性值为:" + attribute.getNodeValue());
        }

        NodeList childNodes = node.getChildNodes();
        System.out.println("plugin子节点个数：" + childNodes.getLength());
        for (int j = 0; j < childNodes.getLength(); j++)
        {
            Node childNode = childNodes.item(j);
            // 如果这个节点属于Element ,再进行取值
            if (childNode instanceof Element)
            {
                // System.out.println("子节点名为:"+childNode.getNodeName()+"相对应的值为"+childNode.getFirstChild().getNodeValue());
                System.out.println("子节点名为:" + childNode.getNodeName());
                System.out.println("对应的值为:" + childNode.getFirstChild().getNodeValue());
            }
        }
    }
}
