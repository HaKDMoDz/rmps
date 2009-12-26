/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp;

import java.io.File;
import java.util.HashMap;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import com.amonsoft.util.LogUtil;

import cons.prp.Plugins;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 最终工具类
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public final class Util
{
    /**
     * @return
     */
    static HashMap<String, String> readPlus(File xmlFile)
    {
        LogUtil.log("插件加载：配置文件读取 － " + xmlFile.getPath());

        HashMap<String, String> nodeMap = new HashMap<String, String>();

        try
        {
            // 构造Document对象
            DocumentBuilder builder = DocumentBuilderFactory.newInstance().newDocumentBuilder();
            Document document = builder.parse(xmlFile);

            // 取得标准插件配置节点
            NodeList nodeList = document.getElementsByTagName(Plugins.NODE_PLUS);
            if (nodeList != null && nodeList.getLength() > 0)
            {
                // 取得节点配置数据
                Node node;
                nodeMap.put(Plugins.NODE_PLUS, Plugins.NODE_PLUS);
                nodeList = nodeList.item(0).getChildNodes();
                for (int i = 0, j = nodeList.getLength(); i < j; i += 1)
                {
                    node = nodeList.item(i);
                    if (node instanceof Element)
                    {
                        if (node.getFirstChild() != null)
                        {
                            nodeMap.put(node.getNodeName(), node.getFirstChild().getNodeValue());
                        }
                    }
                }
            }

            // 取得独立插件配置节点
            nodeList = document.getElementsByTagName(Plugins.NODE_EXEC);
            if (nodeList != null && nodeList.getLength() > 0)
            {
                // 取得节点配置数据
                Node node;
                nodeMap.put(Plugins.NODE_EXEC, Plugins.NODE_EXEC);
                nodeList = nodeList.item(0).getChildNodes();
                for (int i = 0, j = nodeList.getLength(); i < j; i += 1)
                {
                    node = nodeList.item(i);
                    if (node instanceof Element)
                    {
                        if (node.getFirstChild() != null)
                        {
                            nodeMap.put(node.getNodeName(), node.getFirstChild().getNodeValue());
                        }
                    }
                }
            }

            // 取得网络插件配置节点
            nodeList = document.getElementsByTagName(Plugins.NODE_JNLP);
            if (nodeList != null && nodeList.getLength() > 0)
            {
                // 取得节点配置数据
                Node node;
                nodeMap.put(Plugins.NODE_JNLP, Plugins.NODE_JNLP);
                nodeList = nodeList.item(0).getChildNodes();
                for (int i = 0, j = nodeList.getLength(); i < j; i += 1)
                {
                    node = nodeList.item(i);
                    if (node instanceof Element)
                    {
                        if (node.getFirstChild() != null)
                        {
                            nodeMap.put(node.getNodeName(), node.getFirstChild().getNodeValue());
                        }
                    }
                }
            }

            // 取得运行类库节点
            nodeList = document.getElementsByTagName(Plugins.NODE_LIBS);
            if (nodeList != null && nodeList.getLength() > 0)
            {
                // 取得节点配置数据
                Node node;
                int k = 0;
                nodeMap.put(Plugins.NODE_LIBS, Plugins.NODE_LIBS);
                nodeList = nodeList.item(0).getChildNodes();
                for (int i = 0, j = nodeList.getLength(); i < j; i += 1)
                {
                    node = nodeList.item(i);
                    if (node instanceof Element)
                    {
                        if (node.getFirstChild() != null)
                        {
                            nodeMap.put(node.getNodeName() + (k++), node.getFirstChild().getNodeValue());
                        }
                    }
                }
                nodeMap.put("", Integer.toString(k));
            }
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }

        return nodeMap;
    }
}
