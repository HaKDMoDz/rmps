/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.util;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

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
 * 
 * @author Amon
 */
public final class SoapUtil
{
    /**
     * @param nodeRoot
     * @return
     */
    public static List<HashMap<String, String>> domParse2Table(Element nodeRoot)
    {
        return domParse2Table(nodeRoot.getChildNodes());
    }

    /**
     * @return
     */
    public static List<HashMap<String, String>> domParse2Table(NodeList nodeList)
    {
        // 节点列表为空判断
        if (nodeList == null || nodeList.getLength() < 1)
        {
            return new ArrayList<HashMap<String, String>>(0);
        }

        // 返回数据列表初始化
        int itemSize = nodeList.getLength();
        ArrayList<HashMap<String, String>> dataList = new ArrayList<HashMap<String, String>>(itemSize);

        Node subNode;
        NodeList subList;
        HashMap<String, String> item;
        String name;
        for (int i = 0; i < itemSize; i += 1)
        {
            // 取第i个节点
            subNode = nodeList.item(i);
            // 节点是否为空
            if (subNode == null || subNode.getNodeType() != Node.ELEMENT_NODE)
            {
                continue;
            }

            subList = subNode.getChildNodes();
            item = new HashMap<String, String>();
            for (int m = 0, n = subList.getLength(); m < n; m += 1)
            {
                // 取第m个节点
                subNode = subList.item(m);
                // 节点是否为空
                if (subNode == null || subNode.getNodeType() != Node.ELEMENT_NODE)
                {
                    continue;
                }
                name = getNodeName(subNode);

                // 取节点的含值子节点
                subNode = subNode.getFirstChild();
                // 节点是否为空
                if (subNode == null)
                {
                    continue;
                }
                // 节点是否有值
                if (subNode.getNodeValue() == null)
                {
                    break;
                }
                // 记录节点值
                item.put(name, subNode.getNodeValue());
            }

            dataList.add(item);
        }

        return dataList;
    }

    /**
     * @return
     */
    public static Map<Integer, String> domParse2Array(Element nodeRoot)
    {
        return domParse2Array(nodeRoot.getChildNodes());
    }

    /**
     * @param nodeList
     * @return
     */
    public static Map<Integer, String> domParse2Array(NodeList nodeList)
    {
        // 节点列表为空判断
        if (nodeList == null || nodeList.getLength() < 1)
        {
            return new HashMap<Integer, String>(0);
        }

        // 返回数据列表初始化
        int itemSize = nodeList.getLength();
        Map<Integer, String> dataList = new HashMap<Integer, String>(itemSize);

        int idx = 0;
        Node node;
        for (int i = 0; i < itemSize; i += 1)
        {
            // 取第m个节点
            node = nodeList.item(i);
            // 节点是否为空
            if (node == null || node.getNodeType() != Node.ELEMENT_NODE)
            {
                continue;
            }

            // 取节点的含值子节点
            node = node.getFirstChild();
            // 节点是否有值
            if (node == null)
            {
                continue;
            }
            if (node.getNodeValue() == null)
            {
                break;
            }
            // 记录节点值
            dataList.put(idx++, node.getNodeValue());
        }
        return dataList;
    }

    /**
     * 获得节点的名称。<br />
     * 获得名称的规则：<br />
     * 1、没有属性或者有属性但没有name或者id属性的情况下，返回节点名称<br />
     * 2、有id属性的情况下，返回id属性值<br />
     * 3、有name属性的情况下，返回name属性值<br />
     * 
     * @param node
     * @return
     */
    private static String getNodeName(Node node)
    {
        NamedNodeMap map = node.getAttributes();
        if (map != null && map.getLength() > 0)
        {
            Node temp;
            String name;
            for (int i = 0, j = map.getLength(); i < j; i += 1)
            {
                temp = map.item(i);
                name = temp.getNodeName();
                if ("id".equalsIgnoreCase(name) || "name".equalsIgnoreCase(name))
                {
                    return temp.getNodeValue();
                }
            }
        }
        return node.getNodeName();
    }

    /**
     * 读取SOAP请求数据
     * 
     * @param soapFilePath
     * @param soapFileName
     * @param soapArgs
     *            需要进行替换的参数数据
     * @return
     * @throws Exception
     */
    public static String getSoapRequest(String soapFilePath, String soapFileName, String... soapArgs) throws Exception
    {
        InputStream is = FileUtil.getResourceAsStream(soapFilePath, soapFileName);
        BufferedReader br = new BufferedReader(new InputStreamReader(is));

        StringBuffer sb = new StringBuffer();
        String t = br.readLine();
        while (t != null)
        {
            sb.append(t);
            t = br.readLine();
        }
        br.close();
        is.close();

        return StringUtil.format(sb.toString(), soapArgs);
    }
}
