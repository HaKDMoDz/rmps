/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
/*
 * 
 */
package rmp.irp.m.I2070000;

import java.util.List;
import java.util.Stack;

import rmp.bean.K1SV1S;
import rmp.bean.K1SV2S;
import rmp.bean.K1SV3S;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO:
 * <li>使用说明：</li>
 * <br />
 * TODO:
 * </ul>
 * 
 * @author Administrator
 * 
 */
final class Profiles
{
    /**
     * 显示交互菜单
     */
    int showMenu;
    /**
     * 数据编辑状态
     */
    int dataEdit;
    /**
     * 目录列表，仅在目录模式时使用
     */
    Stack<String> pathList;
    /**
     * 类别列表，仅在目录模式时使用
     */
    List<K1SV1S> kindList;
    /**
     * 链接列表，仅在目录模式时使用
     */
    List<K1SV2S> linkList;
    /**
     * 结果列表，仅在搜索模式时使用
     */
    List<K1SV3S> itemList;

    Profiles()
    {
        pathList = new Stack<String>();
        pathList.push("");
    }
}
